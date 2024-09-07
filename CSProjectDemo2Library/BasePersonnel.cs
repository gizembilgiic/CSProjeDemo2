using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjectDemo2Library
{
    public abstract class BasePersonnel
    {

        // Personel AdSoyad
        public string Name { get; set; }
        // Personel Unvanı
        public string Title { get; set; }
        // Personel Saatlik Ücreti
        public decimal HourlyWage { get; set; }
        // Personel Çalışma Saati
        public int WorkingHours { get; set; }

        // name ve title parametreleri aralıcığıyla personelin adı ve unvanını belirlemek için kullanılan constructor metot.
        protected BasePersonnel(string name, string title)
        {
            Name = name;
            Title = title;

        }
        // Personel maaş hesaplama metodu.
        public abstract decimal CalculateSalary();


    }
}
