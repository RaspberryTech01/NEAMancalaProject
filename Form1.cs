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
            serializationAuth serialAuth = new serializationAuth(username, password);
            string jsonString = JsonConvert.SerializeObject(serialAuth);
            //string jsonString = JsonSerializer.Serialize<serializationAuth>(serialAuth);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            

            if (type == "login")
            {
                var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/login", content);
                var RST = await result.Content.ReadAsStringAsync();
                //string deJsonString = JsonSerializer.Deserialize<serializationResponse>(RST);
                //dynamic dataResult = 
                serializationResponse serialRes = new serializationResponse();
                serializationAuth deserialObj = JsonConvert.DeserializeObject<serializationAuth>(RST);
                
                return deserialObj.username;
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