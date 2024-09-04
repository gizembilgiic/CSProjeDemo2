using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSProjectDemo2Library
{
    public class Officer : BasePersonnel
    {
        public string OfficerGrade { get; set; }
        public decimal MaasOfficer { get; set; }
        public Officer(string name, string title) : base(name, title)
        {

        }
        
        public override decimal MaasHesapla()
        {
            Console.WriteLine("Gizem istedi boşluk attım");
            decimal maas = 0;

            Console.WriteLine("Memur bir personelin maaşı hesaplanacaktır.");
            Console.Write("Çalışma saati girin (0-300):");
            int calismasaati_int;                         //TRY parse içine int istedi.
            string strcalismasaati = Console.ReadLine(); //try parse istedi
            calismasaati_int = CalismaSaati;            //TRY parse içine int istedi.
            while (!(int.TryParse(strcalismasaati,out calismasaati_int))||calismasaati_int<1|| calismasaati_int > 300) 
            {
              
                    Console.Clear();
                    Console.WriteLine("Girilen değer bir sayı ve 1 ile 300 arasında olmalıdır.");
                    Console.Write("Lütfen kurala uygun şekilde aylık çalışma saatini tekrar giriniz: ");
                    strcalismasaati = Console.ReadLine();

                
            }
            //---
            Console.Clear();
            Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
            Console.Write("Saatlik ücreti giriniz :");
            decimal saatlikucret_dec;                         //TRY parse içine int istedi.
            string strsaatlikucret = Console.ReadLine(); //try parse istedi
            saatlikucret_dec = SaatlikUcret;            //TRY parse içine int istedi.
            while (!(decimal.TryParse(strsaatlikucret, out saatlikucret_dec)) || saatlikucret_dec < 1 || saatlikucret_dec > 5000)
            {
             
                    Console.Clear();
                Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
                Console.WriteLine("Girilen değer bir sayı ve 1 ile 5000 arasında olmalıdır.");
                    Console.Write("Lütfen kurala uygun şekilde saatlik ücretini tekrar giriniz: ");
                    strsaatlikucret = Console.ReadLine();

               
            }
            Console.Clear();
            Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
            Console.WriteLine($"Saatlik çalışma ücreti: {strsaatlikucret}");

            //---
            Console.Write("Memur derecenizi giriniz (1-2-3) :");
            OfficerGrade = Console.ReadLine();

            while (!(OfficerGrade == "1" || OfficerGrade == "2" || OfficerGrade == "3"))
            {
                Console.Clear();
                Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
                Console.WriteLine($"Saatlik çalışma ücreti: {strsaatlikucret}");
                Console.Write("Hatalı bir seçim girdiniz! Memur derecesini tekrar giriniz(1-2-3) :");
                OfficerGrade = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
            Console.WriteLine($"Saatlik çalışma ücreti: {strsaatlikucret}");
            Console.WriteLine($"Memur derecesi (1-2-3): {OfficerGrade}");

            CalismaSaati = calismasaati_int;
            SaatlikUcret = saatlikucret_dec;


            if (CalismaSaati <= 180)
            {
                maas = SaatlikUcret * CalismaSaati;
            }
            else
            {
                maas = (SaatlikUcret * 180) + ((CalismaSaati - 180) * 1.5m * SaatlikUcret);
            }
            switch (OfficerGrade)
            {
                case "1":
                    maas += SaatlikUcret;
                    Console.WriteLine(maas);
                    break;
                case "2":
                    maas += (SaatlikUcret * 2);
                    Console.WriteLine(maas);
                    break;
                case "3":
                    maas += (SaatlikUcret * 3);
                    Console.WriteLine(maas);
                    break;
            }
            return maas;
        }
    }
  
}
