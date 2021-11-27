using API_27_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace API_27_Client.Controllers
{
    public class ProductsController : Controller
    {
        string baseaddress = "https://localhost:44353/api/";
        HttpClient httpClient = new HttpClient();
        // GET: Products
        public ActionResult Index()
        {
            httpClient.BaseAddress = new Uri(baseaddress);

            var requestedData = httpClient.GetAsync("Products");
            requestedData.Wait();
            var result = requestedData.Result;
            if (result.IsSuccessStatusCode)
            {
                var instituteInfo = result.Content.ReadAsAsync<Product[]>();
                instituteInfo.Wait();
                var model = instituteInfo.Result;
                return View(model);
            }
            return View();
            
        }
    }
}