using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.LabelManager.Annotations;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.LabelManager.Models
{
    public class UnitListViewModel :INotifyPropertyChanged
    {
        private BindingList<LabelGridItem> _bagsList;
        private BindingList<QualityGrade> _qualityGrades;
        private BindingList<LabelGridItem> _boxesList;
        private QualityGrade _selectedGrade;
        private bool _isBagOpened;
        private AnimalLabelsViewModel _selectedAnimalLabel;
        private BindingList<AnimalLabelsViewModel> _animalLables;
        private BindingList<CaseSize> _boxesTareWeights;
        private BindingList<CaseSize> _bagsTareWeights;
        private CaseSize _selectedTare;
        private BindingList<LabelGridItem> _traysList;

        public BindingList<LabelGridItem> BagsList
        {
            get { return _bagsList; }
            set
            {
                if (Equals(value, _bagsList)) return;

                _bagsList = value;
                OnPropertyChanged();
            }
        }

        public BindingList<LabelGridItem> TraysList
        {
            get { return _traysList; }
            set
            {
                if(Equals(value,_traysList)) return;
                _traysList = value;
                OnPropertyChanged();
            }
        }

        public BindingList<LabelGridItem> BoxesList
        {
            get { return _boxesList; }
            set
            {
                if (Equals(value, _boxesList)) return;

                _boxesList = value;
                OnPropertyChanged();
            }
        }

        public bool IsBagOpened
        {
            get
            {
                return _isBagOpened;
            }
            set
            {
                _isBagOpened = value;
                OnPropertyChanged();
            }
        }

        public UnitListViewModel()
        {
            BagsList = new BindingList<LabelGridItem>();
            BoxesList = new BindingList<LabelGridItem>();
            TraysList = new BindingList<LabelGridItem>();
            AnimalLabels = new BindingList<AnimalLabelsViewModel>();
            BoxesTareWeights = new BindingList<CaseSize>();
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
        public BindingList<CaseSize> BoxesTareWeights
        {
            get { return _boxesTareWeights; }
            set
            {
                _boxesTareWeights = value;
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

        public BindingList<QualityGrade> QualityGrades
        {
            get { return _qualityGrades; }
            set
            {
                if (_qualityGrades == null || !_qualityGrades.Any())
                {
                    SelectedGrade = value.FirstOrDefault();
                }
                _qualityGrades = value;
                OnPropertyChanged();
            }
        }

        public BindingList<AnimalLabelsViewModel> AnimalLabels
        {
            get { return _animalLables; }
            set
            {
                if (_animalLables == null || !_animalLables.Any())
                {
                    SelectedAnimalLabel = value.FirstOrDefault();
                }
                _animalLables = value;
                OnPropertyChanged();
            }
        } 
        public QualityGrade SelectedGrade
        {
            get { return _selectedGrade; }
            set
            {
                _selectedGrade = value;
                OnPropertyChanged();
            }
        }

        public AnimalLabelsViewModel SelectedAnimalLabel
        {
            get { return _selectedAnimalLabel; }
            set
            {
                _selectedAnimalLabel = value;
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