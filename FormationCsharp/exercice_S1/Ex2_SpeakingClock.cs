using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
            string message;
            if (heure > 0) {
                switch (heure)
                {
                    case int a when a <= 6 :
                        message = $"Il est {heure} H, Merveilleuse nuit !";
                        break;
                    case int a when a < 12:
                        message = $"Il est {heure} H, Bonne matinée !";
                        break;
                    case int a when a == 12:
                        message = $"Il est {heure} H, Bon appétit !";
                        break;
                    case int a when a <= 18:
                        message = $"Il est {heure} H, Profitez de votre après-midi !";
                        break;
                    case int a when a < 24:
                        message = $"Il est {heure} H, Passez une bonne soirée !";
                        break;

                    default:
                        message = $"Heure trop grande ==> {heure} ";
                        break;

                }
            }
            else {
                message = $"Heure négative ==> {heure} "; }
                return message;
        }
    }
}
