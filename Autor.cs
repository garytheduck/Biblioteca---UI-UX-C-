using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_PIU
{
    public class Autor 
    {
        public static int nextID = 0;
        public Carte[] carti_autor;
        public int id_autor;
        public string nume_autor;
        public Autor(Carte[] carti, string nume_a)
        {
            nume_autor = nume_a;
            carti_autor = carti;
            id_autor = ++nextID;
        }
        public void adaugaCarte()
        {

        }
        public void stergeCarte(string nume_de_sters)
        {

        }
    }
}
