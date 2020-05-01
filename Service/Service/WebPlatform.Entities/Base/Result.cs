namespace WebPlatform.Entities
{
    public class Result
    {
        #region Variables
        private bool _success;
        private Error _error;
        #endregion

        #region Propiedades
        public bool Success
        {
            get { return _error == default(Error) ? true : false; }
            set { _success = value; }
        }
        public Error Error
        {
            get { return _error; }
            set { _error = value; }
        }
        #endregion
    }
}
