using CSProjectDemo2Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjectDemo2Library
{
    public class FileReader
    {
        public void ReadFile()
        {
            Console.Clear();
            Console.WriteLine("Personel Listesi");

            // JSON dosyasını okumak için bir StreamReader nesnesi oluşturulur. Oluşturulan fileReader nesnesi "Json1.json" dosyasını açar.
            StreamReader fileReader = new StreamReader(@"Json1.json");
            // ReadToEnd methodu dosyanın tamamını okur, içeriği readAllList değişkenine atar.
            string readAllList = fileReader.ReadToEnd();
            fileReader.Close();

            // Json formatındaki veriyi tuttuğumuz readAllList değişkenini deserialize ederek, bir liste haline haline getirir.
            // Bu liste, JSON'daki her bir ögeyi JsonElement olarak tutar.
            // personnelList değişkeni, JsonElement lerden oluşan bir liste olur.
            var personnelList = JsonSerializer.Deserialize<List<JsonElement>>(readAllList);

            // Boş bir memur listesi oluşturulu.
            List<Officer> officers = new List<Officer>();
            // Boş bir yönetici listesi oluşturulur.
            List<Manager> managers = new List<Manager>();

            // JSON elemanlarını türlerine göre ayır.
            foreach (var item in personnelList)
            {
                // item bir JsonElement nesnesidir. GetProperty metodu item nesnesinden "Title" adlı property'yi alır.
                // Eğer personelin Title özelliği "Officer" ise 
                if (item.GetProperty("Title").GetString() == "Officer")
                {
                    // Personeli Officer tipine dönüştürür ve officers listesine ekler.
                    Officer officer = JsonSerializer.Deserialize<Officer>(item.ToString());
                    officers.Add(officer);
                }
                // Personelin Title özelliği Manager ise
                else if (item.GetProperty("Title").GetString() == "Manager")
                {
                    // Personeli Manager tipine dönüştürür ve managers listesine ekler.
                    Manager manager = JsonSerializer.Deserialize<Manager>(item.ToString());
                    managers.Add(manager);
                }
            }

            // Officer listesini yazdır
            Console.WriteLine("Officers:");
            foreach (var officer in officers)
            {
                Console.WriteLine($"Title: {officer.Title} - Name: {officer.Name}");
            }

            // Manager listesini yazdır
            Console.WriteLine("\nManagers:");
            foreach (var manager in managers)
            {
                Console.WriteLine($"Title: {manager.Title} - Name: {manager.Name}");
            }
        }

        // Yönetici Maaş Klasör
        // Yöneticilerin maaş bordrolarını JSON dosyasından okur, her bir yönetici için bir klasör oluşturur ve
        // maaş bilgilerini klasörde bir Json dosyasına yazar.
        public void SalaryFolderManager()
        {
            //JSON dosyasını oku
            string json = File.ReadAllText(@"managers_with_salaries1.json");

            // JSON verisini listeye deseralize et
            // staff = personeller
            List<Manager> staff = JsonSerializer.Deserialize<List<Manager>>(json);

            // Her personel için klasör oluştur ve maaş bordrosunu yaz
            foreach (var personnel in staff)
            {
                // Klasör ismi personel ismi ile oluşturuluyor, Güncel tarih bilgisi (ay-yıl) olarak alınıyor.
                string folderName = $"{personnel.Name}_Bordro{DateTime.Now.Month}-{DateTime.Now.Year}";
                Directory.CreateDirectory(folderName);  // Klasör oluştur

                // Bordro dosyasını oluştur ve içine maaş bilgilerini yaz
                string payrollFilePath = Path.Combine(folderName, "Bordro.json");
                // StreamWriter kullanılarak dosyaya yazma işlemi yapılır, using yapısı ile işlem tamamlandığında dosya otomatik olarak kapatılır.
                using (StreamWriter sw = new StreamWriter(payrollFilePath))
                {
                    // StreamWriter ile dosya içine sırasıyla bilgiler yazılır.
                    sw.WriteLine($"Maaş bordro,{DateTime.Now.Month}-{DateTime.Now.Year}");
                    sw.WriteLine($"Personel Ismi: {personnel.Name}");
                    sw.WriteLine($"Calisma Saati: {personnel.WorkingHours}");
                    sw.WriteLine($"Ana Odeme: ₺ {personnel.SalaryManager - personnel.Bonus}");
                    sw.WriteLine($"Toplam Odeme: ₺ {personnel.SalaryManager}");

                }
                Console.WriteLine($"=>{personnel.Name} için bordro {folderName} klasörüne kaydedildi.");
                Console.WriteLine();
            }
        }

        // Memur Maaş Klasörü
        public void SalaryFolderOfficer()
        {
            //JSON dosyasını oku
            string json = File.ReadAllText(@"officers_with_salaries1.json");

            // JSON verisini listeye deseralize et
            List<Officer> staff = JsonSerializer.Deserialize<List<Officer>>(json);

            // Her personel için klasör oluştur ve maaş bordrosunu yaz
            foreach (var personnel in staff)
            {
                // Klasör ismi personel ismi ile oluşturuluyor
                string folderName = $"{personnel.Name}_Bordro{DateTime.Now.Month}-{DateTime.Now.Year}";
                Directory.CreateDirectory(folderName);  // Klasör oluştur

                // Bordro dosyasını oluştur ve içine maaş bilgilerini yaz
                string payrollFilePath = Path.Combine(folderName, "Bordro.json");
                using (StreamWriter sw = new StreamWriter(payrollFilePath))
                {
                    sw.WriteLine($"Maaş bordro,{DateTime.Now.Month}-{DateTime.Now.Year}");
                    sw.WriteLine($"Personel Ismi: {personnel.Name}");
                    sw.WriteLine($"Calisma Saati: {personnel.WorkingHours}");
                    sw.WriteLine($"Ana Odeme: ₺ {personnel.CivilServantSalary - personnel.Overtime}");
                    sw.WriteLine($"Mesai : ₺ {personnel.Overtime}");
                    sw.WriteLine($"Toplam Odeme: ₺ {personnel.CivilServantSalary}");
                }
                Console.WriteLine($"=>{personnel.Name} için bordro {folderName} klasörüne kaydedildi.");
                Console.WriteLine();
            }
        }

    }
}
