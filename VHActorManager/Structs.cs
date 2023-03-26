using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VHActorManager
{
    public struct ServerSpec
    {
        public int Port { get; set; }
        public bool OpenBrowser { get; set; }
    }

    public struct VHYamlSpec
    {
        public bool Enable { get; set; }
        public string Path { get; set; }
    }

        public struct VoiceEngineStruct
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Separator { get; set; }
        public string Encoding { get; set; }
        public Dictionary<string, string> ExtData { get; set; }
    }

    public struct SanitizeRegexpStruct
    {
        public string Pattern { get; set; }
        public string Sub { get; set; }
    }

    public struct TextAttr
    {
        public Color TextColor { get; set; }
        public Color OutlineColor { get; set; }
        public double OutlineWidth { get; set; }
    }

    public struct ActorSpec
    {
        public string Name { get; set; }
        public string Kana { get; set; }
        public List<string> Engines { get; set; }
        public List<string> AnotherNames { get; set; }
        public TextAttr JimakuAttr;
        public TextAttr ActorAttr;
        public Dictionary<string, string> ExtData { get; set; }
    }

    public struct ColorSpec
    {
        public string Name { get; set; }
        public string Hex { get; set; }
        public int Type { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public string ToHex()
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);
        }
    }

    public struct ResponseMessage
    {
        public ResultStatus Status { get; set; }
        public string Message { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        private ResponseMessage Set(ResultStatus st, string msg)
        {
            Status = st;
            Message = msg;
            return this;
        }

        public ResponseMessage None()
        {
            return Set(ResultStatus.NONE, "None");
        }

        public ResponseMessage Succeed()
        {
            return Set(ResultStatus.OK, "Succeed");
        }

        public ResponseMessage Warning(string msg)
        {
            return Set(ResultStatus.WARNING, msg);
        }

        public ResponseMessage Error(string msg)
        {
            return Set(ResultStatus.ERROR, msg);
        }

        public ResponseMessage Fatal(string msg)
        {
            return Set(ResultStatus.FATAL, msg);
        }
    }

    public struct NameListElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
