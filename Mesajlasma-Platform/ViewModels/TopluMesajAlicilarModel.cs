using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mesajlasma_Platform.ViewModels
{
    public class TopluMesajAlicilarModel
    {
        public int Id { get; set; }
        public int MesajId { get; set; }
        public List<int> AliciIds { get; set; }
        public int AliciId { get; set; }
        public string MesajAdi { get; set; }
        public string AliciAdi { get; set; }
    }
}