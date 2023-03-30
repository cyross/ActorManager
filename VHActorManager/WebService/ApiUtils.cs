using Grapevine;

namespace VHActorManager.WebService
{
    internal class ApiUtils
    {
        public static Task CreateAndSendResponse(IHttpContext context, string json)
        {
            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            return response.SendResponseAsync(json);
        }

        public static string GetRequestBody(IHttpContext context)
        {
            StreamReader reader = new StreamReader(context.Request.InputStream);
            return reader.ReadToEnd();
        }
    }
}
