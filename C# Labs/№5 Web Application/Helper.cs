using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1 {
    public static class Helper {

        public static StringBuilder Extend(this StringBuilder builder, string propertyName, object propertyValue) {
            var value = propertyValue.ToString();
            return builder
                .Append(propertyName)
                .Append(": ")
                .Append(string.IsNullOrEmpty(value) ? "<empty>" : value)
                .AppendLine();
        }
    }
}
