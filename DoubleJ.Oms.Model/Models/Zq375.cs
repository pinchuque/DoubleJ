using System;
using DoubleJ.Oms.Settings;
using ZylSerialPort;

namespace DoubleJ.Oms.Model.Models
{
    public class Zq375 : IDisposable
    {
        private readonly SerialPort _serialPort = new SerialPort();
        private string _portBuffer;
        private const int FullPacketSize = 96;

        public event ReadingHandler Reading;

        public delegate void ReadingHandler(Zq375 scale, ReadingEventArgs eventArgs);

        public Zq375()
        {
            int serialPort = SettingsManager.Current.SerialPort;
            switch (serialPort)
            {
                case 1:
                    _serialPort.Port = SerialPort.SerialCommPort.COM01;
                    break;
                case 2:
                    _serialPort.Port = SerialPort.SerialCommPort.COM02;
                    break;
                case 3:
                    _serialPort.Port = SerialPort.SerialCommPort.COM03;
                    break;
                case 4:
                    _serialPort.Port = SerialPort.SerialCommPort.COM04;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _serialPort.BaudRate = SerialPort.SerialBaudRate.br009600;
            _serialPort.DataWidth = SerialPort.SerialDataWidth.dw8Bits;
            _serialPort.ParityBits = SerialPort.SerialParityBits.pbNone;
            _serialPort.StopBits = SerialPort.SerialStopBits.sb1Bit;
            _serialPort.Delay = 100;

            _serialPort.Received += DataReceived;
        }

        public bool IsConnected { get { return _serialPort.ConnectedTo != SerialPort.SerialCommPort.None; } }

        public bool IsLocalBufferComplete { get { return _portBuffer.Length == FullPacketSize; } }

        public bool Connect() { return !IsConnected && _serialPort.Open(); }

        public void Disconnect() { if (IsConnected) _serialPort.Close(); }

        public void FlushData() { if (IsConnected) _serialPort.ClearOutputBuffer(); }

        public void Dispose() { Disconnect(); }

        private void DataReceived(object sender, DataEventArgs eventArgs)
        {
            if (eventArgs.Buffer.Length < FullPacketSize)
            {
                _portBuffer += SerialPort.ASCIIByteArrayToString(eventArgs.Buffer);
                if (!IsLocalBufferComplete)
                {
                    return;
                }
            }
            else if (eventArgs.Buffer.Length > FullPacketSize)
            {
                _serialPort.ClearOutputBuffer();
                _portBuffer = string.Empty;
                return;
            }
            else
            {
                _portBuffer = SerialPort.ASCIIByteArrayToString(eventArgs.Buffer);
            }
            var readingEventArgs = new ReadingEventArgs {Weight = new ScaleWeight(_portBuffer)};
            Reading(this, readingEventArgs);
            _portBuffer = String.Empty;
        }
    }
}
