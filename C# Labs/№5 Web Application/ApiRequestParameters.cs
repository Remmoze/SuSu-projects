using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace WindowsFormsApp1 {
    class ApiRequestParameters {

        public string Method { get; set; }
        public StringBuilder Parameters = new StringBuilder();

        public ApiRequestParameters(string method) {
            Method = method;
        }

        public ApiRequestParameters AddParam(string key, string value) => Add(key, value);
        public ApiRequestParameters Add(string key, string value) {
            Parameters
                .Append("&")
                .Append(key)
                .Append("=")
                .Append(Uri.EscapeUriString(value));
            return this;
        }

        public override string ToString() {
            return Method + "?" + Parameters.ToString();
        }
    }
}