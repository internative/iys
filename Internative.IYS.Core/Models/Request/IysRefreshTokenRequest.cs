namespace Internative.IYS.Core.Models.Request
{
    public class IysRefreshTokenRequest
    {
        public string grant_type { get; set; } = "refresh_token";
        public string refresh_token { get; set; }
    }
}