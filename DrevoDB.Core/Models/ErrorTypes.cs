using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DrevoDB.Core.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum ErrorTypes
{
    InternalServerError
}
