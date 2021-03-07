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
        private static readonly HttpClient client = new HttpClient(); //instatiation of the HTTP client

        public Form1()
        {
            InitializeComponent(); //starts the form 
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private async void loginBtn_Click(object sender, EventArgs e) //on click of login button
        {
            try
            {
                string usernameLogin = usernameInputField.Text; //the username the user input
                string passwordLogin = passwordInputField.Text; //the password the user input
                var response = await LoginRegisterAsync(usernameLogin, passwordLogin, "login"); //send api call to backend requesting data

                responseField.Text = response; //shows error/success message
            }
            catch
            {
                responseField.Text = "An error occurred."; //shows error message if something internally failed
            }
        }

        private async void registerBtn_Click(object sender, EventArgs e) //on click of register button
        {
            try
            {
                string usernameRegister = usernameInputField.Text; //set usernameRegister to username entered by user
                string passwordRegister = passwordInputField.Text; //set passwordRegister to password entered by user
                if(passwordRegister.Length < 6) //if the password length is less than 6 characters
                {
                    responseField.Text = "Password needs to be at least 6 characters"; //show error message
                }
                else if(usernameRegister.Length < 5) //if the username length is less than 5 characters
                {
                    responseField.Text = "Username needs to be at least 5 characters"; //show error message
                }
                else //if all validation tests passed
                {
                    var response = await LoginRegisterAsync(usernameRegister, passwordRegister, "register"); //send api call to backend

                    responseField.Text = response; //set error/success message to message sent from backend
                }
            }
            catch
            {
                responseField.Text = "An error occurred."; //if internal error occurs set message to this
            }
        }

        private async Task<string> LoginRegisterAsync(string username, string password, string type) //sends API call to backend
        {
            try
            {
                SerializationAuth serialAuth = new SerializationAuth(username, password); //new instatiation and setting of variables in SerializationAuth
                string jsonString = JsonConvert.SerializeObject(serialAuth); //convert variables to JSON format
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json"); //add headers to JSON request

                if (type == "login") //if login was chosen
                {
                    var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/login", content); //send JSON to this path
                    var rString = await result.Content.ReadAsStringAsync(); //read result as a string
                    SerializationAuth deserialObj = JsonConvert.DeserializeObject<SerializationAuth>(rString); //add result to new instatiation 
                    if (deserialObj.ApiResponse == "true") //if successfully logged in
                    {
                        Hide(); //hide the login form
                        GameForm gameForm = new GameForm(deserialObj.UserID, username, deserialObj.AuthKey, deserialObj.Wins, deserialObj.Losses, deserialObj.TotalScore);
                        gameForm.Show(); //set up new gameform class with incoming variables in API call and show the form
                    }
                    else //else if login unsuccessful
                    {
                        return "Wrong Username or Password"; //return back error message
                    }
                }
                else if (type == "register") //if register was chosen
                {
                    var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/register", content); //send JSON to this path
                    var rString = await result.Content.ReadAsStringAsync(); //read API response as string

                    SerializationAuth deserialObj = JsonConvert.DeserializeObject<SerializationAuth>(rString); //convert JSON response into a new class
                    if (deserialObj.ApiResponse == "true") //if the API returns back true (Success)
                    {
                        return "Successful! Login to your new account."; //return success message
                    }
                    else //if the API does not return back true
                    {
                        return "Username already exists."; //return error message 
                    }
                }
                return "null"; //must have a return value if nothing is present
            }
            catch (Exception) //if some error occurs
            {
                return "An internal error occurred";
            }
        }


    }
}