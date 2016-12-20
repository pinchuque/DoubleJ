using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.LabelManager.Annotations;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Settings;

using NLog;

using Telerik.Windows.Controls;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class LabelManagerViewModel : INotifyPropertyChanged
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string _customerComments;
        private OrderSummaryViewModel _orderSummary;
        private BindingList<SelectListItemModel> _orders;
        private string _specialInstructions;
        private Brush _weightErrorColor;
        private string _weightOutput;
        private OrdersConstructorViewModel _offalsSource;
        private OrdersConstructorViewModel _combosSource;
        private BackgroundWorker _bw;
        private string _message;
        private Visibility _bagsVisibility;
        private Visibility _boxesVisibility;
        private Visibility _customerBagsVisibility;
        private DateTime? _processDate;
        private UnitListViewModel _unitListViewModel;
        private CustomBoxGridViewModel _customBoxGridViewModel;
        private CustomBoxGridViewModel _customTrayGridViewModel;
        private CustomBagGridViewModel _customBagGridViewModel;
        private BindingList<CaseSize> _bagsTareWeights;

        public Headers Headers { get; set; }

        public LabelManagerViewModel()
        {
            Orders = new BindingList<SelectListItemModel>();
            OrderSummary = new OrderSummaryViewModel();
            CustomBoxGridViewModel = new CustomBoxGridViewModel();
            CustomTrayGridViewModel = new CustomBoxGridViewModel();
            CustomBagGridViewModel = new CustomBagGridViewModel();
            OffalsSource = new OrdersConstructorViewModel();
            CombosSource = new OrdersConstructorViewModel();
            WeightErrorColor = new SolidColorBrush(Colors.PaleGoldenrod);
            ProcessDate = DateTime.Now;
            Headers = new Headers();
        }

        public void StartListening()
        {
            var bytes = new byte[256];

            _bw = new BackgroundWorker {WorkerSupportsCancellation = true};
            _bw.DoWork += (sender, args) =>
            {
                var self = (BackgroundWorker) sender;
                var output = string.Empty;
                while (!self.CancellationPending)
                {
                    Logger.Debug("Waiting for a connection... ");

                    try
                    {
                        var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                        socket.Connect(SettingsManager.Current.ScaleIpAddress, SettingsManager.Current.ScalePort);
                        Logger.Debug("Connected!");
                        Message = "Scale connected";

                        using (var ns = new NetworkStream(socket))
                        {
                            int i;
                            while ((i = ns.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                if (self.CancellationPending)
                                {
                                    break;
                                }

                                var data = Encoding.ASCII.GetString(bytes, 0, i);
                                output += data;
                                if (!output.Contains("\n")) continue;
                                ParseWeightFromScaleData(output);
                                output = string.Empty;
                            }
                        }

                        socket.Close();
                    }
                    catch (SocketException ex)
                    {
                        Logger.Debug("Socket error: " + ex);
                    }

                    Message = "Scale disconnected";
                    Logger.Debug("Disconnected!");
                }
            };
            try
            {
                _bw.RunWorkerAsync();
            }
            catch (Exception e)
            {
                Logger.Error("Error: " + e);
            }
        }

        private void ParseWeightFromScaleData(string output)
        {
            var regex = new Regex(SettingsManager.Current.ScaleRegExp);
            var match = regex.Match(output);
            while (match.Success)
            {
                Weight = double.Parse(match.Value);
                OnWeightReceived();
                match = match.NextMatch();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (value == _message) return;

                _message = value;
                OnPropertyChanged();
            }
        }

        public double Weight { get; set; }

        public void StopListening()
        {
            _bw.CancelAsync();
            Logger.Debug("--- Disonnected!");
            Message = string.Empty;
        }

        public UnitListViewModel UnitListViewModel
        {
            get { return _unitListViewModel; }
            set
            {
                _unitListViewModel = value;
                OnPropertyChanged();
            }
        }

        public CustomBoxGridViewModel CustomBoxGridViewModel
        {
            get { return _customBoxGridViewModel; }
            set
            {
                _customBoxGridViewModel = value;
                OnPropertyChanged();
            }
        }
        public CustomBoxGridViewModel CustomTrayGridViewModel
        {
            get { return _customTrayGridViewModel; }
            set
            {
                _customTrayGridViewModel = value;
                OnPropertyChanged();
            }
        }

        public CustomBagGridViewModel CustomBagGridViewModel
        {
            get { return _customBagGridViewModel; }
            set
            {
                _customBagGridViewModel = value;
                OnPropertyChanged();
            }
        }

        public BindingList<SelectListItemModel> Orders
        {
            get { return _orders; }
            set
            {
                if (Equals(value, _orders)) return;

                _orders = value;
                OnPropertyChanged();
            }
        }

        public OrderSummaryViewModel OrderSummary
        {
            get { return _orderSummary; }
            set
            {
                if (Equals(value, _orderSummary)) return;

                _orderSummary = value;
                OnPropertyChanged();
            }
        }

        public OrdersConstructorViewModel OffalsSource
        {
            get { return _offalsSource; }
            set
            {
                if (Equals(value, _offalsSource)) return;

                _offalsSource = value;
                OnPropertyChanged();
            }
        }

        public OrdersConstructorViewModel CombosSource
        {
            get { return _combosSource; }
            set
            {
                if (Equals(value, _combosSource)) return;

                _combosSource = value;
                OnPropertyChanged();
            }
        }

        public string SpecialInstructions
        {
            get { return _specialInstructions; }
            set
            {
                if (value == _specialInstructions) return;

                _specialInstructions = value;
                OnPropertyChanged();
            }
        }

        public string CustomerComments
        {
            get { return _customerComments; }
            set
            {
                if (value == _customerComments) return;

                _customerComments = value;
                OnPropertyChanged();
            }
        }

        public Brush WeightErrorColor
        {
            get { return _weightErrorColor; }
            set
            {
                if (value.Equals(_weightErrorColor)) return;

                _weightErrorColor = value;
                OnPropertyChanged();
            }
        }

        public string WeightOutput
        {
            get { return _weightOutput; }
            set
            {
                if (value == _weightOutput) return;

                _weightOutput = value;
                OnPropertyChanged();
            }
        }

        public int CurrentOrderId { get; set; }

        public bool IsCustomOwner { get; set; }

        public LabelGridItem SelectedProduct { get; set; }
        public LabelBoxItem SelectedCustomerLocation { get; set; }

        public SideWeightItem SelectedSide { get; set; }
        public CutItem SelectedCutItem { get; set; }

        public Visibility BagsVisibility
        {
            get { return _bagsVisibility; }
            set
            {
                if (value == _bagsVisibility) return;

                _bagsVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility BoxesVisibility
        {
            get { return _boxesVisibility; }
            set
            {
                if (value == _boxesVisibility) return;

                _boxesVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility CustomerBagsVisibility
        {
            get { return _customerBagsVisibility; }
            set
            {
                if (value == _customerBagsVisibility) return;

                _customerBagsVisibility = value;
                OnPropertyChanged();
            }
        }


        public DateTime? ProcessDate
        {
            get { return _processDate; }
            set
            {
                _processDate = value ?? DateTime.Today;
                OnPropertyChanged();
            }
        }

        //public BindingList<CaseSize> BagsTareWeights
        //{
        //    get { return _bagsTareWeights; }
        //    set
        //    {
        //        _bagsTareWeights = value;
        //        OnPropertyChanged();
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler WeightReceived;

        protected virtual void OnWeightReceived()
        {
            var handler = WeightReceived;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}