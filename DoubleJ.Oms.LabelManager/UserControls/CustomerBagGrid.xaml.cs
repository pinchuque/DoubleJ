using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.LabelManager.Extensions;
using DoubleJ.Oms.LabelManager.Models;
using DoubleJ.Oms.Model.Extensions;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Service.Services.Internal;
using Telerik.WinControls;
using Telerik.Windows.Controls;
using Button = System.Windows.Controls.Button;
using ListView = System.Windows.Controls.ListView;
using ListViewItem = System.Windows.Controls.ListViewItem;
using UserControl = System.Windows.Controls.UserControl;

namespace DoubleJ.Oms.LabelManager.UserControls
{
    /// <summary>
    /// Interaction logic for CustomerBagGrid.xaml
    /// </summary>
    /// 
    public partial class CustomerBagGrid : UserControl
    {
        public event EventHandler OnCutChanged;
        public event EventHandler OnSideChanged;
        public event EventHandler OnReprintLabelsForProduct;
        public event EventHandler OnRemoveLabelsForProduct;
        public int? PrimalCutId { get; set; }
        public CutItem CutItem { get; set; }
        public LabelBagItem selectedItem { get; set; }

        private readonly ILabelService _labelService;
        private ListViewItem _sideWeightItem;
        private ListView _listViewOfProducts;
        public CustomerBagGrid()
        {
            InitializeComponent();

            _labelService = new LabelService();
        }

        private void BackTagBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var animalNumberList = (RadComboBox)sender;
            selectedItem = (LabelBagItem)animalNumberList.SelectedItem;
            if (selectedItem == null)
            {
                ListViewSides.ItemsSource = null;
                SelectCutButton.IsEnabled = false;
                PrimalCutId = null;
                CutItem = null;
                CutItemName.Content = string.Empty;
                return;
            }
            SelectCutButton.IsEnabled = true;
            // CutComboBox.ItemsSource = _labelService.GetCustomProducts(selectedItem.SpeciesId, selectedItem.OrderId);

            var sideWeightItems = new ObservableCollection<SideWeightItem>(_labelService.GetSideWeigths(selectedItem.ColdWeightDetailId, selectedItem.OrderId));
            ListViewSides.ItemsSource = sideWeightItems;
            ListViewSides.SelectedItem = sideWeightItems.FirstOrDefault();
            var selectedEntry = ListViewSides.SelectedItem;
            var side = ListViewSides.ItemContainerGenerator.ContainerFromItem(selectedEntry) as ListViewItem;
            if (OnCutChanged != null) OnCutChanged(null, e);
            if (OnSideChanged != null) OnSideChanged(side, e);
            Side_Click(side, null);
        }


        private static void ApplyUnitCaptionStyle(Visual container, bool isNewSide)
        {
            LabelManagerExtensions.ApplyStyle<Grid>(StyleProperty, container, "Side",
                isNewSide ? "SideCaptionSelected" : "SideCaptionDefault");
        }

        private static void ApplyUnitCaptionStyleToProducts(Visual container, bool isNewSide)
        {
            LabelManagerExtensions.ApplyStyle<ListView>(StyleProperty, container, "Product",
                isNewSide ? "ProductCaptionSelected" : "ProductCaptionDefault");
        }

        private void Side_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = (ListView)sender;
            var selectedItem = list.SelectedItem;
            var sideSelected = selectedItem as SideWeightItem;
            if (sideSelected == null)
                return;

            var listViewItem = (ListViewItem)list.ItemContainerGenerator.ContainerFromItem(selectedItem);
            GetSelectedSide(listViewItem);

            var productsListView = listViewItem.GetChildOfType<ListView>();

