using System;
using System.Configuration;
using StocareDate;
using LibrarieClase;

namespace Proiect_PIU
{
    class Program
    {
        static void Main(string[] args)
        {
            //FISIERE 
            string numeFisier1 = args[0];
            string numeFisier2 = args[1];
            string numeFisier3 = ConfigurationManager.AppSettings["NumeFisierPersoane"];
            AdministrareAutori_FisierText adminAutori = new AdministrareAutori_FisierText(numeFisier1);
            AdministrareCarti_FisierText adminCarti = new AdministrareCarti_FisierText(numeFisier2);
            AdministrarePersoane_FisierText adminPersoane = new AdministrarePersoane_FisierText(numeFisier3);

            //vector scara
            
            Autor autorNou = new Autor();
            Carte carteNou = new Carte();
            Persoana persoanaNou = new Persoana();
            int nrAutori = 0;
            int nrCarti = 0;
            int nrPersoane = 0;
            string[][] autor_si_carti = new string[][] { new string[] { " " }, new string[] { " " } };
            string optiune, optiune1, optiune2, optiune3;
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
                    do
                    {
                        Console.WriteLine("A. Afisare Autori.");
                        Console.WriteLine("C. Citire Autor");
                        Console.WriteLine("S. Salvare Autor");
                        Console.WriteLine("F. Cautare Autor");
                        Console.WriteLine("X. Iesire din program.");
                        Console.WriteLine("Alegeti o optiune.");
                        optiune1 = Console.ReadLine();
                        switch (optiune1.ToUpper())
                        {
                            case "A":
                                //afisare autori
                                Autor[] autori = adminAutori.GetAutori(out nrAutori);
                                AfisareAutori(autori, nrAutori);
                                break;
                            case "S":
                                //adauga autor
                                int idAutor = nrAutori + 1;
                                autor_si_carti[idAutor][0] = autorNou.GetCarti();
                                Console.WriteLine(idAutor);
                                nrAutori++;
                                autorNou.SetID(idAutor);
                                adminAutori.AdaugaAutor(autorNou);
                                break;
                            case "C":
                                autorNou = CitireAutorTastatura();
                                
                                break;
                            case "X":
                                return;
                            default:
                                Console.WriteLine("Optiune inexistenta");
                                break;
                        }
                    }while (optiune1.ToUpper() != "X");
                }
                if(optiune == "C")
                {
                    do
                    {
                        Console.WriteLine("A. Afisare Carti.");
                        Console.WriteLine("C. Citire Carte");
                        Console.WriteLine("S. Salvare Carte");
                        Console.WriteLine("F. Cautare Carte");
                        Console.WriteLine("X. Iesire din program.");
                        Console.WriteLine("Alegeti o optiune.");
                        optiune2 = Console.ReadLine();
                        switch (optiune2.ToUpper())
                        {
                            case "A":
                                //afisare carti
                                Carte[] carti = adminCarti.GetCarti(out nrCarti);
                                AfisareCarti(carti, nrCarti);
                                break;
                            case "S":
                                //adauga autor
                                int idCarte = nrCarti + 1;
                                Console.WriteLine(idCarte);
                                nrCarti++;
                                carteNou.SetID(idCarte);
                                adminCarti.AdaugaCarte(carteNou);
                                break;
                            case "C":
                                carteNou = CitireCarteTastatura();
                                break;
                            case "X":
                                return;
                            default:
                                Console.WriteLine("Optiune inexistenta");
                                break;
                        }
                    } while (optiune2.ToUpper() != "X");
                }
                if(optiune == "P")
                {

                    do
                    {
                        Console.WriteLine("A. Afisare Persoane.");
                        Console.WriteLine("C. Citire Persoana");
                        Console.WriteLine("S. Salvare Persoana");
                        Console.WriteLine("F. Cautare Persoana");
                        Console.WriteLine("X. Iesire din program.");
                        Console.WriteLine("Alegeti o optiune.");
                        optiune3 = Console.ReadLine();
                        switch (optiune3.ToUpper())
                        {
                            case "A":
                                //afisare persoane
                                Persoana[] persoane = adminPersoane.GetPersoane(out nrPersoane);
                                AfisarePersoane(persoane, nrPersoane);
                                break;
                            case "S":
                                //adauga persoana
                                int idPersoana = nrPersoane + 1;
                                Console.WriteLine(idPersoana);
                                nrPersoane++;
                                persoanaNou.SetID(idPersoana);
                                adminPersoane.AdaugaPersoana(persoanaNou);
                                break;
                            case "C":
                                persoanaNou = CitirePersoanaTastatura();
                                break;
                            case "X":
                                return;
                            default:
                                Console.WriteLine("Optiune inexistenta");
                                break;
                        }
                    } while (optiune3.ToUpper() != "X");

                }
                
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        // AUTOR 

        public static Autor CitireAutorTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti cartile noului autor :");
            string carti = Console.ReadLine();
            Autor autor = new Autor(0,carti, nume);

            return autor;
        }

        public static void AfisareAutor(Autor autor)
        {
            string infoAutor = string.Format("Autorul cu id-ul #{0} are numele: {1} si cartile: {2} ",
                   autor.GetID(),
                   autor.GetNume() ?? " NECUNOSCUT ",
                   autor.GetCarti() ?? " NECUNOSCUT ");

            Console.WriteLine(infoAutor);
        }
        public static void AfisareAutori(Autor[] autori, int nrAutori)
        {
            Console.WriteLine("Autorii sunt:");
            for (int contor = 0; contor < nrAutori; contor++)
            {
                AfisareAutor(autori[contor]);
            }
        }

        // CARTE

        public static void AfisareCarte(Carte carte)
        {
            string infoCarte= string.Format("Cartea cu id-ul #{0} are numele: {1} si nr de exemplare: {2} ",
                   carte.GetID(),
                   carte.GetNume() ?? " NECUNOSCUT ",
                   carte.GetNrExemplare());
            Console.WriteLine(infoCarte);
        }
        public static void AfisareCarti(Carte[] carti, int nrCarti)
        {
            Console.WriteLine("Cartile sunt:");
            for (int contor = 0; contor < nrCarti; contor++)
            {
                AfisareCarte(carti[contor]);
            }
        }

        public static Carte CitireCarteTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti nr de exemplare :");
            int nr_exemplare = Convert.ToInt32(Console.ReadLine());
            Carte carte = new Carte(nume, nr_exemplare, 0);

            return carte;
        }



        // PERSOANA

        public static void AfisarePersoana(Persoana persoana)
        {
            string infoPersoana = string.Format("Persoana cu id-ul #{0} are numele: {1} si cartile imprumutate: {2} ",
                   persoana.GetID().ToString(),
                   (persoana.GetNume() ?? " NECUNOSCUT "),
                   persoana.GetCarti());
            Console.WriteLine(infoPersoana);
        }
        public static void AfisarePersoane(Persoana[] persoane, int nrPersoane)
        {
            Console.WriteLine("Persoanele sunt:");
            for (int contor = 0; contor < nrPersoane; contor++)
            {
                AfisarePersoana(persoane[contor]);
            }
        }

        public static Persoana CitirePersoanaTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti cnp");
            string cnp = Console.ReadLine();
            Console.WriteLine("Introduceti cartile");
            string carti = Console.ReadLine();
            Persoana persoana = new Persoana(nume, cnp, carti);

            return persoana;
        }
    }
}

