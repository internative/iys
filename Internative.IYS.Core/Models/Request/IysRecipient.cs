using System.Collections.Generic;

namespace Internative.IYS.Core.Models.Request
{
    public class IysRecipient
    {
        public string type { get; set; }
        public string source { get; set; }
        public string recipient { get; set; }
        public string status { get; set; }
        public string consentDate { get; set; }
        public string recipientType { get; set; } = "BIREYSEL";
        public string transactionId { get; set; }
        public List<int> retailerAccess { get; set; } = new List<int>();
    }
}