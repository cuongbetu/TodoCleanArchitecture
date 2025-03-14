using Newtonsoft.Json;

namespace TodoCleanArchitecture.API.Extensions;

public static class StringExtension
{
    public static bool IsValidJson(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return false;
        text = text.Trim();
        if ((text.StartsWith("{") && text.EndsWith("}")) || (text.StartsWith("[") && text.EndsWith("]")))
        {
            try { JsonConvert.DeserializeObject(text); return true; }
            catch (JsonException) { return false; }
        }
        return false;
    }
}
