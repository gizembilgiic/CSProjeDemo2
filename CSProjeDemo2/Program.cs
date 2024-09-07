using CSProjectDemo2Library;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace CSProjeDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            FileReader personnelList = new FileReader();

            SalaryPayroll payroll = new SalaryPayroll();

            char menuSelection = ' ';

            while (menuSelection.ToString().ToUpper() != "Ç")
            {
                menuSelection = ShowMenu();

                switch (menuSelection.ToString().ToUpper())
                {
                    case "P":
                        personnelList.ReadFile();
                        menuSelection = ExitControl();
                        break;
                    case "M":
                        payroll.WritePayroll();
                        personnelList.SalaryFolderManager();
                        personnelList.SalaryFolderOfficer();
                        menuSelection = ExitControl();
                        break;
                }
            }
        }
        public static char ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            // Menü seçenekleri kullanıcıya gösterilir
            Console.WriteLine("                                                            \r\n   " +
                "┌────────────────────────────────────────────────────┐   \r\n   " +
                "│   Personel    Maas     Bordro    Programı    V1.0  │   \r\n   " +
                "│                                                    │   \r\n   " +
                "└───────────────┬─────────────────────┬──────────────┘   \r\n   " +
                "                │        MENU         │                  \r\n   " +
                "┌───────────────┴─────────────────────┴──────────────┐   \r\n   " +
                "│   (P)ersonel listesi                               │   \r\n   " +
                "│   (M)aaş bilgileri                                 │   \r\n   " +
                "│   (Ç)ıkış                                          │   \r\n   " +
                "└────────────────────────────────────────────────────┘   \r\n   " +
                "┌────────────────────────────────────────────────────┐   \r\n   " +
                "│  Lütfen yapmak istediğiniz işlemi seçin            │   \r\n   " +
                "│                                                    │   \r\n   " +
                "│  Personel listesi için (P)                         │   \r\n   " +
                "│  Maaş bilgilerini girmek için (M)                  │   \r\n   " +
                "│  Çıkış yapmak için (Ç)                             │   \r\n   " +
                "│                                                    │   \r\n   " +
                "└────────────────────────────────────────────────────┘   \r\n                                                            ");
            return Console.ReadKey(true).KeyChar;
        }
        public static char ExitControl()
        {
            // Kullanıcıya programdan çıkmak isteyip istemediği sorulur
            Console.Write("Çıkmak için (ç) devam etmek için herhangi bir tuşa basınız ...()");

            char character = Console.ReadKey().KeyChar;
            Console.Clear();
            return character;
        }
    }
}
