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

namespace Mancala_NEA_Computer_Science_Project
{
    public partial class GameForm : Form
    {
        private static readonly HttpClient client = new HttpClient();

        string Username;
        string Wins;
        string Losses;
        string TotalScore;
        string UserID;
        string AuthKey;
        public UserPoints userOnePoints;
        public UserPoints userTwoPoints;
        bool gameStarted = false;
        int UserTurn;
        public GameForm(string UserID, string Username, string AuthKey, string Wins, string Losses, string TotalScore)
        {
            try
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
            catch(Exception err)
            {
                errorBoxRTB.Text = err.ToString();
            }
        }
        private void bankOneRichTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMove("UserOne", int.Parse(userOnePoints.ReturnUserHoleOne()), 1);
            }
        }
        private void playerOneButtonTwo_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMove("UserOne", int.Parse(userOnePoints.ReturnUserHoleTwo()), 2);
            }
        }
        private void playerOneButtonThree_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMove("UserOne", int.Parse(userOnePoints.ReturnUserHoleThree()), 3);
            }
        }
        private void playerOneButtonFour_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMove("UserOne", int.Parse(userOnePoints.ReturnUserHoleFour()), 4);
            }
        }
        private void playerOneButtonFive_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMove("UserOne", int.Parse(userOnePoints.ReturnUserHoleFive()), 5);
            }
        }
        private void playerOneButtonSix_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMove("UserOne", int.Parse(userOnePoints.ReturnUserHoleSix()), 6);
            }
        }
        private void playerOneButtonSeven_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMove("UserOne", int.Parse(userOnePoints.ReturnUserHoleSeven()), 7);
            }
        }
        private void playerTwoButtonOne_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMove("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleOne()), 1);
            }
        }
        private void playerTwoButtonTwo_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMove("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleTwo()), 2);
            }
        }
        private void playerTwoButtonThree_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMove("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleThree()), 3);
            }
        }
        private void playerTwoButtonFour_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMove("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFour()), 4);
            }
        }
        private void playerTwoButtonFive_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMove("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFive()), 5);
            }
        }
        private void playerTwoButtonSix_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMove("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSix()), 6);
            }
        }
        private void playerTwoButtonSeven_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMove("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSeven()), 7);
            }
        }
        private void rulesBtn_Click(object sender, EventArgs e)
        {
            RulesForm rulesForm = new RulesForm();
            rulesForm.Show();
        }
        private void newGameBtn_Click(object sender, EventArgs e)
        {
            NewGame();
            gameStarted = true;
            UserTurn = 1;
        }
        private void savedGameBtn_Click(object sender, EventArgs e)
        {
            GetSavedGame();
            gameStarted = true;
        }
        private void setupUser(string Username, string Wins, string Losses, string TotalScore)
        {
            try
            {
                float winToLoss = 0;

                if (Wins == "null" || Wins == null || Wins == "0")
                {
                    Wins = "0";
                }
                if (Losses == "null" || Losses == null || Losses == "0")
                {
                    Losses = "0";
                    winToLoss = float.Parse(Wins);
                }
                else
                {
                    winToLoss = int.Parse(Wins) / int.Parse(Losses);
                }
                if (TotalScore == "null" || TotalScore == null || TotalScore == "0")
                {
                    TotalScore = "0";
                }

                playerOneNameRTB.Text = Username;
                playerOneWinLossRTB.Text = winToLoss.ToString();
                playerOneAllTimeScoreRTB.Text = TotalScore;
            }
            catch (Exception error)
            {
                playerOneAllTimeScoreRTB.Text = error.ToString();
            };
        }
        private void CentreItems()
        {
            playerTwoBankRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareOneRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareTwoRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareThreeRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareFourRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareFiveRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareSixRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareSevenRTB.SelectionAlignment = HorizontalAlignment.Center;
            //Align Text in boxes for User1 and User2
            playerOneBankRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareOneRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareTwoRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareThreeRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareFourRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareFiveRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareSixRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareSevenRTB.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void NewGame() //starts new game, sets points to 0.
        {
            int[] scoreSetupOne = new int[] { 0, 4, 4, 4, 4, 4, 4, 4 };
            userOnePoints = new UserPoints(scoreSetupOne);
            int[] scoreSetupTwo = new int[] { 0, 4, 4, 4, 4, 4, 4, 4 };
            userTwoPoints = new UserPoints(scoreSetupTwo);
            RefreshBoard();
        }
        private void GetSavedGame()
        {
            GetUserSavedData getData = new GetUserSavedData(Username, UserID, AuthKey); //getData.
            userOnePoints = new UserPoints(getData.GetUserSave()); //not needed 
            userTwoPoints = new UserPoints(getData.GetAISave());
            RefreshBoard();
        }
        private void RefreshBoard()
        {
            playerTwoBankRTB.Text = userOnePoints.ReturnUserBank();
            playerOneBankRTB.Text = userTwoPoints.ReturnUserBank();

            playerOneSquareOneRTB.Text = userOnePoints.ReturnUserHoleOne();
            playerTwoSquareOneRTB.Text = userTwoPoints.ReturnUserHoleOne();

            playerOneSquareTwoRTB.Text = userOnePoints.ReturnUserHoleTwo();
            playerTwoSquareTwoRTB.Text = userTwoPoints.ReturnUserHoleTwo();

            playerOneSquareThreeRTB.Text = userOnePoints.ReturnUserHoleThree();
            playerTwoSquareThreeRTB.Text = userTwoPoints.ReturnUserHoleThree();

            playerOneSquareFourRTB.Text = userOnePoints.ReturnUserHoleFour();
            playerTwoSquareFourRTB.Text = userTwoPoints.ReturnUserHoleFour();

            playerOneSquareFiveRTB.Text = userOnePoints.ReturnUserHoleFive();
            playerTwoSquareFiveRTB.Text = userTwoPoints.ReturnUserHoleFive();

            playerOneSquareSixRTB.Text = userOnePoints.ReturnUserHoleSix();
            playerTwoSquareSixRTB.Text = userTwoPoints.ReturnUserHoleSix();

            playerOneSquareSevenRTB.Text = userOnePoints.ReturnUserHoleSeven();
            playerTwoSquareSevenRTB.Text = userTwoPoints.ReturnUserHoleSeven();

            CentreItems();
        }
        private void playerMove(string playerMoving, int shells, int currentPosition)
        {
            if(shells == 0) //if no shells when button is clicked
            {

            }
            else
            {
                int sideOfBoard;
                int nextPosition;
                if(playerMoving == "UserOne")
                {
                    nextPosition = currentPosition + 1;
                    sideOfBoard = 1;
                    userOnePoints.RemoveShells(currentPosition);
                    UserTurn = 2;
                }
                else
                {
                    nextPosition = currentPosition - 1;
                    sideOfBoard = 2;
                    userTwoPoints.RemoveShells(currentPosition);
                    UserTurn = 1;
                }

                for (int i = 0; i < shells + 1; i++)
                {
                    if (sideOfBoard == 1)
                    {
                        if(i == shells - 1) //check if last shell is placed in bank
                        {
                            if(nextPosition == 8 && playerMoving == "UserOne")
                            {
                                UserTurn = 1;
                                userOnePoints.UpdateHole(8, playerMoving);
                            }
                            //else if(nextPosition == 0 && playerMoving == "UserTwo")
                            //{
                            //    UserTurn = 2;
                            //    userTwoPoints.UpdateHole(7, playerMoving);
                            //}
                        }
                        else if (nextPosition == 8 && playerMoving == "UserOne") //check if next shells goes in the bank for that player or skips opposing team bank
                        {
                            userOnePoints.UpdateHole(8, playerMoving);
                            nextPosition = 7;
                            sideOfBoard = 2;
                        }
                        else if (nextPosition == 8 && playerMoving == "UserTwo") //check to see if user has gone around the board
                        {
                            userTwoPoints.UpdateHole(7, playerMoving);
                            nextPosition = 6;
                            sideOfBoard = 2;
                        }
                        else
                        {
                            userOnePoints.UpdateHole(nextPosition, playerMoving);
                            nextPosition++;
                        }
                    }
                    else if (sideOfBoard == 2)
                    {
                        if (i == shells - 1) //check if last shell is placed in bank
                        {
                            //if (nextPosition == 8 && playerMoving == "UserOne")
                            //{
                            //    UserTurn = 1;
                            //    userOnePoints.UpdateHole(8, playerMoving);
                            //}
                            if (nextPosition == 0 && playerMoving == "UserTwo")
                            {
                                UserTurn = 2;
                                userTwoPoints.UpdateHole(0, playerMoving);
                            }
                        }
                        else if (nextPosition == 0 && playerMoving == "UserTwo")
                        {
                            userTwoPoints.UpdateHole(0, playerMoving);
                            nextPosition = 1;
                            sideOfBoard = 1;
                        }
                        else if (nextPosition == 0 && playerMoving == "UserOne")
                        {
                            userOnePoints.UpdateHole(1, playerMoving);
                            nextPosition = 2;
                            sideOfBoard = 1;
                        }
                        else
                        {
                            userTwoPoints.UpdateHole(nextPosition, playerMoving);
                            nextPosition--;
                        }
                    }
                    RefreshBoard();
                }
            }
        }

        
    }
}
