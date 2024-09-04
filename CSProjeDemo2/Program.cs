using CSProjectDemo2Library;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace CSProjeDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //  string filePath = @"deneme.json";
            ////  JsonService jsonService=new JsonService(filePath);
            //  Person person = jsonService.LoadPersonData();

            //  if (person != null)
            //  {
            //      Console.WriteLine($"Ad: {person.name}");
            //      Console.WriteLine($"Ünvan: {person.title}");


            //  }

            //--------------------------------------------


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



            //}

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


            Officer officer2 = new Officer("Ahmet Karasu", "Memur");
            Manager manager123 = new Manager("Samet Biçer","Manager");
            officer2.MaasHesapla();
            Console.WriteLine("--------------------------------------------------------");
            manager123.MaasHesapla();

             


        }
    }
}
