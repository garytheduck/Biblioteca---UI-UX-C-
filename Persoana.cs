using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_PIU
{
    public class Persoana
    {
        public string nume_persoana;
        public static int nr_maxim_carti = 10;
        public int nr_carti_imprumutate;
        private int[] CNP = new int[12];
        public Carte[] carti_persoana;

        public Persoana(string nume_p, int[] cnpul)
        {
            nume_persoana = nume_p;
            //exceptie : CNP incorect
            CNP = cnpul;
            carti_persoana = new Carte[0];
            nr_carti_imprumutate = 0;
        }
        public void adaugaCarte()
        {
            if(nr_carti_imprumutate + 1 > nr_maxim_carti)
            {
                //nu se mai poate imprumuta
            }
            else
            {
                //se mai poate imprumuta
            }
        }
        public void stergeCarte(string nume_de_sters)
        {

        }
        public int nrcartiImprumutate()
        {
            return nr_carti_imprumutate;
        }
    }
}
