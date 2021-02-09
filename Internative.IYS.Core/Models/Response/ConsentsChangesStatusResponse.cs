using System;
using Internative.IYS.Core.Models.Base;

namespace Internative.IYS.Core.Models.Response
{
    public class ConsentsChangesStatusResponse
    {
        public string requestId { get; set; }
        public string subRequestId { get; set; }
        public int index { get; set; }
        public string transactionId { get; set; }
        public string status { get; set; }
        public DateTime creationDate { get; set; }
        public IysError error { get; set; }
    }
}