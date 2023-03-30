using Grapevine;
using VHActorManager.Master;
using VHActorManager.Specs;

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

            SaveVHYAML();

            await ApiUtils.CreateAndSendResponse(context, ResponseData.SucceedResponse().ToJson());
        }

        [RestRoute("Get", "/SaveVH")]
        public async Task SaveVH(IHttpContext context)
        {
            SaveVHYAML();

            await ApiUtils.CreateAndSendResponse(context, ResponseData.SucceedResponse().ToJson());
        }

        private void SaveVHYAML()
        {
            User user = User.Instance();

            string scriptPath = user.VegasScriptYAML.ScriptPath;

            if (user.VegasScriptYAML.Enable && Path.Exists(scriptPath))
            {
                ActorMaster.Instance().SaveToVHYAMLActorColor((Utility.CombineFilePath(scriptPath, VSHelperColorSpec.JIMAKU_COLORS_FILENAME)));
                ActorMaster.Instance().SaveToVHYAMLOutlineColor((Utility.CombineFilePath(scriptPath, VSHelperColorSpec.OUTLINE_COLORS_FILENAME)));
            }

            string extPath = user.VegasScriptYAML.ExtPath;

            if (user.VegasScriptYAML.Enable && Path.Exists(extPath))
            {
                ActorMaster.Instance().SaveToVHYAMLActorColor((Utility.CombineFilePath(extPath, VSHelperColorSpec.JIMAKU_COLORS_FILENAME)));
                ActorMaster.Instance().SaveToVHYAMLOutlineColor((Utility.CombineFilePath(extPath, VSHelperColorSpec.OUTLINE_COLORS_FILENAME)));
            }
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
                RevertVHYAMLFile(VSHelperColorSpec.JIMAKU_COLORS_FILENAME, scriptPath);
                RevertVHYAMLFile(VSHelperColorSpec.OUTLINE_COLORS_FILENAME, scriptPath);
            }

            string extPath = user.VegasScriptYAML.ExtPath;

            if (user.VegasScriptYAML.Enable && Path.Exists(extPath))
            {
                RevertVHYAMLFile(VSHelperColorSpec.JIMAKU_COLORS_FILENAME, extPath);
                RevertVHYAMLFile(VSHelperColorSpec.OUTLINE_COLORS_FILENAME, extPath);
            }

            await ApiUtils.CreateAndSendResponse(context, ResponseData.SucceedResponse().ToJson());
        }

        private string GetOrgMasterYAMLPath(string fileName)
        {
            return Utility.ExecFilepath(Utility.CombineFilePath(MasterBase.ORG_MASTER_FILE_DIR, fileName));

        }

        private void RevertVHYAMLFile(string fileName, string dst_dir)
        {
            string org_path = GetOrgMasterYAMLPath(fileName);
            string new_path = Utility.CombineFilePath(dst_dir, fileName);
            System.IO.File.Copy(org_path, new_path, true);
        }

        private void RevertYAMLFile(string fileName)
        {
            string org_path = GetOrgMasterYAMLPath(fileName);
            string new_path = Utility.ExecFilepath(fileName);
            System.IO.File.Copy(org_path, new_path, true);
        }
    }
}
