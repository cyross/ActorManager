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

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/VoiceEngineSpec/{id}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string json = VEMaster.Instance().SpecToJson(paramId);

            IHttpResponse response = context.Response as IHttpResponse;
            response.ContentType = ContentType.Json;

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Post", "/VoiceEngineSpec/{id}")]
        [Header("Content-Type", "application/json")]
        public async Task Post(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string body = ApiUtils.GetRequestBody(context);
            string json = VEMaster.Instance().SpecFromJson(paramId, body);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Put", "/VoiceEngineSpec")]
        [Header("Content-Type", "application/json")]
        public async Task Put(IHttpContext context)
        {
            string body = ApiUtils.GetRequestBody(context);
            string json = VEMaster.Instance().SpecFromJson(body);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Delete", "/VoiceEngineSpec/{id}")]
        public async Task Delete(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string json = VEMaster.Instance().DeleteSpec(paramId);

            await ApiUtils.CreateAndSendResponse(context, json);
        }
    }
}
