using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        // GET: Cliente

       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente model)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {

                string query = "INSERT INTO Cliente (NOMINATIVO, IS_AZIENDA , CF, P_IVA) VALUES ( @nominativo, @is_azienda, @cf,@p_iva)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nominativo", model.Nominativo);
                cmd.Parameters.AddWithValue("@is_azienda", model.is_Azienda);
                cmd.Parameters.AddWithValue("@cf", model.Codice_Fiscale);
                cmd.Parameters.AddWithValue("@p_iva", model.Partita_IVA);
          

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("Errore nella richiesta SQL");
                return View(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            TempData["Messaggio"] = "Cliente inserito correttamente";
            return View();

        }
    }
}