            ApplyStyleToProduct(productsListView);
        }

        private void GetSelectedSide(ListViewItem listViewItem)
        {
            if (OnSideChanged != null) OnSideChanged(listViewItem, EventArgs.Empty);

            ApplyUnitCaptionStyle(_sideWeightItem, false);
            _sideWeightItem = listViewItem;
            ApplyUnitCaptionStyle(listViewItem, true);
        }

        private void ApplyStyleToProduct(ListView innerListView)
        {
            ApplyUnitCaptionStyleToProducts(_listViewOfProducts, false);
            _listViewOfProducts = innerListView;
            ApplyUnitCaptionStyleToProducts(innerListView, true);
        }


        private void CutComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CutItemChanged(sender);
        }

        private void ProductChanged(object sender, MouseButtonEventArgs e)
        {
            CutItemChanged(sender);
        }

        private void CutItemChanged(object sender)
        {
            if (OnCutChanged != null) OnCutChanged(sender, EventArgs.Empty);
        }


        private void Remove(object sender, RoutedEventArgs e)
        {
            var result = RadMessageBox.Show("Once a label is removed it can not be recovered. \r\n\r\nAre you sure you want to remove this label?", "Remove Label", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (result != DialogResult.Yes) return;

            if (OnRemoveLabelsForProduct == null)
                return;

            Button button = sender as Button;
            string id = button.Tag.ToString();

            var innerListView = button.GetAncestorOfType<ListView>();
            var outListViewItem = innerListView.GetAncestorOfType<ListViewItem>();

            GetSelectedSide(outListViewItem);
            ApplyStyleToProduct(innerListView);

            var activeproducts = (ObservableCollection<CutItem>)innerListView.ItemsSource;
            activeproducts.RemoveByPredicate(x => x.Id == id);

            innerListView.ItemsSource = activeproducts;

            OnRemoveLabelsForProduct(sender, e);
        }

        //need for selected product
        private void Side_Click(object sender, MouseButtonEventArgs e)
        {
            var listViewItem = sender as ListViewItem;
            GetSelectedSide(listViewItem);

            var productsListView = listViewItem.GetChildOfType<ListView>();
            ApplyStyleToProduct(productsListView);
        }

        private void Reprint(object sender, RoutedEventArgs e)
        {
            var result = RadMessageBox.Show("Once a label is updated and reprinted the original label value cannot be restored. \r\n\r\nAre you sure you want to re-print this label?", "Re-print Label", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (result != DialogResult.Yes) return;

            if (OnReprintLabelsForProduct != null) OnReprintLabelsForProduct(sender, e);
        }

        public void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var primalCutsView = new PrimalCutsList(_labelService.GetPrimals(selectedItem.SpeciesId, selectedItem.OrderId),this) {};
            primalCutsView.Closed += (o, args) =>
            {
                if (this.PrimalCutId != null)
                {
                    var cutProducts = _labelService.GetCustomProducts(selectedItem.BaseSpecies, selectedItem.OrderId,
                        PrimalCutId.GetValueOrDefault());
                    if (!cutProducts.Any())
                    {
                        return;
                    }
                    var orderProductsView = new OrderProducts(cutProducts,this);
                    orderProductsView.Closed += (o_, args_) =>
                    {
                        if (CutItem != null)
                        {
                            CutItemName.Content = CutItem.ProductName;
                            CutItemChanged(new ListViewItem() {Content = CutItem});
                        }
                        PrimalCutId = null;
                    };
                    orderProductsView.ShowDialog();
                }
            };
            primalCutsView.ShowDialog();
        }

        public void BackOrderProducts(OrderProducts products)
        {
            products.Close();
            ButtonBase_OnClick(new object(), new RoutedEventArgs());
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var datacontext = DataContext as CustomBagGridViewModel;
            var senderItem = sender as ListViewItem;
            if (senderItem != null)
            {
                var caseSize = senderItem.DataContext as CaseSize;
                if (caseSize != null && datacontext != null && datacontext.SelectedTare != null)
                {
                    if (caseSize.Id == datacontext.SelectedTare.Id)
                    {
                        datacontext.SelectedTare = null;
                        e.Handled = true;
                        return;
                    }
                }
            }
        }
    }
}
