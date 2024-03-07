using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionaleCorriere.Models
{
    public class CodiceTracciamento
    {
        
            public string CF { get; set; }
            
            public string PartitaIva{ get; set; }

            public string CodiceDiTracciamento { get; set; }

            public CodiceTracciamento()
            {
                
            }

            public CodiceTracciamento( string partitaIva ,string codice_fiscale, string tracciamento )
            {
                CF = codice_fiscale;
                PartitaIva = partitaIva;
                CodiceDiTracciamento = tracciamento;
            }   

        
    }
}