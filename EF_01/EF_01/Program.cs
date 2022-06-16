using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToList metodu ile Bölümleri Listele
            void BolumleriListele()
            {
                
                HastaneSabahEntities hastane = new HastaneSabahEntities();
                var bolumler = hastane.Bolumler.ToList();
                Console.WriteLine($"Bölüm ID\tBolum Adı");
                foreach (var bolum in bolumler)
                {
                    Console.WriteLine($"{bolum.ID}\t\t{bolum.BolumAd}");
                }
                Console.ReadLine();
            }


            //Where ile sorgulama, Diş bölümünü getir 
            void BolumGetir()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    //var sonuc = hastane.Bolumler.Where(x => x.BolumAd == "Diş");
                    var sonuc = hastane.Bolumler.Where(x => x.BolumAd.StartsWith("D"));
                    foreach (var item in sonuc)
                    {
                        Console.WriteLine($"Bölüm ID: {item.ID} Bölüm Ad: {item.BolumAd}");
                    }
                    Console.ReadLine();
                }
            }

            
            //Select ile veri çekme
            void DoktorAdListele()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var adlar = hastane.Doktorlar.Select(x => x.AdSoyad);
                    Console.WriteLine($"Doktor ADI:");
                    foreach (var ad in adlar)
                    {
                        Console.WriteLine(ad);
                    }
                }
                Console.ReadLine();
            }


            //Find ile hızlı arama yapma
            void HizliAra()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    Doktorlar doktor = hastane.Doktorlar.Find(4);
                    //Find metodu ilgili tablodaki primary key üzerinden arama yapar.
                    //Bu da onu oldukça hızlı hale getirir.
                    Console.WriteLine($"Doktor Adı: {doktor.AdSoyad} \nBölümü: {doktor.Bolumler.BolumAd}");
                }
                Console.ReadLine();
            }


            //İlk kaydı getirme, ilk Demet Evgar ' ı getir
            void IlkKayit()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    Doktorlar doktor = hastane.Doktorlar
                        .Where(x => x.AdSoyad == "Demet Evgar")
                        .First();
                    Console.WriteLine($"Doktor Ad: {doktor.AdSoyad} Bolum Ad: {doktor.Bolumler.BolumAd}");
                }
                Console.ReadLine();
            }


            //İlk Üç doktoru getir
            void IlkUcDoktor()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var ilkUcDoktor = hastane.Doktorlar.Take(3);
                    foreach (var doktor in ilkUcDoktor)
                    {
                        Console.WriteLine($"{doktor.AdSoyad}");
                    }
                    Console.ReadLine();
                }
            }


            //Var mı?
            void Varmi()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    bool sonuc = hastane.Doktorlar.Any(x => x.AdSoyad == "Demet Evgar");
                    if (sonuc)
                    {
                        Console.WriteLine("doktor var");
                    }
                    else
                    {
                        Console.WriteLine("doktor yok");
                    }
                }
                Console.ReadLine();
            }


            //Uygunluk var mı?
            void UyuyorMu()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    bool sonuc = hastane.Doktorlar.All(x => x.Bolumler.BolumAd == "Dahiliye");
                    if (sonuc)
                    {
                        Console.WriteLine("evet tümü uygun");
                    }
                    else
                    {
                        Console.WriteLine("Hayır uymayanlar var");
                    }
                }
                Console.ReadLine();
            }


            //Ascending sıralama, A dan Z ye , küçükten büyüğe
            void SiralaAsc()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var siraliDoktorlar = hastane.Doktorlar.OrderBy(x => x.AdSoyad);
                    foreach (var doktor in siraliDoktorlar)
                    {
                        Console.WriteLine(doktor.AdSoyad);
                    }
                }
                Console.ReadLine();
            }


            //Descanding sıralama, z den a ya
            void SiralaDesc()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var tersSiraliDoktorlar = hastane.Doktorlar.OrderByDescending(x=>x.AdSoyad);
                    foreach (var doktor in tersSiraliDoktorlar)
                    {
                        Console.WriteLine(doktor.AdSoyad);
                    }
                }
                Console.ReadLine();
            }


            //Son üç doktoru getir
            void SonUcDoktor()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var sonUcDoktor = hastane.Doktorlar.OrderByDescending(x => x.ID).Take(3);
                    foreach (var item in sonUcDoktor)
                    {
                        Console.WriteLine(item.AdSoyad);

                    }
                }
                Console.ReadLine();
            }


            //Bölümlere göre doktor sayısı
            void BolumlereGoreDoktorSayisiniGetir()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var sonuc = hastane.Doktorlar
                        .GroupBy(a => a.Bolumler.BolumAd)
                        .Select(b => new
                        {
                            name = b.Key,
                            count = b.Count()
                        }); ;
                    Console.WriteLine($"Bölüm\tDoktor Sayısı");

                    foreach (var item in sonuc)
                    {
                        Console.WriteLine($"{item.name}\t{item.count}");
                    }
                }
                Console.ReadLine();
            }


            //BolumleriListele();
            //BolumGetir();
            //DoktorAdListele();
            //HizliAra();
            //IlkUcDoktor();
            //Varmi();
            //UyuyorMu();
            //SiralaAsc();
            //SiralaDesc();
            //SonUcDoktor();
            //BolumlereGoreDoktorSayisiniGetir();
        }
    }
}
