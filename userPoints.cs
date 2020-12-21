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

public class UserPoints
{
	
	private int[] UserScores = new int[8];
	
	public UserPoints(int[] Scores)
	{
        try
        {
			this.UserScores = Scores;
		}
        catch (Exception)
        {

        }
	}
	public string ReturnUserBank()
	{
		return UserScores[0].ToString();
	}
	public string ReturnUserHoleOne()
    {
		return UserScores[1].ToString();
    }
	public string ReturnUserHoleTwo()
	{
		return UserScores[2].ToString();
	}
	public string ReturnUserHoleThree()
	{
		return UserScores[3].ToString();
	}
	public string ReturnUserHoleFour()
	{
		return UserScores[4].ToString();
	}
	public string ReturnUserHoleFive()
	{
		return UserScores[5].ToString();
	}
	public string ReturnUserHoleSix()
	{
		return UserScores[6].ToString();
	}
	public string ReturnUserHoleSeven()
	{
		return UserScores[7].ToString();
	}
	//add functions to return user info
}
