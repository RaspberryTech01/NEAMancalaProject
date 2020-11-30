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

public class userPoints
{
	private int[] UserScores = new int[8];
	private string AuthKey;
	private string Username;
	public userPoints(int[] Scores, string AuthKey, string Username)
	{
		this.UserScores = Scores;
		this.AuthKey = AuthKey;
		this.Username = Username;
	}

	//private async Task<string> GetSavedData(string username, string authKey)
 //   {
	//	serializationGetInfo serialGetInfo = new serializationGetInfo(authKey);
	//	string jsonString = JsonConvert.SerializeObject(serialAuth);
	//	var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
	//	return content;
	//}
}
