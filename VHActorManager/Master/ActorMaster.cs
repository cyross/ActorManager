﻿using YamlDotNet.RepresentationModel;
using VHYAML;

namespace VHActorManager.Master
{
    public class ActorMaster : MasterBase
    {
        private const string DEFAULT_PATH = "actor_master.yaml";

        private const string SPEC_NAME = "Name";
        private const string SPEC_KANA = "Kana";
        private const string SPEC_ENGINES = "Engines";
        private const string SPEC_ANOTHER_NAMES = "AnotherNames";
        private const string SPEC_JIMAKU_ATTR = "JimakuAttr";
        private const string SPEC_ACTOR_ATTR = "ActorAttr";
        private const string ATTR_TEXT_COLOR = "TextColor";
        private const string ATTR_OUTLINE_COLOR = "OutlineColor";
        private const string ATTR_OUTLINE_WIDTH = "OutlineWidth";
        private const string SPEC_EXT_DATA = "ExtData";

        private List<ActorSpec> specs;
        private ActorSpec currentSpec;

        public ActorMaster(string fileName = DEFAULT_PATH): base(fileName){
            specs = new List<ActorSpec>();
        }

        public List<ActorSpec> Specs { get { return specs; } }

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
                case SPEC_NAME:
                    currentSpec.Name = GetString(node);
                    break;
                case SPEC_KANA:
                    currentSpec.Kana = GetString(node);
                    break;

            }
        }

        private void CbSclSeqDepth1MapDepth2(YamlScalarNode node)
        {
            switch(ParentKey)
            {
                case SPEC_JIMAKU_ATTR:
                    CbSclSeqDepth1MapDepth2Attr(node, ref currentSpec.JimakuAttr);
                    break;
                case SPEC_ACTOR_ATTR:
                    CbSclSeqDepth1MapDepth2Attr(node, ref currentSpec.ActorAttr);
                    break;
                case SPEC_EXT_DATA:
                    currentSpec.ExtData[CurrentKey] = GetString(node);
                    break;
            }
        }

        private void CbSclSeqDepth1MapDepth2Attr(YamlScalarNode node, ref TextAttr attr)
        {
            switch (CurrentKey)
            {
                case ATTR_TEXT_COLOR:
                    attr.TextColor = GetColor(node);
                    break;
                case ATTR_OUTLINE_COLOR:
                    attr.OutlineColor = GetColor(node);
                    break;
                case ATTR_OUTLINE_WIDTH:
                    attr.OutlineWidth = GetDouble(node);
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
                    Engines = new List<string>(),
                    AnotherNames = new List<string>(),
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
            if(YamlManager.MapDepth == 2)
            {
                CbMapSDepth2(node);
            }
        }

        private void CbMapSDepth2(YamlMappingNode node)
        {
            switch(CurrentKey)
            {
                case SPEC_JIMAKU_ATTR:
                    currentSpec.JimakuAttr = new TextAttr();
                    break;
                case SPEC_ACTOR_ATTR:
                    currentSpec.ActorAttr = new TextAttr();
                    break;
            }
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