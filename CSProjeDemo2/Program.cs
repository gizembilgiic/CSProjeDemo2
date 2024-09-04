using CSProjectDemo2Library;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace CSProjeDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 1.yol
            //  string filePath = @"deneme.json";
            ////  JsonService jsonService=new JsonService(filePath);
            //  Person person = jsonService.LoadPersonData();

            //  if (person != null)
            //  {
            //      Console.WriteLine($"Ad: {person.name}");
            //      Console.WriteLine($"Ünvan: {person.title}");


            //  } 
            #endregion

            #region 2.yol
            //    Person person = new Person();
            //    List<Person> list = new List<Person>();

            //    string json = JsonSerializer.Serialize(person);
            //    string jsonList = JsonSerializer.Serialize(list);

            //   StreamReader okuyucu = new StreamReader(@"deneme.json");

            //    string deger = okuyucu.ReadToEnd();

            //    if ( deger != null)
            //    {
            //        List<Person> ReadJsonList= JsonSerializer.Deserialize<List<Person>>(deger);
            //        foreach (var item in ReadJsonList)
            //        {
            //            Console.WriteLine($"title: {item.title} Ad: {item.name}");
            //        }
            //    }
            //    okuyucu.Close(); 
            #endregion

            #region 3.yol
            //public class Person
            //{
            //    public string name { get; set; }
            //    public string title { get; set; }

            //}
            //public class JsonService
            //{
            //    private string _filePath;

            //    public JsonService(string filePath)
            //    {
            //        _filePath = filePath;
            //    }
            //    public Person LoadPersonData()
            //    {
            //        try
            //        {
            //            string jsonString = File.ReadAllText(_filePath);
            //            Person person = JsonSerializer.Deserialize<Person>(jsonString);
            //            return person;

            //        }
            //        catch
            //        {
            //            Console.WriteLine("Başaramadım dosya yolunu");
            //            return null;
            //        }

            //    } 
            #endregion


            Officer officer2 = new Officer("Ahmet Karasu", "Memur");
            Manager manager123 = new Manager("Samet Biçer","Manager");
            //officer2.MaasHesapla();
            //Console.WriteLine("--------------------------------------------------------");
            //manager123.MaasHesapla();

            #region deneme
            //FileReader fileReader = new FileReader();

            //// fileReader.DosyaOku();

            //List<Manager> list = new List<Manager>();
            //List<BasePersonnel> personnels = new List<BasePersonnel>();

            //string jsonList = JsonSerializer.Serialize(personnels);
            //StreamReader okuyucu = new StreamReader(@"Json1.json");
            //string tumListeOku = okuyucu.ReadToEnd();

            //if (!string.IsNullOrEmpty(tumListeOku))  // Verinin null olmadığını ve boş olmadığını kontrol edin
            //{
            //    List<Manager> readJsonList = JsonSerializer.Deserialize<List<Manager>>(tumListeOku);

            //    if (readJsonList != null)  // Deserializasyon başarılı olduysa
            //    {
            //        foreach (var readJson in readJsonList)
            //        {
            //            personnels.Add(readJson);  // JSON'dan okunan her Manager nesnesini personnels listesine ekleyin
            //            Console.WriteLine($"Title: {readJson.Title} - Name, Surname: {readJson.Name}");
            //        }
            //    }
            //}

            //okuyucu.Close();

            //// JSON'dan okunan veriler personnels listesine eklendiği için artık burada arama yapılabilir
            //BasePersonnel personel = personnels.FirstOrDefault(p1 => p1.Title == "Manager");

            //if (personel != null)
            //{

            //    Console.WriteLine($"{personel.Title} bulundu");

            //}
            //else
            //{
            //    Console.WriteLine("Personel bulunamadı");
            //} 
            #endregion

            FileReader personelListesi = new FileReader();
            personelListesi.DosyaOku();

            // JSON dosyasını oku
            StreamReader okuyucu = new StreamReader(@"Json1.json");
            string tumListeOku = okuyucu.ReadToEnd();
            okuyucu.Close();

            // JSON'u dynamic tipinde deseralize et
            var personnelList = JsonSerializer.Deserialize<List<JsonElement>>(tumListeOku);

            List<Officer> officers = new List<Officer>();
            List<Manager> managers = new List<Manager>();

            List<Officer> officersMaasListesi = new List<Officer>();

            int counter = 0;
            // JSON elemanlarını türlerine göre ayır
            foreach (var item in personnelList)
            {
                if (item.GetProperty("Title").GetString() == "Officer")
                {
                    Officer officer = JsonSerializer.Deserialize<Officer>(item.ToString());
                    officers.Add(officer);


                    Console.WriteLine($"{officer.Name} adlı çalışan için maaş hesaplaması yapılacaktır: ");
                    officer.MaasOfficer = officer.MaasHesapla();
                    officersMaasListesi[counter]= officer;

                    //officersMaasListesi.Add(new (officer.Name,officer.Title));

                    Console.WriteLine("Liste:");
                    Console.WriteLine(officersMaasListesi[counter]);

                    Console.WriteLine($"Title : {officer.Title} Ad-Soyad : {officer.Name} Maaş : {officer.MaasOfficer}");

                    Console.WriteLine($"\nPersonel İsmi : {officer.Name}\nÇalışmaSaati : {officer.CalismaSaati}\nAna Ödeme : {officer.SaatlikUcret*officer.CalismaSaati}\nMesai : {officer.SaatlikUcret * (officer.CalismaSaati - 180)}\nToplam Ödeme :{officer.MaasOfficer + officer.SaatlikUcret * (officer.CalismaSaati - 180)}");


                    counter++;
                }
                else if (item.GetProperty("Title").GetString() == "Manager")
                {
                    Manager manager = JsonSerializer.Deserialize<Manager>(item.ToString());
                    managers.Add(manager);
                }
            }



        }
    }
}
