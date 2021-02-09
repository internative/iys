namespace Internative.IYS.Core.Models.Request
{
    public class IysTokenRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
    }
}