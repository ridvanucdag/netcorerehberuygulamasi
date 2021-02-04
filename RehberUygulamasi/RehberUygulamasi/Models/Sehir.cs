using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehberUygulamasi.Models
{
    [Table("Sehirler")]
    public class Sehir
    {
        public int Id { get; set; }
        public string SehirAdi { get; set; }
        public int SehirKodu { get; set; }
    }
}
