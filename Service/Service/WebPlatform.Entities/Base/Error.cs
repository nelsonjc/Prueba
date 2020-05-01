using System;

namespace WebPlatform.Entities
{
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
        public string UserMessage
        {
            get { return _userMessage; }
            set { _userMessage = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string ErrorType
        {
            get { return _errorType; }
            set { _errorType = value; }
        }

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public string Pila
        {
            get { return _pila; }
            set { _pila = value; }
        }

        public string MessageInnerException
        {
            get { return _messageInnerException; }
            set { _messageInnerException = value; }
        }
        #endregion

        public Error(Exception ex, string strUserMessage)
        {
            this.UserMessage = strUserMessage;
            this.Message = ex.ToString();
            this.Source = ex.Source;
            this.Pila = ex.StackTrace;
            if (ex.InnerException != null)
            {
                this.MessageInnerException = ex.InnerException.Message;
            }
        }
    }
}
