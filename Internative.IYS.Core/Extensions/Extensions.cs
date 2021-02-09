using Newtonsoft.Json;

namespace Internative.IYS.Core.Extensions
{
    public static class Extensions
    {
        public static string ToJson(this object item)
        {
            return JsonConvert.SerializeObject(item);
        }
    }
}