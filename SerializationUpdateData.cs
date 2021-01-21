using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SerializationUpdateData
{
	public string Username { get; set; }
	public string UserID { get; set; }
	public string AuthKey { get; set; }
	public string Shells { get; set; }
	public bool Win { get; set; }
	public string ApiResponse { get; set; }

	public SerializationUpdateData(string Username, string UserID, string AuthKey, string ShellNumber, bool Win)
	{
		this.Username = Username;
		this.AuthKey = AuthKey;
		this.UserID = UserID;
		this.Shells = ShellNumber;
		this.Win = Win;
	}
}
