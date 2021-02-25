using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DAirlines
    {
        [Key]
        public int id {get; set;}
        [Column(TypeName="nvarchar(100)")]
        public string airlinename { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string noofdesti { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string slogan { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string headquar { get; set; }

    }
}
