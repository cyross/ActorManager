using System.Diagnostics;
using YamlDotNet.RepresentationModel;

namespace VHActorManager.Master
{
    public class User: MasterBase
    {
        private static User? _instance;

        private const string DEFAULT_FILE = "user.yaml";
        private const string SERVER_KEY = "Server";
        private const string SERVER_PORT = "Port";
        private const string SERVER_OPEN_BROWSER = "OpenBrowser";
        private const string VSY_KEY = "VegasScriptYAML";
        private const string VSY_ENABLE = "Enable";
        private const string VSY_SCRIPT_PATH = "ScriptPath";
        private const string VSY_EXT_PATH = "ExtPath";
        private const string EXT_DATA = "ExtPath";

        public ServerSpec Server;
        public VHYamlSpec VegasScriptYAML;
        public Dictionary<string, string> ExtData;

        public static User Instance(string fileName = DEFAULT_FILE)
        {
            _instance ??= new User(fileName);

            return _instance;
        }

        public User(string fileName = DEFAULT_FILE): base(fileName)
        {
            Server = new ServerSpec()
            {
                Port = 3300,
                OpenBrowser = false
            };
            VegasScriptYAML = new VHYamlSpec()
            {
                Enable = false,
                ScriptPath = "",
                ExtPath = ""
            };
            ExtData = new Dictionary<string, string>();
        }

        public new void Load(string? path = null)
        {
            YamlManager.CallbackScalar += CbScl;
            YamlManager.CallbackKey += CbKey;
            YamlManager.CallbackSequenceStart += CbSeqS;
            YamlManager.CallbackSequenceLoopStart += CbSeqLS;
            YamlManager.CallbackSequenceLoopEnd += CbSeqLE;
            YamlManager.CallbackSequenceEnd += CbSeqE;
            YamlManager.CallbackMappingStart += CbMapS;
            YamlManager.CallbackMappingInnerStart += CbMapIS;
            YamlManager.CallbackMappingInnerEnd += CbMapIE;
            YamlManager.CallbackMappingEnd += CbMapE;
            base.Load(path);
            Debug.WriteLine(VegasScriptYAML.ScriptPath);
            Debug.WriteLine(VegasScriptYAML.ExtPath);
        }

        public void Save(string? path = null)
        {
            Save(this, path);
        }

        private void CbScl(YamlScalarNode node)
        {
            Debug.WriteLine(string.Format("CbScl DEPTH: {0}", YamlManager.MapDepth));
            switch (YamlManager.MapDepth)
            {
                case 2:
                    CbSclDepth2(node);
                    break;
            }
        }

        private void CbSclDepth2(YamlScalarNode node)
        {
            Debug.WriteLine(string.Format("CbSclDepth2 PARENT: {0}", ParentKey));
            switch (ParentKey)
            {
                case SERVER_KEY:
                    CbSclDepth2Server(node);
                    break;
                case VSY_KEY:
                    CbSclDepth2VSY(node);
                    break;
                case EXT_DATA:
                    ExtData[CurrentKey] = GetString(node);
                    break;
            }
        }

        private void CbSclDepth2Server(YamlScalarNode node)
        {
            Debug.WriteLine(string.Format("CbSclDepth2Server CURRENT: {0}", CurrentKey));
            switch (CurrentKey)
            {
                case SERVER_PORT:
                    Server.Port = GetInt(node);
                    break;
                case SERVER_OPEN_BROWSER:
                    Server.OpenBrowser = GetBool(node);
                    break;
            }
        }

        private void CbSclDepth2VSY(YamlScalarNode node)
        {
            Debug.WriteLine(string.Format("CbSclDepth2VSY CURRENT: {0}", CurrentKey));
            switch (CurrentKey)
            {
                case VSY_ENABLE:
                    VegasScriptYAML.Enable = GetBool(node);
                    Debug.WriteLine(VegasScriptYAML.Enable);
                    break;
                case VSY_SCRIPT_PATH:
                    VegasScriptYAML.ScriptPath = GetString(node);
                    Debug.WriteLine(VegasScriptYAML.ScriptPath);
                    break;
                case VSY_EXT_PATH:
                    VegasScriptYAML.ExtPath = GetString(node);
                    Debug.WriteLine(VegasScriptYAML.ExtPath);
                    break;
            }
        }

        private void CbKey(YamlScalarNode node)
        {
        }

        private void CbSeqS(YamlSequenceNode node)
        {
        }

        private void CbSeqLS(YamlSequenceNode node)
        {
        }

        private void CbSeqLE(YamlSequenceNode node)
        {
        }

        private void CbSeqE(YamlSequenceNode node)
        {
        }

        private void CbMapS(YamlMappingNode node)
        {
        }

        private void CbMapIS(YamlMappingNode node)
        {
        }

        private void CbMapIE(YamlMappingNode node)
        {
        }

        private void CbMapE(YamlMappingNode node)
        {
        }
    }
}
