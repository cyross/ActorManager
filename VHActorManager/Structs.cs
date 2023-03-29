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
