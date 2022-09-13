using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Home
        [HttpGet]
        public IActionResult Get()
        {
            string userToken = "// Token //";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://graph.facebook.com");

                HttpResponseMessage response = client.GetAsync($"me/videos?fields=title,created_time,post_views&access_token={userToken}").Result;

                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                // var jsonRes = JsonConvert.DeserializeObject<dynamic>(result);

                // var email = jsonRes["email"].ToString();
                return new JsonResult(myDeserializedClass);
            }

            return null;
        }
    }
}
