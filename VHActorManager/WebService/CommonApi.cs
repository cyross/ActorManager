using Grapevine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHActorManager.Master;

namespace VHActorManager.WebService
{
    [RestResource(BasePath = "api/v1")]
    internal class CommonApi
    {
        [RestRoute("Get", "/SaveAll")]
        public async Task SaveAll(IHttpContext context)
        {
            ActorMaster.Instance().Save();
            VoiceEngineMaster.Instance().Save();
            ColorMaster.Instance().Save();

            await ApiUtils.CreateAndSendResponse(context, new ResponseMessage().Succeed().ToJson());
        }

    }
}
