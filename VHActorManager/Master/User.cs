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
        internal VHYamlSpec VegasScriptYAML;
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
        }

        public void Save(string? path = null)
        {
            Save(this, path);
        }

        private void CbScl(YamlScalarNode node)
        {
            switch (YamlManager.MapDepth)
            {
                case 2:
                    CbSclDepth2(node);
                    break;
            }
        }

        private void CbSclDepth2(YamlScalarNode node)
        {
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
            switch (CurrentKey)
            {
                case VSY_ENABLE:
                    VegasScriptYAML.Enable = GetBool(node);
                    break;
                case VSY_SCRIPT_PATH:
                    VegasScriptYAML.ScriptPath = GetString(node);
                    break;
                case VSY_EXT_PATH:
                    VegasScriptYAML.ExtPath = GetString(node);
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
