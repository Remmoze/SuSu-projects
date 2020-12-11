using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

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

        public string GetAccountInfo() {
            var Account = RequestJson(new ApiRequestParameters("account.getProfileInfo"));
            var info = new StringBuilder()
                .Extend("First name", Account["first_name"])
                .Extend("Last name", Account["last_name"])
                .Extend("Id", Account["id"])
                .Extend("Domain", Account["screen_name"])
                .Extend("Country", Account["country"]["title"])
                .Extend("Home Town", Account["home_town"])
                .Extend("Birth day", Account["bdate"]);

            return info.ToString();
        }

        private string PerformRequest(ApiRequestParameters parameters) {
            parameters = parameters
                .Add("access_token", AccessToken)
                .Add("v", ApiVersion);
            return Connection.DownloadString(RequestsUrl + parameters.ToString());
        }

        public string Request(ApiRequestParameters parameters) {
            return PerformRequest(parameters);
        }

        public JToken RequestJson(ApiRequestParameters parameters) {
            var response = JObject.Parse(PerformRequest(parameters));
            if(response["error"] != null)
                return response["error"];
            return response["response"];
        }
    }
}
