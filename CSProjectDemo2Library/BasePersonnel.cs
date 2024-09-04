using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjectDemo2Library
{
    public abstract class BasePersonnel
    {
        protected BasePersonnel(string name, string title)
        {
            Name = name;
            Title = title;

        }

        public string Name { get; set; }
        public string Title { get; set; }
        public decimal SaatlikUcret { get; set; }
        public int CalismaSaati { get; set; }

        public abstract decimal MaasHesapla();

    }
}
