﻿namespace BiodataTest.Utility
{
    public class EmailSettings
    {
        public bool SSl { get; set; } = false;
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string Password { get; set; }
        public string Mfrom { get; set; }
        public string EmailMatchPattern { get; set; }
    }
}
