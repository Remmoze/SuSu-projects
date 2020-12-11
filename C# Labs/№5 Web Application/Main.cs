using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1 {
    public partial class Main : Form {

        static private Api connection;

        public Main() {
            InitializeComponent();
        }

        private void AuthClick(object sender, EventArgs e) {
            string token = "";

            using(AuthBrowser auth = new AuthBrowser()) {
                if(auth.ShowDialog() == DialogResult.Yes)
                    token = auth.GetToken();
            }

            if(string.IsNullOrEmpty(token)) {
                MessageBox.Show("Token not found.", "Failed to login.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            connection = new Api(token);
            if(!connection.IsTokenValid) {
                MessageBox.Show("Provided token is invalid.", "Failed to login.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TokenStatus.Text = "Logged in.";
            LogOut.Enabled = true;
            AuthButton.Enabled = false;

            MainScreen.Text = connection.GetAccountInfo();
        }

        private void LogoutClick(object sender, EventArgs e) {
            LogOut.Enabled = false;
            AuthButton.Enabled = true;
            connection = null;
            MainScreen.Text = "";
            TokenStatus.Text = "Not logged in.";
        }

        private void ChangedTab(object sender, TabControlEventArgs e) {
            if(connection == null || !connection.IsTokenValid) {
                if(e.TabPageIndex != 0)
                    MessageBox.Show("You have to login first.", "Prohibited action.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tabs.SelectTab(0);
            }
        }

        private void CheckEnter(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)Keys.Enter) {
                if(((TextBox)sender).Name == "GetById")
                    GetUserFromId();
                else
                    GetUserFromDomain();
            }
        }

        private void GetUserByIdButtonClick(object sender, EventArgs e) {
            GetUserFromId();
        }

        private void GetUserByDomainButtonClick(object sender, EventArgs e) {
            GetUserFromDomain();
        }

        private void GetUserFromId(string customId = "") {
            var id = UserId.Text;
            if(id.StartsWith("id"))
                id = id.Substring(2);
            if(!string.IsNullOrEmpty(customId))
                id = customId;

            var json = connection.RequestJson(new ApiRequestParameters("users.get")
                .Add("user_ids", id)
                .Add("fields", "domain"));

            if(json.Type == JTokenType.Object && json["error_msg"] != null) {
                MessageBox.Show(json["error_msg"].ToString(), ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            json = json[0];
            var text = new StringBuilder()
                .Extend("First name", json["first_name"])
                .Extend("Last name", json["last_name"])
                .Extend("Id", json["id"])
                .Extend("Domain", json["domain"]);
            Display2.Text = text.ToString();
        }

        private void GetUserFromDomain() {
            var domain = Domain.Text;
            var json = connection.RequestJson(new ApiRequestParameters("utils.resolveScreenName")
                .Add("screen_name", domain));

            // returns an empty array when domain is not taken
            if(json.Type == JTokenType.Array) {
                Display2.Text = "Domain is not taken.";
                return;
            }

            if(json["type"].ToString() != "user") {
                Display2.Text = "Domain does not belong to a user";
                return;
            }

            GetUserFromId(json["object_id"].ToString());
        }

        private void GetShortUrl() {

        }


    }
}
