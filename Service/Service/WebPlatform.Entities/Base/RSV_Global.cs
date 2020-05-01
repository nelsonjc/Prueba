namespace WebPlatform.Entities
{
    public class RSV_Global<T> : Result
    {
        private T _data;

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
