using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            for (int i = 0; i > 24; i++)
            {
                Console.WriteLine($"passe {i}");

                char.TryParse(line.Substring(5 + i, i), out verif);

                if (!alphabet.Any(v => v == verif)) // verif.IsLetter
                { return false; }
            }
            char.TryParse(line.Substring(28, 1), out verif);
            if (!numéro.Any(v => v == verif)) { return false; }
                
            char.TryParse(line.Substring(29, 1), out verif);
            if (!numéro.Any(v => v == verif)) { return false; }

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
            //TODO
            return string.Empty;
        }
    }
}
