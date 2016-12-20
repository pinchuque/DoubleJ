using System.ComponentModel;
using System.Runtime.CompilerServices;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.LabelManager.Annotations;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.LabelManager.Models
{
    public class CustomBoxGridViewModel : INotifyPropertyChanged
    {
        private BindingList<LabelBoxItem> _boxesCustomList;
        private BindingList<CaseSize> _boxesTareWeights;
        private CaseSize _selectedTare;

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
        public BindingList<LabelBoxItem> BoxesCustomList
        {
            get { return _boxesCustomList; }
            set
            {
                if (Equals(value, _boxesCustomList)) return;

                _boxesCustomList = value;
                OnPropertyChanged();
            }
        }

        public BindingList<CaseSize> BoxesTareWeights
        {
            get { return _boxesTareWeights; }
            set
            {
                _boxesTareWeights = value;
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