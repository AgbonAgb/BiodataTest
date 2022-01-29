namespace BiodataTest.Models
{
    public class CybPayload
    {
        public string Currency { get; set; }
        public string MerchantRef { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string IntegrationKey { get; set; }
        public string ReturnUrl { get; set; }
      
    }
}
