using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using DoubleJ.Oms.Domain.Definitions;

namespace DoubleJ.Oms.Model.Models
{
    public class Zq375Scale : IDisposable
    {
        private readonly TcpClient _tcpClient;
        private readonly NetworkStream _stream;
        private const int BufferSize = 256;

        public int Id { get; private set; }


        public Zq375Scale(int id, string ipAddress, int ipPort, int timeoutSeconds)
        {
            Id = id;
            _tcpClient = new TcpClient();
            _tcpClient.Connect(ipAddress, ipPort);
            _stream = _tcpClient.GetStream();
            _stream.ReadTimeout = timeoutSeconds * 1000;
        }

        public ScaleWeight GetWeight()
        {
            if (!_tcpClient.Connected) throw new ApplicationException("not connected to scale\r\n");
            if (!_stream.CanRead) throw new ApplicationException("stream can't be read");

            ScaleWeight weight;
            try
            {
                var data = new byte[BufferSize];
                var bytesRead = _stream.Read(data, 0, data.Length);
                var scaleData = Encoding.ASCII.GetString(data, 0, bytesRead);
                weight = new ScaleWeight(scaleData);
            }
            catch (IOException)
            {
                weight = new ScaleWeight(OmsScaleWeighStatus.ScaleWaitTimeOut);
            }
            return weight;
        }

        public void Flush()
        {
            if (!_tcpClient.Connected) throw new ApplicationException("not connected to scale\r\n");
            if (!_stream.CanRead) throw new ApplicationException("stream can't be read");

            var data = new byte[BufferSize];

            while (_stream.DataAvailable)
            {
                _stream.Read(data, 0, data.Length);
            }
        }

        public void Dispose()
        {
            _stream.Close();
            _tcpClient.Close();
        }
    }
}
