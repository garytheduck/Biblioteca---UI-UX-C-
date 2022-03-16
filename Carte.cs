using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_PIU
{
    public class Carte
    {
        public string nume;
        public int id_autor_carte;
        public int nr_exemplare;

        //constructor explicit
        public Carte(string nume_carte, int nr_ex, int id_autor_c)
        {
            nume = nume_carte;
            nr_exemplare = nr_ex;
            id_autor_carte = id_autor_c;
        }

        
    }
}
