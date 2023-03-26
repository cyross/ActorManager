using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class ColorApi
    {
        [RestRoute("Get", "/SaveColor")]
        public async Task Save(IHttpContext context)
        {
            IHttpResponse response = context.Response as IHttpResponse;

            ResponseMessage status = new ResponseMessage().Succeed();

            string json = status.ToJson();

            response.ContentType = ContentType.Json;
            await response.SendResponseAsync(json);
        }

        [RestRoute("Get", "/ColorSpec")]
        public async Task Get(IHttpContext context)
        {
            ColorMaster master = ColorMaster.Instance();
            string json = master.ToJson();

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
        }

        [RestRoute("Get", "/ColorSpec/{index}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramIndex = context.Request.PathParameters["index"];
            ColorMaster master = ColorMaster.Instance();
            string json = master.ToJson(paramIndex);

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
        }

        [RestRoute("Post", "/ColorSpec/{index}")]
        public async Task Post(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Put", "/ColorSpec")]
        public async Task Put(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Delete", "/ColorSpec")]
        public async Task Delete(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }
    }
}
