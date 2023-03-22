using YamlDotNet.RepresentationModel;
using VHYAML;
using System.Diagnostics;

namespace VHActorManager.Master
{
    public class User: MasterBase
    {
        private const string DEFAULT_FILE = "user.yaml";
        private const string MASTER_FILEPATH = "MasterFilepath";
        private const string SERVER_KEY = "Server";
        private const string SERVER_PORT = "Port";
        private const string VSY_KEY = "VegasScriptYAML";
        private const string VSY_ENABLE = "Enable";
        private const string VSY_PATH = "Path";
        private const string EXT_DATA = "ExtData";

        private string master_filepath;
        public ServerSpec Server;
        public VHYamlSpec VHYaml;
        public Dictionary<string, string> ExtData;

        public string MasterFilepath {
            get { return master_filepath; }
            set { master_filepath = value; }
        }

        public User(string fileName = DEFAULT_FILE): base(fileName)
        {
            master_filepath = "";
            Server = new ServerSpec()
            {
                Port = 3300
            };
            VHYaml = new VHYamlSpec()
            {
                Enable = false,
                Path = ""
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
                case 1:
                    CbSclDepth1(node);
                    break;
                case 2:
                    CbSclDepth2(node);
                    break;
            }
        }

        private void CbSclDepth1(YamlScalarNode node)
        {
            switch (CurrentKey)
            {
                case MASTER_FILEPATH:
                    master_filepath = GetString(node);
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
            }
        }

        private void CbSclDepth2VSY(YamlScalarNode node)
        {
            switch (CurrentKey)
            {
                case VSY_ENABLE:
                    VHYaml.Enable = GetBool(node);
                    break;
                case VSY_PATH:
                    VHYaml.Path = GetString(node);
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
