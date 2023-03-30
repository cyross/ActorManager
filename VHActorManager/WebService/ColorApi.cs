using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class ColorApi
    {
        [RestRoute("Get", "/ColorSpec/Index")]
        public async Task GetNameList(IHttpContext context)
        {
            string json = ColorMaster.Instance().NameListToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/ColorSpec/All")]
        public async Task GetAll(IHttpContext context)
        {
            string json = ColorMaster.Instance().SpecsToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/ColorSpec")]
        public async Task Get(IHttpContext context)
        {
            string json = ColorMaster.Instance().SpecsToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/ColorSpec/{id}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramId = context.Request.PathParameters["id"];
            string json = ColorMaster.Instance().SpecToJson(paramId);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Post", "/ColorSpec/{id}")]
        public async Task Post(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Put", "/ColorSpec")]
        public async Task Put(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }

        [RestRoute("Delete", "/ColorSpec/{id}")]
        public async Task Delete(IHttpContext context)
        {
            await context.Response.SendResponseAsync("");
        }
    }
}
