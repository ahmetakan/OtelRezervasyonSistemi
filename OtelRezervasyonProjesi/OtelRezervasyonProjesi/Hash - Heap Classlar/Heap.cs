using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class Heap
    {
        private HeapDugumu[] heapArray;

        public HeapDugumu[] HeapArray
        {
            get 
            { 
                return heapArray; 
            }
            private set { }
            
        }

        private int maxSize;
        private int currentSize;

        public Heap(int maxHeapSize)
        {
            maxSize = maxHeapSize;

            heapArray = new HeapDugumu[maxSize];

            currentSize = 0;
        }

        public bool Insert(Musteri musteri)
        {
            if (currentSize == maxSize)
            {
                return false;
            }

            HeapDugumu newHeapDugumu = new HeapDugumu(musteri);

            heapArray[currentSize] = newHeapDugumu;

            MoveToUp(currentSize++);

            return true;
        }

        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;

            HeapDugumu bottom = heapArray[index];

            while (index > 0 && string.Compare(heapArray[parent].Musteri.Ad, bottom.Musteri.Ad) == -1)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }

            heapArray[index] = bottom;
        }
    }
}
