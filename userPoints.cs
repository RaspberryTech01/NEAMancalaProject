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
	public string ReturnUserHole(int holeNum)
	{
		return UserScores[holeNum].ToString();
	}
	public async Task <string> UpdateHole(int holeNum, string UserMove)
    {
		if (holeNum == 8 && UserMove == "UserOne")
		{
			UserScores[0] = UserScores[0] + 1;
		}
		else if (holeNum == 0 && UserMove == "UserTwo")
        {
			UserScores[0] = UserScores[0] + 1;
		}
		else
		{
			UserScores[holeNum] = UserScores[holeNum] + 1;
		}
		
		return "done";
    }
	public void UpdateBank(string shellNum)
    {
		UserScores[0] = UserScores[0] + int.Parse(shellNum);
    }
	public void RemoveShells(int holeNum)
    {
		UserScores[holeNum] = 0;
    }
	//add functions to return user info
}
