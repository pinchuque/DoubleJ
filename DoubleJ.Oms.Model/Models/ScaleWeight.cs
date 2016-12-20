using System;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Model.Models
{
    public class ScaleWeight
    {
        #region Constants
        public const int ExpectedDataLength = 96;
        public const int DateTimeLine = 0;
        public const int ScaleIdLine = 1;
        public const int GrossLine = 2;
        public const int TareLine = 3;
        public const int NetLine = 4;
        public const int TimeLinePart = 0;
        public const int DateLinePart = 1;
        public const int DataLinePart = 1;
        private const double CancelThreshold = .25;
        #endregion Constants

        public OmsScaleWeighStatus Status { get; private set; }

        public int ScaleId;
        public DateTime MeasurementDate;
        public double Gross;
        public double Tare;
        public double Net;


        private bool IsCancelled { get { return Gross < CancelThreshold; } }

        public String FormattedDisplay
        {
            get
            {
                return String.Format("{0}\r\n\r\nGross:\t{1:0.000}\r\nTare:\t{2:0.000}\r\n\r\nNet:\t{3:0.000}", MeasurementDate.ToString("MM/dd/yyyy\thh:mm:ss"), Gross, Tare, Net);
            }
        }

        public String MeasurementDateString { get { return MeasurementDate.ToShortDateString(); } }
        public String MeasurementTimeString { get { return MeasurementDate.ToShortTimeString(); } }

        public ScaleWeight(OmsScaleWeighStatus status)
        {
            Status = status;
        }

        public ScaleWeight(string data)
        {
            if (data.Length != ExpectedDataLength)
            {
                Status = OmsScaleWeighStatus.InvalidScaleReading;
                return;
            }
            var dataLines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var lineBuffer = dataLines[DateTimeLine].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            MeasurementDate = Convert.ToDateTime(String.Format("{0} {1}", lineBuffer[DateLinePart], lineBuffer[TimeLinePart]));

            lineBuffer = dataLines[ScaleIdLine].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ScaleId = Convert.ToInt32(lineBuffer[DataLinePart]);

            lineBuffer = dataLines[GrossLine].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Gross = Convert.ToDouble(lineBuffer[DataLinePart]);

            lineBuffer = dataLines[TareLine].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Tare = Convert.ToDouble(lineBuffer[DataLinePart]);

            lineBuffer = dataLines[NetLine].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Net = Convert.ToDouble(lineBuffer[DataLinePart]);

            Status = IsCancelled ? OmsScaleWeighStatus.CancelledAtScale : OmsScaleWeighStatus.Success;
        }
    }
}
