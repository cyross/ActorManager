using VHActorManager.Interfaces;

namespace VHActorManager.Specs
{
    internal class ActorSpec: ISpecInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kana { get; set; }
        public List<string> Engines { get; set; }
        public string PrimaryEngine { get; set; }
        public List<string> AnotherNames { get; set; }
        public string JimakuTextColor { get; set; }
        public string JimakuOutlineColor { get; set; }
        public double JimakuOutlineWidth { get; set; }

        public string ActorTextColor { get; set; }
        public string ActorOutlineColor { get; set; }
        public double ActorOutlineWidth { get; set; }

        public Dictionary<string, string> ExtData { get; set; }

        public ActorSpec()
        {
            Id = -1;
            Name = string.Empty;
            Kana = string.Empty;
            Engines = new List<string>();
            PrimaryEngine = string.Empty;
            AnotherNames = new List<string>();
            JimakuTextColor = string.Empty;
            JimakuOutlineColor = string.Empty;
            JimakuOutlineWidth = 0;
            ActorTextColor = string.Empty;
            ActorOutlineColor = string.Empty;
            ActorOutlineWidth = 0;
            ExtData = new Dictionary<string, string>();
        }

        public ActorSpec Duplicate(
            int? id = null,
            string? name = null,
            string? kana = null,
            List<string>? engines = null,
            string? primary_engine = null,
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
                PrimaryEngine = primary_engine ?? this.PrimaryEngine,
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
}
