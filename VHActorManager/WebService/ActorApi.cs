using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class ActorApi
    {
        [RestRoute("Get", "/SaveActor")]
        public async Task Save(IHttpContext context)
        {
            IHttpResponse response = context.Response as IHttpResponse;

            ResponseMessage status = new ResponseMessage().Succeed();

            string json = status.ToJson();

            response.ContentType = ContentType.Json;
            await response.SendResponseAsync(json);
        }

        [RestRoute("Get", "/ActorSpec")]
        public async Task Get(IHttpContext context)
        {
            ActorMaster master = ActorMaster.Instance();
            string json = master.ToJson();

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
        }

        [RestRoute("Get", "/ActorSpec/{index}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramIndex = context.Request.PathParameters["index"];
            ActorMaster master = ActorMaster.Instance();
            string json = master.ToJson(paramIndex);

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
        }

        [RestRoute("Post", "/ActorSpec/{index}")]
        public async Task Post(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Put", "/ActorSpec")]
        public async Task Put(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Delete", "/ActorSpec")]
        public async Task Delete(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }
    }
}
