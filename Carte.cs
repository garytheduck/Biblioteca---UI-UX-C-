using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarieClase
{
    public class Carte
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        public string nume;
        public int id_autor_carte;
        public int nr_exemplare;
        private string linieFisier;

        public Carte(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.id_autor_carte = Convert.ToInt32(dateFisier[0]);
            this.nume = dateFisier[1];
            this.nr_exemplare = Convert.ToInt32(dateFisier[2]);
        }

        //constructor explicit
        public Carte(string nume_carte, int nr_ex, int id_autor_c)
        {
            nume = nume_carte;
            nr_exemplare = nr_ex;
            id_autor_carte = id_autor_c;
        }

        public Carte()
        {
            nume = string.Empty;
            nr_exemplare = id_autor_carte = 0; 
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectCartePentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                id_autor_carte.ToString(),
                (nume ?? " NECUNOSCUT "),
                nr_exemplare.ToString());
            return obiectCartePentruFisier;
        }
        
        public string GetNume()
        {
            return nume;
        }
        public int GetID()
        {
            return id_autor_carte;
        }
        public int GetNrExemplare()
        {
            return nr_exemplare;
        }
        public void SetID(int id_autor_carte)
        {
            this.id_autor_carte = id_autor_carte;
        }
    }
}
