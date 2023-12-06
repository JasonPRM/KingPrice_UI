using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using KingPrice_UI.Models;
using System.Configuration;
using System.Text;

namespace KingPrice_UI.Controllers
{
    public class UsersController : Controller
    {
        string Baseurl = ConfigurationManager.AppSettings["KingPriceAPIURL"];

        // GET: Users
        public async Task<ActionResult> Index()
        {
            List<Users> userInfo = new List<Users>();
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

                //returning the user list to view
                return View(userInfo);
            }
        }

        public ActionResult AddUserView()
        {
            return View("AddUser");
        }

        public async Task<ActionResult> EditUserView(int ID)
        {
            Users userInfo = new Users();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllUsers using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Users/GetUserByID/" + ID.ToString());
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Users list
                    userInfo = JsonConvert.DeserializeObject<Users>(response);

                    return View("EditUser", userInfo);
                }
                else
                {
                    return View("Error");
                }
            } 
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(Users user)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent cntnt = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/Users/AddUser", cntnt);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //returning the user list to view
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public async Task<ActionResult> EditUser(Users user)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent cntnt = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync("api/Users/UpdateUser", cntnt);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //returning the user list to view
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public async Task<ActionResult> DeleteUser(int ID)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.DeleteAsync("api/Users/DeleteUser/" + ID.ToString());
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //returning the user list to view
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }
}