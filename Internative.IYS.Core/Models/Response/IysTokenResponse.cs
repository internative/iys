namespace Internative.IYS.Core.Models.Response
{
    public class IysTokenResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int refresh_expires_in { get; set; }
    }
}