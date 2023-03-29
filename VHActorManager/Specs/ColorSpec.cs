using System;
using System.Collections.Generic;
using VHActorManager.Interfaces;

namespace VHActorManager.Specs
{
    internal class ColorSpec: SpecInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hex { get; set; }
        public int Type { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public ColorSpec()
        {
            Id = -1;
            Name = string.Empty;
            Hex = string.Empty;
            Type = (int)ColorType.RGB;
            R = 0;
            G = 0;
            B = 0;
        }

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
}
