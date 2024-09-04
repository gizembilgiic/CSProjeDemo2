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
        public void DosyaOku()
        {
            // JSON dosyasını oku
            StreamReader okuyucu = new StreamReader(@"Json1.json");
            string tumListeOku = okuyucu.ReadToEnd();
            okuyucu.Close();

            // JSON'u dynamic tipinde deseralize et
            var personnelList = JsonSerializer.Deserialize<List<JsonElement>>(tumListeOku);

            List<Officer> officers = new List<Officer>();
            List<Manager> managers = new List<Manager>();

            // JSON elemanlarını türlerine göre ayır
            foreach (var item in personnelList)
            {
                if (item.GetProperty("Title").GetString() == "Officer")
                {
                    Officer officer = JsonSerializer.Deserialize<Officer>(item.ToString());
                    officers.Add(officer);
                }
                else if (item.GetProperty("Title").GetString() == "Manager")
                {
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
    }
}
