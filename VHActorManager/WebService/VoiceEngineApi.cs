using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class VoiceEngineApi
    {
        [RestRoute("Get", "/VoiceEngineSpec/Index")]
        public async Task GetNameList(IHttpContext context)
        {
            string json = VoiceEngineMaster.Instance().NameListToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/VoiceEngineSpec")]
        public async Task Get(IHttpContext context)
        {
            string json = VoiceEngineMaster.Instance().SpecsToJson();

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/VoiceEngineSpec/{index}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramIndex = context.Request.PathParameters["index"];
            string json = VoiceEngineMaster.Instance().SpecToJson(paramIndex);

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Post", "/VoiceEngineSpec/{index}")]
        public async Task Post(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Put", "/VoiceEngineSpec")]
        public async Task Put(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Delete", "/VoiceEngineSpec")]
        public async Task Delete(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }
    }
}
