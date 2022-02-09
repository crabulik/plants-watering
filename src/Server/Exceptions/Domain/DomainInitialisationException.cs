using PlantsWatering.Server.Exceptions.Server;
using System.Runtime.Serialization;

[Serializable]
public class DomainInitialisationException : InternalErrorException
{
    public DomainInitialisationException()
    {
    }

    public DomainInitialisationException(string? message) : base(message)
    {
    }

    public DomainInitialisationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DomainInitialisationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}