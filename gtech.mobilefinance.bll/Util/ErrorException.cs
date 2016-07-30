using System;

namespace gtech.mobilefinance.bll.Util
{
    public class ErrorException : Exception
    {
        private int _code;
        private string _message;

        public ErrorException(CodeStatus code, string message)
        {
            this._code = (int)code;
            this._message = message;
        }

        //properties
        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}