using YamlDotNet.RepresentationModel;
using VHYAML;
using System.Text.Json;
using VHActorManager.Interfaces;
using VHActorManager.WebService;

namespace VHActorManager.Master
{
    public class MasterBase
    {
        public const string ORG_MASTER_FILE_DIR = "org_masters";

        private readonly string filepath;
        protected readonly VYManager YamlManager;
        protected Stack<string> KeyStack;
        protected string CurrentKey;
        protected string BaseKey;
        protected int MaxSpecId;

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
            MaxSpecId = 0;
        }

        protected string ParentKey
        {
            get
            {
                if (KeyStack.Count == 0) { return ""; }

                return KeyStack.Peek();
            }
        }

        public static string ResponseNone() { return ResponseData.NoneResponse().ToJson(); }

        public static string ResponseSucceed() { return ResponseData.SucceedResponse().ToJson(); }

        protected static string ResponseWarning(string msg) { return ResponseData.WarninigResponse(msg).ToJson(); }

        protected static string ResponseError(string msg) { return ResponseData.ErrorResponse(msg).ToJson(); }

        protected static string ResponseFatal(string msg) { return ResponseData.FatalResponse(msg).ToJson(); }

        protected static string ResponseOutOfIndexError(string prefix) { return ResponseError($"{prefix}の値が範囲外です"); }

        protected static string ResponseIllegalRequestDataError() { return ResponseError("入力されたデータが不正です"); }

        protected static string ResponseIllegalParamaterError() { return ResponseError("パラメータの書式が不正です"); }

        protected static string ResponseNotFoundKeyError(string prefix, string key) { return ResponseError($"${prefix}のキーが見つかりません: {key}"); }

        protected static string ResponseAlreadyExistKeyError(string prefix, string key) { return ResponseError($"${prefix}のキーは既に存在しています: {key}"); }

        internal static string FindIndexFromSpecs<T>(List<T> specs, string paramId, string id_prefix, out int targetId) where T : class, ISpecInterface
        {
            targetId = -1;

            if (!int.TryParse(paramId, out int id)) { return ResponseIllegalParamaterError(); }

            IEnumerable<T> searchResult = specs.Where(e => e.Id == id);

            if (!searchResult.Any()) { return ResponseOutOfIndexError(id_prefix); }

            // リストのインデックスを求めたいので、結構遠回りなことをやっている
            targetId = specs.IndexOf(searchResult.First());

            return "";
        }

        internal static string NameListToJson<T, E>(List<T> specs) where T : class, ISpecInterface, new() where E: struct, IElementInterface
        {
            List<E> names = new();

            foreach (var spec in specs)
            {
                E element = new()
                {
                    Id = spec.Id,
                    Name = spec.Name
                };
                names.Add(element);
            }

            NameListResponseData<E> data = new(names)
            {
                Message = new ResponseMessage().Succeed()
            };

            return data.ToJson();
        }

        internal static string ColorNameListToJson<T, E>(List<T> specs) where T : class, IColorSpecInterface, new() where E : struct, IColorElementInterface
        {
            List<E> names = new();

            foreach (var spec in specs)
            {
                E element = new()
                {
                    Id = spec.Id,
                    Name = spec.Name,
                    Hex = spec.Hex
                };
                names.Add(element);
            }

            ColorNameListResponseData<E> data = new(names)
            {
                Message = new ResponseMessage().Succeed()
            };

            return data.ToJson();
        }

        internal static string SpecsToJson<T>(List<T> specs) where T : class, ISpecInterface, new()
        {
            SpecsResponseData<T> data = new(specs)
            {
                Message = new ResponseMessage().Succeed()
            };

            return data.ToJson();
        }

        internal static string SpecToJson<T>(string paramId, List<T> specs, string idPrefix) where T: class, ISpecInterface, new()
        {
            string result = FindIndexFromSpecs(specs, paramId, idPrefix, out int targetIndex);

            if (targetIndex == -1) { return result; }

            SpecResponseData<T> data = new(specs[targetIndex])
            {
                Message = new ResponseMessage().Succeed()
            };

            return data.ToJson();
        }

        internal static string SpecFromJson<T>(string json, List<T> specs, ref int maxSpecId) where T : class, ISpecInterface, new()
        {
            T? spec = JsonSerializer.Deserialize<T>(json);

            if (spec == null) { return ResponseIllegalRequestDataError(); }

            spec.Id = ++maxSpecId;

            specs.Add((T)spec);

            NewIdResponseData data = new(spec.Id)
            {
                Message = new ResponseMessage().Succeed()
            };

            return data.ToJson();
        }

        internal static string SpecFromJson<T>(string paramId, string json, List<T> specs, string idPrefix) where T : class, ISpecInterface, new()
        {
            string result = FindIndexFromSpecs(specs, paramId, idPrefix, out int targetIndex);

            if (targetIndex == -1) { return result; }

            T? spec = JsonSerializer.Deserialize<T>(json);

            if (spec == null) { return ResponseIllegalRequestDataError(); }

            specs[targetIndex] = (T)spec;

            return ResponseSucceed();
        }

        internal static string DeleteSpec<T>(string paramId, List<T> specs, string idPrefix) where T : class, ISpecInterface, new()
        {
            string result = FindIndexFromSpecs(specs, paramId, idPrefix, out int targetIndex);

            if (targetIndex == -1) { return result; }

            specs.RemoveAt(targetIndex);

            return ResponseSucceed();
        }

        public virtual string NameListToJson() { return ResponseNone(); }

        public virtual string SpecsToJson() { return ResponseNone(); }

        public virtual string SpecToJson(string index) { return ResponseNone(); }

        public virtual string SpecsFromJson(string json){ return ResponseNone(); }

        public virtual string SpecFromJson(string json) { return ResponseNone(); }

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
            }
            else if(KeyStack.Count == 0)
            {
                BaseKey = key;
            }
            CurrentKey = key;
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
            }
            else
            {
                BaseKey = "";
            }
        }
    }
}
