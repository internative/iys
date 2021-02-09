using System;
using System.Collections.Generic;

namespace Internative.IYS.Core.Models.Base
{
    public class IysError
    {
        public int index { get; set; }
        public List<string> location { get; set; }
        public string value { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    
    public class IysErrorWrapper
    {
        public List<IysError> errors { get; set; } = new List<IysError>();
    }

    public class IysResponseWrapper
    {
        public string transactionId { get; set; }
        public DateTime creationDate { get; set; }
        public List<IysError> errors { get; set; } = new List<IysError>();
    }
}