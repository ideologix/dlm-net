namespace DLM_NET.Http.Responses
{
    public class Base<T>
    {
        public String? code { get; set; }
        public String? message { get; set; }
        public T? data { get; set; }

        public bool isError()
        {
            return !string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(message);
        }

    }
}
