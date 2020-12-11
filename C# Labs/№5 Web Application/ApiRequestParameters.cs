using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1 {
    class ApiRequestParameters {

        public string Method { get; set; }
        public Dictionary<string, string> Parameters = new Dictionary<string, string>();

        public ApiRequestParameters(string method) {
            Method = method;
        }

        public ApiRequestParameters AddParam(string key, string value) => Add(key, value);
        public ApiRequestParameters Add(string key, string value) {
            Parameters.Add(key, value);
            return this;
        }

        private string FormatParams() {
            var args = Parameters.Select(x => string.Format($"&{x.Key}={x.Value}"));
            return string.Join("", args);
        }

        public override string ToString() {
            return Method + "?" +FormatParams();
        }
    }
}