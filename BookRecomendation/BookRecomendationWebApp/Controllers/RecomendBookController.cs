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


        [HttpPost]
        public void AddReviews(BookViewModel fromUI)
        {
            try
            {
                if (fromUI != null)
                {
                    BookDTO NewProd = new BookDTO();
                    NewProd.book_isbn = fromUI.book_isbn;
                    NewProd.title = fromUI.title;
                    NewProd.review = fromUI.review;
                    NewProd.author_id = fromUI.author_id;
                    int newBookId = 0;
                    int retVal = blObj.Addnewprod(NewProd, out newBookId);
                    if (retVal == 1)
                    {
                        return RedirectToAction("DisplayAllProduct");
                    }
                    else
                    {
                        return View("Error");
                    }
                    //return RedirectToAction("Success");
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