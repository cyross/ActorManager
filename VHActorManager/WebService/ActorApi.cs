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
        [Header("Content-Type", "application/json")]
        public async Task Post(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string body = ApiUtils.GetRequestBody(context);
            string json = ActorMaster.Instance().SpecFromJson(paramId, body);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Put", "/ActorSpec")]
        [Header("Content-Type", "application/json")]
        public async Task Put(IHttpContext context)
        {
            string body = ApiUtils.GetRequestBody(context);
            string json = ActorMaster.Instance().SpecFromJson(body);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Delete", "/ActorSpec/{id}")]
        public async Task Delete(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string json = ActorMaster.Instance().DeleteSpec(paramId);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Options", "/ActorSpec/")]
        public async Task Options(IHttpContext context)
        {
            await ApiUtils.CreateOptionsAndSendResponse(context);
        }

        [RestRoute("Options", "/ActorSpec/{id}")]
        public async Task OptionsWithId(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];

            await ApiUtils.CreateOptionsAndSendResponse(context);
        }

        [RestRoute("Options", "/ActorSpec/Index")]
        public async Task OptionsWithIndex(IHttpContext context)
        {
            await ApiUtils.CreateOptionsAndSendResponse(context);
        }
    }
}
