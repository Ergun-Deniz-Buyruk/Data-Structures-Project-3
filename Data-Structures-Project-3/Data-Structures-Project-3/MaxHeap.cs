using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_3
{
    internal class MaxHeap
    {
        /*
         * Heapta tutulacak olan Node Sınıfı;
         */
        public class maxHeapNode
        {
            private int nufus;
            private string mahalleAdi;

            public maxHeapNode(string mahalleAdi, int nufus)
            {
                this.mahalleAdi = mahalleAdi;
                this.nufus = nufus;
            }

            public string MahalleAdi{ get => mahalleAdi; set => mahalleAdi = value; }
            public int Nufus { get => nufus; set => nufus = value; }


            public override string ToString()
            {
                return String.Format("Mahalle adi: {0}, nüfusu: {1}", mahalleAdi, nufus);
            }

        }

        private maxHeapNode[] maxheapArray;
        private int maxSize;           // size of array
        private int currentSize;       // number of nodes in array
                                       // -------------------------------------------------------------
        public MaxHeap(int mx)            // constructor
        {
            maxSize = mx;
            currentSize = 0;
            maxheapArray = new maxHeapNode[maxSize];  // create array
        }
        // -------------------------------------------------------------
        public bool isEmpty()
        { return currentSize == 0; }
        // -------------------------------------------------------------
        public bool insert(string mahalle_adı, int nufus)
        {
            if (currentSize == maxSize)
                return false;
            maxHeapNode newNode = new maxHeapNode(mahalle_adı, nufus);
            maxheapArray[currentSize] = newNode;
            trickleUp(currentSize++);
            return true;
        }  // end insert()
           // -----------------------------------------------------------
        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            maxHeapNode bottom = maxheapArray[index];

            while (index > 0 && maxheapArray[parent].Nufus < bottom.Nufus)
            {
                maxheapArray[index] = maxheapArray[parent];  // move it down
                index = parent;
                parent = (parent - 1) / 2;
            }  // end while
            maxheapArray[index] = bottom;
        }  // end trickleUp()
           // -------------------------------------------------------------
        
        public maxHeapNode remove()           // delete item with max key
        {
            maxHeapNode root = maxheapArray[0];
            maxheapArray[0] = maxheapArray[--currentSize];
            trickleDown(0);
            return root;
        }

        public void trickleDown(int index)
        {
            int largerChild;
            maxHeapNode top = maxheapArray[index];       // save root
            while (index < currentSize / 2)       // while node has at
            {                               //    least one child,
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                // find larger child
                if (rightChild < currentSize &&  // (rightChild exists?)
                                    maxheapArray[leftChild].Nufus <
                                    maxheapArray[rightChild].Nufus)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                // top >= largerChild?
                if (top.Nufus >= maxheapArray[largerChild].Nufus)
                    break;
                // shift child up
                maxheapArray[index] = maxheapArray[largerChild];
                index = largerChild;            // go down
            }  // end while
            maxheapArray[index] = top;            // root to index
        }

        public void displayHeap()
        {
            Console.Write("MaxHeapArray: ");    // array format
            for (int m = 0; m < currentSize; m++)
                if (maxheapArray[m] != null)
                    Console.Write(maxheapArray[m].Nufus + " ");
                else
                    Console.Write("-- ");
            Console.WriteLine();
            // heap format
            int nBlanks = 32;
            int itemsPerRow = 1;
            int column = 0;
            int j = 0;                          // current item
            String dots = "...........................................................";
            Console.WriteLine(dots + dots);      // dotted top line

            while (currentSize > 0)              // for each heap item
            {
                if (column == 0)                  // first item in row?
                    for (int k = 0; k < nBlanks; k++)  // preceding blanks
                        Console.Write(' ');
                // display item
                Console.Write(maxheapArray[j].Nufus);
                Console.Write(maxheapArray[j].MahalleAdi);

                if (++j == currentSize)           // done?
                    break;

                if (++column == itemsPerRow)        // end of row?
                {
                    nBlanks /= 2;                 // half the blanks
                    itemsPerRow *= 2;             // twice the items
                    column = 0;                   // start over on
                    Console.WriteLine();         //    new row
                }
                else                             // next item on row
                    for (int k = 0; k < nBlanks * 2 - 2; k++)
                        Console.Write(' ');     // interim blanks
            }  // end for
            Console.WriteLine("\n" + dots + dots); // dotted bottom line
        }
    }
}