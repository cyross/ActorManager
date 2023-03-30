using System;
using System.Collections.Generic;
using VHActorManager.Interfaces;

namespace VHActorManager.Specs
{
    internal class VESpec: ISpecInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Separator { get; set; }
        public string Encoding { get; set; }
        public Dictionary<string, string> ExtData { get; set; }

        public VESpec()
        {
            Id = -1;
            Name = string.Empty;
            RealName = string.Empty;
            Separator = string.Empty;
            Encoding = string.Empty;
            ExtData = new Dictionary<string, string>();
        }

        public VESpec Duplicate(
            int? id = null,
            string? name = null,
            string? real_name = null,
            string? separator = null,
            string? encoding = null,
            Dictionary<string, string>? ext_data = null
            )
        {
            return new VESpec()
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
}
