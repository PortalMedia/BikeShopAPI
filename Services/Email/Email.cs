using System.Collections.Generic;

namespace BikeShopAPI.Services.Email
{
    public class Email
    {
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> ToAddresses { get; set; }
        public IEnumerable<string> BccAddresses { get; set; }
        public IEnumerable<string> CcAddresses { get; set; }
    }
}