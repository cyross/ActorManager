using YamlDotNet.RepresentationModel;
using System.Text.Json;
using System.ComponentModel;
using System.Collections.Generic;
using VHActorManager.Specs;

namespace VHActorManager.Master
{
    public class ActorMaster : MasterBase
    {
        public const string YAML_FILENAME = "actor_master.yaml";

        private static ActorMaster? _instance;

        private const string SPEC_ID = "Id";
        private const string SPEC_NAME = "Name";
        private const string SPEC_KANA = "Kana";
        private const string SPEC_ENGINES = "Engines";
        private const string SPEC_ANOTHER_NAMES = "AnotherNames";
        private const string SPEC_JIMAKU_TEXT_COLOR = "JimakuTextColor";
        private const string SPEC_JIMAKU_OUTLINE_COLOR = "JimakuOutlineColor";
        private const string SPEC_JIMAKU_OUTLINE_WIDTH = "JimakuOutlineWidth";
        private const string SPEC_ACTOR_TEXT_COLOR = "ActorTextColor";
        private const string SPEC_ACTOR_OUTLINE_COLOR = "ActorOutlineColor";
        private const string SPEC_ACTOR_OUTLINE_WIDTH = "ActorOutlineWidth";
        private const string SPEC_EXT_DATA = "ExtData";

        private const string ID_PREFIX = "声優ID";

        private readonly List<ActorSpec> specs;

        private ActorSpec currentSpec;

        internal static ActorMaster Instance(string fileName = YAML_FILENAME)
        {
            _instance ??= new ActorMaster(fileName);

            return _instance;
        }

        private ActorMaster(string fileName = YAML_FILENAME) : base(fileName){
            specs = new List<ActorSpec>();
            currentSpec = new ActorSpec();
        }

        internal List<ActorSpec> Specs { get { return specs; } }

        public override string NameListToJson() {
            List<NameListElement> names = new();

            foreach(var spec in specs)
            {
                NameListElement nameElement = new()
                {
                    Id = spec.Id,
                    Name = spec.Name
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
            string result = FindIndexFromSpecs(specs, indexParam, ID_PREFIX, out int targetIndex);

            if (targetIndex == -1) { return result; }

            return JsonSerializer.Serialize(specs[targetIndex]);
        }

        public override string SpecsFromJson(string json)
        {
            ActorSpec? spec = JsonSerializer.Deserialize<ActorSpec>(json);

            if(spec == null) { return ResponseIllegalRequestDataError(); }

            specs.Add((ActorSpec)spec);

            return ResponseSucceed();
        }

        public override string SpecFromJson(string indexParam, string json)
        {
            string result = FindIndexFromSpecs(specs, indexParam, ID_PREFIX, out int targetIndex);

            if (targetIndex == -1) { return result; }

            ActorSpec? spec = JsonSerializer.Deserialize<ActorSpec>(json);

            if (spec == null) { return ResponseIllegalRequestDataError(); }

            specs[targetIndex] = (ActorSpec)spec;

            return ResponseSucceed();
        }

        public override string DeleteSpec(string indexParam)
        {
            string result = FindIndexFromSpecs(specs, indexParam, ID_PREFIX, out int targetIndex);

            if (targetIndex == -1) { return result; }

            specs.RemoveAt(targetIndex);

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
            attachSpecId();
        }

        public void Reload(string? path = null)
        {
            specs.Clear();
            MaxSpecId = 0;

            base.Load(path);

            attachSpecId();
        }

        public void Save(string? path = null)
        {
            Save(specs, path);
        }

        private void attachSpecId()
        {
            for (int i = 0; i < specs.Count; i++)
            {
                if (specs[i].Id != -1) { continue; }

                specs[i] = specs[i].Duplicate(MaxSpecId++);
            }
        }

        private void CbScl(YamlScalarNode node)
        {
            switch(YamlManager.SeqDepth)
            {
                case 1:
                    CbSclSeqDepth1(node);
                    break;
                case 2:
                    CbSclSeqDepth2(node);
                    break;
            }
        }

        private void CbSclSeqDepth1(YamlScalarNode node)
        {
            switch(YamlManager.MapDepth)
            {
                case 1:
                    CbSclSeqDepth1MapDepth1(node);
                    break;
                case 2:
                    CbSclSeqDepth1MapDepth2(node);
                    break;
            }
        }

        private void CbSclSeqDepth1MapDepth1(YamlScalarNode node)
        {
            switch(CurrentKey)
            {
                case SPEC_ID:
                    currentSpec.Id = GetInt(node);
                    if(currentSpec.Id > MaxSpecId) { MaxSpecId = currentSpec.Id; }
                    break;
                case SPEC_NAME:
                    currentSpec.Name = GetString(node);
                    break;
                case SPEC_KANA:
                    currentSpec.Kana = GetString(node);
                    break;
                case SPEC_JIMAKU_TEXT_COLOR:
                    currentSpec.JimakuTextColor = GetString(node);
                    break;
                case SPEC_JIMAKU_OUTLINE_COLOR:
                    currentSpec.JimakuOutlineColor = GetString(node);
                    break;
                case SPEC_JIMAKU_OUTLINE_WIDTH:
                    currentSpec.JimakuOutlineWidth = GetDouble(node);
                    break;
                case SPEC_ACTOR_TEXT_COLOR:
                    currentSpec.ActorTextColor = GetString(node);
                    break;
                case SPEC_ACTOR_OUTLINE_COLOR:
                    currentSpec.ActorOutlineColor = GetString(node);
                    break;
                case SPEC_ACTOR_OUTLINE_WIDTH:
                    currentSpec.ActorOutlineWidth = GetDouble(node);
                    break;
            }
        }
        public string ToHex(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        private void CbSclSeqDepth1MapDepth2(YamlScalarNode node)
        {
            switch(ParentKey)
            {
                case SPEC_EXT_DATA:
                    currentSpec.ExtData[CurrentKey] = GetString(node);
                    break;
            }
        }

        private void CbSclSeqDepth2(YamlScalarNode node)
        {
            switch (YamlManager.MapDepth)
            {
                case 1:
                    CbSclSeqDepth2MapDepth1(node);
                    break;
                case 2:
                    break;
            }
        }

        private void CbSclSeqDepth2MapDepth1(YamlScalarNode node)
        {
            switch(CurrentKey)
            {
                case SPEC_ENGINES:
                    currentSpec.Engines.Add(GetString(node));
                    break;
                case SPEC_ANOTHER_NAMES:
                    currentSpec.AnotherNames.Add(GetString(node));
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
            if(YamlManager.SeqDepth == 1)
            {
                currentSpec = new ActorSpec()
                {
                    Id = 0,
                    Engines = new List<string>(),
                    AnotherNames = new List<string>(),
                    JimakuTextColor = "White",
                    JimakuOutlineColor = "Black",
                    JimakuOutlineWidth = 10,
                    ActorTextColor = "White",
                    ActorOutlineColor = "Black",
                    ActorOutlineWidth = 10,
                    ExtData = new Dictionary<string, string>()
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
