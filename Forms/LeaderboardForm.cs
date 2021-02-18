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
        string userOneName = "";
        string userTwoName = "";
        string userThreeName = "";
        string userOnePoints = "";
        string userTwoPoints = "";
        string userThreePoints = "";
        public LeaderboardForm(string userOneName, string userOnePoints, string userTwoName, 
            string userTwoPoints, string userThreeName, string userThreePoints)
        {
            this.userOneName = userOneName;
            this.userOnePoints = userOnePoints;
            this.userTwoName = userTwoName;
            this.userTwoPoints = userTwoPoints;
            this.userThreeName = userThreeName;
            this.userThreePoints = userThreePoints;
            InitializeComponent();
            setupBoard();
        }

        private void setupBoard()
        {
            playerOneNamesRTB.Text = userOneName;
            playerOnePointsRTB.Text = userOnePoints;
            playerTwoNameRTB.Text = userTwoName;
            playerTwoPointsRTB.Text = userTwoPoints;
            playerThreeNameRTB.Text = userThreeName;
            playerThreePointsRTB.Text = userThreePoints;
        }
        private void playerOneNameRTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
