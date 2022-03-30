using System;

namespace LibrarieClase
{
    public class Autor
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int NUME = 1;
        private const int CARTI = 2;

        public string carti_autor;
        public int idAutor;
        public string nume_autor;
        
        public Autor(int idautor, string carti, string nume_a)
        {
            this.nume_autor = nume_a;
            this.carti_autor = carti;
            this.idAutor = idautor;
        }
        public Autor(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.idAutor = Convert.ToInt32(dateFisier[ID]);
            this.nume_autor = dateFisier[NUME];
            this.carti_autor = dateFisier[CARTI];
            
        }
     
        public Autor()
        {
            nume_autor = carti_autor = string.Empty;
            idAutor = 0;
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectAutorPentruFisier = string.Format("{1}{0}{3}{0}{2}",
                SEPARATOR_PRINCIPAL_FISIER,
                idAutor.ToString(),
                (carti_autor ?? " NECUNOSCUT "),
                (nume_autor ?? " NECUNOSCUT "));

            return obiectAutorPentruFisier;
        }

        public string GetCarti()
        {
            return carti_autor;
        }
        public string GetNume()
        {
            return nume_autor;
        }
        public void SetID(int idAutor)
        {
            this.idAutor = idAutor;
        }
        public int GetID()
        {
            return idAutor;
        }
    }
}
