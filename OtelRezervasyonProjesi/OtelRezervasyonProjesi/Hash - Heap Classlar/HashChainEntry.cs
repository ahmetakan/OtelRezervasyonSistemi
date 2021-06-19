using System;
using System.Collections.Generic;
using System.Text;

namespace OtelRezervasyonProjesi
{
    public class HashChainEntry
    {
        Rezervasyon rezervasyon;

        public Rezervasyon Rezervasyon
        {
            get 
            { 
                return rezervasyon; 
            }
            set 
            { 
                rezervasyon = value; 
            }
        }

        private HashChainEntry next;

        public HashChainEntry Next
        {
            get 
            { 
                return next; 
            }
            set 
            { 
                next = value; 
            }
        }

        public HashChainEntry(int KisiSayisi)
        {
            rezervasyon = new Rezervasyon(KisiSayisi);
        }
    }
}
