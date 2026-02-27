using Serie_I;
using Serie_II;
using Serie_III;
using Serie_VI;
using Serie2_I;
using Serie2_II;
using Serie2_III;
using Serie3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercice_S1
{
    public enum Sexe
    {
        masculin,
        feminin,
        nonbinaire
    }

    public struct identité
    {
        public string Nom;
        public string Prenom;
        public DateTime Datenaissance;
        public int Age;
        public Sexe Sexe;

        public identité(string nom, string prenom, DateTime datenaissance, int age, Sexe sexe)
        {
            Nom = nom;
            Prenom = prenom;
            Datenaissance = datenaissance;
            Age= age;
            Sexe = sexe;
        }
        public override string ToString()
        {
            return ($"{Nom}, {Prenom}, date de naissance : {Datenaissance.ToString("dd/MM/yyyy")}, {Age} an, {Sexe}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)

        {
            /*int x = 12 - 2 * 3;
            Console.WriteLine("La valeur de x est : " + x);
            string entree = Console.ReadLine();
            Console.WriteLine("la valeur de l'entrée est : " + entree);
            int y = 12;
            int z = x + y;

            string phrase = Console.ReadLine();

            int entier;
            bool res = int.TryParse(phrase, out entier);

            int[] nom = {5, 2, 3, 4, 5};
            //Console.WriteLine("ca tableau " + nom);
            foreach (int l in nom)
            {
                Console.Write("ca tableau " + l);
            }
            foreach (int e in nom)
            {
                Console.WriteLine("ca tableau " + e);
            }

            if (res == true) {
                Console.WriteLine("ca passe");
            }
            else { 
                Console.WriteLine("ca passe pas");
            }
            /*
            Console.WriteLine($"la valeur de z est : {z:000.00}");
            if ( y  > 22) { 
                Console.WriteLine($"la valeur de y est inf à 22");
            }
            else if (y == 22)
            {
                Console.WriteLine($"la valeur de y est ega à 22");
            }
            else
            {
                Console.WriteLine($"la valeur de y est sup à 22");
            }
            int d = additionentier(ref z, 5);
            
            StringBuilder str = new StringBuilder();
                str.Append("bob");
*/

            /*
            bool existe = File.Exists(@"C:\Users\Formation\Desktop\tkt.txt");
            bool existe2 = File.Exists("Cestunfichierdetest.txt");
            using (FileStream file = new FileStream(@"C:\Users\Formation\Desktop\tkt.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader str = new StreamReader(file))
                {
                    while (!str.EndOfStream)
                    {
                        Console.WriteLine(str.ReadLine());
                    }

                }
            }
                
            FileStream file2 = File.OpenWrite("Cestunfichierdetest.txt");

                
            file2.Dispose();
            */


            ////////// ex 1 et 2 de la serie I 


            /*ElementaryOperations.BasicOperation(6, 4, '+');
            ElementaryOperations.BasicOperation(6, 4, '-');
            ElementaryOperations.BasicOperation(3, 4, '-');
            ElementaryOperations.BasicOperation(6, 4, '*');
            ElementaryOperations.BasicOperation(6, 4, '/');
            ElementaryOperations.BasicOperation(6, 0, '/');
            ElementaryOperations.BasicOperation(6, 4, 'e');

            ElementaryOperations.IntegerDivision(6, 4);
            ElementaryOperations.IntegerDivision(8, 4);
            ElementaryOperations.IntegerDivision(6, 0);

            ElementaryOperations.Pow(6, 2);
            ElementaryOperations.Pow(6, -2);

            string message = SpeakingClock.GoodDay(1);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(8);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(12);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(14);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(18);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(23); 
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(-1);
            Console.WriteLine(message);
            message = SpeakingClock.GoodDay(102);
            Console.WriteLine(message);
            */


            ////////// ex 3 et 4 de la serie I 


            /*
            Pyramid.PyramidConstruction(10, false);
            int x = 12;
            long a;
            Stopwatch sw = Stopwatch.StartNew();

            sw.Restart();
            Factorial.Factorial_(x);
            sw.Stop();
            Console.WriteLine($"temps factorial  {sw.ElapsedTicks}");
            sw.Restart();

            sw.Start();
            Factorial.FactorialRecursive(x, x);
            sw.Stop();
            Console.WriteLine($"temps factorial recursive  {sw.ElapsedTicks}");
            sw.Restart();

            sw.Start();
            a = Factorial.FactorialRecursivevrai(x);
            Console.Write($" {x}! = {a} ");
            sw.Stop();
            Console.WriteLine($"temps factorial recursive 'vrai' {sw.ElapsedTicks}");
            */


            ////////// taskstable


            /*
            int[] tab = {1,5,3,9,7,5,65,85,4 };
            Console.WriteLine("tableaux de base");
            print_tab (tab);

            int somme = TasksTables.SumTab(tab);
            Console.WriteLine("somme : " + somme);

            tab = TasksTables.OpeTab(tab, '*', 2);

            Console.WriteLine("tableau apres operation");
            print_tab(tab);


            Console.WriteLine("tableau ajouté");
            int[] tab_ajout = { 1, 5, 85, 4 };
            print_tab(tab_ajout);

            int[] tab_concat = new int[tab.Length + tab_ajout.Length];
            tab_concat = TasksTables.ConcatTab(tab,tab_ajout);
            
            Console.WriteLine("tableau apres concatenation");
            print_tab (tab_concat);
            */


            ////////// morpion


            /*
            char[,] tab2d = { { 'X', 'X', 'O' }, { 'X', 'O', 'O' },{ '_', 'X', '_' } };
            
            Morpion.DisplayMorpion(tab2d);

            Console.WriteLine(Morpion.CheckMorpion(tab2d));
            tab2d[2, 0] = 'X';
            

            Morpion.DisplayMorpion(tab2d);
            
            Console.WriteLine(Morpion.CheckMorpion(tab2d));
            tab2d[2, 0] = 'O';
            tab2d[2, 2] = 'O';

            Morpion.DisplayMorpion(tab2d);

            Console.WriteLine(Morpion.CheckMorpion(tab2d));
            tab2d[1, 1] = 'X';
            tab2d[0, 2] = 'X';
            tab2d[0, 1] = 'O';

            Morpion.DisplayMorpion(tab2d);

            Console.WriteLine(Morpion.CheckMorpion(tab2d));
            */


            ////////// recherche

            /*
            int[] tab = { 1, 3, 5, 9, 17, 25, 65, 85, 94 };
            string val;
            Console.WriteLine(" Entrer le nombre a trouve ou entrer fin pour l'arreter");
            val = Console.ReadLine();
            int valeur ;
            
            while (val != "fin")
            {
                bool test = int.TryParse(val, out valeur);

                if (test)
                {
                    int a = Search.LinearSearch(tab, valeur);
                    if (a == -1)
                    {
                        Console.WriteLine(valeur + " n'a pas été trouvé");
                    }
                    else
                    {
                        Console.WriteLine(valeur + " a été trouvé en position " + a);
                    }

                    int b = Search.BinarySearch(tab, valeur);
                    if (b == -1)
                    {
                        Console.WriteLine(valeur + " n'a pas été trouvé");
                    }
                    else
                    {
                        Console.WriteLine(valeur + " a été trouvé en position " + b);
                    }
                    
                }
                else
                {
                    Console.WriteLine("l'entree n'est pas nombre entier permis pour un int"); 
                }
                val = Console.ReadLine();
            }
            */


            /////////tache administrative


            /*
            Console.WriteLine("Texte d'entrée : ");
            string phrasemenace = Console.ReadLine();
            string[] mot_interdit = { "dollars", " Reagan", " Afghanistan", "ouest", "crime", " defaite" };
            string phrasepurifier = AdministrativeTasks.EliminateSeditiousThoughts(phrasemenace, mot_interdit);
            Console.Write("Censure des mots suivants : ");
            print_tab_string(mot_interdit);

            Console.WriteLine("Texte de sortie : ");
            Console.WriteLine(phrasepurifier);
            

            Console.WriteLine("Recencement des résidents : ");
            string info_resident1 = "M.  Slovaman    Dmitri      25";
            Console.WriteLine("Ligne 1 : " + info_resident1);
            if (AdministrativeTasks.ControlFormat(info_resident1))
            {
                Console.WriteLine("Format OK ");
            }
            else
            {
                Console.WriteLine("Format KO");
            }
            

            Console.WriteLine("Texte d'entrée : ");
            string phrasemenace2 = "1994-12-05. Papi est parti le 1994-11-31. Ca soule. 1994-1e-05.  1e94-12-05.";
            Console.WriteLine(phrasemenace2);
            Console.WriteLine("Texte de sortie : ");
            string phrasepurifier2 = AdministrativeTasks.ChangeDate(phrasemenace2);
            Console.WriteLine(phrasepurifier2);
            */


            ///// code de Cesar


            // ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz
            /*
            Console.WriteLine("Texte d'entrée : ");
            string phrasecode = Console.ReadLine();
            Console.WriteLine("Texte de sortie : ");
            Cesar Jules = new Cesar();
            phrasecode = Jules.CesarCode(phrasecode);
            Console.WriteLine(phrasecode);
            phrasecode = Jules.DecryptCesarCode(phrasecode);
            Console.WriteLine(phrasecode);

            int cle = 152452;
            Console.WriteLine();
            Console.WriteLine("Texte d'entrée : ");
            phrasecode = Console.ReadLine();
            Console.WriteLine("Texte de sortie : ");
            phrasecode = Jules.GeneralCesarCode(phrasecode,cle);
            Console.WriteLine(phrasecode);
            phrasecode = Jules.GeneralDecryptCesarCode(phrasecode,cle);
            Console.WriteLine(phrasecode);
            */

            ///// code Morse

            Morse Jules = new Morse();
            string phrase_codee = "=.===.=.=...=.....===.===...===.===.===...===.=...===.....=.=.=...=.===...=.=...===.=...===.....===.===...=.=...===.=.===.=...=.=.=.=...=...=.===.=.=";
            int nb_lettre=Jules.LettersCount(phrase_codee);
            int nb_mot = Jules.WordsCount(phrase_codee);
            Console.WriteLine($"Nombre de mot : {nb_mot}  Nombre de lettre : {nb_lettre}   ");
            string phrase_decodee = Jules.MorseTranslation(phrase_codee);
            Console.WriteLine("phrase decodee : ");
            Console.WriteLine(phrase_decodee);

            Console.ReadKey();
           
        }
        public static void print_tab_int ( int [] tab )
        {
            Console.Write("tab : [");
            foreach (int e in tab)
            {
                Console.Write(" " + e + ",");
            }
            Console.WriteLine("]");
        }
        public static void print_tab_string(string[] tab)
        {
            Console.Write("[");
            foreach (string e in tab)
            {
                Console.Write(" " + e + ",");
            }
            Console.WriteLine("]");
        }
        public static int AdditionEntiers(params int [] tab)
        {
                int res = 0;
                foreach (int e in tab)
                { res += e; }
            return res;
            
        }
            
    }
}
