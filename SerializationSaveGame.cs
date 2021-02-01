using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SerializationSaveGame
{
	public string UserSave { get; set; }
	public string AISave { get; set; }
	public string WhichTurn { get; set; }

	public string Username { get; set; }
	public string UserID { get; set; }
	public string AuthKey { get; set; }
	public string ApiResponse { get; set; }

	public SerializationSaveGame(string Username, string UserID, string AuthKey, int[] UserOnePoints, int[] UserTwoPoints, int UserTurn)
	{
		this.Username = Username;
		this.AuthKey = AuthKey;
		this.UserID = UserID;

		this.UserSave = ConvertToString(UserOnePoints);
        this.AISave = ConvertToString(UserTwoPoints);
        this.WhichTurn = UserTurn.ToString();
	}
    private static string ConvertToString(int[] array)
    {
        string StringFinal = "";
        for (int i = 0; i < array.Length; i++)
        {
            if (i != array.Length - 1)
            {
                StringFinal += array[i].ToString() + ",";
            }
            else
            {
                StringFinal += array[i].ToString();
            }
        }
        return StringFinal;
    }
}
