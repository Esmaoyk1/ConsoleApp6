using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Kac tane tapu var:");
            int tapusayisi = Convert.ToInt32(Console.ReadLine());
            Tapu[] t = new Tapu[tapusayisi];


            for (int i = 0; i < tapusayisi; i++)
            {
                Console.WriteLine((i + 1) + ". tapuda Kaç ortak var?");
                int ortak = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("ada bilgisini giriniz");
                int ada = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("parsel bilgisini giriniz");
                int parsel = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("miktar bilgisini giriniz");
                int miktar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("edinme tarihi bilgisini giriniz(orn:15032003)");
                int edinmetarihi = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("nasıl alındı bilgisini giriniz(1-0)");
                int nasılalındı = Convert.ToInt32(Console.ReadLine());

                string X;
                if (nasılalındı == 1)
                {
                    X = "Miras alındı";
                }
                else
                {
                    X = "Para ile alındı";
                }


                t[i] = new Tapu(ortak);
                t[i].tapuekle(ada, parsel, edinmetarihi, miktar, nasılalındı);

                Console.WriteLine("ada:{0} parsel:{1} miktar:{2} ", ada, parsel, miktar);
                Kisi[] k = new Kisi[ortak];

                for (int j = 0; j < ortak; j++)
                {
                    Console.WriteLine("{0}. sahibi Adınızı Giriniz: ", j + 1);
                    string adi = Console.ReadLine();
                    Console.WriteLine("Soyadınızı Giriniz: ");
                    string soyadi = Console.ReadLine();
                    Console.WriteLine("Doğum Yılınızı Giriniz: ");
                    int dogumyili = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("TC Numaranızı Giriniz: ");
                    int tcno = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("edinme tarihi bilgisini giriniz(orn:01012000)");
                    int edinmetarihi1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("nasıl alındı bilgisini giriniz(1-0)");
                    int nasılalındı1 = Convert.ToInt32(Console.ReadLine());
                    k[j] = new Kisi();
                    t[i].kisiekle(adi, soyadi, dogumyili, tcno, j);
                    k[j].kisiekle(adi, soyadi, dogumyili, tcno);
                    Console.WriteLine("{0}  alım tarihi:{1} alım nedeni:{2} kaçıncı sahibi:{3}", k[j].Sifrele(), edinmetarihi1, X, j + 1);
              
                }
                Console.ReadLine();

            }
        }


        public class Tapu
        {
            private int ada;
            private int parsel;
            private int edim_tarihi;
            private int edim_miktari;

            private int nasilalindi;
            public int ortak;

            public Kisi[] k;


            public Tapu(int kacadetortakvar)
            {
                k = new Kisi[kacadetortakvar + 1];
                this.ortak = kacadetortakvar;

            }

            public void tapuekle(int ada, int parsel, int edim_tarihi, int edim_miktari, int nasilalindi)
            {
                this.ada = ada;
                this.parsel = parsel;
                this.edim_tarihi = edim_tarihi;
                this.edim_miktari = edim_miktari;
                this.nasilalindi = nasilalindi;
            }


            public void kisiekle(string ad, string soyad, int dogumYili, int tc_kimlikNo, int sahiplikbilgisi)
            {
                k[sahiplikbilgisi] = new Kisi();
                k[sahiplikbilgisi].kisiekle(ad, soyad, dogumYili, tc_kimlikNo);
            }

            public void ekrandagoster(Tapu kacincitapu, int kacincisahip)
            {
                Console.WriteLine(kacincitapu.ada);
                Console.WriteLine(kacincitapu.parsel);
                Console.WriteLine(kacincitapu.edim_tarihi);
                Console.WriteLine(kacincitapu.edim_miktari);

                Console.Write(kacincitapu.k[kacincisahip].getad()[0]);
                for (int i = 1; i < kacincitapu.k[kacincisahip].getad().Length - 1; i++)
                {
                    Console.Write("*");
                }
                Console.Write(kacincitapu.k[kacincisahip].getad()[kacincitapu.k[kacincisahip].getad().Length - 1]);
                Console.WriteLine();


                Console.Write(kacincitapu.k[kacincisahip].getsoyad()[0]);
                for (int i = 1; i < kacincitapu.k[kacincisahip].getsoyad().Length - 1; i++)
                {
                    Console.Write("*");
                }
                Console.Write(kacincitapu.k[kacincisahip].getsoyad()[kacincitapu.k[kacincisahip].getsoyad().Length - 1]);
                Console.WriteLine();


                Console.WriteLine(kacincitapu.k[kacincisahip].getdogumYili());
                Console.WriteLine(kacincitapu.k[kacincisahip].gettc_kimlikNo());

            }

        }

        public class Kisi
        {
            private string ad;
            private string soyad;
            private int dogumYili;
            private int tc_kimlikNo;

            public void kisiekle(string ad, string soyad, int dogumYili, int tc_kimlikNo)
            {
                this.ad = ad;
                this.soyad = soyad;
                this.dogumYili = dogumYili;
                this.tc_kimlikNo = tc_kimlikNo;

            }
            public string Sifrele()
            {
                string x = "";
                for (int i = 0; i < ad.Length - 2; i++)
                {
                    x = x + "*";
                }
                string y = "";
                for (int i = 0; i < soyad.Length - 2; i++)
                {
                    y = y + "*";
                }
                return ad[0] + x + ad[ad.Length - 1] + "  " + soyad[0] + y + soyad[soyad.Length - 1];
            }

            public string getad() { return ad; }
            public string getsoyad() { return soyad; }
            public int getdogumYili() { return dogumYili; }
            public int gettc_kimlikNo() { return tc_kimlikNo; }


        }
    }
}