using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

using DoubleJ.Oms.LabelManager.Annotations;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _beefFileName;
        private string _bisonFileName;
        private string _printer;
        private string _secondaryPrinter;
        private string _secondLabel;
        private bool _isSecondaryLabel;
        private string _doubleJLogoFileName;
        private string _labelBaseFolder;
        private string _noLogoImageFileName;
        private string _organicFileName;
        private string _password;
        private int _scaleId;
        private string _scaleIpAddress;
        private int _scalePort;
        private string _scaleRegExp;
        private string _scaleTestMessage;
        private int _serialPort;

        public int ScaleId
        {
            get { return _scaleId; }
            set
            {
                if (value == _scaleId)
                {
                    return;
                }

                _scaleId = value;
                OnPropertyChanged();
            }
        }

        public int SerialPort
        {
            get { return _serialPort; }
            set
            {
                if (value == _serialPort)
                {
                    return;
                }

                _serialPort = value;
                OnPropertyChanged();
            }
        }

        public string OrganicFileName
        {
            get { return _organicFileName; }
            set
            {
                if (value == _organicFileName)
                {
                    return;
                }

                _organicFileName = value;
                OnPropertyChanged();
            }
        }

        [StringLength(100)]
        public string Printer
        {
            get { return _printer; }
            set
            {
                if (value == _printer)
                {
                    return;
                }

                _printer = value;
                OnPropertyChanged();
            }
        }


        [StringLength(100)]
        public string SecondaryPrinter
        {
            get { return _secondaryPrinter; }
            set
            {
                if (value == _secondaryPrinter)
                {
                    return;
                }

                _secondaryPrinter = value;
                OnPropertyChanged();
            }
        }

        [StringLength(100)]
        public string SecondLabel
        {
            get { return _secondLabel; }
            set
            {
                if (value == _secondLabel)
                {
                    return;
                }

                _secondLabel = value;
                OnPropertyChanged();
            }
        }

        public bool IsSecondaryLabel
        {
            get { return _isSecondaryLabel; }
            set
            {
                if (value == _isSecondaryLabel)
                {
                    return;
                }

                _isSecondaryLabel = value;
                OnPropertyChanged();
            }
        }

        public string BeefFileName
        {
            get { return _beefFileName; }
            set
            {
                if (value == _beefFileName)
                {
                    return;
                }

                _beefFileName = value;
                OnPropertyChanged();
            }
        }

        public string BisonFileName
        {
            get { return _bisonFileName; }
            set
            {
                if (value == _bisonFileName)
                {
                    return;
                }

                _bisonFileName = value;
                OnPropertyChanged();
            }
        }

        public string NoLogoImageFileName
        {
            get { return _noLogoImageFileName; }
            set
            {
                if (value == _noLogoImageFileName)
                {
                    return;
                }

                _noLogoImageFileName = value;
                OnPropertyChanged();
            }
        }

        public string DoubleJLogoFileName
        {
            get { return _doubleJLogoFileName; }
            set
            {
                if (value == _doubleJLogoFileName)
                {
                    return;
                }

                _doubleJLogoFileName = value;
                OnPropertyChanged();
            }
        }

        public string LabelBaseFolder
        {
            get { return _labelBaseFolder; }
            set
            {
                if (value == _labelBaseFolder)
                {
                    return;
                }

                _labelBaseFolder = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password)
                {
                    return;
                }

                _password = value;
                OnPropertyChanged();
            }
        }

        public string ScaleIpAddress
        {
            get { return _scaleIpAddress; }
            set
            {
                if (value == _scaleIpAddress)
                {
                    return;
                }

                _scaleIpAddress = value;
                OnPropertyChanged();
            }
        }

        public int ScalePort
        {
            get { return _scalePort; }
            set
            {
                if (value == _scalePort)
                {
                    return;
                }

                _scalePort = value;
                OnPropertyChanged();
            }
        }

        public string ScaleRegExp
        {
            get { return _scaleRegExp; }
            set
            {
                if (value == _scaleRegExp)
                {
                    return;
                }

                _scaleRegExp = value;
                OnPropertyChanged();
            }
        }

        public string ScaleTestMessage
        {
            get { return _scaleTestMessage; }
            set
            {
                if (value == _scaleTestMessage)
                {
                    return;
                }

                _scaleTestMessage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}