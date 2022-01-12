using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_3
{
    internal class BornovaMahalle
    {
        private String mahalleAdi;
        private int mahalleNufusu;

        public BornovaMahalle(String mahalleAdi, int mahalleNufusu)
        {
            this.MahalleAdi = mahalleAdi;
            this.MahalleNufusu = mahalleNufusu;
        }

        public string MahalleAdi { get => mahalleAdi; set => mahalleAdi = value; }
        public int MahalleNufusu { get => mahalleNufusu; set => mahalleNufusu = value; }

        override
        public String ToString()
        {
            return String.Format("Mahalle Adi: {0}, Nüfusu: {1}", mahalleAdi, MahalleNufusu);
        }
    }
}
