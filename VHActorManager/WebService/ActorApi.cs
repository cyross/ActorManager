using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class ActorApi
    {
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

        [RestRoute("Get", "/ActorSpec/{id}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string json = ActorMaster.Instance().SpecToJson(paramId);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Post", "/ActorSpec/{id}")]
        public async Task Post(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Put", "/ActorSpec")]
        public async Task Put(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Delete", "/ActorSpec/{id}")]
        public async Task Delete(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }
    }
}
