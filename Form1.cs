using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Mancala_NEA_Computer_Science_Project
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();
            string usernameLogin = usernameInputField.Text;
            string passwordLogin = passwordInputField.Text;
            var response = await LoginRegisterAsync(usernameLogin, passwordLogin, "login");
            responseField.Text = response;
            //response.
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            string usernameRegister = usernameInputField.Text;
            string passwordRegister = passwordInputField.Text;
            var response = await LoginRegisterAsync(usernameRegister, passwordRegister, "register");
            responseField.Text = response;
            //GameForm gameForm = gameF
        }

        private async Task<string> LoginRegisterAsync(string username, string password, string type)
        {
            var values = new Dictionary<string, string>
            {
                { "username", $"{username}" },
                { "password", $"{password}" }
            };
            var content = new FormUrlEncodedContent(values);

            if (type == "login")
            {
                //POST REQUEST
                var response = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/login", content);
                var responseString = await response.Content.ReadAsStringAsync();
                //POST END
                //GET REQUEST
                var contentReturn = await client.GetStringAsync($"https://eu1.sunnahvpn.com:8888/api/login/{username}/{password}");
                Console.WriteLine(contentReturn);
                //GET END

                return contentReturn;
            }
            else if (type == "register")
            {
                var response = await client.PostAsync("http://eu1.sunnahvpn.com:8443/api/register/{username}/{password}", content);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            return "null";
        }


    }
}
