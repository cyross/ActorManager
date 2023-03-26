using System.Drawing;

namespace VHActorManager
{
    public struct ServerSpec
    {
        public int Port;
    }

    public struct VHYamlSpec
    {
        public bool Enable;
        public string Path;
    }

    public struct VoiceEngineStruct
    {
        public string Name;
        public string RealName;
        public string Separator;
        public string Encoding;
        public Dictionary<string, string> ExtData;
    }

    public struct SanitizeRegexpStruct
    {
        public string Pattern;
        public string Sub;
    }

    public struct TextAttr
    {
        public Color TextColor;
        public Color OutlineColor;
        public double OutlineWidth;
    }

    public struct ActorSpec
    {
        public string Name;
        public string Kana;
        public List<string> Engines;
        public List<string> AnotherNames;
        public TextAttr JimakuAttr;
        public TextAttr ActorAttr;
        public Dictionary<string, string> ExtData;
    }

    public struct ColorSpec
    {
        public string Name;
        public string Hex;
        public ColorType Type;
        public byte R;
        public byte G;
        public byte B;
        public string ToHex()
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);
        }
    }
}
