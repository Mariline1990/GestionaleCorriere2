﻿using GestionaleCorriere.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionaleCorriere.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpedizioneController : Controller
    {
        // GET: Spedizione

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
        public ActionResult Create(Spedizione model)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Gestionale"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {

                string query = "INSERT INTO Spedizione (FK_ID_CLIENTE, COD_TRACCIAMENTO , DATA_SPEDIZIONE, PESO_SPEDIZIONE, CITTA_DESTINAZIONE, INDIRIZZO_DESTINAZIONE, COSTO_SPEDIZIONE, DATA_CONSEGNA, NOMINATIVO_DESTINATARIO) VALUES " +
                    "( @fk_cliente, @cod_tracciamento, @data_spe, @peso, @citta_destinazione,@indirizzo, @costo_spe, @data_consegna, @nom_destinazione)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fk_cliente", model.Fk_Id_Cliente);
                cmd.Parameters.AddWithValue("@cod_tracciamento", model.Cod_tracciamento);
                cmd.Parameters.AddWithValue("@data_spe", model.Data_spedizione);
                cmd.Parameters.AddWithValue("@peso", model.Peso_spedizione);
                cmd.Parameters.AddWithValue("@citta_destinazione", model.Città_destinazione);
                cmd.Parameters.AddWithValue("@indirizzo", model.Indirizzo_destinazione);
                cmd.Parameters.AddWithValue("@costo_spe", model.Costo_spedizione);
                cmd.Parameters.AddWithValue("@data_consegna", model.Data_consegna);
                cmd.Parameters.AddWithValue("@nom_destinazione", model.Nominativo_destinatario);


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

            return View();


        }
    }
}