using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1 {
    public static class Helper {
        public static string Extend(this string str, string PropertyName, object PropertyValue) {
            var value = PropertyValue;
            if(string.IsNullOrEmpty(PropertyValue.ToString()))
                value = "<empty>";
            return str + PropertyName + ": " + value + "\n";
        }
    }
}
