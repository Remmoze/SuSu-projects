using System;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class AuthBrowser : Form {

        private string _AuthUrl = "https://oauth.vk.com/authorize";
        private string _RedirectApi = "https://oauth.vk.com/blank.html";
        private string _Scope = "friends";

        private string FullAuthUrl {
            get {
                var param = new ApiRequestParameters("")
                    .Add("display", "page")
                    .Add("response_type", "token")
                    .Add("v", "5.126")
                    .Add("redirect_uri", _RedirectApi)
                    .Add("client_id", AppId.ToString())
                    .Add("scope", _Scope)
                    .Add("revoke", "1");
                return _AuthUrl + param.ToString();
            }
        }

        private int AppId = 7653211;
        private string AccessToken { get; set; }

        public AuthBrowser() {
            InitializeComponent();
        }

        public string GetToken() {
            return AccessToken;
        }

        private void WindowShown(object sender, EventArgs e) {
            webBrowser1.Navigate(new Uri(FullAuthUrl));
        }

        private void BrowserNavigated(object sender, WebBrowserNavigatedEventArgs e) {
            string uri = e.Url.ToString();
            if(uri.StartsWith(_AuthUrl))
                return;

            if(!uri.StartsWith(_RedirectApi)) {
                DialogResult = DialogResult.No;
                return;
            }

            // url sample: https://oauth.vk.com/blank.html#access_token=HERE&expires_in=12345
            AccessToken = uri.Split('#')[1].Split('&')[0].Split('=')[1];
            DialogResult = DialogResult.Yes;
        }
    }
}
