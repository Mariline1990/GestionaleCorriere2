using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult List()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();



                cmd.CommandText = "SELECT * FROM Spedizione";
                SqlDataReader reader = cmd.ExecuteReader();
                Response.Write(reader);

                List<Spedizione> Ordini = new List<Spedizione>();

                while (reader.Read())
                {

                    Spedizione ordine = new Spedizione
                    {


                        
                        Cod_tracciamento = reader["COD_TRACCIAMENTO"].ToString(),
                        Data_spedizione = Convert.ToDateTime(reader["DATA_SPEDIZIONE"]),                       
                        Città_destinazione = reader["CITTA_DESTINAZIONE"].ToString(),
                        Indirizzo_destinazione = reader["INDIRIZZO_DESTINAZIONE"].ToString(),
                        Data_consegna = Convert.ToDateTime(reader["DATA_CONSEGNA"]),
                        Nominativo_destinatario = reader["NOMINATIVO_DESTINATARIO"].ToString(),
                        Costo_spedizione = Convert.ToDecimal(reader["COSTO_SPEDIZIONE"]),
                        Stato_attuale = reader["STATO"].ToString(),
                        Luogo_attuale = reader["LUOGO"].ToString(),



                    };

                    Ordini.Add(ordine);
                }

                return View(Ordini);
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
        }
        public ActionResult Edit()
        {
            return View();
        }


    }
}