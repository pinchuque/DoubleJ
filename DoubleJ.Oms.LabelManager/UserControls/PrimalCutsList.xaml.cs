using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.LabelManager.UserControls
{
    /// <summary>
    /// Interaction logic for PrimalCutsList.xaml
    /// </summary>
    public partial class PrimalCutsList
    {
        private readonly CustomerBagGrid _owner;

        public PrimalCutsList(IList<PrimalCut> primalCuts, CustomerBagGrid owner)
        {
            _owner = owner;
            InitializeComponent();
            PrimalCuts.ItemsSource = primalCuts.OrderBy(x=>x.SortOrder);
            PrimalCutsWindow.Height =  (primalCuts.Count / 7 + 1) * 120;
            PrimalCutsWindow.MaxHeight = (primalCuts.Count / 7 + 1) *120;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int id = (int) button.Tag;
                _owner.PrimalCutId = id;
                Close();
            }
        }
    }
}
