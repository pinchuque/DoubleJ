using System;
using System.Configuration;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Service.Interfaces;

namespace DoubleJ.Oms.Service.Services.Device
{
    public class ScaleService : IScaleService
    {
        private readonly ILabelCreateService _labelCreateService;
        private readonly IScaleRepository _scaleRepository;

        public ScaleService(IScaleRepository scaleRepository, ILabelCreateService labelCreateService)
        {
            _scaleRepository = scaleRepository;
            _labelCreateService = labelCreateService;
        }

        public Zq375Scale InitializeScale(int scaleId)
        {
            var scale = _scaleRepository.Get(scaleId);
            var zq375 = new Zq375Scale(scaleId, scale.IpAddress, scale.IpPort, scale.TimeoutSeconds);
            zq375.Flush();
            return zq375;
        }

        public OmsScaleWeighStatus WeighAndLabel(int orderDetailId, OmsLabelType labelType)
        {
            var scaleId = Convert.ToInt32(ConfigurationManager.AppSettings["ScaleId"]);
            if (SessionService.Get().BagScale == null)
            {
                SessionService.Get().BagScale = InitializeScale(scaleId);
            }

            var scaleWeight = SessionService.Get().BagScale.GetWeight();
            var status = scaleWeight.Status;
            if (status == OmsScaleWeighStatus.Success)
            {
               _labelCreateService.ProduceLabel(orderDetailId, scaleWeight, labelType,null);
            }

            return status;
        }

        public string GetScaleStatusMessage(OmsScaleWeighStatus status)
        {
            switch (status)
            {
                case OmsScaleWeighStatus.UnknownApplicationError:
                    return "An unknown error has occured during the weight reading.";
                case OmsScaleWeighStatus.Success:
                    return "Success weight reading.";
                case OmsScaleWeighStatus.CancelledAtScale:
                    return "Weight reading was cancelled at scale.";
                case OmsScaleWeighStatus.InvalidScaleReading:
                    return "Invalid weight reading.";
                case OmsScaleWeighStatus.ScaleWaitTimeOut:
                    return "The scale timeout was exceeded.";
                default:
                    throw new ArgumentOutOfRangeException("status");
            }
        }
    }
}