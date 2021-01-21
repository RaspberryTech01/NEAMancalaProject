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
        bool gameOver = false;
        bool captureFunction = false;
        int UserTurn;
        bool AIPlaying = false;
        bool sentFinishedData;
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
            catch (Exception err)
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
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleOne()), 1);
            }
        }
        private void playerOneButtonTwo_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleTwo()), 2);
            }
        }
        private void playerOneButtonThree_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleThree()), 3);
            }
        }
        private void playerOneButtonFour_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleFour()), 4);
            }
        }
        private void playerOneButtonFive_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleFive()), 5);
            }
        }
        private void playerOneButtonSix_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleSix()), 6);
            }
        }
        private void playerOneButtonSeven_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleSeven()), 7);
            }
        }
        private void playerTwoButtonOne_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleOne()), 1);
            }
        }
        private void playerTwoButtonTwo_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleTwo()), 2);
            }
        }
        private void playerTwoButtonThree_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleThree()), 3);
            }
        }
        private void playerTwoButtonFour_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFour()), 4);
            }
        }
        private void playerTwoButtonFive_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFive()), 5);
            }
        }
        private void playerTwoButtonSix_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSix()), 6);
            }
        }
        private void playerTwoButtonSeven_Click(object sender, EventArgs e)
        {
            if (gameStarted && UserTurn == 2)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSeven()), 7);
            }
        }
        private void rulesBtn_Click(object sender, EventArgs e)
        {
            RulesForm rulesForm = new RulesForm();
            rulesForm.Show();
        }
        private void newGameBtn_Click(object sender, EventArgs e)
        {
            AIPlayerGameBtn.Visible = true;
            twoPlayerGameBtn.Visible = true;
            newGameBtn.Visible = false;
        }
        private void savedGameBtn_Click(object sender, EventArgs e)
        {
            GetSavedGame();
        }
        private void captureBtn_Click(object sender, EventArgs e)
        {
            if (captureFunction)
            {
                captureFunction = false;
                captureBtn.Text = "Capture Off";
            }
            else if (!captureFunction)
            {
                captureFunction = true;
                captureBtn.Text = "Capture On";
            }
        }
        private void twoPlayerGameBtn_Click(object sender, EventArgs e)
        {
            NewGame();
            AIPlaying = false;
            AIPlayerGameBtn.Visible = false;
            twoPlayerGameBtn.Visible = false;
            newGameBtn.Visible = true;
            playerTwoNameRTB.Text = "Player 2";
        }

        private void AIPlayerGameBtn_Click(object sender, EventArgs e)
        {
            AIPlaying = true;
            playerTwoNameRTB.Text = "AI Player";
            NewGame();
            AIPlayerGameBtn.Visible = false;
            twoPlayerGameBtn.Visible = false;
            newGameBtn.Visible = true;
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
            playerOneRTBTurn.SelectionAlignment = HorizontalAlignment.Center;
            //Align Text in boxes for User1 and User2
            playerOneBankRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareOneRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareTwoRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareThreeRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareFourRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareFiveRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareSixRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoSquareSevenRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoRTBTurn.SelectionAlignment = HorizontalAlignment.Center;
        }
        private void NewGame() //starts new game, sets points to 0.
        {
            //int[] scoreSetupOne = new int[] { 0, 4, 4, 4, 4, 4, 4, 4 };
            int[] scoreSetupOne = new int[] { 0, 0, 0, 0, 0, 0, 0, 4 };
            userOnePoints = new UserPoints(scoreSetupOne);
           // int[] scoreSetupTwo = new int[] { 0, 4, 4, 4, 4, 4, 4, 4 };
            int[] scoreSetupTwo = new int[] { 0, 0, 0, 0, 0, 0, 0, 4 };

            userTwoPoints = new UserPoints(scoreSetupTwo);
            UserTurn = 1;
            gameStarted = true;
            gameOver = false;
            sentFinishedData = false;
            RefreshBoard();
        }
        private void GetSavedGame()
        {
            GetUserSavedData getData = new GetUserSavedData(Username, UserID, AuthKey); //getData.
            userOnePoints = new UserPoints(getData.GetUserSave()); //not needed 
            userTwoPoints = new UserPoints(getData.GetAISave());
            gameStarted = true;
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

            playerOneCurrentScoreRTB.Text = userOnePoints.ReturnUserBank();
            playerTwoCurrentScoreRTB.Text = userTwoPoints.ReturnUserBank();

            if (UserTurn == 1)
            {
                playerOneRTBTurn.Text = "Player 1's Turn";
                playerTwoRTBTurn.Text = "";
            }
            else if (UserTurn == 2)
            {
                playerOneRTBTurn.Text = "";
                playerTwoRTBTurn.Text = "Player 2's Turn";
            }
            if (gameOver)
            {
                playerOneRTBTurn.Text = "Game Over";
                playerTwoRTBTurn.Text = "Game Over";
            }
            CentreItems();
        }
        private async Task playerMoveAsync(string playerMoving, int shells, int currentPosition)
        {
            if (shells == 0) //if no shells when button is clicked
            {
                return;
            }
            else if (gameOver)
            {
                return;
            }
            else
            {
                int sideOfBoard;
                int nextPosition;
                if (playerMoving == "UserOne")
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

                for (int i = 0; i < shells; i++)
                {
                    if (sideOfBoard == 1)
                    {
                        if (i == shells - 1) //check for last shell
                        {
                            bool capturePieces = false;
                            if (captureFunction)
                            {
                                if (playerMoving == "UserOne")
                                {
                                    if (nextPosition < 8 && userOnePoints.ReturnUserHole(nextPosition) == "0")
                                    {
                                        capturePieces = true;
                                    }
                                }
                            }

                            if (nextPosition == 8 && playerMoving == "UserOne")
                            {
                                UserTurn = 1;
                                await userOnePoints.UpdateHole(8, playerMoving);
                            }
                            else if (nextPosition == 8 && playerMoving == "UserTwo")
                            {
                                await userTwoPoints.UpdateHole(7, playerMoving);
                            }
                            else
                            {
                                if (capturePieces)
                                {
                                    if (playerMoving == "UserOne")
                                    {
                                        string shellCapture = userTwoPoints.ReturnUserHole(nextPosition);
                                        userOnePoints.UpdateBank(shellCapture);
                                        userTwoPoints.RemoveShells(nextPosition);
                                    }
                                }
                                await userOnePoints.UpdateHole(nextPosition, playerMoving);
                                nextPosition++;
                            }
                        }
                        else if (nextPosition == 8 && playerMoving == "UserOne") //check if next shells goes in the bank for that player or skips opposing team bank
                        {
                            await userOnePoints.UpdateHole(8, playerMoving);
                            nextPosition = 7;
                            sideOfBoard = 2;
                        }
                        else if (nextPosition == 8 && playerMoving == "UserTwo") //check to see if user has gone around the board
                        {
                            await userTwoPoints.UpdateHole(7, playerMoving);
                            nextPosition = 6;
                            sideOfBoard = 2;
                        }
                        else
                        {
                            await userOnePoints.UpdateHole(nextPosition, playerMoving);
                            nextPosition++;
                        }
                    }
                    else if (sideOfBoard == 2)
                    {
                        if (i == shells - 1) //check if last shell is placed in bank
                        {
                            bool capturePieces = false;
                            if (captureFunction)
                            {
                                if (playerMoving == "UserTwo")
                                {
                                    if (nextPosition < 8 && userTwoPoints.ReturnUserHole(nextPosition) == "0")
                                    {
                                        capturePieces = true;
                                    }
                                }
                            }

                            if (nextPosition == 0 && playerMoving == "UserTwo")
                            {
                                UserTurn = 2;
                                await userTwoPoints.UpdateHole(0, playerMoving);
                            }
                            else if (nextPosition == 0 && playerMoving == "UserOne")
                            {
                                await userOnePoints.UpdateHole(1, playerMoving);
                            }
                            else
                            {
                                if (capturePieces)
                                {
                                    if (playerMoving == "UserTwo")
                                    {
                                        string shellCapture = userOnePoints.ReturnUserHole(nextPosition);
                                        userTwoPoints.UpdateBank(shellCapture);
                                        userOnePoints.RemoveShells(nextPosition);
                                    }
                                }
                                await userTwoPoints.UpdateHole(nextPosition, playerMoving);
                                nextPosition++;
                            }
                        }
                        else if (nextPosition == 0 && playerMoving == "UserTwo")
                        {
                            await userTwoPoints.UpdateHole(0, playerMoving);
                            nextPosition = 1;
                            sideOfBoard = 1;
                        }
                        else if (nextPosition == 0 && playerMoving == "UserOne")
                        {
                            await userOnePoints.UpdateHole(1, playerMoving);
                            nextPosition = 2;
                            sideOfBoard = 1;
                        }
                        else
                        {
                            await userTwoPoints.UpdateHole(nextPosition, playerMoving);
                            nextPosition--;
                        }
                    }
                    RefreshBoard();
                    await GameOverAsync();
                    
                }
            }
        }
        private async Task<bool> GameOverAsync()
        {
            if (userOnePoints.ReturnUserHoleOne() == "0" && userOnePoints.ReturnUserHoleTwo() == "0" && userOnePoints.ReturnUserHoleThree() == "0" &&
                userOnePoints.ReturnUserHoleFour() == "0" && userOnePoints.ReturnUserHoleFive() == "0" && userOnePoints.ReturnUserHoleSix() == "0" &&
                userOnePoints.ReturnUserHoleSeven() == "0")
            {
                gameOver = true;
                
            }
            else if (userTwoPoints.ReturnUserHoleOne() == "0" && userTwoPoints.ReturnUserHoleTwo() == "0" && userTwoPoints.ReturnUserHoleThree() == "0" &&
                userTwoPoints.ReturnUserHoleFour() == "0" && userTwoPoints.ReturnUserHoleFive() == "0" && userTwoPoints.ReturnUserHoleSix() == "0" &&
                userTwoPoints.ReturnUserHoleSeven() == "0")
            {
                gameOver = true;
            }
            else
            {
                return false;
            }

            bool Win;
            if (int.Parse(userOnePoints.ReturnUserBank()) > int.Parse(userTwoPoints.ReturnUserBank()))
            {
                Win = true;
            }
            else
            {
                Win = false;
            }
            try
            {
                if (gameOver && !sentFinishedData)
                {
                    string response = await UpdateDataAsync(Username, UserID, AuthKey, userOnePoints.ReturnUserBank(), Win);
                    if (response == "true")
                    {
                        errorBoxRTB.Text = "Update data in database successfully!";
                    }
                    else
                    {
                        errorBoxRTB.Text = "An error occurred when trying to update data.";
                    }
                    sentFinishedData = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                errorBoxRTB.Text = "An error occurred when trying to update data.";
                return false;
            }
        }
        private async Task<string> UpdateDataAsync(string Username, string UserID, string AuthKey, string Shells, bool Win)
        {
            try
            {
                SerializationUpdateData serialSaveGame = new SerializationUpdateData(Username, UserID, AuthKey, Shells, Win);
                string jsonString = JsonConvert.SerializeObject(serialSaveGame);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/savedata", content);
                var RString = await result.Content.ReadAsStringAsync();
                SerializationUpdateData deserialObj = JsonConvert.DeserializeObject<SerializationUpdateData>(RString);
                return deserialObj.ApiResponse;
            }
            catch
            {
                return "false";
            }
        }
    }
}
