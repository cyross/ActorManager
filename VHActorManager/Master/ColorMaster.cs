using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;

namespace VHActorManager.Master
{
    internal class ColorMaster: MasterBase
    {
        private const string DEFAULT_PATH = "color_master.yaml";

        private const string SPEC_NAME = "Name";
        private const string SPEC_HEX = "Hex";
        private const string SPEC_TYPE = "Type";
        private const string SPEC_R = "R";
        private const string SPEC_G = "G";
        private const string SPEC_B = "B";

        private List<ColorSpec> specs;
        private ColorSpec currentSpec;

        public ColorMaster(string fileName = DEFAULT_PATH) : base(fileName)
        {
            specs = new List<ColorSpec>();
        }

        public List<ColorSpec> Specs { get { return specs; } }

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
                    currentSpec.Hex = GetString(node);
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
                    Type = ColorType.RGB
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
