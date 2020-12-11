using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var parameters = new ApiRequestParameters("friends.get")
                .Add("user_id", "120454958")
                .Add("order", "hints")
                .Add("count", "3")
                .Add("fields", "domain");

            MainScreen.Text = connection.Request(parameters);
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
                .Add("fields", "domain"))
                ["response"][0];

            var text = $"First name: {json["first_name"]}\n";
            text += $"Last name: {json["last_name"]}\n";
            text += $"Domain: {json["domain"]}\n";
            text += $"Id: {id}\n";
            Display2.Text = text;
        }

        private void GetUserFromDomain() {
            var domain = Domain.Text;
            var json = connection.RequestJson(new ApiRequestParameters("utils.resolveScreenName")
                .Add("screen_name", domain))["response"];

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
    }
}
