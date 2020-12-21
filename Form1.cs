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
using Newtonsoft.Json;

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
            //GameForm gameForm = new GameForm();
            //gameForm.Show();
            try
            {
                string usernameLogin = usernameInputField.Text;
                string passwordLogin = passwordInputField.Text;
                var response = await LoginRegisterAsync(usernameLogin, passwordLogin, "login");

                if (response == "true")
                {
                    responseField.Text = "logged in";
                }
                else
                {
                    responseField.Text = "Username or Password is incorrect.";
                }
                responseField.Text = response;
            }
            catch
            {
                responseField.Text = "An error occurred.";
            }
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string usernameRegister = usernameInputField.Text;
                string passwordRegister = passwordInputField.Text;
                var response = await LoginRegisterAsync(usernameRegister, passwordRegister, "register");
                if (response == "true")
                {
                    responseField.Text = "Registered";
                }
                else
                {
                    responseField.Text = "User is already registered";
                }
                responseField.Text = response;
            }
            catch
            {
                responseField.Text = "An error occurred.";
            }
        }

        private async Task<string> LoginRegisterAsync(string username, string password, string type)
        {
            try
            {
                SerializationAuth serialAuth = new SerializationAuth(username, password);
                string jsonString = JsonConvert.SerializeObject(serialAuth);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                if (type == "login")
                {
                    var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/login", content);
                    var RString = await result.Content.ReadAsStringAsync();
                    SerializationAuth deserialObj = JsonConvert.DeserializeObject<SerializationAuth>(RString);
                    if (deserialObj.ApiResponse == "true")
                    {
                        Hide();
                        GameForm gameForm = new GameForm(deserialObj.UserID, username, deserialObj.AuthKey, deserialObj.Wins, deserialObj.Losses, deserialObj.TotalScore);
                        gameForm.Show();
                    }
                    else
                    {
                        return "Wrong Username or Password";
                    }
                }
                else if (type == "register")
                {
                    var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/register", content);
                    var rString = await result.Content.ReadAsStringAsync();

                    SerializationAuth deserialObj = JsonConvert.DeserializeObject<SerializationAuth>(rString);
                    if (deserialObj.ApiResponse == "true")
                    {
                        return "Successful! Login to your new account.";
                    }
                    else
                    {
                        return "Username already exists.";
                    }
                }
                return "null";
            }
            catch (Exception)
            {
                return "An internal error occurred";
            }
        }


    }
}