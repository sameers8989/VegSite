namespace works.Utilities
{
    public class ResponseAPI<T>
    {
        public T? Value { get; set; }
        public string? Msg { get; set; }
        public bool? Status { get; set; }
    }
}
