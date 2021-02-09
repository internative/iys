using System.Collections.Generic;
using Internative.IYS.Core.Models.Request;

namespace Internative.IYS.Core.Models.Response
{
    public class ConsentsChangesResponse
    {
        public string after { get; set; }
        public List<IysRecipient> list { get; set; }
    }
}