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

        [RestRoute("Get", "/ResetAll")]
        public async Task ResetAll(IHttpContext context)
        {
            User user = User.Instance();

            RevertYAMLFile(ActorMaster.YAML_FILENAME);
            RevertYAMLFile(VEMaster.YAML_FILENAME);
            RevertYAMLFile(ColorMaster.YAML_FILENAME);

            ActorMaster.Instance().Reload();
            VEMaster.Instance().Reload();
            ColorMaster.Instance().Reload();

            string scriptPath = user.VegasScriptYAML.ScriptPath;

            if (user.VegasScriptYAML.Enable && Path.Exists(scriptPath))
            {
                ReplaceYAMLFile(scriptPath, ActorMaster.YAML_FILENAME);
                ReplaceYAMLFile(scriptPath, VEMaster.YAML_FILENAME);
                ReplaceYAMLFile(scriptPath, ColorMaster.YAML_FILENAME);
            }

            string extPath = user.VegasScriptYAML.ExtPath;

            if (user.VegasScriptYAML.Enable && Path.Exists(extPath))
            {
                ReplaceYAMLFile(extPath, ActorMaster.YAML_FILENAME);
                ReplaceYAMLFile(extPath, VEMaster.YAML_FILENAME);
                ReplaceYAMLFile(extPath, ColorMaster.YAML_FILENAME);
            }

            await ApiUtils.CreateAndSendResponse(context, new ResponseMessage().Succeed().ToJson());
        }

        private string GetOrgMasterYAMLPath(string fileName)
        {
            return Utility.ExecFilepath(Utility.CombineFilePath(MasterBase.ORG_MASTER_FILE_DIR, fileName));

        }

        private void ReplaceYAMLFile(string fileName, string dst_dir)
        {
            System.IO.File.Copy(GetOrgMasterYAMLPath(fileName), Utility.CombineFilePath(dst_dir, fileName));
        }

        private void RevertYAMLFile(string fileName)
        {
            System.IO.File.Copy(GetOrgMasterYAMLPath(fileName), Utility.ExecFilepath(fileName));
        }
    }
}
