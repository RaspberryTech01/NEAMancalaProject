using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SerializationGetInfo //Used in requesting saved games from backend
{
	public string UserSave { get; set; } //The user string array for saved games shells
	public string AISave { get; set; } //user two/AI string array for saved game shells
	public string WhichTurn { get; set; } //which user turn is next

	public string Username { get; set; } //username of user
	public string UserID { get; set; } //userid of user
	public string AuthKey { get; set; } //authkey of user
	public string ApiResponse { get; set; } //api response from backend

	public SerializationGetInfo(string Username, string UserID, string AuthKey) //constructor
	{
		this.Username = Username; //Setting of variables
		this.AuthKey = AuthKey;
		this.UserID = UserID;
	}
}
