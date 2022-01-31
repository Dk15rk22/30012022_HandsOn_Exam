using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookReviewsAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDTO;
using Moq;
using System.Net.Http;

namespace BookReviewsAPI.Controllers.Tests
{
    [TestClass()]
    public class BookReviewsControllerTests
    {
        [TestMethod()]
        public void GetRatingsForBookTest()
        {
            
                BookDTO expectedresult = new BookDTO();
                expectedresult.name = "Juice";
                expectedresult.color = "Orange";
                List<BookDTO> result = new List<BookDTO>();
                result.Add(expectedresult);

                Mock<IAdvWorksBL> mockobj = new Mock<IAdvWorksBL>();
                mockobj.Setup(x => x.fetchallproduct(10, 200)).Returns(result);

                MinMaxController controlobj = new MinMaxController(mockobj.Object);
                controlobj.Request = new HttpRequestMessage()
                {
                    Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()
                    }
                }
                };
                HttpResponseMessage actualresult = controlobj.Getallproduct(10, 200);

                List<ProductsDTO> lstactualobj = actualresult.Content.ReadAsAsync<List<ProductsDTO>>().Result;
                Assert.AreEqual(result, lstactualobj);
            }
    }
}