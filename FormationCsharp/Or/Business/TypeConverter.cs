using System;
using System.Globalization;
using System.Windows.Data;

namespace Or.Business
{
    public class TypeConverter : IValueConverter
    {
        // Bonne idée le converteur - propriété d'affichage possible
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Operation)
            {
                // Bien, valide. - switch possible aussi
                Operation operation = (Operation)value;
                if (operation == Operation.DepotSimple)
                {
                    return "Dépôt";
                }
                else if (operation == Operation.RetraitSimple)
                {
                    return "Retrait";
                }
                else if (operation == Operation.InterCompte)
                {
                    return "Virement";
                }
                else
                {
                    return "Indéfini";
                }
                
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Pas besoin en lecture seule
        }
    }
}
