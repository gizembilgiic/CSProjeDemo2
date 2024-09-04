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
         List<Manager> personneller = new List<Manager>();
        public string DosyaOku()
        {
            string jsonList = JsonSerializer.Serialize(personneller);
            StreamReader okuyucu = new StreamReader(@"Json1.json");
            string tumListeOku = okuyucu.ReadToEnd();

            if (tumListeOku != null)
            {
                List<Manager> readJsonList = JsonSerializer.Deserialize<List<Manager>>(tumListeOku);
                foreach (var readJson in readJsonList)
                {
                    Console.WriteLine($"Title: {readJson.Title} - Name,Surname: {readJson.Name}");
                    
                }
            }
            okuyucu.Close();
            return jsonList;
        }

        //public string IslenecekDosya()
        //{
        //    DosyaOku();


        //}




    }
}
