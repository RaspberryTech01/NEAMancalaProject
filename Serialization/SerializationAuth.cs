using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mancala_NEA_Computer_Science_Project
{
    public class SerializationAuth //used in making API call for login/register
    {
        public string Username { get; set; } //Username of user
        public string Password { get; set; } //password of user
        public string ApiResponse { get; set; } //API response from backend
        public string UserID { get; set; } //UserID of user
        public string AuthKey { get; set; } //Authorization key to be sent to backend in future requests
        public string Wins { get; set; } //user wins
        public string Losses { get; set; } //user losses
        public string TotalScore { get; set; } //total score of user
        public SerializationAuth(string Username, string Password) //constructor
        {
            this.Username = Username; //setting of variables
            this.Password = Password;
        }
    }
}
