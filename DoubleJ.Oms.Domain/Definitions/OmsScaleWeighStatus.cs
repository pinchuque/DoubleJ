namespace DoubleJ.Oms.Domain.Definitions
{
    public enum OmsScaleWeighStatus
    {
        UnknownApplicationError = -1,
        Success = 0,
        CancelledAtScale,
        InvalidScaleReading,
        ScaleWaitTimeOut
    }
}