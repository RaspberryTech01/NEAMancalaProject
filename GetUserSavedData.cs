using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Mancala_NEA_Computer_Science_Project
{
    class GetUserSavedData
    {
        private static readonly HttpClient client = new HttpClient();
        private string Username;
        private string UserID;
        private string AuthKey;
        private string[] UserSave;
        private string[] AISave;
        public GetUserSavedData(string Username, string UserID, string AuthKey)
        {
            this.Username = Username;
            this.UserID = UserID;
            this.AuthKey = AuthKey;
            GetSavedData();
        }
        private async Task<string> GetSavedData()
        {
            serializationGetInfo serialGetInfo = new serializationGetInfo(Username, UserID, AuthKey);
            string jsonString = JsonConvert.SerializeObject(serialGetInfo);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/getinfo", content);
            var RString = await result.Content.ReadAsStringAsync();
            serializationGetInfo deserialObj = JsonConvert.DeserializeObject<serializationGetInfo>(RString);
            this.UserSave = deserialObj.UserSave;
            this.AISave = deserialObj.AISave;
            return null;
        }

        public string[] GetUserSave()
        {
            return UserSave;
        }
        public string[] GetAISave()
        {
            return AISave;
        }
    }
}
