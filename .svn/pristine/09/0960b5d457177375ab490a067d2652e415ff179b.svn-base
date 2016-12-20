namespace DoubleJ.Oms.Settings
{
    public class SettingsManager
    {
        private static SettingsManager _current;
        private readonly Properties.Settings _currentSettings = Properties.Settings.Default;

        protected SettingsManager()
        {
        }

        public static SettingsManager Current
        {
            get { return _current ?? (_current = new SettingsManager()); }
        }

        public int ScaleId
        {
            get { return _currentSettings.ScaleId; }
            set { _currentSettings.ScaleId = value; }
        }

        public string Printer
        {
            get { return _currentSettings.Printer; }
            set { _currentSettings.Printer = value; }
        }

        public string SecondaryPrinter
        {
            get { return _currentSettings.SecondaryPrinter; }
            set { _currentSettings.SecondaryPrinter = value; }
        }
        public string SecondLabel
        {
            get { return _currentSettings.SecondLabel; }
            set { _currentSettings.SecondLabel = value; }
        }

        public bool IsSecondaryLabel
        {
            get { return _currentSettings.IsSecondaryLabel; }
            set { _currentSettings.IsSecondaryLabel = value; }
        }

        public string ScaleIpAddress
        {
            get { return _currentSettings.ScaleIpAddress; }
            set { _currentSettings.ScaleIpAddress = value; }
        }

        public int ScalePort
        {
            get { return _currentSettings.ScalePort; }
            set { _currentSettings.ScalePort = value; }
        }

        public string ScaleRegExp
        {
            get { return _currentSettings.ScaleRegExp; }
            set { _currentSettings.ScaleRegExp = value; }
        }

        public int SerialPort
        {
            get { return _currentSettings.SerialPort; }
            set { _currentSettings.SerialPort = value; }
        }

        public string BeefFileName
        {
            get { return _currentSettings.BeefFileName; }
            set { _currentSettings.BeefFileName = value; }
        }

        public string BisonFileName
        {
            get { return _currentSettings.BisonFileName; }
            set { _currentSettings.BisonFileName = value; }
        }

        public string DoubleJLogoFileName
        {
            get { return _currentSettings.DoubleJLogoFileName; }
            set { _currentSettings.DoubleJLogoFileName = value; }
        }

        public string NoLogoImageFileName
        {
            get { return _currentSettings.NoLogoImageFileName; }
            set { _currentSettings.NoLogoImageFileName = value; }
        }

        public string OrganicFileName
        {
            get { return _currentSettings.OrganicFileName; }
            set { _currentSettings.OrganicFileName = value; }
        }

        public string LabelBaseFolder
        {
            get { return _currentSettings.LabelBaseFolder; }
            set { _currentSettings.LabelBaseFolder = value; }
        }

        public string Password
        {
            get { return _currentSettings.Password; }
            set { _currentSettings.Password = value; }
        }
        
        public void Save()
        {
            _currentSettings.Save();
        }
    }
}