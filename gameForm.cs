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

        bool gameStarted = false;
        public GameForm(string UserID, string Username, string AuthKey, string Wins, string Losses, string TotalScore)
        {
            this.UserID = UserID;
            this.Username = Username;
            this.AuthKey = AuthKey;
            this.Wins = Wins;
            this.Losses = Losses;
            this.TotalScore = TotalScore;
            InitializeComponent();
            CentreItems();
            setupUser(this.Username, this.Wins, this.Losses, this.TotalScore);
            
        }

        private void bankOneRichTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerOneSquareTwoRTB.Text = Wins + Losses;
            CentreItems();
        }
        private void playerOneButtonTwo_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {

            }
            else
            {
                
            }
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

        
        private void setupUser(string Username, string Wins, string Losses, string TotalScore)
        {
            try
            {
                float winToLoss = 0;

                if (Wins == "null" || Wins == null)
                {
                    Wins = "0";
                }
                if(Losses == "null" || Losses == null)
                {
                    Losses = "0";
                    winToLoss = float.Parse(Wins);
                }
                else
                {
                    winToLoss = int.Parse(Wins) / int.Parse(Losses);
                }
                if (TotalScore == "null" || TotalScore == null)
                {
                    TotalScore = "0";
                }

                playerOneNameRTB.Text = Username;
                playerOneWinLossRTB.Text = winToLoss.ToString();
                playerOneAllTimeScoreRTB.Text = TotalScore;
            }
            catch (Exception error){
                playerOneAllTimeScoreRTB.Text = error.ToString();
            };
            
        }
       
        private void rulesBtn_Click(object sender, EventArgs e)
        {
            RulesForm rulesForm = new RulesForm();
            rulesForm.Show();
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {

        }

        private void savedGameBtn_Click(object sender, EventArgs e)
        {

        }
        private void CentreItems()
        {
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
        }
        public void NewGame() //starts new game, sets points to 0.
        {
            int[] scoreSetup = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            UserPoints userOnePoints = new UserPoints(scoreSetup);
            UserPoints userTwoPoints = new UserPoints(scoreSetup);
        }
        
        public void RefreshBoard()
        {

        }
        
    }
}
