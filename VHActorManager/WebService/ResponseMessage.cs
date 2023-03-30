using System.Text.Json;

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

        public ResponseMessage None(string? msg = null)
        {
            return Set(ResultStatus.NONE, msg ?? "None");
        }

        public ResponseMessage Succeed(string? msg = null)
        {
            return Set(ResultStatus.OK, msg ?? "Succeed");
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
