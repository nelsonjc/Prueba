using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPlatform.Front.Models
{
    public class RSV_Global<T> : Result
    {
        private T _data;

        public T data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    public class Result
    {
        #region Variables
        private bool _success;
        private Error _error;
        #endregion

        #region Propiedades
        public bool success
        {
            get { return _error == default(Error) ? true : false; }
            set { _success = value; }
        }
        public Error error
        {
            get { return _error; }
            set { _error = value; }
        }
        #endregion
    }

    public class Error
    {
        #region Variables
        private string _userMessage;
        private string _message;
        private string _errorType;
        private string _source;
        private string _pila;
        private string _messageInnerException;
        #endregion

        #region Propiedades
        public string userMessage
        {
            get { return _userMessage; }
            set { _userMessage = value; }
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string errorType
        {
            get { return _errorType; }
            set { _errorType = value; }
        }

        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        public string pila
        {
            get { return _pila; }
            set { _pila = value; }
        }

        public string messageInnerException
        {
            get { return _messageInnerException; }
            set { _messageInnerException = value; }
        }
        #endregion

        public Error(Exception ex, string strUserMessage)
        {
            this.userMessage = strUserMessage;
            this.message = ex != null ? ex.ToString(): string.Empty;
            this.source = ex != null ? ex.Source : string.Empty;
            this.pila = ex != null ? ex.StackTrace : string.Empty;;
            if (ex!= null && ex.InnerException != null)
            {
                this.messageInnerException = ex.InnerException.Message;
            }
        }
    }
}
