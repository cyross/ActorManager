using YamlDotNet.RepresentationModel;

namespace VHActorManager.Master
{
    public class VoiceEngineMaster: MasterBase
    {
        private const string DEFAULT_PATH = "voice_engine_master.yaml";

        private const string SPEC_KEY = "Spec";
        private const string SPEC_NAME = "Name";
        private const string SPEC_REAL_NAME = "RealName";
        private const string SPEC_SEPARATOR = "Separator";
        private const string SPEC_ENCODING = "Encoding";
        private const string SPEC_EXT_DATA = "ExtData";
        private const string SANITIZE_KEY = "SanitizeRegexp";
        private const string SANITIZE_PATTERN = "Pattern";
        private const string SANITIZE_SUB = "Sub";
        private const string NONES_KEY = "NoneVoiceEngines";
        private const string SEPS_KEY = "SeparateActorEngines";

        private List<VoiceEngineStruct> specs;
        private Dictionary<string, List<SanitizeRegexpStruct>> sanitizers;
        private List<string> noneVoiceEngines;
        private List<string> separateActorEngines;

        private VoiceEngineStruct currentSpec;
        private SanitizeRegexpStruct currentSanitize;

        public VoiceEngineMaster(string fileName = DEFAULT_PATH) : base(fileName) {
            specs = new List<VoiceEngineStruct>();
            sanitizers = new Dictionary<string, List<SanitizeRegexpStruct>>();
            noneVoiceEngines = new List<string>();
            separateActorEngines = new List<string>();
            currentSanitize = new SanitizeRegexpStruct();
        }

        public VoiceEngineStruct[] Specs { get { return specs.ToArray(); } }
        public Dictionary<string, List<SanitizeRegexpStruct>> SanitizeRegexp { get { return sanitizers; } }
        public List<string> NoneVoiceEngines { get { return noneVoiceEngines; } }
        public List<string> SeparateActorEngines { get { return separateActorEngines; } }

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
            switch(BaseKey)
            {
                case SPEC_KEY:
                    CbSclSpecs(node);
                    break;
                case SANITIZE_KEY:
                    CbSclSanitize(node);
                    break;
                case NONES_KEY:
                    noneVoiceEngines.Add(GetString(node));
                    break;
                case SEPS_KEY:
                    separateActorEngines.Add(GetString(node));
                    break;
            }
        }

        private void CbSclSpecs(YamlScalarNode node)
        {
            if(YamlManager.MapDepth == 3)
            {
                CbSclSpecsMapDepth3(node);
                return;
            }
            else if(YamlManager.MapDepth != 2) { return; }

            switch (CurrentKey)
            {
                case SPEC_NAME:
                    currentSpec.Name = GetString(node);
                    return;
                case SPEC_REAL_NAME:
                    currentSpec.RealName = GetString(node);
                    return;
                case SPEC_SEPARATOR:
                    currentSpec.Separator = GetString(node);
                    return;
                case SPEC_ENCODING:
                    currentSpec.Encoding = GetString(node);
                    return;
            }
        }

        private void CbSclSpecsMapDepth3(YamlScalarNode node)
        {
            switch (ParentKey)
            {
                case SPEC_EXT_DATA:
                    currentSpec.ExtData[CurrentKey] = GetString(node);
                    break;
            }
        }

        private void CbSclSanitize(YamlScalarNode node)
        {
            if (YamlManager.MapDepth != 3) { return; }

            switch (CurrentKey)
            {
                case SANITIZE_PATTERN:
                    currentSanitize.Pattern = GetString(node);
                    break;
                case SANITIZE_SUB:
                    currentSanitize.Sub = GetString(node);
                    break;
            }
        }

        private void CbKey(YamlScalarNode node)
        {
        }

        private void CbSeqS(YamlSequenceNode node)
        {
            if (YamlManager.MapDepth == 2 && YamlManager.SeqDepth == 1 && ParentKey == SANITIZE_KEY)
            {
                sanitizers[CurrentKey] = new List<SanitizeRegexpStruct>();
            }
        }

        private void CbSeqLS(YamlSequenceNode node)
        {
            if (YamlManager.MapDepth == 1 && CurrentKey == SPEC_KEY)
            {
                currentSpec = new VoiceEngineStruct()
                {
                    ExtData = new Dictionary<string, string>()
                };
            }
            else if (YamlManager.MapDepth == 2 && YamlManager.SeqDepth == 1 && ParentKey == SANITIZE_KEY)
            {
                currentSanitize = new SanitizeRegexpStruct();
            }
        }

        private void CbSeqLE(YamlSequenceNode node)
        {
            if (YamlManager.MapDepth == 1 && CurrentKey == SPEC_KEY)
            {
                specs.Add(currentSpec);
            }
            else if (YamlManager.MapDepth == 2 && YamlManager.SeqDepth == 1 && ParentKey == SANITIZE_KEY)
            {
                sanitizers[CurrentKey].Add(currentSanitize);
            }
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
