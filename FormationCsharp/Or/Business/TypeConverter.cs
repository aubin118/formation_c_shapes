using System;
using System.Globalization;
using System.Windows.Data;

namespace Or.Business
{
    public class TypeConverter : IValueConverter
    {
        private static readonly CultureInfo EuroCulture = new CultureInfo("fr-FR");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Operation)
            {
                Operation operation = (Operation)value;
                if (operation == Operation.DepotSimple)
                {
                    return "Dépot";
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
