using Mesajlasma_Platform.Models;
using Mesajlasma_Platform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mesajlasma_Platform.Controllers
{
    public class ServisController : ApiController
    {
        Entities db = new Entities();
        SonucModel sonuc = new SonucModel();

        #region Kullanicilar

        [HttpGet]
        [Route("api/kullanicilistele")]
        public List<KullanicilarModel> KullaniciListele()
        {
            List<KullanicilarModel> liste = db.Kullanicilar.Select(x => new KullanicilarModel()
            {
                KullaniciId = x.kullaniciId,
                KullaniciAdi = x.kullaniciAdi,
                AdSoyad = x.adSoyad,
                Sifre = x.sifre,
                Eposta = x.eposta,
                Telefon = x.telefon,
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/kullanicibyid/{kullaniciId}")]
        public KullanicilarModel KullaniciById(int kullaniciId)
        {
            KullanicilarModel kullanici = db.Kullanicilar.Where(s => s.kullaniciId == kullaniciId).Select(x => new KullanicilarModel()
            {
                KullaniciId = x.kullaniciId,
                KullaniciAdi = x.kullaniciAdi,
                AdSoyad = x.adSoyad,
                Sifre = x.sifre,
                Eposta = x.eposta,
                Telefon = x.telefon
            }).FirstOrDefault();
            return kullanici;
        }

        [HttpPost]
        [Route("api/kullaniciekle")]
        public SonucModel KullaniciEkle(KullanicilarModel model)
        {
            if (db.Kullanicilar.Count(s => s.kullaniciAdi == model.KullaniciAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcı Kayıtlıdır";
                return sonuc;
            }
            Kullanicilar yeni = new Kullanicilar();
            yeni.kullaniciAdi = model.KullaniciAdi;
            yeni.adSoyad = model.AdSoyad;
            yeni.sifre = model.Sifre;
            yeni.eposta = model.Eposta;
            yeni.telefon = model.Telefon;
            db.Kullanicilar.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yeni kullanıcı Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kullaniciduzenle")]
        public SonucModel KullaniciDuzenle(KullanicilarModel model)
        {
            Kullanicilar kullanici = db.Kullanicilar.Where(s => s.kullaniciId == model.KullaniciId).FirstOrDefault();
            if (kullanici == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcı Bulunamadı";
                return sonuc;
            }
            kullanici.kullaniciAdi = model.KullaniciAdi;
            kullanici.adSoyad = model.AdSoyad;
            kullanici.sifre = model.Sifre;
            kullanici.eposta = model.Eposta;
            kullanici.telefon = model.Telefon;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Güncellendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kullanicisil/{kullaniciId}")]
        public SonucModel KullaniciSil(int kullaniciId)
        {
            Kullanicilar kullanici = db.Kullanicilar.Where(s => s.kullaniciId == kullaniciId).FirstOrDefault();
            if (kullanici == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcı Bulunamadı";
                return sonuc;
            }
            db.Kullanicilar.Remove(kullanici);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Silindi";
            return sonuc;
        }

        #endregion


        #region Gruplar

        [HttpGet]
        [Route("api/gruplistele")]
        public List<GruplarModel> GrupListele()
        {
            List<GruplarModel> liste = db.Gruplar.Select(x => new GruplarModel()
            {
                GrupId = x.grupId,
                GrupAdi = x.grupAdi
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/grupbyid/{grupId}")]
        public GruplarModel GrupById(int grupId)
        {
            GruplarModel grup = db.Gruplar.Where(s => s.grupId == grupId).Select(x => new GruplarModel()
            {
                GrupId = x.grupId,
                GrupAdi = x.grupAdi
            }).FirstOrDefault();
            return grup;
        }

        [HttpPost]
        [Route("api/grupekle")]
        public SonucModel GrupEkle(GruplarModel model)
        {
            if (db.Gruplar.Count(s => s.grupAdi == model.GrupAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Grup Mevcuttur";
                return sonuc;
            }
            Gruplar yeni = new Gruplar();
            yeni.grupAdi = model.GrupAdi;
            yeni.olusturanId = model.OlusturanId;
            db.Gruplar.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yeni grup Oluşturuldu";
            return sonuc;
        }

        [HttpPut]
        [Route("api/grupduzenle")]
        public SonucModel GrupDuzenle(GruplarModel model)
        {
            Gruplar grup = db.Gruplar.Where(s => s.grupId == model.GrupId).FirstOrDefault();
            if (grup == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Grup Bulunamadı";
                return sonuc;
            }
            grup.grupAdi = model.GrupAdi;
            grup.olusturanId = model.OlusturanId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Grup Adı Güncellendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/grupsil/{grupId}")]
        public SonucModel GrupSil(int grupId)
        {
            Gruplar grup = db.Gruplar.Where(s => s.grupId == grupId).FirstOrDefault();
            if (grup == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Grup Bulunamadı";
                return sonuc;
            }
            db.Gruplar.Remove(grup);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Grup Silindi";
            return sonuc;
        }

        #endregion


        #region GrupUyeleri

        [HttpGet]
        [Route("api/grupuyeListele")]
        public List<GrupUyeleriModel> GrupUyeListele()
        {
            List<GrupUyeleriModel> liste = db.GrupUyeleri.Select(x => new GrupUyeleriModel()
            {
                GrupUyeId = x.grupUyeId,
                GrupId = x.grupId,
                UyeId = x.uyeId,
                UyeAdi = x.Kullanicilar.adSoyad,
                GrupAdi = x.Gruplar.grupAdi
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/grupuyebyid/{grupUyeId}")]
        public GrupUyeleriModel GrupUyeById(int grupUyeId)
        {
            GrupUyeleriModel grupUye = db.GrupUyeleri.Where(s => s.grupUyeId == grupUyeId).Select(x => new GrupUyeleriModel()
            {
                GrupUyeId = x.grupUyeId,
                GrupId = x.grupId,
                UyeId = x.uyeId,
                UyeAdi = x.Kullanicilar.adSoyad,
                GrupAdi = x.Gruplar.grupAdi

            }).FirstOrDefault();
            return grupUye;
        }

        [HttpGet]
        [Route("api/grupuyeleri/{grupId}")]
        public List<GrupUyeleriModel> GrupUyeleriById(int grupId)
        {
            List<GrupUyeleriModel> grupUyeleri = db.GrupUyeleri.Where(g => g.grupId == grupId).Select(x => new GrupUyeleriModel()
            {
                GrupUyeId = x.grupUyeId,
                GrupId = x.grupId,
                UyeId = x.uyeId,
                UyeAdi = x.Kullanicilar.adSoyad,
                GrupAdi = x.Gruplar.grupAdi
            }).ToList();
            return grupUyeleri;
        }


        [HttpPost]
        [Route("api/grupuyeekle")]
        public SonucModel GrupUyeEkle(List<GrupUyeleri> model)
        {
            foreach (var item in model)
            {
                GrupUyeleri yeni = new GrupUyeleri();
                yeni.grupId = item.grupId;
                yeni.uyeId = item.uyeId;
                db.GrupUyeleri.Add(yeni);
            }
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Grup Üyeleri Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/grupuyeduzenle")]
        public SonucModel GrupUyeDuzenle(GrupUyeleri model)
        {
            GrupUyeleri grupUye = db.GrupUyeleri.Where(s => s.grupUyeId == model.grupUyeId).FirstOrDefault();
            if (grupUye == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Grup Üye Bulunamadı";
                return sonuc;
            }
            grupUye.grupId = model.grupId;
            grupUye.uyeId = model.uyeId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Grup Üye Güncellendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/grupuyesil/{grupUyeId}")]
        public SonucModel GrupUyeSil(int grupUyeId)
        {
            GrupUyeleri grupUye = db.GrupUyeleri.Where(s => s.grupUyeId == grupUyeId).FirstOrDefault();
            if (grupUye == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Grup Üye Bulunamadı";
                return sonuc;
            }
            db.GrupUyeleri.Remove(grupUye);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Grup Üye Silindi";
            return sonuc;
        }

        #endregion


        #region Mesajlar

        [HttpGet]
        [Route("api/mesajlistele")]
        public List<MesajlarModel> MesajListele()
        {
            List<MesajlarModel> liste = db.Mesajlar.Select(x => new MesajlarModel()
            {
                MesajId = x.mesajId,
                Icerik = x.icerik,
                MesajTarihi = x.mesajTarihi,
                GonderenId = x.gonderenId,
                AliciId = x.aliciId,
                GrupId = x.grupId,
                GonderenAdi = x.Kullanicilar.adSoyad,
                AliciAdi = x.Kullanicilar1.adSoyad,
                GrupAdi = x.Gruplar.grupAdi
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/mesajbyid/{mesajId}")]
        public MesajlarModel MesajById(int mesajId)
        {
            MesajlarModel mesaj = db.Mesajlar.Where(s => s.mesajId == mesajId).Select(x => new MesajlarModel()
            {
                MesajId = x.mesajId,
                Icerik = x.icerik,
                MesajTarihi = x.mesajTarihi,
                GonderenId = x.gonderenId,
                AliciId = x.aliciId,
                GrupId = x.grupId,
                GonderenAdi = x.Kullanicilar.adSoyad,
                AliciAdi = x.Kullanicilar1.adSoyad,
                GrupAdi = x.Gruplar.grupAdi
            }).FirstOrDefault();
            return mesaj;
        }

        [HttpPost]
        [Route("api/mesajekle")]
        public SonucModel MesajEkle(MesajlarModel model)
        {
            Mesajlar yeniMesaj = new Mesajlar()
            {
                icerik = model.Icerik,
                mesajTarihi = DateTime.Now,
                gonderenId = model.GonderenId,
                aliciId = model.AliciId,
                grupId = model.GrupId
            };

            db.Mesajlar.Add(yeniMesaj);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Mesaj Gönderildi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/mesajduzenle")]
        public SonucModel MesajDuzenle(MesajlarModel model)
        {
            Mesajlar mesaj = db.Mesajlar.FirstOrDefault(u => u.mesajId == model.MesajId);

            if (mesaj == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Mesaj Bulunamadı";
                return sonuc;
            }

            mesaj.icerik = model.Icerik;
            mesaj.mesajTarihi = model.MesajTarihi;
            mesaj.gonderenId = model.GonderenId;
            mesaj.aliciId = model.AliciId;
            mesaj.grupId = model.GrupId;

            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Mesaj Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/mesajsil/{mesajId}")]
        public SonucModel MesajSil(int mesajId)
        {
            Mesajlar mesaj = db.Mesajlar.FirstOrDefault(u => u.mesajId == mesajId);

            if (mesaj == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Mesaj Bulunamadı";
                return sonuc;
            }

            db.Mesajlar.Remove(mesaj);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Mesaj Silindi";
            return sonuc;
        }

        #endregion


        #region TopluMesajlar

        [HttpGet]
        [Route("api/toplumesajlistele")]
        public List<TopluMesajlarModel> TopluMesajListele()
        {
            List<TopluMesajlarModel> liste = db.Mesajlar.Select(x => new TopluMesajlarModel()
            {
                MesajId = x.mesajId,
                Icerik = x.icerik,
                MesajTarihi = x.mesajTarihi
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/toplumesajbyid/{mesajId}")]
        public TopluMesajlarModel TopluMesajById(int mesajId)
        {
            TopluMesajlarModel mesaj = db.Mesajlar.Where(s => s.mesajId == mesajId).Select(x => new TopluMesajlarModel()
            {
                MesajId = x.mesajId,
                Icerik = x.icerik,
                MesajTarihi = x.mesajTarihi
            }).FirstOrDefault();
            return mesaj;
        }

        [HttpPost]
        [Route("api/toplumesajekle")]
        public SonucModel TopluMesajEkle(TopluMesajlarModel model)
        {
            TopluMesajlar yeniMesaj = new TopluMesajlar()
            {
                icerik = model.Icerik,
                mesajTarihi = DateTime.Now
            };

            db.TopluMesajlar.Add(yeniMesaj);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "";
            return sonuc;
        }

        [HttpPut]
        [Route("api/toplumesajduzenle")]
        public SonucModel TopluMesajDuzenle(TopluMesajlarModel model)
        {
            TopluMesajlar mesaj = db.TopluMesajlar.FirstOrDefault(u => u.mesajId == model.MesajId);

            if (mesaj == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Mesaj Bulunamadı";
                return sonuc;
            }

            mesaj.icerik = model.Icerik;
            mesaj.mesajTarihi = model.MesajTarihi;

            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Toplu Mesaj Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/toplumesajsil/{mesajId}")]
        public SonucModel TopluMesajSil(int mesajId)
        {
            TopluMesajlar mesaj = db.TopluMesajlar.FirstOrDefault(u => u.mesajId == mesajId);

            if (mesaj == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Mesaj Bulunamadı";
                return sonuc;
            }

            db.TopluMesajlar.Remove(mesaj);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Toplu Mesaj Silindi";
            return sonuc;
        }

        #endregion


        #region TopluMesajAlicilar

        [HttpGet]
        [Route("api/toplumesajalicilarlistele")]
        public List<TopluMesajAlicilarModel> TopluMesajAlicilarListele()
        {
            List<TopluMesajAlicilarModel> liste = db.TopluMesajAlicilar.Select(x => new TopluMesajAlicilarModel()
            {
                Id = x.id,
                MesajId = x.mesajId,
                AliciId = x.aliciId,
                MesajAdi = x.TopluMesajlar.icerik,
                AliciAdi = x.Kullanicilar.adSoyad
            }).ToList();
            return liste;
        }

        [HttpPost]
        [Route("api/toplumesajalicilarekle")]
        public SonucModel TopluMesajAlicilarEkle(TopluMesajAlicilarModel model)
        {
            foreach (var aliciId in model.AliciIds)
            {
                TopluMesajAlicilar yeniAlici = new TopluMesajAlicilar()
                {
                    mesajId = model.MesajId,
                    aliciId = aliciId
                };

                db.TopluMesajAlicilar.Add(yeniAlici);
            }

            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Alicilar Eklendi";
            return sonuc;
        }


        [HttpDelete]
        [Route("api/toplumesajalicilarsil/{id}")]
        public SonucModel TopluMesajAlicilarSil(int id)
        {
            TopluMesajAlicilar alici = db.TopluMesajAlicilar.FirstOrDefault(u => u.id == id);

            if (alici == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Alıcı Bulunamadı";
                return sonuc;
            }

            db.TopluMesajAlicilar.Remove(alici);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Alıcı Silindi";
            return sonuc;
        }

        #endregion


    }
}
