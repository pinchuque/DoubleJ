using System;
using System.Runtime.Serialization;

namespace DoubleJ.Oms.Model.Models
{
    [Serializable]
    public class UnexpectedDataException : Exception
    {
        public UnexpectedDataException()
        {
        }

        public UnexpectedDataException(string message)
            : base(message)
        {
        }

        public UnexpectedDataException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UnexpectedDataException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}