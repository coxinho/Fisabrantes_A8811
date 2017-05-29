using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fisabrantes.Models
{
    public class Utentes
    {

        public Utentes()
        {
            ListaDeConsultasAoUtente = new HashSet<Consultas>();
        }


        [Key]
        public int idUtente { get; set; }

        //[Column(TypeName = "Nome")]
        public string Nome { get; set; }

        //[Column(TypeName = "DataNasc")]
        public DateTime DataNasc { get; set; }

        //[Column(TypeName = "NIF")]
        public string NIF { get; set; }

        //[Column(TypeName = "Telefone")]
        public string Telefone { get; set; }

        //[Column(TypeName = "Morada")]
        public string Morada { get; set; }

        public string CodPostal { get; set; }

        // [Column(TypeName = "SNS")]
        public string SNS { get; set; }

        //**************************************************************************
        // lista das Consultas associadas ao Utente
        public virtual ICollection<Consultas> ListaDeConsultasAoUtente { get; set; }

    }
}