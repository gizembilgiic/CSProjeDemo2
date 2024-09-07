using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjectDemo2Library
{
    public class SalaryPayroll
    {
        // Maaş Bordro Yaz metodu
        public void WritePayroll()
        {
            Console.Clear();
            Console.WriteLine("Personellerin maaş bilgilerini gir");
            Console.WriteLine();

            // JSON dosyasını oku
            StreamReader fileReader = new StreamReader(@"Json1.json");
            string readAllList = fileReader.ReadToEnd();


            // JSON'u dynamic tipinde deseralize et
            var personnelList = JsonSerializer.Deserialize<List<JsonElement>>(readAllList);

            List<Officer> officers = new List<Officer>();
            List<Manager> managers = new List<Manager>();



            // JSON elemanlarını türlerine göre ayır
            foreach (var item in personnelList)
            {
                // Her bir personelin "Title" özelliğini alır ve title değişkenine kaydeder.
                string title = item.GetProperty("Title").GetString();

                if (title == "Officer")
                {
                    // Personel, Officer tipine deseralize edilir.
                    Officer officer = JsonSerializer.Deserialize<Officer>(item.ToString());


                    Console.WriteLine($"=>{officer.Name} adlı çalışan için maaş hesaplaması yapılacaktır: ");

                    Console.WriteLine();

                    // officer.CalculateSalary() ile memurun maaşı hesaplanır ve MemurMaaşı alanına atanır.
                    officer.CivilServantSalary = officer.CalculateSalary();

                    // Memur listeye eklenir,ve console temizlenir.
                    officers.Add(officer);

                    Console.Clear();
                }
                else if (title == "Manager")
                {
                    Manager manager = JsonSerializer.Deserialize<Manager>(item.ToString());

                    Console.WriteLine($"=>{manager.Name} adlı çalışan için maaş hesaplaması yapılacaktır: ");

                    Console.WriteLine();

                    // manager.CalculateSalary() ile yöneticinin maaşı hesaplanır ve YonetiniMaası alanına atanır.
                    manager.SalaryManager = manager.CalculateSalary();

                    // Yönetici listeye eklenir ve console temizlenir.
                    managers.Add(manager);

                    Console.Clear();
                }

                // Maaşı hesaplanan memurlar ve yöneticiler dosyalara kaydedilir.
                WriteToJsonFile(managers, "managers_with_salaries1.json");
                WriteToJsonFile(officers, "officers_with_salaries1.json");

            }
            // Memurlar ve Yöneticilerden oluşan iki farklı tipteki veriyi bir arada tutmak için bir tuple oluşturulur.
            var personnelTupple = Tuple.Create(officers, managers);

            Console.WriteLine();

            CultureInfo culture = new CultureInfo("tr-TR");

            // Assume personnelTupple is defined and filled elsewhere in your code

            Console.WriteLine("Officer Listesi:");
            foreach (var officer in personnelTupple.Item1)
            {
                // Maaş bilgilerini biçimlendir
                string civilServantSalaryFormatted = (officer.CivilServantSalary - officer.Overtime).ToString("C", culture);
                string overtimeFormatted = officer.Overtime.ToString("C", culture);
                string totalSalaryFormatted = officer.CivilServantSalary.ToString("C", culture);

                // ₺ sembolünü elle ekleme
                civilServantSalaryFormatted = civilServantSalaryFormatted.Replace("₺", "₺ ");
                overtimeFormatted = overtimeFormatted.Replace("₺", "₺ ");
                totalSalaryFormatted = totalSalaryFormatted.Replace("₺", "₺ ");

                // Biçimlendirilmiş bilgileri yazdır
                Console.WriteLine($"Name: {officer.Name}, Calisma Saati: {officer.WorkingHours}, Ana Ödeme: {civilServantSalaryFormatted} Mesai: {overtimeFormatted} Toplam Ödeme: {totalSalaryFormatted}");
            }

            Console.WriteLine();

            Console.WriteLine("Manager Listesi:");
            foreach (var manager in personnelTupple.Item2)
            {
                // Maaş bilgilerini biçimlendir
                string salaryFormatted = (manager.SalaryManager - manager.Bonus).ToString("C", culture);
                string bonusFormatted = manager.Bonus.ToString("C", culture);
                string totalManagerSalaryFormatted = manager.SalaryManager.ToString("C", culture);

                // ₺ sembolünü elle ekleme
                salaryFormatted = salaryFormatted.Replace("₺", "₺ ");
                bonusFormatted = bonusFormatted.Replace("₺", "₺ ");
                totalManagerSalaryFormatted = totalManagerSalaryFormatted.Replace("₺", "₺ ");

                // Biçimlendirilmiş bilgileri yazdır
                Console.WriteLine($"Name: {manager.Name}, Calisma Saati: {manager.WorkingHours}, Ana Ödeme: {salaryFormatted} Bonus: {bonusFormatted} Toplam Ödeme: {totalManagerSalaryFormatted}");
            }

            Console.WriteLine();

            Console.WriteLine("150 saatten az çalışan officer Listesi:");
            foreach (var personel in personnelTupple.Item1)
            {
                if (personel.WorkingHours < 150)
                    Console.WriteLine(personel.Name);
            }

            Console.WriteLine();

            Console.WriteLine("150 saatten az çalışan manager Listesi:");
            foreach (var personel in personnelTupple.Item2)
            {
                if (personel.WorkingHours < 150)
                    Console.WriteLine(personel.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Personellerin klasörleri oluşturuldu");
            Console.WriteLine();
        }
        // Bir listeyi Json formatında bir dosyaya kaydetmek için kullanılır.
        // Generic bir methoddur. (List<T> data, Json dosyasına yazılacak verilerin bulunduğu listeyi, string fileName ise Json dosyasının ismini ve yolunu ifade eder.
        private static void WriteToJsonFile<T>(List<T> data, string fileName)
        {
            // JsonSerializer.Serialize(data), veriyi Json string'ine çevirir.
            // new JsonSerializerOptions { WriteIndented = true }: JSON çıktısının daha okunabilir olması için girintili (indentation) şekilde yazılmasını sağlar.
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            // fileName parametresi ile belirtilen dosya yoluna, json verisi yazılır. Eğer dosya mevcut değilse, oluşturulur; mevcutsa üzerine yazılır.
            File.WriteAllText(fileName, json);
        }
    }
}
