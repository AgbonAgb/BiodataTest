namespace BiodataTest.Models
{
    
    public class Data
    {
        public string transactionReference { get; set; }
        public int charge { get; set; }
        public string redirectUrl { get; set; }
    }

    public class CYbPaymentresponse
    {
        public bool succeeded { get; set; }
        public Data data { get; set; }
    }
}
