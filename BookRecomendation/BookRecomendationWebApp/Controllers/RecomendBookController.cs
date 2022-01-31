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
        BookRecomendationBL blObj;
        public RecomendBookController()
        {
            blObj = new BookRecomendationBL();
        }
        // GET: RecomendBook
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddReviews()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        
        public ActionResult DisplayResultsUsingWebAPI()
        {
            try
            {
                List<BookDTO> lstProduct = blObj.ShowReviewsForBook();
                List<BookViewModel> lstDeptModel = new List<BookViewModel>();
                foreach (var product in lstProduct)
                {
                    BookViewModel newObj = new BookViewModel();
                    newObj.author_id = product.author_id;
                    newObj.book_isbn = product.book_isbn;
                    newObj.title = product.title;
                    newObj.review = product.review;
                    lstDeptModel.Add(newObj);
                }
                return View(lstDeptModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
    }
}