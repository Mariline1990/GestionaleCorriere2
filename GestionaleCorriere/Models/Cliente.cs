using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static GestionaleCorriere.ControlloCF;

namespace GestionaleCorriere.Models
{
    public class Cliente
    {


        [Display(Name = "Id Cliente")]
        public int Id_cliente { get; set; } 

        public string Nominativo { get; set; }

        [Display(Name = "Id Azienda")]

        
        public bool is_Azienda { get; set; }
        public string Partita_IVA { get; set; }



        [StringLength(16, MinimumLength = 16, ErrorMessage = "La password deve essere di almeno 16 caratteri")]
        [Required(ErrorMessage = "cf è obbligatorio")]
        [ControlloCF]

        public string Codice_Fiscale { get; set; }


        public Cliente()
        {

        }
        public Cliente(int id_cliente, string nominativo, bool is_azienda, string partita_IVA, string codice_fiscale)
        {
            Id_cliente = id_cliente;
            Nominativo = nominativo;
            is_Azienda = is_azienda;
            Partita_IVA = partita_IVA;
            Codice_Fiscale = codice_fiscale;
        }   
    }
}