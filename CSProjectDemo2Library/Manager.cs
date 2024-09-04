using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjectDemo2Library
{
    public class Manager : BasePersonnel
    {
        public decimal Bonus { get; set; }
        public decimal MaasManager { get; set; }
        public Manager(string name, string title) : base(name, title)
        {

        }

        public override decimal MaasHesapla()
        {
            decimal maas = 0;
            Console.WriteLine("Yönetici maaşı hesaplanacaktır.");
            Console.Write("Çalışma saati girin (0-300):");
            int calismasaati_int;                         //TRY parse içine int istedi.
            string strcalismasaati = Console.ReadLine(); //try parse istedi
            calismasaati_int = CalismaSaati;            //TRY parse içine int istedi.
            while (!(int.TryParse(strcalismasaati, out calismasaati_int)) || calismasaati_int < 1 || calismasaati_int > 300)
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
            while (!(decimal.TryParse(strsaatlikucret, out saatlikucret_dec)) || saatlikucret_dec < 500 || saatlikucret_dec > 5000)
            {

                Console.Clear();
                Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
                Console.WriteLine("Girilen değer bir sayı ve 500 ile 5000 arasında olmalıdır.");
                Console.Write("Lütfen kurala uygun şekilde saatlik ücretini tekrar giriniz: ");
                strsaatlikucret = Console.ReadLine();


            }
            Console.Clear();
            Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
            Console.WriteLine($"Saatlik çalışma ücreti: {strsaatlikucret}");
            //---

            Console.Write("Bonus ücreti giriniz :");
            decimal bonus_dec;                         //TRY parse içine int istedi.
            string strbonus = Console.ReadLine(); //try parse istedi
            bonus_dec = Bonus;            //TRY parse içine int istedi.
            while (!(decimal.TryParse(strbonus, out bonus_dec)) || bonus_dec < 1000 || bonus_dec > 10000)
            {

                Console.Clear();
                Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
                Console.WriteLine($"Saatlik çalışma ücreti: {strsaatlikucret}");
                Console.WriteLine("Girilen değer bir sayı ve 1000 ile 10000 arasında olmalıdır.");
                Console.Write("Lütfen kurala uygun şekilde saatlik ücretini tekrar giriniz: ");
                strbonus = Console.ReadLine();


            }
            Console.Clear();
            Console.WriteLine($"Aylık çalışma saati: {strcalismasaati}");
            Console.WriteLine($"Saatlik çalışma ücreti: {strsaatlikucret}");
            Console.WriteLine($"Girilen bonus: {strbonus}");
            Bonus = bonus_dec;
            CalismaSaati = calismasaati_int;
            SaatlikUcret = saatlikucret_dec;


            maas = SaatlikUcret * CalismaSaati + Bonus;
            Console.WriteLine(maas);
            return maas;
        }

    
    }
}
