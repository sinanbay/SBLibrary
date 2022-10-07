using NLog;
using SB.Library.Enum;

namespace SB.Library.Helper
{
    public class CustomExceptionHelper : Exception
    {
        public int ErrorCode { get; set; }
        public EnumErrorCodeType ErrorCodeType { get; set; }

        public CustomExceptionHelper(EnumErrorCode errorCode, 
                                    EnumErrorCodeType errorCodeType, 
                                    string message = "", 
                                    Logger logger = null, 
                                    Exception ex=null)
            : base(message)
        {
            ErrorCode = (int)errorCode;
            ErrorCodeType = errorCodeType;

            if (errorCodeType == EnumErrorCodeType.Code)
            {
                logger.Error(ex, message);
            }

        }

    }
}
