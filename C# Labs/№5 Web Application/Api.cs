using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WindowsFormsApp1 {
    class Api {
        private readonly WebClient Connection = new WebClient { Encoding = Encoding.UTF8 };
        private readonly string RequestsUrl = "https://api.vk.com/method/";
        private readonly string ApiVersion = "5.126";

        private string AccessToken { get; set; }
        public bool IsTokenValid { get; private set; }

        public Api(string AccessToken) {
            this.AccessToken = AccessToken;
            CheckToken();
        }

        private bool CheckToken() {

            if(string.IsNullOrEmpty(AccessToken))
                return IsTokenValid = false;

            var check = new ApiRequestParameters("execute")
                .Add("code", "return 1337;");

            var response = Request(check);
            return IsTokenValid = response == "{\"response\":1337}";
        }

        private string PerformRequest(ApiRequestParameters parameters) {
            parameters = parameters
                .Add("access_token", AccessToken)
                .Add("v", ApiVersion)
                .Add("revoke", "1");
            return Connection.DownloadString(RequestsUrl + parameters.ToString());
        }

        public string Request(ApiRequestParameters parameters) {
            return PerformRequest(parameters);
        }

        public JObject RequestJson(ApiRequestParameters parameters) {
            return JObject.Parse(PerformRequest(parameters));
        }
    }
}
