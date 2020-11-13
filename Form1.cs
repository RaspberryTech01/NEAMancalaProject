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
//using System.Text.Json;
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

            }
            catch
            {

            }
            string usernameLogin = usernameInputField.Text;
            string passwordLogin = passwordInputField.Text;
            var response = await LoginRegisterAsync(usernameLogin, passwordLogin, "login");
            if(response == "Successful")
            {

            }
            else
            {
                responseField.Text = "Username or Password is incorrect.";
            }
            responseField.Text = response;
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            string usernameRegister = usernameInputField.Text;
            string passwordRegister = passwordInputField.Text;
            var response = await LoginRegisterAsync(usernameRegister, passwordRegister, "register");
            responseField.Text = response;
        }

        private async Task<string> LoginRegisterAsync(string username, string password, string type)
        {
            serializationAuth serialAuth = new serializationAuth(username, password, "null");
            string jsonString = JsonConvert.SerializeObject(serialAuth);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            

            if (type == "login")
            {
                var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/login", content);
                var RString = await result.Content.ReadAsStringAsync();
                //serializationResponse serialRes = new serializationResponse();
                serializationAuth deserialObj = JsonConvert.DeserializeObject<serializationAuth>(RString);

                return deserialObj.apiResponse;
            }
            else if (type == "register")
            {
                var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/register", content);
                var RST = await result.Content.ReadAsStringAsync();

                return result.ToString();
            }
            return "null";
        }


    }
}