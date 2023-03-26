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
            ActorMaster.Instance().Save();

            await ApiUtils.CreateAndSendResponse(context, new ResponseMessage().Succeed().ToJson());
        }

        [RestRoute("Get", "/ActorSpec/Index")]
        public async Task GetNameList(IHttpContext context)
        {
            string json = ActorMaster.Instance().NameListToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/ActorSpec")]
        public async Task Get(IHttpContext context)
        {
            string json = ActorMaster.Instance().SpecsToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/ActorSpec/{index}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramIndex = context.Request.PathParameters["index"];
            string json = ActorMaster.Instance().SpecToJson(paramIndex);

            await ApiUtils.CreateAndSendResponse(context, json);
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
