using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mesajlasma_Platform.ViewModels
{
    public class TopluMesajlarModel
    {
        public int MesajId { get; set; }
        public string Icerik { get; set; }
        public DateTime MesajTarihi { get; set; }
    }
}