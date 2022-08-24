﻿using System.Runtime.Serialization;

namespace KeysetPagination.Domain.Exceptions;

public class InvalidRequestException : Exception
{
    public List<string> Errors { get; }

    public InvalidRequestException(List<string> errors)
    {
        Errors = errors;
    }

    public InvalidRequestException()
    {
    }

    public InvalidRequestException(string message) : base(message)
    {
    }

    public InvalidRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected InvalidRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

