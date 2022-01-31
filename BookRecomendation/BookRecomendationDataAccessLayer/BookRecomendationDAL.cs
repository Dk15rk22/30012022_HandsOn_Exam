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

        public int SaveReviewForBookToDB(BookDTO bookobj, out int bookid)
        {
            try
            {
                cmdObj = new SqlCommand();
                cmdObj.CommandText = @"uspAddNewProd";
                cmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                cmdObj.Connection = conObj;
                cmdObj.Parameters.AddWithValue("@book_isbn", bookobj.book_isbn);
                cmdObj.Parameters.AddWithValue("@title", bookobj.title);
                cmdObj.Parameters.AddWithValue("@review", bookobj.review);
                cmdObj.Parameters.AddWithValue("@author_id", bookobj.author_id);
                SqlParameter returnvalue = new SqlParameter();
                returnvalue.Direction = ParameterDirection.ReturnValue;
                returnvalue.SqlDbType = SqlDbType.Int;
                cmdObj.Parameters.Add(returnvalue);
                SqlParameter outputValue = new SqlParameter();
                outputValue.Direction = ParameterDirection.Output;
                outputValue.SqlDbType = SqlDbType.Int;
                outputValue.ParameterName = "@author_id";
                cmdObj.Parameters.Add(outputValue);
                conObj.Open();
                cmdObj.ExecuteNonQuery();
                bookid = Convert.ToInt32(outputValue.Value);
                return Convert.ToInt32(returnvalue.Value);

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

}
}
