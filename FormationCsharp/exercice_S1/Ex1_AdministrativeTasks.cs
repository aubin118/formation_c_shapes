using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Serie3
{
    public static class AdministrativeTasks
    {
        public static string EliminateSeditiousThoughts(string text, params string[] prohibitedTerms)
        {
            StringBuilder sbtext = new StringBuilder();
            sbtext.Append(text);
            for (int i = 0; i < prohibitedTerms.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int e = 0; e < prohibitedTerms[i].Length; e++)
                {
                    sb.Append("X");
                }
                string mot = sb.ToString();
                sbtext.Replace(prohibitedTerms[i], mot);
            }
            text = sbtext.ToString();
            return text;
        }

        public static bool ControlFormat(string line)
        {
            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string numéro = "0123456789";
            if (!((line.Substring(0, 4) == "M.  ") || (line.Substring(0, 4) == "Mme ") || (line.Substring(0, 4) == "Mlle")))
            { return false; }

            char verif;
            for (int i = 0; i < 24; i++)
            {

                char.TryParse(line.Substring(4 + i, 1), out verif);
                
                if (!alphabet.Any(v => v == verif)) // verif.IsLetter
                {
                    
                    return false; 
                }
            }
            char.TryParse(line.Substring(28, 1), out verif);
            if (!numéro.Any(v => v == verif)) 
            {
                
                return false; 
            }
                
            char.TryParse(line.Substring(29, 1), out verif);
            if (!numéro.Any(v => v == verif)) 
            {
                
                return false; 
            }

            return true;
        }
                
        
        

            
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        /// <exception>cref="" </exception> 
        /// <returns></returns>
        public static string ChangeDate(string report)
        {
            char verif;
            char verif2;
            char verif3;
            bool test = true;
            string date_correcte;
            string mois_correct;
            string jour_correct;
            string annee_correcte;
            string numéro = "0123456789";
            StringBuilder sbtext = new StringBuilder();
            sbtext.Append(report);
            for (int i = 0 ; i < (report.Length - 10 ); i++ )
            {
                

                char.TryParse(report.Substring( i, 1), out verif);
                //Console.WriteLine($"passe {verif}");

                if (numéro.Any(v => v == verif))
                {
                    //Console.WriteLine($"tiret {report.Substring(i, 10)} ");
                    char.TryParse(report.Substring(i+4, 1), out verif);
                    char.TryParse(report.Substring(i + 7, 1), out verif2);
                    //Console.WriteLine($"tiret {verif}   {verif2} ");
                    if ((verif == '-') && (verif2 == '-'))

                    {
                        for (int j = 0; j < 2; j++)
                        {
                            char.TryParse(report.Substring(i + 2 + j, 1), out verif);
                            char.TryParse(report.Substring(i + 5 + j, 1), out verif2);
                            char.TryParse(report.Substring(i + 8 + j, 1), out verif3);
                            //Console.WriteLine($"chiffre {j} {verif}   {verif2} ");
                            if ((!numéro.Any(v => v == verif)) || (!numéro.Any(v => v == verif)) || (!numéro.Any(v => v == verif2))) 
                            {
                                test = false;
                            }
                        }
                        char.TryParse(report.Substring(i + 1, 1), out verif);
                        if (!numéro.Any(v => v == verif))
                        {
                            test = false;
                        }
                            if (test)
                        {
                            jour_correct = report.Substring(i + 8, 2);
                            mois_correct = report.Substring(i + 5, 2);
                            annee_correcte = report.Substring(i + 2, 2);

                            date_correcte = string.Concat(jour_correct, ".", mois_correct, ".", annee_correcte);
                            sbtext.Replace(report.Substring(i, 10), date_correcte);
                            i += 9;
                        }
                    }
                }
            }
            report = sbtext.ToString();
            return report;
        }
    }
}
