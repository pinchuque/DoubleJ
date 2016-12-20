using System.ComponentModel;
using System.Net.Sockets;
using System.Windows;

using DoubleJ.Oms.LabelManager.Models;
using DoubleJ.Oms.Settings;


namespace DoubleJ.Oms.LabelManager
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        private readonly SettingsViewModel _model;

        public SettingsWindow()
        {
            InitializeComponent();
            _model = new SettingsViewModel
            {
                Printer = SettingsManager.Current.Printer,
                BeefFileName = SettingsManager.Current.BeefFileName,
                Password = SettingsManager.Current.Password,
                ScaleId = SettingsManager.Current.ScaleId,
                BisonFileName = SettingsManager.Current.BisonFileName,
                DoubleJLogoFileName = SettingsManager.Current.DoubleJLogoFileName,
                LabelBaseFolder = SettingsManager.Current.LabelBaseFolder,
                NoLogoImageFileName = SettingsManager.Current.NoLogoImageFileName,
                OrganicFileName = SettingsManager.Current.OrganicFileName,
                SerialPort = SettingsManager.Current.SerialPort,
                ScaleIpAddress = SettingsManager.Current.ScaleIpAddress,
                ScalePort = SettingsManager.Current.ScalePort,
                ScaleRegExp = SettingsManager.Current.ScaleRegExp,

                SecondaryPrinter = SettingsManager.Current.SecondaryPrinter,
                SecondLabel = SettingsManager.Current.SecondLabel,
                IsSecondaryLabel = SettingsManager.Current.IsSecondaryLabel
            };

            DataContext = _model;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            SettingsManager.Current.ScaleId = _model.ScaleId;
            SettingsManager.Current.Printer = _model.Printer;
            SettingsManager.Current.SerialPort = _model.SerialPort;
            SettingsManager.Current.BeefFileName = _model.BeefFileName;
            SettingsManager.Current.BisonFileName = _model.BisonFileName;
            SettingsManager.Current.DoubleJLogoFileName = _model.DoubleJLogoFileName;
            SettingsManager.Current.NoLogoImageFileName = _model.NoLogoImageFileName;
            SettingsManager.Current.OrganicFileName = _model.OrganicFileName;
            SettingsManager.Current.LabelBaseFolder = _model.LabelBaseFolder;
            SettingsManager.Current.Password = _model.Password;
            SettingsManager.Current.ScaleIpAddress = _model.ScaleIpAddress;
            SettingsManager.Current.ScalePort = _model.ScalePort;
            SettingsManager.Current.ScaleRegExp = _model.ScaleRegExp;
            if (_model.IsSecondaryLabel)
            {
                SettingsManager.Current.SecondaryPrinter = _model.SecondaryPrinter;
                SettingsManager.Current.SecondLabel = _model.SecondLabel;
            }
            SettingsManager.Current.IsSecondaryLabel = _model.IsSecondaryLabel;
            SettingsManager.Current.Save();
            Close();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void TestScaleClick(object sender, RoutedEventArgs e)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += ScaleDoWork;
            bw.RunWorkerAsync();
        }

        private void ScaleDoWork(object o, DoWorkEventArgs args)
        {
            _model.ScaleTestMessage = "Testing scale conectivity...";

            try
            {
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(_model.ScaleIpAddress, _model.ScalePort);
                _model.ScaleTestMessage = "Scale can be successfully connected. Success";
            }
            catch
            {
                _model.ScaleTestMessage = "Scale could not be connected. Test Failed";
            }
        }
    }
}