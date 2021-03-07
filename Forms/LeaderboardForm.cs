using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mancala_NEA_Computer_Science_Project.Forms
{
    public partial class LeaderboardForm : Form
    {
        string userOneName = ""; //user one name
        string userTwoName = ""; //user two name
        string userThreeName = ""; //user three name
        string userOnePoints = ""; //user one's points
        string userTwoPoints = ""; //user two's points
        string userThreePoints = ""; //user three's points
        public LeaderboardForm(string userOneName, string userOnePoints, string userTwoName, 
            string userTwoPoints, string userThreeName, string userThreePoints)
        { //constructor
            this.userOneName = userOneName; //setting of variables
            this.userOnePoints = userOnePoints;
            this.userTwoName = userTwoName;
            this.userTwoPoints = userTwoPoints;
            this.userThreeName = userThreeName;
            this.userThreePoints = userThreePoints;
            InitializeComponent(); //creation of form
            setupBoard(); //setting up board
        }

        private void setupBoard() //adding placeholders
        {
            playerOneNamesRTB.Text = userOneName; //setting text to variables
            playerOnePointsRTB.Text = userOnePoints;
            playerTwoNameRTB.Text = userTwoName;
            playerTwoPointsRTB.Text = userTwoPoints;
            playerThreeNameRTB.Text = userThreeName;
            playerThreePointsRTB.Text = userThreePoints;
        }
        private void playerOneNameRTB_TextChanged(object sender, EventArgs e) //just a test button to quickly access code
        {

        }
    }
}
