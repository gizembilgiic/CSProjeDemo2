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
        // Memur Derecesi
        public string OfficerGrade { get; set; }
        // Memur Maaşı
        public decimal CivilServantSalary { get; set; }
        // Memur Mesai 
        public decimal Overtime { get; set; }

        // BasePersonel sınıfında tanımlanan özellikleri miras alan constructor metot.
        public Officer(string name, string title) : base(name, title)
        {

        }
        // BasePersonel sınıfının MaasHesapla metodu override edilir.
        public override decimal CalculateSalary()
        {
            Console.WriteLine("*** Memur maası hesaplanacaktır ***");
            Console.WriteLine();

            Console.Write("Çalışma saati girin(0-300)\t:");
            // Çalışma saati metodunun döndürdüğü değer ÇalışmaSaati property'sine atanır.
            WorkingHours = WorkingHoursRange(1, 300);

            Console.Write("Saatlik ücreti giriniz(1-5000) :  ");
            // Ucret aralığı metodunun döndürdüğü değer SaatlikÜcret property'sine atanır.
            HourlyWage = WageRange(1, 5000);

            Console.Write("Memur derecenizi giriniz (1-2-3):");
            // Memur Derecesini okur.
            OfficerGrade = Console.ReadLine();

            // Kullanıcının girdiği Memur Derecesinin geçerli olup olmadığını kontrol eeder.
            while (OfficerGrade != "1" && OfficerGrade != "2" && OfficerGrade != "3")
            {
                Console.WriteLine("Hatalı bir seçim girdiniz! Memur derecesini tekrar giriniz (1-2-3): ");
                OfficerGrade = Console.ReadLine();
            }

            // Çalışma satine göre maaş hesaplaması yapar.
            decimal salary = WorkingHours <= 180
            ? HourlyWage * WorkingHours // Eğer çalışma saati 180 den küçük veya eşitse ÇalışmaSaati ile SaatlikUcreti çarpar.
            : (HourlyWage * 180) + ((WorkingHours - 180) * 1.5m * HourlyWage); // Değilse 180 saatin üzerindeki saatler için, SaatlikUcretin 1.5 katı ile hesaplanır.

            // ÇalışmaSaati 180 den fazla ise, fazla mesai hesaplanır.
            if (WorkingHours > 180)
            {
                decimal overtime = ((WorkingHours - 180) * 1.5m * HourlyWage);
                Overtime = overtime;
            }
            // Memur Derece'sine göre ek maaş ekleme işlemi yapar.
            switch (OfficerGrade)
            {
                case "1":
                    salary += HourlyWage;
                    break;
                case "2":
                    salary += HourlyWage * 2;
                    break;
                case "3":
                    salary += HourlyWage * 3;
                    break;
            }

            Console.WriteLine($"Hesaplanan maaş: {salary}");
            // Hesaplanan maaşı metodun çağrıldığı yere döndürür.
            return salary;

        }
        private static int WorkingHoursRange(int min, int max)
        {
            while (true)
            {
                // Kullanıcının girdiği değerin (int) türüne dönüştürülüp dönüştürülemeyexceğini ve belirtilen aralıklarda olup olmadığını kontrol eder.
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Girilen değer bir sayı ve {min} ile {max} arasında olmalıdır.");
                Console.ResetColor();
                Console.Write($"Lütfen {min} ile {max} arasında bir değer giriniz: ");
            }
        }

        private static decimal WageRange(decimal min, decimal max)
        {
            while (true)
            {
                // Kullanıcının girdiği değerin (decimal) türüne dönüştürülüp dönüştürülemeyeceğini ve belirtilen aralıklarda olup olmadığını kontrol eder.
                if (decimal.TryParse(Console.ReadLine(), out decimal value) && value >= min && value <= max)
                    return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Girilen değer bir sayı ve {min} ile {max} arasında olmalıdır.");
                Console.ResetColor();
                Console.Write($"Lütfen {min} ile {max} arasında bir değer giriniz: ");
            }
        }
    }

}
