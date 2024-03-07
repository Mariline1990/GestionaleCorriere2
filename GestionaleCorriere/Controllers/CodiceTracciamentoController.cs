using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionaleCorriere.images
{
    public class CodiceTracciamentoController : Controller
    {
        // GET: CodiceTracciamento
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CodiceTracciamento()
        {

       

            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            try
            {
                

                SqlCommand cmd = new SqlCommand("Stampa_aggiornamento4", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODICE_FISCALE", Request.QueryString["CF"]);
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie("CF", false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    conn.Close();
                    ViewBag.AuthError = "Autenticazione non riuscita";
                    return View();

                }
            }
            catch (Exception)
            {

                return View();

            }
            finally { conn.Close(); }



        }
    }
}