using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_3
{
    internal class Program
    {

        // Listeden rastgele eleman cekeceğimden kullanacagim random.
        static Random random = new Random();

        static String[] mahalleler = { "Evka 3", "Özkanlar", "Atatürk", "Erzene", "Kazımdirik" };
        static String[] yemekler = { "Türlü", "Pizza", "Hamburger", "Pilav", "Börek", "Simit", "Kızartma" };
        static int[] yemekBirimFiyatlari = { 15, 20, 25, 10, 30, 5, 15 };

        static int toplamYiyecekSayisi = 0;

        static void Main(string[] args)
        {

            // Agaci olustur.
            IkiliAramaAgaci binarySearchTree = yemekSiparisAgaciniOlustur();

            // Agacin derinligini ve içerisindeki tüm yemek siparişlerini yazdir.
            agacinDerinliginiVeBilgileriniYazdir(binarySearchTree);

            // Adi verilen mahallledeki 150 TL üzerindeki siparişleri konsola yazdir.
            yuzElliTlUzeriniYazdir(binarySearchTree, "Özkanlar");

            // Adi verilen yiyeceğin agacta kac tane oldugunu bul ve indirim uygula.
            String aranacakYiyecek = "Hamburger";
            adiVerilenYiyecegiBul(binarySearchTree.getRoot(), aranacakYiyecek);

            Console.WriteLine(aranacakYiyecek + " yiyeceğinin toplam sayısı: " + toplamYiyecekSayisi + "\n\n");

            // Bornovadaki 10 mahalleyi hashtable'a ekleyen metot.
            Hashtable hashtable = HashtableOlustur();

            // HashTable'i guncelle.
            HashtableGuncelle(hashtable, 'B');

            QuickSortOrnegi();

            Console.ReadLine();

        }

        /*
         * 1. sorunun a şıkkında belirtildigi gibi yemek sipariş ağacını olusturan metot.
         */
        public static IkiliAramaAgaci yemekSiparisAgaciniOlustur()
        {
            // Agaci olustur
            IkiliAramaAgaci binarySearchTree = new IkiliAramaAgaci();

            /*
             * Her bir mahalle icin siparişleri ve yemekleri rastgele olusturup 
             * daha sonra bu mahalleler agaca ekleyen bir for dongusu.
             */
            for (int i = 0; i < mahalleler.Length; i++)
            {
                // Her bir mahallenin tuttugu siparisler listesini yarat.
                List<SiparisBilgileri> siparislerListesi = new List<SiparisBilgileri>();

                // 5 - 10 sayıda siparis olabileceginden random olarak al.
                int randomSiparisSayisi = random.Next(5, 11);
                for (int j = 0; j < randomSiparisSayisi; j++)
                {
                    // her bir siparis listesinde yemekleri tutan yemek listesini yarat.
                    SiparisBilgileri siparisBilgileri = new SiparisBilgileri();

                    // 3-5 sayıda yemek olabileceğinden random olarak al.
                    int randomYemekSayisi = random.Next(3, 6);
                    for (int k = 0; k < randomYemekSayisi; k++)
                    {
                        // yemegin adi ve birim fiyatini listeden alabilmek icin rastgele bir sayi yarat.
                        int yemekSirasi = random.Next(7);

                        // Yemegi olustur.
                        Yemek yemek = new Yemek(yemekler[yemekSirasi], random.Next(1, 9), yemekBirimFiyatlari[yemekSirasi]);

                        // Olusan yemegi yemek listesine (siparis bilgilerine) ekle.
                        siparisBilgileri.getSiparis().Add(yemek);
                    }
                    //Olusan siparisleri siparisler listesine ekle.
                    siparislerListesi.Add(siparisBilgileri);
                }

                // Mahalleyi olustur ve siparislerini mahalleye ekle.
                Mahalle mahalle = new Mahalle(mahalleler[i]);
                mahalle.setSiparislerListesi(siparislerListesi);

                // Olusan mahalleyi agaca ekle.
                binarySearchTree.insert(mahalle);
            }

            return binarySearchTree;
        }

        /*
         * 1. sorunun b şıkkında belirtildiği gibi agacın derinliğini ve içerisinde bulunan
         * siparişleri konsola yazdir.
         */
        public static void agacinDerinliginiVeBilgileriniYazdir(IkiliAramaAgaci binarySearchTree)
        {
            // Agacin Derinligini yazdir.
            Console.WriteLine("Agacin Derinligi: " + binarySearchTree.derinligiBul(binarySearchTree.getRoot()));

            // Agaci inOrder gezerek tum elemanlari kucukten buyuge dogru olacak sekilde ekrana yazdir.
            binarySearchTree.inOrder(binarySearchTree.getRoot());
        }

        /*
         * 1. sorunun c şıkkında belirtildigi gibi adı verilen bir mahallenin
         * 150 tl uzerindeki siparişleri ekrana yazdir.
         */
        public static void yuzElliTlUzeriniYazdir(IkiliAramaAgaci binarySearchTree, String mahalle)
        {
            // Once ismi verilen mahalleyi bul.
            Mahalle arananMahalle = binarySearchTree.mahalleyiBul(binarySearchTree.getRoot(), mahalle);
            int count = 1;

            // Eger mahalle bulunduysa o mahallenin 150 tl üzerindeki siparişlerini yazdir.
            if (arananMahalle != null)
            {
                Console.WriteLine("150 TL üzerindeki siparişler: \n");
                // her siparişi gez.
                foreach(SiparisBilgileri siparis in arananMahalle.GetSiparislerListesi())
                {
                    if (siparis.toplamFiyatiBul() > 150)
                    {
                        Console.WriteLine(count + ". siparis: ");
                        foreach(Yemek yemek in siparis.getSiparis())
                        {
                            Console.WriteLine(yemek.ToString());
                        }
                        Console.WriteLine();
                        count++;
                    }
                }
            }
        }

        /*
         * 1. sorunun d şıkkında belirtildigi gibi adi verilen yiyecen agaçta toplam kac tane 
         * oldugunu bulan ve o yiyeceğin fiyatına %10 indirim uygulayan metot.
         */
        public static void adiVerilenYiyecegiBul(Node localNode, String yiyecekAdi)
        {
            if (localNode != null)
            {

                // O andaki node'un mahallesinin icerisinde bulunan siparisleri tek tek gez.
                foreach(SiparisBilgileri siparisler in localNode.mahalle.GetSiparislerListesi())
                {
                    // Toplam siparisteki yemekleri tek tek dolas.
                    foreach(Yemek yemek in siparisler.getSiparis())
                    {
                        // Eger aradıgımız yemek varsa toplam degerimizi arttir ve %10 indirim uygula.
                        if (yemek.YemekAdi.Equals(yiyecekAdi))
                        {
                            toplamYiyecekSayisi += yemek.YemekSayisi;
                            yemek.BirimFiyati = yemek.BirimFiyati * 0.9;
                        }
                    }
                }

                // Agacın once soldaki cocuklarına giderek aynı islemleri tekrarla.
                adiVerilenYiyecegiBul(localNode.leftChild, yiyecekAdi);

                // Agacın sonra sagdaki cocuklarına giderek aynı islemleri tekrarla.
                adiVerilenYiyecegiBul(localNode.rightChild, yiyecekAdi);
            }
        }

        /*
         * 2. sorunun a şıkkında belirtildiği gibi hash tablosunu olusturan metot.
         */
        public static Hashtable HashtableOlustur()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("Barbaros", new BornovaMahalle("Barbaros", 11598));
            hashtable.Add("Ergene", new BornovaMahalle("Ergene", 11245));
            hashtable.Add("Naldoken", new BornovaMahalle("Naldoken", 11245));
            hashtable.Add("Zafer", new BornovaMahalle("Zafer", 9876));
            hashtable.Add("Karacaoglan", new BornovaMahalle("Karacaoglan", 8818));
            hashtable.Add("Meric", new BornovaMahalle("Meric", 8394));
            hashtable.Add("Kosukavak", new BornovaMahalle("Kosukavak", 7916));
            hashtable.Add("Tuna", new BornovaMahalle("Tuna", 7607));
            hashtable.Add("Birlik", new BornovaMahalle("Birlik", 6949));
            hashtable.Add("Serintepe", new BornovaMahalle("Serintepe", 6905));

            return hashtable;

        }

        /* 2. sorunun b şıkkında belirtildigi gibi verilen Hashtable'in parametre olarak verilen 
        * harf ile baslayan mahallelerin nüfusunu 1 arttıran metot.
        */
        public static void HashtableGuncelle(Hashtable hashtable, char mahalleBasHarfi)
        {
            // Parametre olarak gelen hashTable'i kopyalayıp kopya hashtableile devam ettim.
            // Kopyalamayınca hata veriyor ve sebebini çözemedim.
            Hashtable copyHashtable = (Hashtable) hashtable.Clone();

            // Hashtabledeki tum mahalleleri tek tek gez.
            foreach (string mahalleAdi in copyHashtable.Keys)
            {
                // Eger mahallenin ilk harfi aradıgımız har ise nüfusunu 1 arttırıp hashtableda güncelle.
                if (mahalleBasHarfi.Equals(mahalleAdi[0]))
                {
                    BornovaMahalle mahalle = (BornovaMahalle)hashtable[mahalleAdi];
                    mahalle.MahalleNufusu += 1;
                    hashtable[mahalleAdi] = mahalle;
                }
            }
        }

        /*public static void heapOlustur()
        {
            MaxHeap.Heap maxHeap = new MaxHeap.Heap(15);

            maxHeap.insert(new BornovaMahalle("Barbaros", 11598));
            maxHeap.insert(new BornovaMahalle("Ergene", 11245));
            maxHeap.insert(new BornovaMahalle("Naldoken", 11245));
            maxHeap.insert(new BornovaMahalle("Zafer", 9876));
            maxHeap.insert(new BornovaMahalle("Karacaoglan", 8818));
            maxHeap.insert(new BornovaMahalle("Meric", 8394));
            maxHeap.insert(new BornovaMahalle("Kosukavak", 7916));
            maxHeap.insert(new BornovaMahalle("Tuna", 7607));
            maxHeap.insert(new BornovaMahalle("Birlik", 6949));
            maxHeap.insert(new BornovaMahalle("Serintepe", 6905));


            maxHeap.displayHeap();


        }*/

        public static void QuickSortOrnegi()
        {
            int[] sayilar = { 11598, 11245, 11245, 9876, 8818, 8394, 7916, 7607, 6949, 6905 };

            foreach(int i in sayilar)
            {
                Console.Write(i + "-");
            }
            Console.WriteLine();

            QuickSort.Quick_Sort(sayilar, 0, sayilar.Length - 1);

            foreach (int i in sayilar)
            {
                Console.Write(i + "-");
            }
        }

        
    }
}
