﻿using System.Text.Json;
using VHActorManager.Interfaces;
using VHActorManager.Specs;

namespace VHActorManager.WebService
{
    internal class ResponseData
    {
        public ResponseMessage Message { get; set; }
        public Dictionary<string, string> CommodityData { get; set; }

        public ResponseData()
        {
            this.Message = new ResponseMessage();
            this.CommodityData = new Dictionary<string, string>();
        }

        public ResponseData(ResponseMessage message)
        {
            this.Message = message;
            this.CommodityData = new Dictionary<string, string>();
        }

        public static ResponseData NoneResponse(string? msg = null)
        {
            return new ResponseData(new ResponseMessage().None(msg));
        }

        public static ResponseData SucceedResponse(string? msg = null)
        {
            return new ResponseData(new ResponseMessage().Succeed(msg));
        }

        public static ResponseData WarninigResponse(string msg = "")
        {
            return new ResponseData(new ResponseMessage().Warning(msg));
        }

        public static ResponseData ErrorResponse(string msg = "")
        {
            return new ResponseData(new ResponseMessage().Error(msg));
        }

        public static ResponseData FatalResponse(string msg = "")
        {
            return new ResponseData(new ResponseMessage().Fatal(msg));
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class NameListResponseData<T> : ResponseData where T: struct, IElementInterface
    {
        public List<T> Names { get; set; }

        public NameListResponseData() : base()
        {
            Names = new List<T>();
        }

        public NameListResponseData(List<T> names) : base()
        {
            Names = names;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class ColorNameListResponseData<T> : ResponseData where T: struct, IColorElementInterface
    {
        public List<T> Names { get; set; }

        public ColorNameListResponseData() : base()
        {
            Names = new List<T>();
        }

        public ColorNameListResponseData(List<T> names) : base()
        {
            Names = names;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class NewIdResponseData : ResponseData
    {
        public int NewId { get; set; }

        public NewIdResponseData() : base()
        {
            NewId = -1;
        }

        public NewIdResponseData(int newId) : base()
        {
            NewId = newId;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class SpecResponseData<T> : ResponseData where T: class, ISpecInterface, new()
    {
        public T Spec { get; set; }

        public SpecResponseData() : base()
        {
            Spec = new T();
        }

        public SpecResponseData(T spec) : base()
        {
            Spec = spec;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class SpecsResponseData<T> : ResponseData where T : class, ISpecInterface, new()
    {
        public List<T> Specs { get; set; }

        public SpecsResponseData() : base()
        {
            Specs = new List<T>();
        }

        public SpecsResponseData(List<T> specs) : base()
        {
            Specs = specs;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class ListResponseData<T, E> : ResponseData where T : class, IList<E>, new()
    {
        public T List { get; set; }

        public ListResponseData() : base()
        {
            List = new T();
        }

        public ListResponseData(T list) : base()
        {
            List = list;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class DictResponseData<T, E> : ResponseData where T : class, IDictionary<string, E>, new()
    {
        public T Dict { get; set; }

        public DictResponseData() : base()
        {
            Dict = new T();
        }

        public DictResponseData(T dict) : base()
        {
            Dict = dict;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    internal class NewKeyResponseData : ResponseData
    {
        public string NewKey { get; set; }

        public NewKeyResponseData() : base()
        {
            NewKey = "";
        }

        public NewKeyResponseData(string newKey) : base()
        {
            NewKey = newKey;
        }

        public new string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}