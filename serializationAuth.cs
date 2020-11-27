using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mancala_NEA_Computer_Science_Project
{
    public class serializationAuth
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiResponse { get; set; }
        public string UserID { get; set; }
        public string AuthKey { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string TotalScore { get; set; }
        public serializationAuth(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
