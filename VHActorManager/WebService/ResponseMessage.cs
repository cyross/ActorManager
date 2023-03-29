using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VHActorManager.WebService
{
    internal class ResponseMessage
    {
        public ResultStatus Status { get; set; }
        public string Message { get; set; }

        public ResponseMessage()
        {
            Status = ResultStatus.NONE;
            Message = string.Empty;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        private ResponseMessage Set(ResultStatus st, string msg)
        {
            Status = st;
            Message = msg;
            return this;
        }

        public ResponseMessage None()
        {
            return Set(ResultStatus.NONE, "None");
        }

        public ResponseMessage Succeed()
        {
            return Set(ResultStatus.OK, "Succeed");
        }

        public ResponseMessage Warning(string msg)
        {
            return Set(ResultStatus.WARNING, msg);
        }

        public ResponseMessage Error(string msg)
        {
            return Set(ResultStatus.ERROR, msg);
        }

        public ResponseMessage Fatal(string msg)
        {
            return Set(ResultStatus.FATAL, msg);
        }
    }
}
