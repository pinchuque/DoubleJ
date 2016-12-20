using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Annotations;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class LabelBoxItem : INotifyPropertyChanged
    {
        private int _customerLocationId;
        private int _orderId;
        private string _customerLocationName;
        private string _productName;
        private int? _completedCount;
        private int _coldWeightDetailId;
        private OmsSideType _side;
        private QualityGrade _qualityGrade;

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
            get { return _customerLocationName; }
            set
            {
                if (value == _customerLocationName) return;
                _customerLocationName = value;
                OnPropertyChanged();
            }
        }

        public int? CompletedCount
        {
            get { return _completedCount; }
            set
            {
                if (value == _completedCount) return;
                _completedCount = value;
                OnPropertyChanged();
            }
        }
        
        //for future logic
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

        public OmsSideType Side
        {
            get { return _side; }
            set
            {
                if (value == _side) return;
                _side = value;
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

        public AnimalLabel AnimalLabel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
