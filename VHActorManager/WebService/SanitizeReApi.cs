using Grapevine;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class SanitizeReApi
    {
        [RestRoute("Get", "/SanitizeRe/Index")]
        public async Task GetKeyList(IHttpContext context)
        {
            string json = VEMaster.Instance().KeyListToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/SanitizeRe/All")]
        public async Task GetAll(IHttpContext context)
        {
            string json = VEMaster.Instance().SanitaizeRegsToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/SanitizeRe")]
        public async Task Get(IHttpContext context)
        {
            string json = VEMaster.Instance().SanitaizeRegsToJson();

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Get", "/SanitizeRe/{key}")]
        public async Task GetByIndex(IHttpContext context)
        {
            var paramKey = context.Request.PathParameters["key"];
            string json = VEMaster.Instance().SanitaizeRegListToJson(paramKey);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Post", "/SanitizeRe/{key}")]
        [Header("Content-Type", "application/json")]
        public async Task Post(IHttpContext context)
        {
            var paramKey = context.Request.PathParameters["key"];
            string body = ApiUtils.GetRequestBody(context);
            string json = VEMaster.Instance().SanitaizeRegListFromJson(paramKey, body);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Put", "/SanitizeRe/{key}")]
        [Header("Content-Type", "application/json")]
        public async Task Put(IHttpContext context)
        {
            var paramKey = context.Request.PathParameters["key"];

            string body = ApiUtils.GetRequestBody(context);
            string json = VEMaster.Instance().NewSanitaizeRegListFromJson(paramKey, body);

            await ApiUtils.CreateAndSendResponse(context, json);
        }

        [RestRoute("Delete", "/SanitizeRe/{key}")]
        public async Task Delete(IHttpContext context)
        {
            var paramKey = context.Request.PathParameters["key"];

            string json = VEMaster.Instance().DeleteSanitaizeRegList(paramKey);

            await ApiUtils.CreateAndSendResponse(context, json);
        }
    }
}
