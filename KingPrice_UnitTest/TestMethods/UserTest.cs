using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KingPrice_UI.Models;

namespace KingPrice_UnitTest.TestMethods
{
    public class UserTest
    {
        string Baseurl = "https://localhost:7113/";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestGetUsers()
        {
            List<Users>? userInfo = new List<Users>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllUsers using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Users/GetAllUsers");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Users list
                    userInfo = JsonConvert.DeserializeObject<List<Users>>(response);
                }
            }

            Assert.IsTrue(!(userInfo is null));
        }
    }
}
