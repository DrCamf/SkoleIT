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
    public class StudentSkemaService
    {
        public List<Skema> GetSkemaByDate(DateTime date,int id)
        {
            var url = "https://svt.elthoro.dk";
            var client = new RestClient(url);

            var apiurl = "/?pass=skema&item=" + date.ToString("yyyy-MM-dd") + "&id=" + id;
            var request = new RestRequest(apiurl, Method.Get);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Skema>>(response.Content);
            }
            else
            {
                return null;
            }
        }
    }
}
