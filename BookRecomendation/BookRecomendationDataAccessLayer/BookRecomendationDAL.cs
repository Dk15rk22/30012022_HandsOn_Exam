using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDTO;

namespace BookRecomendationDataAccessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookRecomendationDAL
    {
        SqlConnection conObj;
        SqlCommand cmdObj;
        public BookRecomendationDAL()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvWorksConnectionStr"].ConnectionString);
        }
        public List<BookDTO> FetchReviewsForBook()
        {
            try
            {
                cmdObj = new SqlCommand(@"select title,review,AVG(rating) from Books,Reviews where Books.book_isbn = Reviews.book_isbn and Books.title LIKE '%Little Prince%';
", conObj);
                conObj.Open();
                SqlDataReader drBook = cmdObj.ExecuteReader();

                List<BookDTO> lstBook = new List<BookDTO>();
                while (drBook.Read())
                {
                    BookDTO deptFromReader = new BookDTO();
                    deptFromReader.book_isbn = Convert.ToInt32(drBook["ListPrice"]); 
                    deptFromReader.title = drBook["title"].ToString();
                    deptFromReader.review = drBook["review"].ToString();
                    deptFromReader.author_id = Convert.ToInt32(drBook["ListPrice"]);
                    lstBook.Add(deptFromReader);

                }
                return lstBook;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conObj.Close();
            }
        }

        public void SaveReviewForBookToDB()
        {

        }

}
}
