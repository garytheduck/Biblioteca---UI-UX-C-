using System.IO;
using LibrarieClase;

namespace StocareDate
{
    public class AdministrareAutori_FisierText
    {
        private const int NR_MAX_AUTORI = 50;
        public string numeFisier;

        public AdministrareAutori_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaAutor(Autor autor)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(autor.ConversieLaSir_PentruFisier());
            }
        }

        public Autor[] GetAutori(out int nrAutori)
        {
            Autor[] autori = new Autor[NR_MAX_AUTORI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrAutori = 0;
                
                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    autori[nrAutori++] = new Autor(linieFisier);
                }
            }

            return autori;
        }
    }
}
