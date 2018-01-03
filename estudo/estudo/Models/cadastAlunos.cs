using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace estudo.Models
{
    public class cadastAlunos
    {
        [Key]
        public int ID { get; set; }
        public string nome { get; set; }
        public DateTime dataNasc { get; set; }
        public string RG { get; set; }
        public string RA { get; set; }
    }
}