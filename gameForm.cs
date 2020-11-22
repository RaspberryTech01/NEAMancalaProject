using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mancala_NEA_Computer_Science_Project
{
    public partial class GameForm : Form
    {
        string Username;
        string Wins;
        string Losses;
        string TotalScore;
        string UserID;
        string AuthKey;
        public GameForm(string UserID, string AuthKey)
        {
            this.UserID = UserID;
            this.AuthKey = AuthKey;
            InitializeComponent();
            playerOneBankRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareOneRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareTwoRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareThreeRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareFourRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareFiveRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareSixRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareSevenRTB.SelectionAlignment = HorizontalAlignment.Center;
            //Align Text in boxes for User1 and User2
            playerTwoBankRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareOneRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareTwoRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareThreeRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareFourRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareFiveRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareSixRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareSevenRTB.SelectionAlignment = HorizontalAlignment.Center;

            playerOneButtonOne.FlatStyle = FlatStyle.Flat;
            playerOneButtonOne.BackColor = Color.Transparent;
            playerOneButtonOne.FlatAppearance.MouseDownBackColor = Color.Transparent;
            playerOneButtonOne.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void bankOneRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerOneSquareTwoRTB.Text = "2";
        }

        private void playerOneButtonThree_Click(object sender, EventArgs e)
        {

        }

        private void playerOneButtonFour_Click(object sender, EventArgs e)
        {

        }

        private void playerOneButtonFive_Click(object sender, EventArgs e)
        {

        }

        private void playerOneButtonSix_Click(object sender, EventArgs e)
        {

        }

        private void playerOneButtonSeven_Click(object sender, EventArgs e)
        {

        }
    }
}
