using Newtonsoft.Json;
using RestSharp;
using SkoleIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkoleIT.Services
{
    public class StudentGradesService
    {
        //Grades grades = new();

        public List<Grades> GetGrades(int id)
        {
            var url = "https://svt.elthoro.dk";
            var client = new RestClient(url);

            var apiurl = "/?pass=elev&item=grades&id=" + id;
            var request = new RestRequest(apiurl, Method.Get);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Grades>>(response.Content);
            }
            else
            {
                return null;
            }
        }
    }
}
