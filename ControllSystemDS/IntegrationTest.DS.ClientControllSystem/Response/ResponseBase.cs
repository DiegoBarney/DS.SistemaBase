namespace IntegrationTest.DS.ClientControllSystem.Response
{
    public class ResponseBase
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public object Error { get; set; }
    }
}
