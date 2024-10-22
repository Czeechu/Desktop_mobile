using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterMauiApp.Converters
{
    public class GradeToTextGradeConverter : IValueConverter //kontrakt gwarantujacy ze w klasie cos bedzie(interfejs)
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string grade = value as string;
            string returnValue = "Nieprawidłowa dana";
            if (grade != null)
            {
                switch (grade)
                {
                    case "1":
                        returnValue = "Niedostateczny";
                        break;
                    case "2":
                        returnValue = "dopuszczający";
                        break;
                    case "3":
                        returnValue = "dostateczny";
                        break;
                    case "4":
                        returnValue = "dobry";
                        break;
                    case "5":
                        returnValue = "bardzo dobry";
                        break;
                    case "6":
                        returnValue = "celujący";
                        break;
                    default:
                        returnValue = "Nieprawidłowa ocena";
                        break;
                }

            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
