using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using VHActorManager.Interfaces;

namespace VHActorManager
{
    public struct ServerSpec
    {
        public int Port { get; set; }
        public bool OpenBrowser { get; set; }
    }

    internal struct VHYamlSpec
    {
        public bool Enable { get; set; }
        public string ScriptPath { get; set; }
        public string ExtPath { get; set; }
    }

    internal struct NameListElement: IElementInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal struct ColorNameListElement: IColorElementInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hex { get; set; }
    }
}
