using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Serie3  
{
    public class phrase_morse
    {
        public int phrase_nbmot;
        public int phrase_nblettre;
        public string phrase_text_mot;
        public string phrase_text_lettre;
        

        public phrase_morse(string phrase) 
        {
            phrase_text_mot = phrase.Replace(".....", "M");
            phrase_nbmot = phrase_text_mot.Count(X => X == 'M') + 1;
            phrase_text_lettre = phrase_text_mot.Replace("...", "L");
            phrase_nblettre = phrase_text_lettre.Count(X => X == 'L') + 1 + phrase_text_lettre.Count(X => X == 'M');
            
        }
    
    }
public class Efficientphrase_morse
    {
    public int phrase_nbmot;
    public int phrase_nblettre;
    public string phrase_text_mot;
    public string phrase_text_lettre;


    public Efficientphrase_morse(string phrase)
    {
        phrase_text_mot = phrase.Replace(".....", "M");
        
        phrase_nbmot = phrase_text_mot.Count(X => X == 'M') + 1;
        phrase_text_lettre = phrase_text_mot.Replace("....", "L");
        phrase_text_lettre = phrase_text_mot.Replace("...", "L");
        phrase_text_lettre = phrase_text_mot.Replace("..", ".");
        phrase_nblettre = phrase_text_lettre.Count(X => X == 'L') + 1 + phrase_text_lettre.Count(X => X == 'M');

    }

}
public class Morse
    {
        private const string Taah = "===";
        private const string Ti = "=";
        private const string Point = ".";
        private const string PointLetter = "...";
        private const string PointWord = ".....";

        
        private readonly Dictionary<string, char> _alphabet;

        public Morse()
        {
            _alphabet = new Dictionary<string, char>()
            {
                {$"{Ti}.{Taah}", 'A'},
                {$"{Taah}.{Ti}.{Ti}.{Ti}", 'B'},
                {$"{Taah}.{Ti}.{Taah}.{Ti}", 'C'},
                {$"{Taah}.{Ti}.{Ti}", 'D'},
                {$"{Ti}", 'E'},
                {$"{Ti}.{Ti}.{Taah}.{Ti}", 'F'},
                {$"{Taah}.{Taah}.{Ti}", 'G'},
                {$"{Ti}.{Ti}.{Ti}.{Ti}", 'H'},
                {$"{Ti}.{Ti}", 'I'},
                {$"{Ti}.{Taah}.{Taah}.{Taah}", 'J'},
                {$"{Taah}.{Ti}.{Taah}", 'K'},
                {$"{Ti}.{Taah}.{Ti}.{Ti}", 'L'},
                {$"{Taah}.{Taah}", 'M'},
                {$"{Taah}.{Ti}", 'N'},
                {$"{Taah}.{Taah}.{Taah}", 'O'},
                {$"{Ti}.{Taah}.{Taah}.{Ti}", 'P'},
                {$"{Taah}.{Taah}.{Ti}.{Taah}", 'Q'},
                {$"{Ti}.{Taah}.{Ti}", 'R'},
                {$"{Ti}.{Ti}.{Ti}", 'S'},
                {$"{Taah}", 'T'},
                {$"{Ti}.{Ti}.{Taah}", 'U'},
                {$"{Ti}.{Ti}.{Ti}.{Taah}", 'V'},
                {$"{Ti}.{Taah}.{Taah}", 'W'},
                {$"{Taah}.{Ti}.{Ti}.{Taah}", 'X'},
                {$"{Taah}.{Ti}.{Taah}.{Taah}", 'Y'},
                {$"{Taah}.{Taah}.{Ti}.{Ti}", 'Z'},
            };
        }

        public int LettersCount(string code)
        {
            code = code.Replace(".....", "X");
            code = code.Replace("...", "X");
            int nblettre = code.Count(X => X == 'X') + 1;
            return nblettre;
        }

        public int WordsCount(string code)
        {
            code = code.Replace("=.....=", "X");
            int nbmot = code.Count(X => X == 'X') + 1;
            return nbmot;
        }

        public string MorseTranslation(string code)
        {
            phrase_morse C_code = new phrase_morse(code);
            StringBuilder sbline = new StringBuilder();
            for (int i = 0; i < C_code.phrase_nblettre-1; i++)
            {
                Console.WriteLine(C_code.phrase_text_lettre);
                int index_L = C_code.phrase_text_lettre.IndexOf('L');
                int index_M = C_code.phrase_text_lettre.IndexOf('M');
                if (index_L == -1) { index_L = 10000; }
                if (index_M == -1) { index_M = 10000; }

                Console.WriteLine($" index l  {index_L}  index_M     {index_M} ");
                if (index_L < index_M)
                {
                    Console.WriteLine(C_code.phrase_text_lettre.Substring(0, (index_L )));
                    if (_alphabet.TryGetValue(C_code.phrase_text_lettre.Substring(0,  (index_L )), out char lettre))
                    {
                        sbline.Append(lettre);
                        
                    }

                    else
                    {
                        sbline.Append("+");


                    }
                    C_code.phrase_text_lettre = C_code.phrase_text_lettre.Remove( 0,index_L+1);
                    
                }
                else
                {
                    if (_alphabet.TryGetValue(C_code.phrase_text_lettre.Substring(0, (index_M )), out char lettre))
                    {
                        sbline.Append(lettre);
                        sbline.Append(" ");
                    }
                    else
                    {
                        sbline.Append("+ ");
                    }
                    C_code.phrase_text_lettre = C_code.phrase_text_lettre.Remove(0, index_M+1);
                    
                }

                
            }
            if (_alphabet.TryGetValue(C_code.phrase_text_lettre.Substring(0, C_code.phrase_text_lettre.Length), out char dlettre))
            {
                sbline.Append(dlettre);
            }
            else
            {
                sbline.Append("+");
            }
            

            string line = sbline.ToString();
            return line;
        }
        

        public string EfficientMorseTranslation(string code)
        {
            Efficientphrase_morse C_code = new Efficientphrase_morse(code);
            StringBuilder sbline = new StringBuilder();
            for (int i = 0; i < C_code.phrase_nblettre - 1; i++)
            {
                Console.WriteLine(C_code.phrase_text_lettre);
                int index_L = C_code.phrase_text_lettre.IndexOf('L');
                int index_M = C_code.phrase_text_lettre.IndexOf('M');
                if (index_L == -1) { index_L = 10000; }
                if (index_M == -1) { index_M = 10000; }

                Console.WriteLine($" index l  {index_L}  index_M     {index_M} ");
                if (index_L < index_M)
                {
                    Console.WriteLine(C_code.phrase_text_lettre.Substring(0, (index_L)));
                    if (_alphabet.TryGetValue(C_code.phrase_text_lettre.Substring(0, (index_L)), out char lettre))
                    {
                        sbline.Append(lettre);

                    }

                    else
                    {
                        sbline.Append("+");


                    }
                    C_code.phrase_text_lettre = C_code.phrase_text_lettre.Remove(0, index_L + 1);

                }
                else
                {
                    if (_alphabet.TryGetValue(C_code.phrase_text_lettre.Substring(0, (index_M)), out char lettre))
                    {
                        sbline.Append(lettre);
                        sbline.Append(" ");
                    }
                    else
                    {
                        sbline.Append("+ ");
                    }
                    C_code.phrase_text_lettre = C_code.phrase_text_lettre.Remove(0, index_M + 1);

                }


            }
            if (_alphabet.TryGetValue(C_code.phrase_text_lettre.Substring(0, C_code.phrase_text_lettre.Length), out char dlettre))
            {
                sbline.Append(dlettre);
            }
            else
            {
                sbline.Append("+");
            }


            string line = sbline.ToString();
            return line;
        }

        public string MorseEncryption(string sentence)
        {
            //TODO
            return string.Empty;
        }
    }
}
