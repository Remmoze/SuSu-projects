using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void CheckEnter(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)Keys.Enter) {
                GetDomainFromId();
            }
        }

        private void GetDomainButtonClick(object sender, EventArgs e) {
            GetDomainFromId();
        }

        private void GetDomainFromId() {
            var id = UserId.Text;
            if(id.StartsWith("id"))
                id = id.Substring(2);
            var json = connection.RequestJson(new ApiRequestParameters("users.get").Add("user_ids", id).Add("fields", "domain"))["response"][0];

            var text = $"First name: {json["first_name"]}\n";
            text += $"Last name: {json["last_name"]}\n";
            text += $"Domain: {json["domain"]}\n";
            text += $"Id: {id}\n";
            Display2.Text = text;
        }
    }
}
