using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHActorManager
{
    public enum ColorType
    {
        NamedColor = 0,
        SystemColor = 1,
        DialogColor = 2,
        RGB = 3
    }

    public enum ResultStatus
    {
        NONE = -1,
        OK = 0,
        WARNING = 999,
        ERROR = 1000,
        FATAL = 9999
    }
}
