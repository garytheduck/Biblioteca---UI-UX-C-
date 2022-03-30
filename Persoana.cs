using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarieClase
{
    public class Persoana
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        public string nume_persoana;
        public const int nr_maxim_carti = 10;
        public int nr_carti_imprumutate;
        private string CNP;
        public string carti_persoana;
        public int idPersoana;

        public Persoana(string nume_p, string cnpul, string carti)
        {
            nume_persoana = nume_p;
            //exceptie : CNP incorect
            CNP = cnpul;
            carti_persoana = carti;
        }

        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.idPersoana = Convert.ToInt32(dateFisier[0]);
            this.nume_persoana = dateFisier[1];
            this.carti_persoana = dateFisier[2];
        }

        public Persoana()
        {
        }

        public void AdaugaCarte()
        {
            if (carti_persoana.Split(' ').Length + 1 > nr_maxim_carti)
            {
                string carte_noua = Console.ReadLine();
                carti_persoana = carti_persoana + " " + carte_noua;
            }
            else
            {
                Console.WriteLine("Ati ajuns la numarul maxim de carti pentru persoana " + nume_persoana + "!");
            }
        }
        public void StergeCarte(string nume_de_sters)
        {
            int i = 0, de_sters = 0;
            string[] carti_persoana_aux = carti_persoana.Split(' ');
            foreach(var nume in carti_persoana_aux)
            {
                i++;
                if(nume_de_sters == nume.ToString())
                {
                    de_sters = i;
                    break;
                }
            }
            for(int j = de_sters; j < carti_persoana_aux.Length; j++)
            {
                carti_persoana_aux[de_sters] = carti_persoana_aux[j];
            }
            string carti_persoana_final = string.Join(' ', carti_persoana_aux);
            carti_persoana = carti_persoana_final;
        }

        public bool CautareCartePersoana(string nume_de_cautat)
        {
            foreach (var nume in carti_persoana.Split(' '))
            {
                if (nume == nume_de_cautat)
                {
                    return true;
                }
            }
            return false;
        }

        public int NrcartiImprumutate()
        {
            return carti_persoana.Split(' ').Length;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectPersoanaPentruFisier = string.Format("{1}{0}{2}{0}{3}",
                SEPARATOR_PRINCIPAL_FISIER,
                idPersoana.ToString(),
                (nume_persoana ?? " NECUNOSCUT "),
                carti_persoana);

            return obiectPersoanaPentruFisier;
        } 
        public string GetNume()
        {
            return nume_persoana;
        }
        public void SetID(int idPersoana)
        {
            this.idPersoana = idPersoana;
        }
        public int GetID()
        {
            return idPersoana;
        }
        public string GetCarti()
        {
            return carti_persoana;
        }
    }
}
