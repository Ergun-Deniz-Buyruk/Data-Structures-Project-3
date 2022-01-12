using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_3
{
    /*
     * Ilk soruda kullanılacak olan Yemek sınıfı.
     */
    internal class Yemek
    {
        private String yemekAdi;
        private int yemekSayisi;
        private double birimFiyati;

        public Yemek()
        {
            yemekAdi = "";
            yemekSayisi = 0;
            birimFiyati = 0;
        }

        public Yemek(String yemekAdi, int yemekSayisi, double birimFiyati)
        {
            this.yemekAdi = yemekAdi;
            this.yemekSayisi = yemekSayisi;
            this.birimFiyati = birimFiyati;

        }

        public string YemekAdi { get => yemekAdi; set => yemekAdi = value; }
        public int YemekSayisi { get => yemekSayisi; set => yemekSayisi = value; }
        public double BirimFiyati { get => birimFiyati; set => birimFiyati = value; }

        override
        public string ToString()
        {
            return String.Format("Yemek Adı: {0}, Yemek Sayısı: {1}, Birim Fiyatı: {2} TL, Toplam Fiyat: {3} TL", 
                yemekAdi, yemekSayisi, birimFiyati, yemekSayisi*birimFiyati);
        }
    }
}
