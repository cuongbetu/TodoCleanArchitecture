﻿using Newtonsoft.Json;

namespace TodoCleanArchitecture.Application.DTOs.Common;

public class ValidationError
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Field { get; }

    public string Message { get; }

    public ValidationError(string field, string message)
    {
        Field = field != string.Empty ? field : null;
        Message = message;
    }
}
