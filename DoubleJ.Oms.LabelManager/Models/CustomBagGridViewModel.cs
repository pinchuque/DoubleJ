using System.ComponentModel;
using System.Runtime.CompilerServices;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.LabelManager.Annotations;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.LabelManager.Models
{
    public class CustomBagGridViewModel : INotifyPropertyChanged
    {
        private BindingList<LabelBagItem> _animalNumbers;
        private BindingList<CaseSize> _bagsTareWeights;
        private CaseSize _selectedTare;

        public CustomBagGridViewModel()
        {
            AnimalNumbers = new BindingList<LabelBagItem>();
            BagsTareWeights = new BindingList<CaseSize>();
        }
        public CaseSize SelectedTare
        {
            get
            {
                return _selectedTare;
            }
            set
            {
                _selectedTare = value;
                OnPropertyChanged();
            }
        }
        public BindingList<LabelBagItem> AnimalNumbers
        {
            get { return _animalNumbers; }
            set
            {
                if (Equals(value, _animalNumbers)) return;

                _animalNumbers = value;
                OnPropertyChanged();
            }
        }


        public BindingList<CaseSize> BagsTareWeights
        {
            get { return _bagsTareWeights; }
            set
            {
                _bagsTareWeights = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}