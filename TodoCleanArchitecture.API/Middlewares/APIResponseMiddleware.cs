using Newtonsoft.Json;
using System.Net;
using TodoCleanArchitecture.API.Extensions;
using TodoCleanArchitecture.Application.DTOs.Common;

namespace TodoCleanArchitecture.API.Middlewares;

public class APIResponseMiddleware
{
    private readonly RequestDelegate _next;
    public APIResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;
            try
            {
                await _next.Invoke(context);

                if (context.Response.StatusCode == (int)HttpStatusCode.OK)
                {
                    var body = await FormatResponse(context.Response);
                    context.Response.Body = originalBodyStream;
                    await HandleSuccessRequestAsync(context, body, context.Response.StatusCode);
                }
                //else
                //{
                //    await HandleNotSuccessRequestAsync(context, context.Response.StatusCode);
                //}
            }
            catch (Exception ex)
            {
                context.Response.Body = originalBodyStream;
                await HandleExceptionAsync(context, ex);
            }
        }
    }

    private static Task HandleSuccessRequestAsync(HttpContext context, object body, int code)
    {
        context.Response.ContentType = "application/json";
        string jsonString, bodyText = string.Empty;
        APIResponse apiResponse = null;

        if (!body.ToString().IsValidJson())
            bodyText = JsonConvert.SerializeObject(body);
        else
            bodyText = body.ToString();

        dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);
        Type type;

        type = bodyContent?.GetType();

        if (type.Equals(typeof(Newtonsoft.Json.Linq.JObject)))
        {
            apiResponse = JsonConvert.DeserializeObject<APIResponse>(bodyText);
            if (apiResponse.StatusCode != code)
                jsonString = JsonConvert.SerializeObject(apiResponse);
            else if (apiResponse.Result != null)
                jsonString = JsonConvert.SerializeObject(apiResponse);
            else
            {
                apiResponse = new APIResponse(code, bodyContent);
                jsonString = JsonConvert.SerializeObject(apiResponse);
            }
        }
        else
        {
            apiResponse = new APIResponse(code, bodyContent);
            jsonString = JsonConvert.SerializeObject(apiResponse);
        }
        return context.Response.WriteAsync(jsonString);
    }

    private static Task HandleExceptionAsync(HttpContext context,Exception ex)
    {
        context.Response.ContentType = "application/json";

        var response = APIResponse.Exception(ex);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return plainBodyText;
    }
}
