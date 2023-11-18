using Grapevine;
using System.Diagnostics;

namespace VHActorManager.WebService
{
    internal class ApiUtils
    {
        private static string GetOrigin(IHttpRequest request)
        {
            // Originヘッダの値がnullのときがある
            // そのときはワイルドカードを設定
            return request.Headers.Get("Origin") ?? "*";
        }

        private static IHttpResponse ApplyCorsHeader(IHttpResponse response, IHttpRequest request)
        {
            string origin = GetOrigin(request);

            response.AddHeader("Content-Type", ContentType.Binary);

            // 現在Webページ版はVueCLIプロジェクトを使用して開発中であり
            // npm run serveで動作させるために一時的にCORSを無視するようにする
            response.AddHeader("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, DELETE");
            response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            response.AddHeader("Access-Control-Allow-Origin", origin);

            return response;
        }

        public static Task CreateAndSendResponse(IHttpContext context, string json)
        {
            IHttpResponse response = ApplyCorsHeader(context.Response as IHttpResponse, context.Request as IHttpRequest);

            return response.SendResponseAsync(json);
        }

        public static Task CreateOptionsAndSendResponse(IHttpContext context)
        {
            IHttpResponse response = ApplyCorsHeader(context.Response as IHttpResponse, context.Request as IHttpRequest);

            response.AddHeader("Allow", "OPTIONS, GET, POST, PUT, DELETE");

            return response.SendResponseAsync("");
        }

        public static string GetRequestBody(IHttpContext context)
        {
            StreamReader reader = new StreamReader(context.Request.InputStream);
            return reader.ReadToEnd();
        }
    }
}
