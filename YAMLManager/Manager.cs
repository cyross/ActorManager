using YamlDotNet.RepresentationModel;

namespace VHYAML
{
    public class VYManager
    {
        protected string path;
        protected VYProcessor processor;

        public VYManager(string path)
        {
            this.path = path;

            processor = new VYProcessor();
        }

        public int SeqDepth { get { return processor.SeqDepth; } }
        public int MapDepth { get { return processor.MapDepth; } }

        public Action<YamlScalarNode> CallbackScalar
        {
            get { return processor.CallbackScalar; }
            set { processor.CallbackScalar = value; }
        }

        public Action<YamlScalarNode> CallbackKey
        {
            get { return processor.CallbackKey; }
            set { processor.CallbackKey = value; }
        }

        public Action<YamlSequenceNode> CallbackSequenceStart
        {
            get { return processor.CallbackSequenceStart; }
            set { processor.CallbackSequenceStart = value; }
        }

        public Action<YamlSequenceNode> CallbackSequenceLoopStart
        {
            get { return processor.CallbackSequenceLoopStart; }
            set { processor.CallbackSequenceLoopStart = value; }
        }

        public Action<YamlSequenceNode> CallbackSequenceLoopEnd
        {
            get { return processor.CallbackSequenceLoopEnd; }
            set { processor.CallbackSequenceLoopEnd = value; }
        }

        public Action<YamlSequenceNode> CallbackSequenceEnd
        {
            get { return processor.CallbackSequenceEnd; }
            set { processor.CallbackSequenceEnd = value; }
        }

        public Action<YamlMappingNode> CallbackMappingStart
        {
            get { return processor.CallbackMappingStart; }
            set { processor.CallbackMappingStart = value; }
        }

        public Action<YamlMappingNode> CallbackMappingInnerStart
        {
            get { return processor.CallbackMappingInnerStart; }
            set { processor.CallbackMappingInnerStart = value; }
        }

        public Action<YamlMappingNode> CallbackMappingInnerEnd
        {
            get { return processor.CallbackMappingInnerEnd; }
            set { processor.CallbackMappingInnerEnd = value; }
        }

        public Action<YamlMappingNode> CallbackMappingEnd
        {
            get { return processor.CallbackMappingEnd; }
            set { processor.CallbackMappingEnd = value; }
        }

        /// <summary>
        /// ファイルからYAML文字列を取得、オブジェクトに追加する
        /// </summary>
        public bool Load(string? filePath = null)
        {
            if (filePath == null) { filePath = path; }
            if (!File.Exists(filePath)) { return false; }

            using (var yamlStream = new StreamReader(filePath))
            {
                var stream = new YamlStream();

                stream.Load(yamlStream);

                processor.Deserialize(stream);
            }

            return true;
        }

        /// <summary>
        /// オブジェクトの内容をYAML文字列に変換してファイルに保存する
        /// </summary>
        public void Save<T>(T obj, string? filePath = null)
        {
            if (filePath == null) { filePath = path; }

            var yaml = processor.Serialize(obj);

            using (var f = new StreamWriter(filePath))
            {
                f.WriteLine(yaml);
            }
        }
    }
}
