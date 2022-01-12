using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_3
{
    /*
     * İkili arama ağacında kullanılacak Node sınıfı.
     */
    class Node
    {
        public Mahalle mahalle;
        public Node leftChild;
        public Node rightChild;

        public Node(Mahalle mahalle, Node leftChild, Node rightChild)
        {
            this.mahalle = mahalle;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
    }

    internal class IkiliAramaAgaci
    {
        private Node root;

        public IkiliAramaAgaci()
        {
            root = null;
        }

        /*
         * Tum ağacı kucukten buyuge doğru sıralayacak olan inorder metodu.
         */
        public void inOrder(Node localNode)
        {
            if (localNode != null)
            {
                inOrder(localNode.leftChild);
                Console.WriteLine(localNode.mahalle.ToString());
                inOrder(localNode.rightChild);
            }
        }

        /*
         * Parametre olarak aldigi mahalle adina sahip mahalleyi bulup donderen metot.
         */
        public Mahalle mahalleyiBul(Node localNode, String mahalleAdi)
        {
            if (localNode != null)
            {

                // Eger aradigimiz mahalle localNode ise donder.
                if (localNode.mahalle.getMahalleAdi().Equals(mahalleAdi))
                {
                    return localNode.mahalle;
                }

                /*
                 * Ama eger aradigimiz node localNode degilse kıyaslama yap.
                 * Eger aranan mahalle daha buyukse sağ çocuğa kuçukse sol cocuğa giderek 
                 * aynı işlemleri bulana kadar tekrarla.
                 */
                if (mahalleAdi.CompareTo(localNode.mahalle.getMahalleAdi()) < 0)
                {
                    localNode = localNode.leftChild;
                } else
                {
                    localNode = localNode.rightChild;
                }

                // localNode guncelledik simdi tekrar ara.
                return mahalleyiBul(localNode, mahalleAdi);

            }
            // Eger hic bulunamazsa null donder.
            return null;
        }

        /*
         * Parametre olarak aldığı Mahalleyi ağaca ekleyen metot.
         */
        public void insert(Mahalle newMahalle)
        {
            // Once Node'u olustur.
            Node newNode = new Node(newMahalle, null, null);
            // Eger root null ise agacta eleman yok demektir bu sebeple gelen eleman root olur.
            if (root == null)
            {
                root = newNode;
            } else
            {
                Node current = root;
                Node parent;

                while (true)
                {
                    parent = current;

                    // Eger eklenecek eleman alfabetik sırada daha kucukse sol cocuğa ekle.
                    if (newMahalle.getMahalleAdi().CompareTo(current.mahalle.getMahalleAdi()) < 0)
                    { 
                        current = current.leftChild;

                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    // Ama eger eklenecek eleman alfabetik sırada daha buyukse sag cocuğa ekle.
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        // Rootu donderen metot.
        public Node getRoot()
        {
            return root;
        }

        public int derinligiBul(Node node)
        {
            if (node == null)
            {
                return -1;
            }
            int rigthNodeDerinlik = derinligiBul(node.rightChild);
            int leftNodeDerinlik = derinligiBul(node.leftChild);
            return Math.Max(rigthNodeDerinlik, leftNodeDerinlik) + 1;
        }


    }
}
