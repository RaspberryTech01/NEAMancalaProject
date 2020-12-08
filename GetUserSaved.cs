using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Mancala_NEA_Computer_Science_Project
{
    class GetUserSaved
    {
        private static readonly HttpClient client = new HttpClient();
        private async Task<string> GetSavedData(string username, string authKey)
        {
            SerializationGetInfo serialGetInfo = new SerializationGetInfo(username, authKey);
            string jsonString = JsonConvert.SerializeObject(serialGetInfo);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/getinfo", content);
            var RString = await result.Content.ReadAsStringAsync();
            SerializationGetInfo deserialObj = JsonConvert.DeserializeObject<SerializationGetInfo>(RString);
            return null;
        }
    }
}
