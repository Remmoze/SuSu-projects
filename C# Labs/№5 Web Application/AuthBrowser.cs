using System;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class AuthBrowser : Form {

        private string _AuthUrl = "https://oauth.vk.com/authorize";
        private string _RedirectApi = "https://oauth.vk.com/blank.html";
        private string _Scope = "friends";

        private string FullAuthUrl {
            get {
                var url = _AuthUrl;
                url += "?display=page&response_type=token&v=5.126";
                url += "&redirect_uri=" + _RedirectApi;
                url += "&client_id=" + AppId;
                url += "&scope=" + _Scope;
                return url;
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

            // url sample: https://oauth.vk.com/blank.html#access_token=HERE&expires_in=86400
            AccessToken = uri.Split('#')[1].Split('&')[0].Split('=')[1];
            DialogResult = DialogResult.Yes;
        }
    }
}
