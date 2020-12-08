using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_NEA_Computer_Science_Project
{
    class UserInfoSplit
    {
        private string[] arrayAfterSplit;
        public UserInfoSplit(string strToBeSplit)
        {
            this.arrayAfterSplit = SplitStringIntoArray(strToBeSplit);
        }

        private string[] SplitStringIntoArray (string strToBeSplit)
        {
            string[] arrayAfterSplit = strToBeSplit.Split(',');
            return arrayAfterSplit;
        }
        public string[] SendSplit()
        {
            return this.arrayAfterSplit;
        }
    }
}
