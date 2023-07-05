using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mesajlasma_Platform.ViewModels
{
    public class GrupUyeleriModel
    {
        public int GrupUyeId { get; set; }
        public int GrupId { get; set; }
        public int UyeId { get; set; }

        public string GrupAdi { get; set; }
        public string UyeAdi { get; set; }


    }
}