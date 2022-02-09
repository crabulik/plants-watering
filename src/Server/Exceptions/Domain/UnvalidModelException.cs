using PlantsWatering.Server.Exceptions.Server;
using System.Runtime.Serialization;

namespace PlantsWatering.Server.Exceptions.Domain
{
    [Serializable]
    public class UnvalidModelException : InternalErrorException
    {
        public UnvalidModelException()
        {
        }

        public UnvalidModelException(string? message) : base(message)
        {
        }

        public UnvalidModelException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnvalidModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
