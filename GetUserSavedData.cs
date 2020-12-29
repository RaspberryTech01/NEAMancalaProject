using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Mancala_NEA_Computer_Science_Project
{
    public class GetUserSavedData
    {
        private static readonly HttpClient client = new HttpClient();
        private string Username;
        private string UserID;
        private string AuthKey;
        private int[] UserSave;
        private int[] AISave;
        public GetUserSavedData(string Username, string UserID, string AuthKey)
        {
            this.Username = Username;
            this.UserID = UserID;
            this.AuthKey = AuthKey;
            StartReq();
        }
        public async void StartReq()
        {
            await GetSavedData();
        }
        private async Task<string> GetSavedData()
        {
            SerializationGetInfo serialGetInfo = new SerializationGetInfo(Username, UserID, AuthKey);
            string jsonString = JsonConvert.SerializeObject(serialGetInfo);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/getinfo", content);
            var RString = await result.Content.ReadAsStringAsync();
            SerializationGetInfo deserialObj = JsonConvert.DeserializeObject<SerializationGetInfo>(RString);
            string userSave = deserialObj.UserSave;
            string AISave = deserialObj.AISave;
            UserInfoSplit UserSplitSave = new UserInfoSplit(userSave);
            UserInfoSplit AISplitSave = new UserInfoSplit(AISave);
            this.UserSave = UserSplitSave.SendSplit();
            this.AISave = AISplitSave.SendSplit();
            return "null";
        }

        public int[] GetUserSave()
        {
            return UserSave;
        }
        public int[] GetAISave()
        {
            return AISave;
        }
    }
}
