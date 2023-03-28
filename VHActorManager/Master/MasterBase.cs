using YamlDotNet.RepresentationModel;
using VHYAML;
using System.Text.Json;
using System.Diagnostics;

namespace VHActorManager.Master
{
    public class MasterBase
    {
        private readonly string filepath;
        protected readonly VYManager YamlManager;
        protected Stack<string> KeyStack;
        protected string CurrentKey;
        protected string BaseKey;

        public MasterBase(
            string fileName
            )
        {
            filepath = Utility.ExecFilepath(fileName);

            YamlManager = new(filepath);
            YamlManager.CallbackScalar += MBCbScl;
            YamlManager.CallbackKey += MBCbKey;
            YamlManager.CallbackSequenceStart += MBCbSeqS;
            YamlManager.CallbackSequenceLoopStart += MBCbSeqLS;
            YamlManager.CallbackSequenceLoopEnd += MBCbSeqLE;
            YamlManager.CallbackSequenceEnd += MBCbSeqE;
            YamlManager.CallbackMappingStart += MBCbMapS;
            YamlManager.CallbackMappingInnerStart += MBCbMapIS;
            YamlManager.CallbackMappingInnerEnd += MBCbMapIE;
            YamlManager.CallbackMappingEnd += MBCbMapE;

            KeyStack = new();

            CurrentKey = "";
            BaseKey = "";
        }

        public static string ResponseNone() { return new ResponseMessage().None().ToJson(); }

        public static string ResponseSucceed() { return new ResponseMessage().Succeed().ToJson(); }

        protected static string ResponseWarning(string msg) { return JsonSerializer.Serialize(new ResponseMessage().Warning(msg)); }

        protected static string ResponseError(string msg) { return JsonSerializer.Serialize(new ResponseMessage().Error(msg)); }

        protected static string ResponseFatal(string msg) { return JsonSerializer.Serialize(new ResponseMessage().Fatal(msg)); }

        protected static string ResponseOutOfIndexError(string prefix) { return JsonSerializer.Serialize(new ResponseMessage().Error($"{prefix}の値が範囲外です")); }

        protected static string ResponseIllegalRequestDataError() { return JsonSerializer.Serialize(new ResponseMessage().Error("入力されたデータが不正です")); }

        protected static string ResponseIllegalParamaterError() { return JsonSerializer.Serialize(new ResponseMessage().Error("パラメータの書式が不正です")); }

        public virtual string NameListToJson() { return ResponseNone(); }

        public virtual string SpecsToJson() { return ResponseNone(); }

        public virtual string SpecToJson(string index) { return ResponseNone(); }

        public virtual string SpecsFromJson(string json){ return ResponseNone(); }

        public virtual string SpecFromJson(string index, string json) { return ResponseNone(); }

        public virtual string DeleteSpec(string index) { return ResponseNone(); }

        public void Load(string? path = null)
        {
            YamlManager.Load(path);
        }

        public void Save<T>(T obj, string? path = null)
        {
            YamlManager.Save<T>(obj, path);
        }

        protected string ParentKey
        {
            get
            {
                if (KeyStack.Count == 0) { return ""; }

                return KeyStack.Peek();
            }
        }

        protected static string GetString(YamlScalarNode node)
        {
            if (node.Value == null)
            {
                throw new("YAML Node の値が null です");
            }

            return node.Value;
        }

        protected static int GetInt(YamlScalarNode node)
        {
            if (int.TryParse(node.Value, out int value))
            {
                return value;
            }
            else
            {
                throw new("YAML Node の値が null か、書式がInt整数ではありません");
            }
        }

        protected static byte GetByte(YamlScalarNode node)
        {
            if (byte.TryParse(node.Value, out byte value))
            {
                return value;
            }
            else
            {
                throw new("YAML Node の値が null か、書式がByte整数ではありません");
            }
        }

        protected static double GetDouble(YamlScalarNode node)
        {
            if (double.TryParse(node.Value, out double value))
            {
                return value;
            }
            else
            {
                throw new("YAML Node の値が null か、書式が整数ではありません");
            }
        }

        protected static bool GetBool(YamlScalarNode node)
        {
            if (bool.TryParse(node.Value, out bool value))
            {
                return value;
            }
            else
            {
                throw new("YAML Node の値が null か、書式が true/false ではありません");
            }
        }

        protected static Color GetColor(YamlScalarNode node)
        {
            if(node.Value == null) { return Color.White; }

            return Color.FromName(node.Value);
        }

        private void MBCbScl(YamlScalarNode node)
        {
        }

        private void MBCbKey(YamlScalarNode node)
        {
            string key = node.Value ?? "";

            if(CurrentKey != "")
            {
                KeyStack.Push(CurrentKey);
                //Debug.WriteLine(string.Format("[{0}]Pushed Key {1}", YamlManager.MapDepth, CurrentKey));
            }
            else if(KeyStack.Count == 0)
            {
                BaseKey = key;
            }
            CurrentKey = key;
            //Debug.WriteLine(string.Format("[{0}]Current Key is {1}", YamlManager.MapDepth, CurrentKey));
        }

        private void MBCbSeqS(YamlSequenceNode node)
        {
        }

        private void MBCbSeqLS(YamlSequenceNode node)
        {
        }

        private void MBCbSeqLE(YamlSequenceNode node)
        {
        }

        private void MBCbSeqE(YamlSequenceNode node)
        {
        }

        private void MBCbMapS(YamlMappingNode node)
        {
        }

        private void MBCbMapIS(YamlMappingNode node)
        {
        }

        private void MBCbMapIE(YamlMappingNode node)
        {
            CurrentKey = "";
        }

        private void MBCbMapE(YamlMappingNode node)
        {
            if(KeyStack.Count > 0)
            {
                CurrentKey = KeyStack.Pop();
                //Debug.WriteLine(string.Format("[{0}]Poped Key {1}", YamlManager.MapDepth, CurrentKey));
            }
            else
            {
                BaseKey = "";
            }
        }
    }
}
