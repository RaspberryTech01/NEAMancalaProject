using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mancala_NEA_Computer_Science_Project
{
    public class serializationRegRes
    {
        public string userID { get; set; }
        public string apiResponse { get; set; }
        public serializationRegRes(string userID, string apiResponse)
        {
            this.apiResponse = apiResponse;
            this.userID = userID;         
        }


    }
    
}
