using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mancala_NEA_Computer_Science_Project
{
    public class serializationAuth
    {
        public string username { get; set; }
        public string password { get; set; }
        public serializationAuth(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


    }
    
}
