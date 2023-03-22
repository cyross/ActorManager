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
            seq_depth++;
            //Debug.WriteLine(string.Format("[{0}]START SEQUENCE", seq_depth));
            CallbackSequenceStart(node);
            int cnt = 1;
            foreach (var child in node.Children)
            {
                //Debug.WriteLine(string.Format("[{0}][{1}]LOOP START", seq_depth, cnt));
                CallbackSequenceLoopStart(node);
                DeserializeDispatch(child);
                CallbackSequenceLoopEnd(node);
                //Debug.WriteLine(string.Format("[{0}][{1}]LOOP END", seq_depth, cnt));
                cnt++;
            }
            CallbackSequenceEnd(node);
            //Debug.WriteLine(string.Format("[{0}]FINISH SEQUENCE", seq_depth));
            seq_depth--;
        }

        private void DeserializeMapping(YamlMappingNode node)
        {
            map_depth++;
            //Debug.WriteLine(string.Format("[{0}]START MAPPING", map_depth));
            CallbackMappingStart(node);
            foreach (var child in node.Children)
            {
                CallbackMappingInnerStart(node);
                //Debug.WriteLine(string.Format("[{0}]KEY", map_depth));
                DeserializeKey((YamlScalarNode)child.Key);
                //Debug.WriteLine(string.Format("[{0}]VALUE", map_depth));
                DeserializeDispatch(child.Value);
                CallbackMappingInnerEnd(node);
            }
            CallbackMappingEnd(node);
            //Debug.WriteLine(string.Format("[{0}]FINISH MAPPING", map_depth));
            map_depth--;
        }
    }
}