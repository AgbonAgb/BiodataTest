namespace BiodataTest.Models
{
    public class CyberPayV2RequeryResponse
    {
        public bool succeeded { get; set; }
        public Data1 data { get; set; }
    }

    public class Data1
    {
        public string status { get; set; }
        public string message { get; set; }
        public string reference { get; set; }
    }
}
