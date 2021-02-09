using System.Collections.Generic;
using Internative.IYS.Core.Models.Base;
using Internative.IYS.Core.Models.Request;

namespace Internative.IYS.Core.Models.Response
{
    public class ConsentsStatusResponse : IysRecipient
    {
        public List<IysError> errors { get; set; }
    }
}