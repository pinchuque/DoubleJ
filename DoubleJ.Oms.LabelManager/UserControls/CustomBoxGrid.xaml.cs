using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.LabelManager.Extensions;
using DoubleJ.Oms.LabelManager.Models;

namespace DoubleJ.Oms.LabelManager.UserControls
{
    /// <summary>
    ///     Interaction logic for CustomBoxGrid.xaml
    /// </summary>
    public partial class CustomBoxGrid : UserControl
    {
        public event EventHandler OnCustomerLocationChanged;
        public event EventHandler OnButtonEditClicked;
        private FrameworkElement _sideItem;

        public CustomBoxGrid()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = (ListView)sender;
            var selectedItem = list.SelectedItem;
            var listViewItem = (ListViewItem)list.ItemContainerGenerator.ContainerFromItem(selectedItem);

            if (selectedItem == null)
                return;

            if (OnCustomerLocationChanged != null) OnCustomerLocationChanged(sender, EventArgs.Empty);


            if (_sideItem != null)
                LabelManagerExtensions.ApplyStyle<StackPanel>(StyleProperty, _sideItem, "Side", "CustomBagCaptionDefault");
            _sideItem = listViewItem;
            LabelManagerExtensions.ApplyStyle<StackPanel>(StyleProperty, listViewItem, "Side", "CustomBagCaptionSelected");
        }

        private void EditLabelsButton_OnClick(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;
            var item = dep as ListViewItem;
            if (item != null) item.IsSelected = true;
            if (OnButtonEditClicked != null) OnButtonEditClicked(sender, EventArgs.Empty);
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var datacontext = DataContext as CustomBoxGridViewModel;
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
