using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SerializationSaveGame //used for saving current game on backend
{
	public string UserSave { get; set; } //User array for points
	public string AISave { get; set; } //User Two/AI array for points
	public string WhichTurn { get; set; } //Which users turn is next

	public string Username { get; set; } //User's username
	public string UserID { get; set; } //user's UserID
	public string AuthKey { get; set; } //Authorization key for user
	public string ApiResponse { get; set; } //API response from backend

	public SerializationSaveGame(string Username, string UserID, string AuthKey, int[] UserOnePoints, int[] UserTwoPoints, int UserTurn)
	{ //constructor
		this.Username = Username; //setting of variables
		this.AuthKey = AuthKey;
		this.UserID = UserID;

		this.UserSave = ConvertToString(UserOnePoints); //converts incoming array to a string and stores
        this.AISave = ConvertToString(UserTwoPoints);
        this.WhichTurn = UserTurn.ToString();
	}
    private static string ConvertToString(int[] array) //converts an array to a string
    {
        string StringFinal = ""; //final string 
        for (int i = 0; i < array.Length; i++) //for loop to loop through each array value
        {
            if (i != array.Length - 1) //if not final value
            {
                StringFinal += array[i].ToString() + ","; //add comma
            }
            else
            {
                StringFinal += array[i].ToString(); //no comma
            }
        }
        return StringFinal;
    }
}
