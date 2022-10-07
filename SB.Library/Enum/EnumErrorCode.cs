using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Library.Enum
{
    public enum EnumErrorCode : int
    {
        NULL = 1,
        WrongParameter = 1,
        MissingParameter = 2,
        NotFound = 3,
        AlreadyHave = 4
    }
}
