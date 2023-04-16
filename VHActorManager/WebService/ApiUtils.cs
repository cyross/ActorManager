using Grapevine;
using System.Diagnostics;

namespace VHActorManager.WebService
{
    internal class ApiUtils
    {
        public static Task CreateAndSendResponse(IHttpContext context, string json)
        {
            IHttpResponse response = context.Response as IHttpResponse;

            response.AddHeader("Content-Type", ContentType.Json);

            // 現在Webページ版はVueCLIプロジェクトを使用して開発中であり
            // npm run serveで動作させるために一時的にCORSを無視するようにする
            response.AddHeader("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, DELETE");
            response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            response.AddHeader("Access-Control-Allow-Origin", "*");

            return response.SendResponseAsync(json);
        }

        public static Task CreateOptionsAndSendResponse(IHttpContext context)
        {
            IHttpResponse response = context.Response as IHttpResponse;

            // 現在Webページ版はVueCLIプロジェクトを使用して開発中であり
            // npm run serveで動作させるために一時的にCORSを無視するようにする
            response.AddHeader("Allow", "OPTIONS, GET, POST, PUT, DELETE");
            response.AddHeader("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, DELETE");
            response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            response.AddHeader("Access-Control-Allow-Origin", "*");

            return response.SendResponseAsync("");
        }

        public static string GetRequestBody(IHttpContext context)
        {
            StreamReader reader = new StreamReader(context.Request.InputStream);
            return reader.ReadToEnd();
        }
    }
}
