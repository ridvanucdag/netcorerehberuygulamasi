using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberUygulamasi.Models
{
    public class KisiGuncelle
    {
        public Kisi Kisi { get; set; }
        public List<Sehir> Sehirler { get; set; }
    }
}
