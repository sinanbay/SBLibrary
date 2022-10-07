using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Library.LibraryDto
{
    public class ResultObject<T> : IResultObject
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public T Result { get; set; }
        public string ExceptionErrorMessage { get; set; }
        public Exception Exception
        {
            set
            {
                ExceptionErrorMessage = value.Message;
                if (value.InnerException != null)
                {
                    ExceptionErrorMessage += Environment.NewLine + "1: " + value.InnerException.Message;
                    if (value.InnerException.InnerException != null)
                    {
                        ExceptionErrorMessage += Environment.NewLine + "2: " + value.InnerException.InnerException.Message;
                        if (value.InnerException.InnerException.InnerException != null)
                        {
                            ExceptionErrorMessage += Environment.NewLine + "3: " + value.InnerException.InnerException.InnerException.Message;
                            if (value.InnerException.InnerException.InnerException.InnerException != null)
                            {
                                ExceptionErrorMessage += Environment.NewLine + "4: " + value.InnerException.InnerException.InnerException.InnerException.Message;
                            }
                        }
                    }
                }
            }
        }

    }
}
