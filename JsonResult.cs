namespace AutoPost
{
    internal class JsonResult<T>
    {
        public int result { get; set; }
        public string message { get; set; }

        public T data { get; set; }
    }
}