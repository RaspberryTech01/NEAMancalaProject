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

	//add functions to return user info
}
