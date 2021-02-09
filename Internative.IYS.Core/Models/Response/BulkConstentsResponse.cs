using System.Collections.Generic;
using Internative.IYS.Core.Models.Base;
using Internative.IYS.Core.Models.Request;

namespace Internative.IYS.Core.Models.Response
{
    public class BulkConstentsResponse
    {
        public string requestId { get; set; }
        public List<IysRecipient> subRequests { get; set; }
        public List<IysError> errors { get; set; }
    }
}