using YamlDotNet.RepresentationModel;
using System.Text.Json;

namespace VHActorManager.Master
{
    public class VoiceEngineMaster: MasterBase
    {
        public const string YAML_FILENAME = "voice_engine_master.yaml";

        private static VoiceEngineMaster? _instance;

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

        private readonly List<VoiceEngineSpec> specs;
        private readonly Dictionary<string, List<SanitizeRegexpStruct>> sanitizers;
        private readonly List<string> noneVoiceEngines;
        private readonly List<string> separateActorEngines;

        private VoiceEngineSpec currentSpec;
        private SanitizeRegexpStruct currentSanitize;

        public static VoiceEngineMaster Instance(string fileName = YAML_FILENAME)
        {
            _instance ??= new VoiceEngineMaster(fileName);

            return _instance;
        }

        public VoiceEngineMaster(string fileName = YAML_FILENAME) : base(fileName) {
            specs = new List<VoiceEngineSpec>();
            sanitizers = new Dictionary<string, List<SanitizeRegexpStruct>>();
            noneVoiceEngines = new List<string>();
            separateActorEngines = new List<string>();
            currentSanitize = new SanitizeRegexpStruct();
        }

        public VoiceEngineSpec[] Specs { get { return specs.ToArray(); } }
        public Dictionary<string, List<SanitizeRegexpStruct>> SanitizeRegexp { get { return sanitizers; } }
        public List<string> NoneVoiceEngines { get { return noneVoiceEngines; } }
        public List<string> SeparateActorEngines { get { return separateActorEngines; } }

        public override string NameListToJson()
        {
            List<NameListElement> names = new();

            for (int i = 0; i < specs.Count; i++)
            {
                NameListElement nameElement = new()
                {
                    Id = i,
                    Name = specs[i].Name
                };
                names.Add(nameElement);
            }

            return JsonSerializer.Serialize(names);
        }

        public override string SpecsToJson()
        {
            return JsonSerializer.Serialize(specs);
        }

        public override string SpecToJson(string indexParam)
        {
            if (!int.TryParse(indexParam, out int index)) { return ResponseIllegalParamaterError(); }

            if (index < 0 || index >= specs.Count) { return ResponseOutOfIndexError(ID_PREFIX); }

            return JsonSerializer.Serialize(specs[index]);
        }

        public override string SpecsFromJson(string json)
        {
            VoiceEngineSpec? spec = JsonSerializer.Deserialize<VoiceEngineSpec>(json);

            if (spec == null) { return ResponseIllegalRequestDataError(); }

            specs.Add((VoiceEngineSpec)spec);

            return ResponseSucceed();
        }

        public override string SpecFromJson(string indexParam, string json)
        {
            if (!int.TryParse(indexParam, out int index)) { return ResponseIllegalParamaterError(); }

            if (index < 0 || index >= specs.Count) { return ResponseOutOfIndexError(ID_PREFIX); }

            VoiceEngineSpec? spec = JsonSerializer.Deserialize<VoiceEngineSpec>(json);

            if (spec == null) { return ResponseIllegalRequestDataError(); }

            specs[index] = (VoiceEngineSpec)spec;

            return ResponseSucceed();
        }

        public override string DeleteSpec(string indexParam)
        {
            if (!int.TryParse(indexParam, out int index)) { return ResponseIllegalParamaterError(); }

            if (index < 0 || index >= specs.Count) { return ResponseOutOfIndexError(ID_PREFIX); }

            specs.RemoveAt(index);

            return ResponseSucceed();
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
            // IDカラムが存在していないときのために、ID振り直し
            for (int i = 0; i < specs.Count; i++)
            {
                if (specs[i].Id != 0) { continue; }

                specs[i] = specs[i].Duplicate(MaxSpecId++);
            }
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
                sanitizers[CurrentKey] = new List<SanitizeRegexpStruct>();
            }
        }

        private void CbSeqLS(YamlSequenceNode node)
        {
            if (YamlManager.MapDepth == 1 && CurrentKey == SPEC_KEY)
            {
                currentSpec = new VoiceEngineSpec()
                {
                    Id = 0,
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
