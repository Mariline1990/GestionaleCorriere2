using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionaleCorriere.Controllers
{
    public class UtenteController : Controller
    {
        // GET: Login
        public ActionResult Utente()
        {
            return View();
        }

        public ActionResult DatiCancellati()
        {
           


            return RedirectToAction("Home page");
        }


        [HttpPost]
        public ActionResult Utente(Utente user)
        {
            TempData["Messaggio"] = "La tua sessione è finita, accedi di nuovo!";
           
            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            try
            {
                string query = "SELECT * FROM log_in WHERE Utente = @Utente AND Password = @Password";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Utente", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    conn.Close();
                    ViewBag.AuthError = "Autenticazione non riuscita";
                    return View();

                }
            }
            catch (Exception ) { 
              
                return View();
            
            }
            finally { conn.Close(); }

          


        }

        [HttpPost]
        public ActionResult Delete()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }
      


    }
}