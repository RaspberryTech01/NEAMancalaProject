using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_NEA_Computer_Science_Project
{
    class SerializationResponse
    {
        public string wins { get; set; }
        public string losses { get; set; }
        public string totalScore { get; set; }
        public string userGameID { get; set; }
        public SerializationResponse()
        {
            //this.username = username;
            //this.password = password;
        }
    }
}
