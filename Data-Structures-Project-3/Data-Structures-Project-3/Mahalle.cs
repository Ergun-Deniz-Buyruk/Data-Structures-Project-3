using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_3
{
    /*
     * Ilk soruda kullanılacak olan Mahalle sınıfı.
     */
    internal class Mahalle
    {
        private String mahalleAdi;
        // Her Mahalle, siparişler listesini referans gosterecek bir bağ sahasina sahip.
        private List<SiparisBilgileri> siparislerListesi;

        public Mahalle()
        {
            mahalleAdi = "";
            siparislerListesi = new List<SiparisBilgileri>();
        }

        public Mahalle(string mahalleAdi)
        {
            this.mahalleAdi = mahalleAdi;
            siparislerListesi = new List<SiparisBilgileri>();
        }
        
        public String getMahalleAdi()
        {
            return mahalleAdi;
        }

        public void setMahalleAdi(String mahalleAdi)
        {
            this.mahalleAdi = mahalleAdi;
        }

        public void setSiparislerListesi(List<SiparisBilgileri> siparislerListesi)
        {
            this.siparislerListesi = siparislerListesi;
        }

        public List<SiparisBilgileri> GetSiparislerListesi()
        {
            return siparislerListesi;
        }

        public
        override String ToString()
        {
            String mahalleStringi = "Mahalle Adi: " + mahalleAdi + ", Siparişler:\n";

            int count = 1;
            foreach (SiparisBilgileri siparisBilgileri in siparislerListesi)
            {
                mahalleStringi +="\t" + count + ". sipariş içeriği:\n";
                foreach(Yemek yemek in siparisBilgileri.getSiparis())
                {
                    mahalleStringi += "\t\t" + yemek.ToString() + "\n";
                }
                count++;
            }
            mahalleStringi += "\n";

            return mahalleStringi;
        }
    }
}
