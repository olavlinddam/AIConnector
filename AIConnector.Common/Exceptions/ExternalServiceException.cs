namespace AIConnector.Common.Exceptions;
using System;
using System.Runtime.Serialization;

[Serializable]
public class ExternalServiceException : Exception
{
    public ExternalServiceException()
    {
    }

    public ExternalServiceException(string message)
        : base(message)
    {
    }

    public ExternalServiceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected ExternalServiceException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
