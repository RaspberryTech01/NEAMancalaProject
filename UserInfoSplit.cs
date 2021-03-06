﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_NEA_Computer_Science_Project
{
    class UserInfoSplit
    {
        private int[] arrayAfterSplit; //holds array of integer shells
        public UserInfoSplit(string strToBeSplit) //constructor
        {
            this.arrayAfterSplit = SplitStringIntoArray(strToBeSplit);
        }

        private int[] SplitStringIntoArray(string strToBeSplit) //splits string into integer array
        {
            int[] arrayAfterSplit = strToBeSplit.Split(',').Select(int.Parse).ToArray(); //splits at comma
            return arrayAfterSplit;
        }
        public int[] SendSplit()
        {
            return this.arrayAfterSplit; //returns back the array
        }
    }
}
