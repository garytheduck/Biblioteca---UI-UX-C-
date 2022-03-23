using System;
using System.Configuration;
using StocareDate;
using LibrarieClase;

namespace Proiect_PIU
{
    class Program
    {
        static void Main()
        {
            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string numeFisier3 = ConfigurationManager.AppSettings["NumeFisier3"];
            AdministrareAutori_FisierText adminAutori = new AdministrareAutori_FisierText(numeFisier1);
            AdministrareCarti_FisierText adminCarti = new AdministrareCarti_FisierText(numeFisier2);
            AdministrarePersoane_FisierText adminPersoane = new AdministrarePersoane_FisierText(numeFisier3);
            int nrAutori = 0;
            int nrCarti = 0;
            int nrPersoane = 0;
            string carti = "";
            string nume_a = "";
            string optiune;
            do
            {
                Console.WriteLine("A. Administrare Autori.");
                Console.WriteLine("C. Administrare Carti.");        
                Console.WriteLine("P. Administrare Persoane.");
                Console.WriteLine("X. Iesire din program.");
                Console.WriteLine("Alegeti o optiune.");
                optiune = Console.ReadLine();
                if(optiune == "A")
                {
                    switch (optiune.ToUpper())
                    {
                        case "F":
                            Autor[] autori = adminAutori.GetAutori(out nrAutori);
                            //AfisareAutori(autori, nrAutori);
                            break;
                        case "S":
                            int idAutor = nrAutori + 1;
                            nrAutori++;
                            Autor autor = new Autor(carti, nume_a);
                            //adaugare autor in fisier
                            adminAutori.AdaugaAutor(autor);
                            break;
                        case "C":
                            nume_a = Console.ReadLine();
                            carti = Console.ReadLine();
                            break;
                        case "X":
                            return;
                        default:
                            Console.WriteLine("Optiune inexistenta");
                            break;
                    }
                }
                if(optiune == "C")
                {

                }
                if(optiune == "P")
                {

                }
                
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
    }
}

