
using Newtonsoft.Json;
using RestSharp;
using SkoleIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SkoleIT.Services
{

    public class StudentCardService
    {
       /* HttpClient httpClient;
        public StudentCardService()
        {
            httpClient = new HttpClient();
        }*/

        StudentCard studentCard = new();
        public StudentCard getStudentCard(int id)
        {
            var url = "https://svt.elthoro.dk";
            //var url = "http://localhost/SkoleITApi";
            var client = new RestClient(url);
            
            var apiurl = "/?pass=elev&item=card&id=" + id;
            var request = new RestRequest(apiurl, Method.Get);
                //request.AddHeader("Authorization", "Basic YWlsZTY4OTg6RXJEZXR0ZT9NOUNvZGU=");
                //request.AddHeader("Content-Type", "application/json");
                //var body = @"";
                //request.AddParameter("application/json", body, ParameterType.RequestBody);
               
            RestResponse response =  client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<StudentCard>(response.Content);
            } else
            {
                return null;
            }

            
        }
    }
}
