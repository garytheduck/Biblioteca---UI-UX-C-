using System;

namespace LibrarieClase
{
    public class Autor
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int ID = 0;
        private const int NUME = 1;
        private string linieFisier;

        public static int nextID = 0;
        public string carti_autor;
        public int idAutor;
        public string nume_autor;
        
        public Autor(string carti, string nume_a)
        {
            nume_autor = nume_a;
            carti_autor = carti;
            idAutor = ++nextID;
        }
        public Autor(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idAutor = Convert.ToInt32(dateFisier[++nextID]);
            nume_autor = dateFisier[NUME];
            
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectAutorPentruFisier = string.Format("{1}{0}{2}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idAutor.ToString(),
                (nume_autor ?? " NECUNOSCUT "));

            return obiectAutorPentruFisier;
        }
    }
}
