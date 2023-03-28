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
        public string ScriptPath { get; set; }
        public string ExtPath { get; set; }
    }

    public struct VoiceEngineSpec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Separator { get; set; }
        public string Encoding { get; set; }
        public Dictionary<string, string> ExtData { get; set; }

        public VoiceEngineSpec Duplicate(
            int? id = null,
            string? name = null,
            string? real_name = null,
            string? separator = null,
            string? encoding = null,
            Dictionary<string, string>? ext_data = null
            )
        {
            return new VoiceEngineSpec()
            {
                Id = id ?? this.Id,
                Name = name ?? this.Name,
                RealName = real_name ?? this.RealName,
                Separator = separator ?? this.Separator,
                Encoding = encoding ?? this.Encoding,
                ExtData = ext_data ?? this.ExtData
            };
        }
    }

    public struct SanitizeRegexpStruct
    {
        public string Pattern { get; set; }
        public string Sub { get; set; }

        public SanitizeRegexpStruct Duplicate(
            string? pattern = null,
            string? sub = null
            )
        {
            return new SanitizeRegexpStruct()
            {
                Pattern = pattern ?? this.Pattern,
                Sub = sub ?? this.Sub
            };
        }
    }

    public struct TextAttr
    {
        public Color TextColor { get; set; }
        public Color OutlineColor { get; set; }
        public double OutlineWidth { get; set; }

        public TextAttr Duplicate(
            Color? text_color = null,
            Color? outline_color = null,
            double? outline_width = null
            )
        {
            return new TextAttr()
            {
                TextColor = text_color ?? this.TextColor,
                OutlineColor = outline_color ?? this.OutlineColor,
                OutlineWidth = outline_width ?? this.OutlineWidth
            };
        }
    }

    public struct ActorSpec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kana { get; set; }
        public List<string> Engines { get; set; }
        public List<string> AnotherNames { get; set; }
        public string JimakuTextColor { get; set; }
        public string JimakuOutlineColor { get; set; }
        public double JimakuOutlineWidth { get; set; }

        public string ActorTextColor { get; set; }
        public string ActorOutlineColor { get; set; }
        public double ActorOutlineWidth { get; set; }

        public Dictionary<string, string> ExtData { get; set; }

        public ActorSpec Duplicate(
            int? id = null,
            string? name = null,
            string? kana = null,
            List<string>? engines = null,
            List<string>? another_names = null,
            string? jimaku_text_color = null,
            string? jimaku_outline_color = null,
            double? jimaku_outline_width = null,
            string? actor_text_color = null,
            string? actor_outline_color = null,
            double? actor_outline_width = null,
            Dictionary<string, string>? ext_data = null
            )
        {
            return new ActorSpec()
            {
                Id = id ?? this.Id,
                Name = name ?? this.Name,
                Kana = kana ?? this.Kana,
                Engines = engines ?? this.Engines,
                AnotherNames = another_names ?? this.AnotherNames,
                JimakuTextColor = jimaku_text_color ?? this.JimakuTextColor,
                JimakuOutlineColor = jimaku_outline_color ?? this.JimakuOutlineColor,
                JimakuOutlineWidth = jimaku_outline_width ?? this.JimakuOutlineWidth,
                ActorTextColor = actor_text_color ?? this.ActorTextColor,
                ActorOutlineColor = actor_outline_color ?? this.ActorOutlineColor,
                ActorOutlineWidth = actor_outline_width ?? this.ActorOutlineWidth,
                ExtData = ext_data ?? this.ExtData
            };
        }
    }

    public struct ColorSpec
    {
        public int Id { get; set; }
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

        public ColorSpec Duplicate(
            int? id = null,
            string? name = null,
            string? hex = null,
            int? type = null,
            byte? r = null,
            byte? g = null,
            byte? b = null
            )
        {
            return new ColorSpec()
            {
                Id = id ?? this.Id,
                Name = name ?? this.Name,
                Hex = hex ?? this.Hex,
                Type = type ?? this.Type,
                R = r ?? this.R,
                G = g ?? this.G,
                B = b ?? this.B
            };
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

    public struct ColorNameListElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hex { get; set; }
    }
}
