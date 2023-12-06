using KingPrice_UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace KingPrice_UI.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = ConfigurationManager.AppSettings["KingPriceAPIURL"];
        public async Task<ActionResult> Index()
        {
            List<UserDetails> userInfo = new List<UserDetails>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllUsers using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/UserDetails/GetAllUserDetails");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Users list
                    userInfo = JsonConvert.DeserializeObject<List<UserDetails>>(response);
                }

                //returning the user list to view
                return View(userInfo);
            }
        }
    }
}