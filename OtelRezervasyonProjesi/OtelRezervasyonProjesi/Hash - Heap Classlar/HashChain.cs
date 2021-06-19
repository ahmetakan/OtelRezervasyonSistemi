using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class HashChain
    {
        int TabloBoyutu = 10;

        private HashChainEntry[] table;

        public HashChainEntry[] Table
        {
            get 
            { 
                return table; 
            }

            private set { }
        }

        public HashChain()
        {
            table = new HashChainEntry[TabloBoyutu];
            
            for (int i = 0; i < TabloBoyutu; i++)
            {
                table[i] = null;
            }
        }

        public void RezervasyonEkle(HashChainEntry rezervasyon)
        {
            int hash = (rezervasyon.Rezervasyon.RezervasyonNo % TabloBoyutu);

            if (table[hash] == null)
            {
                table[hash] = rezervasyon;
            }

            else
            {
                HashChainEntry entry = table[hash];
                while (entry.Next != null && entry.Rezervasyon.RezervasyonNo != rezervasyon.Rezervasyon.RezervasyonNo)
                {
                    entry = entry.Next;
                }

                if (entry.Rezervasyon.RezervasyonNo == rezervasyon.Rezervasyon.RezervasyonNo)
                {
                    entry = rezervasyon;
                }

                else
                {
                    entry.Next = rezervasyon;
                }
            }
        }
    }
}
