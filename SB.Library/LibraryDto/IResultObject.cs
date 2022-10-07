using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Library.LibraryDto
{
    public interface IResultObject
    {
        string Message { get; set; }
        bool IsError { get; set; }
    }
}
