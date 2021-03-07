using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_NEA_Computer_Science_Project
{
    class SerializationResponse //Used for the response of getting user info
    {
        public string wins { get; set; } //user wins
        public string losses { get; set; } //user losses
        public string totalScore { get; set; } //user total score
        public string userGameID { get; set; } //game ID of game
    }
}
