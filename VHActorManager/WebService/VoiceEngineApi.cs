using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class VoiceEngineApi
    {
        [RestRoute("Get", "/SaveVoiceEngine")]
        public async Task Save(IHttpContext context)
        {
            IHttpResponse response = context.Response as IHttpResponse;

            ResponseMessage status = new ResponseMessage().Succeed();

            string json = status.ToJson();

            response.ContentType = ContentType.Json;
            await response.SendResponseAsync(json);
        }

        [RestRoute("Get", "/VoiceEngineSpec")]
        public async Task Get(IHttpContext context)
        {
            VoiceEngineMaster master = VoiceEngineMaster.Instance();
            string json = master.ToJson();

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
        }

        [RestRoute("Get", "/VoiceEngineSpec/{index}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramIndex = context.Request.PathParameters["index"];
            VoiceEngineMaster master = VoiceEngineMaster.Instance();
            string json = master.ToJson(paramIndex);

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await response.SendResponseAsync(json);
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
