using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mesajlasma_Platform.ViewModels
{
    public class MesajlarModel
    {
        public int MesajId { get; set; }
        public string Icerik { get; set; }
        public DateTime MesajTarihi { get; set; }
        public int GonderenId { get; set; }
        public int? AliciId { get; set; }
        public int? GrupId { get; set; }

        public string GonderenAdi { get; set; }
        public string AliciAdi { get; set; }
        public string GrupAdi { get; set; }
    }
}