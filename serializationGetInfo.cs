using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class serializationGetInfo
{
	public string UserSave { get; set; }
	public string AISave { get; set; }

	public string Username { get; set; }
	public string UserID { get; set; }
	public string AuthKey { get; set; }

	public serializationGetInfo(string Username, string UserID, string AuthKey)
	{
		this.Username = Username;
		this.AuthKey = AuthKey;
		this.UserID = UserID;
	}
}
