using YamlDotNet.RepresentationModel;
using VHActorManager.Specs;

namespace VHActorManager.Master
{
    public class VEMaster: MasterBase
    {
        public const string YAML_FILENAME = "voice_engine_master.yaml";

        private static VEMaster? _instance;

        private const string SPEC_KEY = "Specs";
        private const string SPEC_ID = "Id";
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

        private const string ID_PREFIX = "音声合成エンジンID";

        private readonly List<VESpec> specs;
        private readonly Dictionary<string, List<SanitizeRESpec>> sanitizers;
        private readonly List<string> noneVoiceEngines;
        private readonly List<string> separateActorEngines;

        private VESpec currentSpec;
        private SanitizeRESpec currentSanitize;

        private int maxSanId;

        internal static VEMaster Instance(string fileName = YAML_FILENAME)
        {
            _instance ??= new VEMaster(fileName);

            return _instance;
        }

        private VEMaster(string fileName = YAML_FILENAME) : base(fileName) {
            specs = new List<VESpec>();
            currentSpec = new VESpec();
            sanitizers = new Dictionary<string, List<SanitizeRESpec>>();
            noneVoiceEngines = new List<string>();
            separateActorEngines = new List<string>();
            currentSanitize = new SanitizeRESpec();
            maxSanId = 0;
        }

        internal VESpec[] Specs { get { return specs.ToArray(); } }
        internal Dictionary<string, List<SanitizeRESpec>> SanitizeRegexp { get { return sanitizers; } }
        public List<string> NoneVoiceEngines { get { return noneVoiceEngines; } }
        public List<string> SeparateActorEngines { get { return separateActorEngines; } }

        public override string NameListToJson()
        {
            return NameListToJson<VESpec, NameListElement>(specs);
        }

        public override string SpecsToJson()
        {
            return SpecsToJson<VESpec>(specs);
        }

        public override string SpecToJson(string paramId)
        {
            return SpecToJson<VESpec>(paramId, specs, ID_PREFIX);
        }

        public override string SpecFromJson(string json)
        {
            return SpecFromJson<VESpec>(json, specs, ref MaxSpecId);
        }

        public override string SpecFromJson(string paramId, string json)
        {
            return SpecFromJson<VESpec>(paramId, json, specs, ID_PREFIX);
        }

        public override string DeleteSpec(string paramId)
        {
            return DeleteSpec<VESpec>(paramId, specs, ID_PREFIX);
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

            // IDカラムが存在していないときのために、ID振り直し
            AttachSpecId();
            AttachSanSpecId();
        }

        public void Reload(string? path = null)
        {
            specs.Clear();
            sanitizers.Clear();
            noneVoiceEngines.Clear();
            separateActorEngines.Clear();
            MaxSpecId = 0;

            base.Load(path);

            AttachSpecId();
            AttachSanSpecId();
        }

        public void Save(string? path = null)
        {
            Save(this, path);
        }

        private void AttachSpecId()
        {
            // IDカラムが存在していないときのために、ID振り直し
            for (int i = 0; i < specs.Count; i++)
            {
                if (specs[i].Id != -1) { continue; }

                specs[i] = specs[i].Duplicate(MaxSpecId++);
            }
        }

        private void AttachSanSpecId()
        {
            foreach (var sanReKey in sanitizers.Keys)
            {
                List<SanitizeRESpec> sanSpecs = sanitizers[sanReKey];

                for (int i = 0; i < sanSpecs.Count; i++)
                {
                    if (sanSpecs[i].Id != -1) { continue; }

                    sanSpecs[i] = sanSpecs[i].Duplicate(maxSanId++);
                }
            }
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
                case SPEC_ID:
                    currentSpec.Id = GetInt(node);
                    if (currentSpec.Id > MaxSpecId) { MaxSpecId = currentSpec.Id; }
                    break;
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
                sanitizers[CurrentKey] = new List<SanitizeRESpec>();
            }
        }

        private void CbSeqLS(YamlSequenceNode node)
        {
            if (YamlManager.MapDepth == 1 && CurrentKey == SPEC_KEY)
            {
                currentSpec = new VESpec()
                {
                    Id = 0,
                    ExtData = new Dictionary<string, string>()
                };
            }
            else if (YamlManager.MapDepth == 2 && YamlManager.SeqDepth == 1 && ParentKey == SANITIZE_KEY)
            {
                currentSanitize = new SanitizeRESpec();
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
