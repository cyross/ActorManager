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

        [RestRoute("Get", "/ColorSpec")]
        public async Task Get(IHttpContext context)
        {
            string json = ColorMaster.Instance().SpecsToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/ColorSpec/{index}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramIndex = context.Request.PathParameters["index"];
            string json = ColorMaster.Instance().SpecToJson(paramIndex);

            await ApiUtils.CreateAndSendResponse(context, json);
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
