using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookRecomendationBusinessLayer;
using BookRecomendationDTO;
using BookRecomendationWebApp.Models;
using Newtonsoft.Json;

namespace BookRecomendationWebApp.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class RecomendBookController : Controller
    {
        // GET: RecomendBook
        public ActionResult Index()
        {
            return View();
        }



        public void AddReviews()
        {

        }

        public ViewResult DisplayResultsUsingWebAPI()
        {
            try
            {
                string baseURL = "http://localhost:55577/";
                string routeURL = @"api/Book/ShowReviewsForBook";
                var apiClient = new HttpClient();
                apiClient.BaseAddress = new Uri(baseURL);
                apiClient.DefaultRequestHeaders.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage apiResponse = await apiClient.GetAsync(routeURL);
                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = apiResponse.Content.ReadAsStringAsync().Result;
                    List<ProductViewModel> lstAllProds = new List<ProductViewModel>();
                    var finalResult = JsonConvert.DeserializeObject<List<ProductViewModel>>(result);
                    return View(finalResult);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
    }
}