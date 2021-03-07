using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SerializationUpdateData //API call to backend to update data after game ends
{
	public string Username { get; set; } //username of user
	public string UserID { get; set; } //UserID of user
	public string AuthKey { get; set; } //authorization key of user
	public string Shells { get; set; } //user of shells 
	public bool Win { get; set; } //user of wins
	public string ApiResponse { get; set; } //API Response

	public SerializationUpdateData(string Username, string UserID, string AuthKey, string ShellNumber, bool Win)
	{ //Constructor
		this.Username = Username; //Setting of values
		this.AuthKey = AuthKey;
		this.UserID = UserID;
		this.Shells = ShellNumber;
		this.Win = Win;
	}
}
