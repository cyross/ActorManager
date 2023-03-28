using YamlDotNet.RepresentationModel;
using System.Text.Json;

namespace VHActorManager.Master
{
    internal class ColorMaster: MasterBase
    {
        public const string YAML_FILENAME = "color_master.yaml";

        private static ColorMaster? _instance;

        private const string SPEC_NAME = "Name";
        private const string SPEC_HEX = "Hex";
        private const string SPEC_TYPE = "Type";
        private const string SPEC_R = "R";
        private const string SPEC_G = "G";
        private const string SPEC_B = "B";

        private const string ID_PREFIX = "色ID";

        private readonly List<ColorSpec> specs;
        private ColorSpec currentSpec;

        public static ColorMaster Instance(string fileName = YAML_FILENAME)
        {
            _instance ??= new ColorMaster(fileName);

            return _instance;
        }

        public ColorMaster(string fileName = YAML_FILENAME) : base(fileName)
        {
            specs = new List<ColorSpec>();
        }

        public List<ColorSpec> Specs { get { return specs; } }

        public override string NameListToJson()
        {
            List<ColorNameListElement> names = new List<ColorNameListElement>();

            for (int i = 0; i < specs.Count; i++)
            {
                ColorNameListElement nameElement = new ColorNameListElement()
                {
                    Id = i,
                    Name = specs[i].Name,
                    Hex = specs[i].Hex
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
            ColorSpec? spec = JsonSerializer.Deserialize<ColorSpec>(json);

            if (spec == null) { return ResponseIllegalRequestDataError(); }

            specs.Add((ColorSpec)spec);

            return ResponseSucceed();
        }

        public override string SpecFromJson(string indexParam, string json)
        {
            if (!int.TryParse(indexParam, out int index)) { return ResponseIllegalParamaterError(); }

            if (index < 0 || index >= specs.Count) { return ResponseOutOfIndexError(ID_PREFIX); }

            ColorSpec? spec = JsonSerializer.Deserialize<ColorSpec>(json);

            if (spec == null) { return ResponseIllegalRequestDataError(); }

            specs[index] = (ColorSpec)spec;

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
        }

        public void Save(string? path = null)
        {
            Save(specs, path);
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
                currentSpec.Hex = currentSpec.ToHex();
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
