using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHActorManager.Specs
{
    public class VSHelperColorSpec
    {
        public const string JIMAKU_COLORS_FILENAME = "VoiceActorColors.yaml";
        public const string OUTLINE_COLORS_FILENAME = "VoiceActorOutlineColors.yaml";

        public Dictionary<string, string> ColorSpecs { get; set; }

        public VSHelperColorSpec() {
            ColorSpecs = new Dictionary<string, string>();
        }

        public void SetColor(string name, string color)
        {
            if (color[0] == '#')
            {
                string r = color.Substring(1, 2);
                string g = color.Substring(3, 2);
                string b = color.Substring(5, 2);
                ColorSpecs[name] = string.Format("{0},{1},{2}", Convert.ToInt32(r, 16), Convert.ToInt32(g, 16), Convert.ToInt32(b, 16));
            }
            else
            {
                // named color
                ColorSpecs[name] = color;
            }
        }
    }
}
