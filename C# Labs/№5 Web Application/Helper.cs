using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1 {
    public static class Helper {

        public static StringBuilder Extend(this StringBuilder builder, string propertyName, object propertyValue) {
            var value = "<empty>";
            if(propertyValue != null && !string.IsNullOrEmpty(propertyValue.ToString()))
                value = propertyValue.ToString();
            return builder
                .Append(propertyName)
                .Append(": ")
                .Append(value)
                .AppendLine();
        }
    }
}
