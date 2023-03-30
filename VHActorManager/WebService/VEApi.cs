using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class VEApi
    {
        [RestRoute("Get", "/VoiceEngineSpec/Index")]
        public async Task GetNameList(IHttpContext context)
        {
            string json = VEMaster.Instance().NameListToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/VoiceEngineSpec")]
        public async Task Get(IHttpContext context)
        {
            string json = VEMaster.Instance().SpecsToJson();

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/VoiceEngineSpec/{id}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string json = VEMaster.Instance().SpecToJson(paramId);

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Post", "/VoiceEngineSpec/{id}")]
        public async Task Post(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Put", "/VoiceEngineSpec")]
        public async Task Put(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Delete", "/VoiceEngineSpec/{id}")]
        public async Task Delete(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }
    }
}
