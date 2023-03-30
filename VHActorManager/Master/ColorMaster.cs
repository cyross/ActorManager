using YamlDotNet.RepresentationModel;
using VHActorManager.Specs;

namespace VHActorManager.Master
{
    internal class ColorMaster: MasterBase
    {
        public const string YAML_FILENAME = "color_master.yaml";

        private static ColorMaster? _instance;

        private const string SPEC_ID = "Id";
        private const string SPEC_NAME = "Name";
        private const string SPEC_HEX = "Hex";
        private const string SPEC_TYPE = "Type";
        private const string SPEC_R = "R";
        private const string SPEC_G = "G";
        private const string SPEC_B = "B";

        private const string ID_PREFIX = "色ID";

        private readonly List<ColorSpec> specs;

        private ColorSpec currentSpec;

        internal static ColorMaster Instance(string fileName = YAML_FILENAME)
        {
            _instance ??= new ColorMaster(fileName);

            return _instance;
        }

        public ColorMaster(string fileName = YAML_FILENAME) : base(fileName)
        {
            specs = new List<ColorSpec>();
            currentSpec = new ColorSpec();
        }

        internal List<ColorSpec> Specs { get { return specs; } }

        public override string NameListToJson()
        {
            return ColorNameListToJson<ColorSpec, ColorNameListElement>(specs);
        }

        public override string SpecsToJson()
        {
            return SpecsToJson<ColorSpec>(specs);
        }

        public override string SpecToJson(string indexParam)
        {
            return SpecToJson<ColorSpec>(indexParam, specs, ID_PREFIX);
        }

        public override string SpecFromJson(string json)
        {
            return SpecFromJson<ColorSpec>(json, specs, ref MaxSpecId);
        }

        public override string SpecFromJson(string indexParam, string json)
        {
            return SpecFromJson<ColorSpec>(indexParam, json, specs, ID_PREFIX);
        }

        public override string DeleteSpec(string indexParam)
        {
            return DeleteSpec<ColorSpec>(indexParam, specs, ID_PREFIX);
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
        }

        public void Reload(string? path = null)
        {
            specs.Clear();
            MaxSpecId = 0;

            base.Load(path);

            AttachSpecId();
        }

        public void Save(string? path = null)
        {
            Save(specs, path);
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

        private void CbScl(YamlScalarNode node)
        {
            switch (YamlManager.SeqDepth)
            {
                case 1:
                    CbSclSeqDepth1(node);
                    break;
            }
        }

        private void CbSclSeqDepth1(YamlScalarNode node)
        {
            switch (YamlManager.MapDepth)
            {
                case 1:
                    CbSclSeqDepth1MapDepth1(node);
                    break;
            }
        }

        private void CbSclSeqDepth1MapDepth1(YamlScalarNode node)
        {
            switch (CurrentKey)
            {
                case SPEC_ID:
                    currentSpec.Id = GetInt(node);
                    if (currentSpec.Id > MaxSpecId) { MaxSpecId = currentSpec.Id; }
                    break;
                case SPEC_NAME:
                    currentSpec.Name = GetString(node);
                    break;
                case SPEC_HEX:
                    currentSpec.Hex = GetString(node);
                    break;
                case SPEC_TYPE:
                    currentSpec.Type = GetInt(node);
                    break;
                case SPEC_R:
                    currentSpec.R = GetByte(node);
                    break;
                case SPEC_G:
                    currentSpec.G = GetByte(node);
                    break;
                case SPEC_B:
                    currentSpec.B = GetByte(node);
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
            if (YamlManager.SeqDepth == 1)
            {
                currentSpec = new ColorSpec()
                {
                    Id = 0,
                    Name = "",
                    Hex = "#000000",
                    Type = (int)ColorType.RGB
                };
            }
        }

        private void CbSeqLE(YamlSequenceNode node)
        {
            if (YamlManager.SeqDepth == 1)
            {
                specs.Add(currentSpec);
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
