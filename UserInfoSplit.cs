using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_NEA_Computer_Science_Project
{
    class UserInfoSplit
    {
        private int[] arrayAfterSplit;
        public UserInfoSplit(string strToBeSplit)
        {
            this.arrayAfterSplit = SplitStringIntoArray(strToBeSplit);
        }

        private int[] SplitStringIntoArray(string strToBeSplit)
        {
            int[] arrayAfterSplit = strToBeSplit.Split(',').Select(int.Parse).ToArray();
            return arrayAfterSplit;
        }
        public int[] SendSplit()
        {
            return this.arrayAfterSplit;
        }
    }
}
