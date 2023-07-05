using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mesajlasma_Platform.ViewModels
{
    public class KullanicilarModel
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdSoyad { get; set; }
        public string Sifre { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }

        
    }
}