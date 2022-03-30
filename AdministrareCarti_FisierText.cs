using LibrarieClase;
using System;
using System.IO;

namespace StocareDate
{
    public class AdministrareCarti_FisierText
    {
        private const int NR_MAX_CARTI = 50;
        private string numeFisier;

        public AdministrareCarti_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaCarte(Carte carte)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(carte.ConversieLaSir_PentruFisier());
            }
        }

        public Carte[] GetCarti(out int nrCarti)
        {
            Carte[] carti = new Carte[NR_MAX_CARTI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrCarti = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    carti[nrCarti++] = new Carte(linieFisier);
                }
            }

            return carti;
        }
        /*public bool Disponibil(string nume_carte)
        {
            for (int i = 0; i <= carti_biblioteca.Length; ++i)
            {
                if (nume_carte == carti_biblioteca[i].nume)
                {
                    return true;
                }
            }
            return false;
        }*/
    }
}
