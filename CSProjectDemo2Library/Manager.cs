using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjectDemo2Library
{
    public class Manager : BasePersonnel
    {
        // Yöneticinin maaş dışında aldığı ek ödeme.
        public decimal Bonus { get; set; }
        // Yönetici maaşı.
        public decimal SalaryManager { get; set; }

        // BasePersonel sınıfında tanımlanan özellikleri miras alan constructor metot.
        public Manager(string name, string title) : base(name, title)
        {

        }
        // BasePersonel sınıfının MaasHesapla metodu override edilir.
        public override decimal CalculateSalary()
        {
            Console.WriteLine("*** Yönetici maaşı hesaplanacaktır ***");
            Console.WriteLine();

            Console.Write("Çalışma saati girin(0-300)\t:");
            // Çalışma saati metodunun döndürdüğü değer ÇalışmaSaati property'sine atanır.
            WorkingHours = WorkingHoursRange(1, 300);

            Console.Write("Saatlik ücreti giriniz(500-5000):");
            // Ucret aralığı metodunun döndürdüğü değer SaatlikÜcret property'sine atanır.
            HourlyWage = WageRange(500, 5000);

            Console.Write("Bonus ücreti giriniz(1000-10000):");
            // Ucret aralığı metodunun döndürdüğü değer Bonus property'sine atanır.
            Bonus = WageRange(1000, 10000);

            // Maaş hesaplanır. Maaş, saatlik ücret ile çalışma saati çarpılarak ve ardından bonus eklenerek hesaplanır.
            decimal salary = (HourlyWage * WorkingHours) + Bonus;

            // Hesaplanan maaş console a yazdırılır.
            Console.Write($"Hesaplanan maas:{salary}");

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
