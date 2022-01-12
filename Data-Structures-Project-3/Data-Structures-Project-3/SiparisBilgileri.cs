using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_3
{
    /*
     * Ilk soruda kullanılacak olan SiparisBilgileri sınıfı.
     */
    internal class SiparisBilgileri
    {
        private List<Yemek> siparisBilgileri;

        public SiparisBilgileri()
        {
            siparisBilgileri = new List<Yemek>();

        }

        public List<Yemek> getSiparis()
        {
            return siparisBilgileri;
        }

        // Siparişteki tum yemeklerin ucretini toplayarak toplam siparis ucretini bulan metot.
        public double toplamFiyatiBul()
        {
            double toplamUcret = 0;
            foreach (Yemek yemek in siparisBilgileri)
            {
                toplamUcret += yemek.YemekSayisi * yemek.BirimFiyati;
            }

            return toplamUcret;
        }
    }
}
