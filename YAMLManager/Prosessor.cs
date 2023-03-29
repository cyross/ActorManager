using System.Diagnostics;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace VHYAML
{
    public class VYProcessor
    {
        public Action<YamlScalarNode> CallbackScalar;
        public Action<YamlScalarNode> CallbackKey;
        public Action<YamlSequenceNode> CallbackSequenceStart;
        public Action<YamlSequenceNode> CallbackSequenceLoopStart;
        public Action<YamlSequenceNode> CallbackSequenceLoopEnd;
        public Action<YamlSequenceNode> CallbackSequenceEnd;
        public Action<YamlMappingNode> CallbackMappingStart;
        public Action<YamlMappingNode> CallbackMappingInnerStart;
        public Action<YamlMappingNode> CallbackMappingInnerEnd;
        public Action<YamlMappingNode> CallbackMappingEnd;

        private readonly ISerializer serializer;
        private int seq_depth;
        private int map_depth;

        public VYProcessor()
        {
            serializer = new SerializerBuilder().Build();
            CallbackScalar = (node) => { };
            CallbackKey = (node) => { };
            CallbackSequenceStart = (node) => { };
            CallbackSequenceLoopStart = (node) => { };
            CallbackSequenceLoopEnd = (node) => { };
            CallbackSequenceEnd = (node) => { };
            CallbackMappingStart = (node) => { };
            CallbackMappingInnerStart = (node) => { };
            CallbackMappingInnerEnd = (node) => { };
            CallbackMappingEnd = (node) => { };
            seq_depth = 0;
            map_depth = 0;
        }

        public int SeqDepth { get { return seq_depth; } }
        public int MapDepth { get { return map_depth; } }

        public string Serialize<T>(T obj)
        {
            return serializer.Serialize(obj);
        }

        public void Deserialize(YamlStream stream)
        {
            seq_depth = 0;
            map_depth = 0;
            foreach (var document in stream.Documents)
            {
                DeserializeDispatch(document.RootNode);
            }
        }

        private void DeserializeDispatch(YamlNode node)
        {
            switch (node.NodeType)
            {
                case YamlNodeType.Scalar:
                    DeserializeScalar((YamlScalarNode)node);
                    break;
                case YamlNodeType.Sequence:
                    DeserializeSequence((YamlSequenceNode)node);
                    break;
                case YamlNodeType.Mapping:
                    DeserializeMapping((YamlMappingNode)node);
                    break;
                default:
                    Debug.WriteLine(string.Format("[DISPATCH]Unknown:{0}", node.NodeType));
                    break;
            }
        }

        private void DeserializeScalar(YamlScalarNode node)
        {
            CallbackScalar(node);
        }

        private void DeserializeKey(YamlScalarNode node)
        {
            CallbackKey(node);
        }

        private void DeserializeSequence(YamlSequenceNode node)
        {
            if (node.Children.Count == 0)
            {
                CallbackSequenceStart(node);
                CallbackSequenceEnd(node);
                return;
            }

            seq_depth++;
            CallbackSequenceStart(node);
            foreach (var child in node.Children)
            {
                CallbackSequenceLoopStart(node);
                DeserializeDispatch(child);
                CallbackSequenceLoopEnd(node);
            }
            CallbackSequenceEnd(node);
            seq_depth--;
        }

        private void DeserializeMapping(YamlMappingNode node)
        {
            if (node.Children.Count == 0)
            {
                return;
            }

            map_depth++;
            CallbackMappingStart(node);
            foreach (var child in node.Children)
            {
                CallbackMappingInnerStart(node);
                DeserializeKey((YamlScalarNode)child.Key);
                DeserializeDispatch(child.Value);
                CallbackMappingInnerEnd(node);
            }
            CallbackMappingEnd(node);
            map_depth--;
        }
    }
}