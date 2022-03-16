using System;
namespace Proiect_PIU
{
    public class Biblioteca
    {
        public int nr_carti;
        public int nr_persoane;
        public int nr_autori;

        public Carte[] carti_biblioteca;
        public Persoana[] pers;
        public Autor[] autori;

        public static int current_index_autori = 0;
        public static int current_index_pers = 0;
        public static int current_index_carte = 0;

        public Biblioteca(int nr_c, int nr_p, int nr_a)
        {
            //pregatirea cartilor, persoanelor, autorilor
            nr_carti = nr_c;
            nr_persoane = nr_p;
            nr_autori = nr_a;
            carti_biblioteca = new Carte[nr_carti];
            pers = new Persoana[nr_persoane];
            autori = new Autor[nr_autori];
        }
        public void adaugaCarte()
        {

        }
        public void stergeCarte(string nume_de_sters)
        {

        }
        
        public void adaugaPersoana(Persoana p)
        {
            
        }
        public void stergePersoana(string nume_de_sters)
        {

        }
        public void adaugaAutor()
        {

        }
        public void stergeAutor(string nume_de_sters)
        {

        }

        public bool Disponibil(string nume_carte)
        {
            for (int i = 0; i <= carti_biblioteca.Length; ++i)
            {
                if(nume_carte == carti_biblioteca[i].nume)
                {
                    return true;
                }
            }
            return false;
        }
        public static void Main(){

        }
    }

    
    

}
