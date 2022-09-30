using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SkoleIT.Models;

namespace SkoleIT.Services
{
    public class LoginService : ILoginService
    {
        public async Task<LoginApi> Authenticate (LoginRequest loginRequest)
        {
           string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(loginRequest.Login + ":" + loginRequest.Password));

            var url = "https://svt.elthoro.dk/basic.php";
            using (var client = new RestClient(url))
            {
                var request = new RestRequest(url, Method.Get);
                request.AddHeader("Authorization", "Basic " + encoded);
                var body = @"";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = await client.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   
                    var json = response.Content.ToString();
                    var userDetails = new UserBasicInfo
                    {
                        Admitent = encoded

                    };
                    return JsonConvert.DeserializeObject<LoginApi>(json);
                   // return null;
                }
                else
                {
                    return null;
                }
            }


            /*using (var client = new HttpClient(httpClientHandler))
            {
                string loginrequestStr = JsonConvert.SerializeObject(loginRequest);
                //string loginrequestStr = Base64Encode(loginRequest.Login, loginRequest.Password);
                var response = await client.PostAsync("https://svt.elthoro.dk/basic.php",
                    new StringContent(loginrequestStr, Encoding.UTF8, "application/json"));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LoginApi>(json);
                }
                else
                {
                    return null;
                }
            }*/
        }
    }
}
