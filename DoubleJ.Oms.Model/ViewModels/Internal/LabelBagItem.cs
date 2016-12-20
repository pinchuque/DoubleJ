using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Annotations;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class LabelBagItem : INotifyPropertyChanged
    {
        private int _coldWeightid;
        private int _orderId;
        private string _name;
        private int _speciesId;
        private string _baseSpecies;

        public int ColdWeightDetailId
        {
            get { return _coldWeightid; }
            set
            {
                if (value == _coldWeightid) return;
                _coldWeightid = value;
                OnPropertyChanged();
            }
        }

        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (value == _orderId) return;
                _orderId = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public int SpeciesId
        {
            get { return _speciesId; }
            set
            {
                if (value == _speciesId) return;
                _speciesId = value;
                OnPropertyChanged();
            }
        }

        public string BaseSpecies
        {
            get { return _baseSpecies; }
            set
            {
                _baseSpecies = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CutItem : INotifyPropertyChanged
    {
        private string _productName;
        private int _productProductId;
        private int _orderDetailId;
        private int? _customerLocationId;
        private string _id;
        private string _weight;
        private string _textColor;
        private string _backGroundColor;

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value == _productName) return;
                _productName = value;
                OnPropertyChanged();
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public int ProductId
        {
            get { return _productProductId; }
            set
            {
                if (value == _productProductId) return;
                _productProductId = value;
                OnPropertyChanged();
            }
        }

        public int? CustomerLocationId
        {
            get { return _customerLocationId; }
            set
            {
                if (value == _customerLocationId) return;
                _customerLocationId = value;
                OnPropertyChanged();
            }
        }

        public int OrderDetailId
        {
            get { return _orderDetailId; }
            set
            {
                if (value == _orderDetailId) return;
                _orderDetailId = value;
                OnPropertyChanged();
            }
        }

        public string Weight
        {
            get { return _weight; }
            set
            {
                if (value == _weight) return;
                _weight = value;
                OnPropertyChanged();
            }
        }

        public string TextColor
        {
            get { return _textColor; }
            set
            {
                if (value == _textColor) return;
                _textColor = value;
                OnPropertyChanged();
            }
        }

        public string BackGroundColor
        {
            get { return _backGroundColor; }
            set
            {
                if (value == _backGroundColor) return;
                _backGroundColor = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SideWeightItem : INotifyPropertyChanged
    {
        private string _name;
        private bool _isWeight;
        private int _customerLocationId;
        private int _orderId;
        private int _coldWeightDetailId;
        private int _speciesId;
        private OmsSideType _sideNumber;
        private ObservableCollection<CutItem> _products = new ObservableCollection<CutItem>();
        private string _animalPart;
        private QualityGrade _qualityGrade;
        private AnimalLabel _animalLabel;
        private string _sideMark;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public bool IsWeight
        {
            get { return _isWeight; }
            set
            {
                if (value == _isWeight) return;
                _isWeight = value;
                OnPropertyChanged();
            }
        }

        public int CustomerLocationId
        {
            get { return _customerLocationId; }
            set
            {
                if (value == _customerLocationId) return;
                _customerLocationId = value;
                OnPropertyChanged();
            }
        }

        public QualityGrade QualityGrade
        {
            get { return _qualityGrade; }
            set
            {
                _qualityGrade = value;
                OnPropertyChanged();
            }
        }

        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (value == _orderId) return;
                _orderId = value;
                OnPropertyChanged();
            }
        }

        public int ColdWeightDetailId
        {
            get { return _coldWeightDetailId; }
            set
            {
                if (value == _coldWeightDetailId) return;
                _coldWeightDetailId = value;
                OnPropertyChanged();
            }
        }

        public int SpeciesId
        {
            get { return _speciesId; }
            set
            {
                if (value == _speciesId) return;
                _speciesId = value;
                OnPropertyChanged();
            }
        }

        public OmsSideType SideNumber
        {
            get { return _sideNumber; }
            set
            {
                if (value == _sideNumber) return;
                _sideNumber = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CutItem> Products
        {
            get { return _products; }
            set
            {
                if (value == _products) return;
                _products = value;
                OnPropertyChanged();
            }
        }


        public string AnimalPart
        {
            get { return _animalPart; }
            set
            {
                if(value == _animalPart) return;
                _animalPart = value;
                OnPropertyChanged();
            }
        }

        public AnimalLabel AnimalLabel
        {
            get { return _animalLabel; }
            set
            {
                _animalLabel = value;
                OnPropertyChanged();
            }
        }

        public string SideMark
        {
            get { return _sideMark; }
            set
            {
                _sideMark = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
