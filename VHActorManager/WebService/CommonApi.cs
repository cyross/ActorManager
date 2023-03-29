using Grapevine;
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
            VEMaster.Instance().Save();
            ColorMaster.Instance().Save();

            User user = User.Instance();

            string scriptPath = user.VegasScriptYAML.ScriptPath;

            if (user.VegasScriptYAML.Enable && Path.Exists(scriptPath))
            {
                ActorMaster.Instance().Save(Utility.CombineFilePath(scriptPath, ActorMaster.YAML_FILENAME));
                VEMaster.Instance().Save(Utility.CombineFilePath(scriptPath, VEMaster.YAML_FILENAME));
                ColorMaster.Instance().Save(Utility.CombineFilePath(scriptPath, ColorMaster.YAML_FILENAME));
            }

            string extPath = user.VegasScriptYAML.ExtPath;

            if (user.VegasScriptYAML.Enable && Path.Exists(extPath))
            {
                ActorMaster.Instance().Save(Utility.CombineFilePath(extPath, ActorMaster.YAML_FILENAME));
                VEMaster.Instance().Save(Utility.CombineFilePath(extPath, VEMaster.YAML_FILENAME));
                ColorMaster.Instance().Save(Utility.CombineFilePath(extPath, ColorMaster.YAML_FILENAME));
            }

            await ApiUtils.CreateAndSendResponse(context, new ResponseMessage().Succeed().ToJson());
        }

    }
}
