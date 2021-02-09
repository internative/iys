using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Internative.IYS.Core.Extensions;
using Internative.IYS.Core.Models.Base;
using Internative.IYS.Core.Models.Request;
using Internative.IYS.Core.Models.Response;
using Newtonsoft.Json;

namespace Internative.IYS.Core.Client
{
    public static class IysApiClient
    {

        /// <summary>
        /// Iys api üzerinden token oluşturma işlemini yapar
        /// </summary>
        public static async Task<IysTokenResponse> GetTokenRequest(IysTokenRequest request, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            string IYSToken = "";
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(baseUrl + "oauth2/token");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new IysTokenRequest
                    {
                        username = request.username,
                        password = request.password,
                        grant_type = request.grant_type
                    }.ToJson();
                    await streamWriter.WriteAsync(json);
                }

                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await streamReader.ReadToEndAsync();
                        return JsonConvert.DeserializeObject<IysTokenResponse>(result);
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// Iys api üzerinden token yenileme işlemini yapar
        /// </summary>
        public static async Task<IysTokenResponse> RefreshTokenRequest(IysRefreshTokenRequest request, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            string IYSToken = "";
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(baseUrl + "oauth2/token");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = request.ToJson();
                    await streamWriter.WriteAsync(json);
                }

                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await streamReader.ReadToEndAsync();
                        return JsonConvert.DeserializeObject<IysTokenResponse>(result);
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// Asenkron tekil izin ekleme işlemi yapar
        /// </summary>
        public static async Task<IysResponseWrapper> ConsentRequest(IysRecipient request,
            string token, string iysCode, string brandCode, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            var response = new IysResponseWrapper();
            
            var httpWebRequest =
                (HttpWebRequest) WebRequest.Create(baseUrl +
                                                   $"sps/{iysCode}/brands/{brandCode}/consents");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = request.ToJson();
                await streamWriter.WriteAsync(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<IysResponseWrapper>(result);
                }
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var result = await reader.ReadToEndAsync();
                response = JsonConvert.DeserializeObject<IysResponseWrapper>(result);
            }

            return response;
        }
        
        /// <summary>
        /// Tekil izin durumu sorgulama işlemi yapar
        /// </summary>
        public static async Task<ConsentsStatusResponse> ConsentStatusRequest(IysRecipient request,
            string token, string iysCode, string brandCode, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            var response = new ConsentsStatusResponse();
            
            var httpWebRequest =
                (HttpWebRequest) WebRequest.Create(baseUrl +
                                                   $"sps/{iysCode}/brands/{brandCode}/consents");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = request.ToJson();
                await streamWriter.WriteAsync(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<ConsentsStatusResponse>(result);
                }
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var result = await reader.ReadToEndAsync();
                response = JsonConvert.DeserializeObject<ConsentsStatusResponse>(result);
            }

            return response;
        }
        
        /// <summary>
        /// Asenkron toplu izin ekleme işlemi yapar
        /// </summary>
        public static async Task<BulkConstentsResponse> BulkConstentsRequest(List<IysRecipient> request,
            string token, string iysCode, string brandCode, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            var response = new BulkConstentsResponse();
            
            var httpWebRequest =
                (HttpWebRequest) WebRequest.Create(baseUrl +
                                                   $"sps/{iysCode}/brands/{brandCode}/consents/request");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = request.ToJson();
                await streamWriter.WriteAsync(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<BulkConstentsResponse>(result);
                }
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var result = await reader.ReadToEndAsync();
                response = JsonConvert.DeserializeObject<BulkConstentsResponse>(result);
            }

            return response;
        }
        
        /// <summary>
        /// Çoklu izin ekleme isteği sorgulama işlemi yapar
        /// </summary>
        public static async Task<List<ConsentsChangesStatusResponse>> ConsentsChangesStatusRequest(string token, string iysCode, string brandCode, string requestId, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            var response = new List<ConsentsChangesStatusResponse>();
            
            var httpWebRequest =
                (HttpWebRequest) WebRequest.Create(baseUrl +
                                                   $"sps/{iysCode}/brands/{brandCode}/consents/request/{requestId}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);

            try
            {
                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<List<ConsentsChangesStatusResponse>>(result);
                }
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var result = await reader.ReadToEndAsync();
                response = JsonConvert.DeserializeObject<List<ConsentsChangesStatusResponse>>(result);
            }

            return response;
        }

        
        /// <summary>
        /// Çoklu izin durumu sorgulama işlemi yapar
        /// </summary>
        public static async Task<ConsentsChangesResponse> ConsentsChangesRequest(List<IysRecipient> request,
            string token, string iysCode, string brandCode, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            var response = new ConsentsChangesResponse();
            
            var httpWebRequest =
                (HttpWebRequest) WebRequest.Create(baseUrl +
                                                   $"sps/{iysCode}/brands/{brandCode}/consents/changes");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = request.ToJson();
                await streamWriter.WriteAsync(json);
            }

            try
            {
                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<ConsentsChangesResponse>(result);
                }
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var result = await reader.ReadToEndAsync();
                response = JsonConvert.DeserializeObject<ConsentsChangesResponse>(result);
            }

            return response;
        }

        /// <summary>
        /// İzin hareketi sorgulama işlemi yapar
        /// </summary>
        public static async Task<ConsentsChangesResponse> ConsentsChangesPullRequest(string token, string iysCode, string brandCode, string baseUrl = "https://api.sandbox.iys.org.tr")
        {
            var response = new ConsentsChangesResponse();
            
            var httpWebRequest =
                (HttpWebRequest) WebRequest.Create(baseUrl +
                                                   $"sps/{iysCode}/brands/{brandCode}/consents/changes");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);

            try
            {
                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = await streamReader.ReadToEndAsync();
                    response = JsonConvert.DeserializeObject<ConsentsChangesResponse>(result);
                }
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var result = await reader.ReadToEndAsync();
                response = JsonConvert.DeserializeObject<ConsentsChangesResponse>(result);
            }

            return response;
        }


        
        
        
    }
    
}