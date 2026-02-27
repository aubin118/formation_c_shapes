using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Serie3
{
    public class Cesar
    {
        private readonly char[,] _cesarTable;

        public Cesar()
        {
            _cesarTable = new char[,]
            {
                { 'A', 'D' },
                { 'B', 'E' },
                { 'C', 'F' },
                { 'D', 'G' },
                { 'E', 'H' },
                { 'F', 'I' },
                { 'G', 'J' },
                { 'H', 'K' },
                { 'I', 'L' },
                { 'J', 'M' },
                { 'K', 'N' },
                { 'L', 'O' },
                { 'M', 'P' },
                { 'N', 'Q' },
                { 'O', 'R' },
                { 'P', 'S' },
                { 'Q', 'T' },
                { 'R', 'U' },
                { 'S', 'V' },
                { 'T', 'W' },
                { 'U', 'X' },
                { 'V', 'Y' },
                { 'W', 'Z' },
                { 'X', 'A' },
                { 'Y', 'B' },
                { 'Z', 'C' }
            };
        }

        public string CesarCode(string line)
        {
            StringBuilder sbline = new StringBuilder();
            line = line.ToUpper();
            char lettre;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < line.Length; i++)
            {
                
                char.TryParse(line.Substring(i, 1), out lettre);
                
                if (alphabet.Any(v => v == lettre))
                {
                    
                    int e = 0;
                    while ( _cesarTable[e,0] != lettre) 
                    { 
                        e++;
                    }
                    sbline.Append(_cesarTable[e, 1]);

                }
                else 
                {
                    sbline.Append(lettre);
                }

            }
            line = sbline.ToString();
            return line; 
        }

        public string DecryptCesarCode(string line)
        {
            StringBuilder sbline = new StringBuilder();
            line = line.ToUpper();

            char lettre;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < line.Length; i++)
            {

                char.TryParse(line.Substring(i, 1), out lettre);

                if (alphabet.Any(v => v == lettre))
                {

                    int e = 0;
                    while (_cesarTable[e, 1] != lettre)
                    {
                        e++;
                    }
                    sbline.Append(_cesarTable[e, 0]);

                }
                else
                {
                    sbline.Append(lettre);
                }

            }
            line = sbline.ToString();
            return line;
        }

        public string GeneralCesarCode(string line, int x)
        {
            while (x > 26) {x-=26; }
            StringBuilder sbline = new StringBuilder();

            char lettre;
            int lettre_int;
            
            for (int i = 0; i < line.Length; i++)
            {

                char.TryParse(line.Substring(i, 1), out lettre);

                if (char.IsLetter(lettre))
                {
                    lettre_int = x + (int)lettre;
                    if ((int)lettre > 91)
                    {
                        if (lettre_int > 122) 
                        {
                           lettre_int -= 26;
                            sbline.Append((char)lettre_int);
                        }
                        else 
                        { 
                            sbline.Append((char)lettre_int);
                            
                        }

                    }
                    else  
                    {
                        if (lettre_int > 90)
                        {
                            lettre_int -= 26;
                            sbline.Append((char)lettre_int);
                        }
                        else
                        {
                            sbline.Append((char)lettre_int);
                        }
                    }

                }
                else
                {
                    sbline.Append(lettre);
                }

            }
            line = sbline.ToString();
            return line;
        }

        public string GeneralDecryptCesarCode(string line, int x)
        {
            while (x > 26) { x -= 26; }
            StringBuilder sbline = new StringBuilder();

            char lettre;
            int lettre_int;

            for (int i = 0; i < line.Length; i++)
            {

                char.TryParse(line.Substring(i, 1), out lettre);

                if (char.IsLetter(lettre))
                {
                    lettre_int =  (int)lettre - x;
                    if ((int)lettre > 91)
                    {
                        if (lettre_int < 97)
                        {
                            lettre_int += 26;
                            sbline.Append((char)lettre_int);
                        }
                        else
                        {
                            sbline.Append((char)lettre_int);

                        }

                    }
                    else
                    {
                        if (lettre_int < 65)
                        {
                            lettre_int += 26;
                            sbline.Append((char)lettre_int);
                        }
                        else
                        {
                            sbline.Append((char)lettre_int);
                        }
                    }

                }
                else
                {
                    sbline.Append(lettre);
                }

            }
            line = sbline.ToString();
            return line;
        }
    }
}
