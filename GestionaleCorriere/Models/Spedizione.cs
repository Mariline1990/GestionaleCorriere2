using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleCorriere.Models
{
    public class Spedizione
    {
        public int Id_spedizione { get; set; }


        [Display(Name = "Id Cliente")]
        [Required(ErrorMessage = "Id Cliente è obbligatorio")]
        public int Fk_Id_Cliente { get; set; }

        [Display(Name = "Codice di tracciamento")]
        [Required(ErrorMessage = "Codice di tracciamento è obbligatorio")]
        public string Cod_tracciamento { get; set; }

        [Display(Name = "Data spedizione")]
        [Required(ErrorMessage = "Data spedizione è obbligatorio")]
        public DateTime Data_spedizione { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Peso è obbligatorio")]
        public decimal Peso_spedizione { get; set; }

        [Display(Name = "Città di destinazione")]
        [Required(ErrorMessage = "Città di destinazione è obbligatorio")]
        public string Città_destinazione { get; set; }

        [Display(Name = "Indirizzo di destinazione")]
        [Required(ErrorMessage = "Indirizzo di destinazione è obbligatorio")]
        public string Indirizzo_destinazione { get; set; }

        [Display(Name = "Costo Spedizione")]
        [Required(ErrorMessage = "Costo Spedizione è obbligatorio")]
        public decimal Costo_spedizione { get; set; }
        [Display(Name = "Data di Consegna")]
        [Required(ErrorMessage = "Data di Consegna è obbligatorio")]
        public DateTime Data_consegna { get; set; }

        [Display(Name = "Nominativo destinatario")]
        [Required(ErrorMessage = "Nominativo destinatario è obbligatorio")] 
        public string Nominativo_destinatario { get; set; }
        [Display(Name = "Stato attuale")]
        [Required(ErrorMessage = "Lo stato è obbligatorio")]
        public string Stato_attuale { get; set; }
        [Display(Name = "Luogo")]
        [Required(ErrorMessage = "Il luogo è obbligatorio")]
        public string Luogo_attuale { get; set; }

        public Spedizione()
        {

        }
 

      public Spedizione(int id_spedizione, int fk_id_cliente, string cod_tracciamento, DateTime data_spedizione, decimal peso_spedizione, string città_destinazione,string indirizzo, decimal costo_spedizione, DateTime data_consegna, string nominativo_destinatario, string stato_attuale, string luogo_attuale)
        {
            Id_spedizione = id_spedizione;
            Fk_Id_Cliente = fk_id_cliente;
            Cod_tracciamento = cod_tracciamento;
            Data_spedizione = data_spedizione;
            Peso_spedizione = peso_spedizione;
            Città_destinazione = città_destinazione;
            Indirizzo_destinazione = indirizzo;
            Costo_spedizione = costo_spedizione;
            Data_consegna = data_consegna;
            Nominativo_destinatario = nominativo_destinatario;
            Stato_attuale= stato_attuale;
            Luogo_attuale= luogo_attuale;
        }

    }
}