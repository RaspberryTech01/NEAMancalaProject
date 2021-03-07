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
	public string ReturnUserBank() //returns back user bank
	{
		return UserScores[0].ToString();
	}
	public string ReturnUserHoleOne() //returns back user hole
	{
		return UserScores[1].ToString();
    }
	public string ReturnUserHoleTwo() //returns back user hole
	{
		return UserScores[2].ToString();
	}
	public string ReturnUserHoleThree()//returns back user hole
	{
		return UserScores[3].ToString();
	}
	public string ReturnUserHoleFour() //returns back user hole
	{
		return UserScores[4].ToString();
	}
	public string ReturnUserHoleFive() //returns back user hole
	{
		return UserScores[5].ToString();
	}
	public string ReturnUserHoleSix()//returns back user hole
	{
		return UserScores[6].ToString();
	}
	public string ReturnUserHoleSeven() //returns back user hole
	{
		return UserScores[7].ToString();
	}
	public string ReturnUserHole(int holeNum) //returns back user hole based on integer
	{
		return UserScores[holeNum].ToString();
	}
	public async Task <string> UpdateHole(int holeNum, string UserMove)// increment hole by one
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
	public void UpdateBank(string shellNum) // update player bank based on shell input
    {
		UserScores[0] = UserScores[0] + int.Parse(shellNum);
    }
	public void RemoveShells(int holeNum) //set shell box to 0
    {
		UserScores[holeNum] = 0;
    }
	public int[] ReturnArray()
    {
		return UserScores;
    }
}
