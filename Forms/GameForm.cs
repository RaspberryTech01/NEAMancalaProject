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
using Mancala_NEA_Computer_Science_Project.Forms;

namespace Mancala_NEA_Computer_Science_Project
{
    public partial class GameForm : Form
    {
        private static readonly HttpClient client = new HttpClient(); //instatiation of http client

        string Username; //stores username of user
        string Wins; //stores the wins of the user
        string Losses; //stores the losses of the user
        string TotalScore; //stores the total score of the user
        string UserID; //stores the user's user id
        string AuthKey; //stores user Authorization key
        public UserPoints userOnePoints; //user one points
        public UserPoints userTwoPoints; //user two/AI points
        bool gameStarted = false; //for checking if game has started or not
        bool gameOver = false; //for checking game has ended or not
        bool captureFunction = false; //checks if the capture function is enabled 
        int UserTurn; //stores which user turn it is
        bool AIPlaying = false; //checks if AI is playing or not
        bool sentFinishedData; //checks if finished game data has been sent
        AI stringAI = new AI(); //a new AI instance
        int AIMode = 1; //AI mode (hardness)

        public GameForm(string UserID, string Username, string AuthKey, string Wins, string Losses, string TotalScore) //constructor
        {
            try
            {
                this.UserID = UserID; //setting of incoming values
                this.Username = Username;
                this.AuthKey = AuthKey;
                this.Wins = Wins;
                this.Losses = Losses;
                this.TotalScore = TotalScore;
                InitializeComponent(); //start up form
                CentreItems(); //centre text in form
                setupUser(this.Username, this.Wins, this.Losses, this.TotalScore); //setup user one
            }
            catch (Exception err) //if error has occurred
            {
                errorBoxRTB.Text = err.ToString();
            }
        }

        private void bankOneRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e) //if user one hole one clicked
        {
            if (gameStarted && UserTurn == 1) //if game has been started and it is user one turn
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleOne()), 1); //run function
            }
        }
        private void playerOneButtonTwo_Click(object sender, EventArgs e) //if user one hole two clicked
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleTwo()), 2);
            }
        }
        private void playerOneButtonThree_Click(object sender, EventArgs e) //if user one hole three clicked
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleThree()), 3);
            }
        }
        private void playerOneButtonFour_Click(object sender, EventArgs e) //if user one hole four clicked
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleFour()), 4);
            }
        }
        private void playerOneButtonFive_Click(object sender, EventArgs e) //if user one hole five clicked
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleFive()), 5); 
            }
        }
        private void playerOneButtonSix_Click(object sender, EventArgs e)//if user one hole six clicked
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleSix()), 6);
            }
        }
        private void playerOneButtonSeven_Click(object sender, EventArgs e) //if user one hole seven clicked
        {
            if (gameStarted && UserTurn == 1)
            {
                playerMoveAsync("UserOne", int.Parse(userOnePoints.ReturnUserHoleSeven()), 7);
            }
        }
        private void playerTwoButtonOne_Click(object sender, EventArgs e) //if user two hole one clicked
        {
            if (gameStarted && UserTurn == 2 && !AIPlaying)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleOne()), 1);
            }
        }
        private void playerTwoButtonTwo_Click(object sender, EventArgs e) //if user two hole two clicked
        {
            if (gameStarted && UserTurn == 2 && !AIPlaying) //if game has started, User turn is 2 and AI is not playing
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleTwo()), 2);
            }
        }
        private void playerTwoButtonThree_Click(object sender, EventArgs e) //if user two hole three clicked
        {
            if (gameStarted && UserTurn == 2 && !AIPlaying)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleThree()), 3);
            }
        }
        private void playerTwoButtonFour_Click(object sender, EventArgs e) //if user two hole four clicked
        {
            if (gameStarted && UserTurn == 2 && !AIPlaying)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFour()), 4);
            }
        }
        private void playerTwoButtonFive_Click(object sender, EventArgs e) //if user two hole five clicked
        {
            if (gameStarted && UserTurn == 2 && !AIPlaying)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFive()), 5);
            }
        }
        private void playerTwoButtonSix_Click(object sender, EventArgs e) //if user two hole six clicked
        {
            if (gameStarted && UserTurn == 2 && !AIPlaying)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSix()), 6);
            }
        }
        private void playerTwoButtonSeven_Click(object sender, EventArgs e) //if user two hole seven clicked
        {
            if (gameStarted && UserTurn == 2 && !AIPlaying)
            {
                playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSeven()), 7);
            }
        }
        private void rulesBtn_Click(object sender, EventArgs e) //if rules button is clicked
        {
            RulesForm rulesForm = new RulesForm(); //new rules form instance
            rulesForm.Show(); //show the rules form
        }
        private void newGameBtn_Click(object sender, EventArgs e) //if new game is clicked
        {
            AIPlayerGameBtn.Visible = true; //show AI player button
            twoPlayerGameBtn.Visible = true; //show two player game button
            newGameBtn.Visible = false; //hide new game button

            twoPlayerSavedBtn.Visible = false; //hide two player saved button
            AIPlayerSavedBtn.Visible = false; //hide ai player saved button
            savedGameBtn.Visible = true; //show saved game button
        }
        private void savedGameBtn_Click(object sender, EventArgs e) //if saved game button clicked
        {
            twoPlayerSavedBtn.Visible = true; //show two player saved button
            AIPlayerSavedBtn.Visible = true; //show AI player saved button
            savedGameBtn.Visible = false; //hide saved game button

            twoPlayerGameBtn.Visible = false; //hide two player game button
            AIPlayerGameBtn.Visible = false; //hide ai player game button
            newGameBtn.Visible = true; //show new game button

        }
        private void captureBtn_Click(object sender, EventArgs e) //if capture button clicked
        {
            if (captureFunction) //if capture function is enabled
            {
                captureFunction = false; //disable capture function 
                captureBtn.Text = "Capture Off"; //show capture function turned off
            }
            else if (!captureFunction)// if capture function disabled 
            {
                captureFunction = true; //enable capture function
                captureBtn.Text = "Capture On"; //show capture function turned on
            }
        }
        private void twoPlayerGameBtn_Click(object sender, EventArgs e) //if two player new game button clicked
        {
            NewGame(); //start a new game
            AIPlaying = false; //disable AI player
            AIPlayerGameBtn.Visible = false; //hide AI player new game button
            twoPlayerGameBtn.Visible = false; //hide two player new game button
            newGameBtn.Visible = true; //show new game button
            playerTwoNameRTB.Text = "Player 2"; //opposing player is player 2
            doAITurnBtn.Visible = false; //hide AI player buttons
            AIModeBtn.Visible = false;
        }

        private void AIPlayerGameBtn_Click(object sender, EventArgs e) //if AI player new game clicked
        {
            AIPlaying = true; //enable AI player
            playerTwoNameRTB.Text = "AI Player"; //opposing player is AI player
            NewGame(); //start new game
            AIPlayerGameBtn.Visible = false; // hide AI player new game button
            twoPlayerGameBtn.Visible = false; //hide two player new game button
            newGameBtn.Visible = true; //new game button shown
            doAITurnBtn.Visible = true; //AI movement buttons shown
            AIModeBtn.Visible = true;
        }
        private void twoPlayerSavedBtn_Click(object sender, EventArgs e) //if two player saved game clicked
        {
            savedGameBtn.Visible = true; //show saved game button
            twoPlayerSavedBtn.Visible = false; //hide two player saved button
            AIPlayerSavedBtn.Visible = false; //hide ai player saved button
            GetSavedGameAsync(Username, UserID, AuthKey); //make API call to get saved data
            doAITurnBtn.Visible = false; //hide AI player button
            playerTwoNameRTB.Text = "Player 2"; //set opposite player name
            AIPlaying = false; //disable AI
            AIModeBtn.Visible = false; //hide AI button
        }
        private void AIPlayerSavedBtn_Click(object sender, EventArgs e) //if ai player saved game clicked
        {
            savedGameBtn.Visible = true; //saved game button shown
            twoPlayerSavedBtn.Visible = false; //two player saved game button hidden
            AIPlayerSavedBtn.Visible = false; //ai player saved game button hidden
            GetSavedGameAsync(Username, UserID, AuthKey); //make api call to get saved data
            doAITurnBtn.Visible = true; //show AI player button
            playerTwoNameRTB.Text = "AI Player"; //opposite player name set
            AIPlaying = true; //enable AI player
            AIModeBtn.Visible = true; //show AI mode button
        }
        private void doAITurnBtn_ClickAsync(object sender, EventArgs e) //if AI player turn button is clicked
        {
            if (UserTurn == 2) //if it is User two's turn (the opposite player)
            {
                string AIValue = stringAI.DoAITurn(userOnePoints.ReturnArray(), userTwoPoints.ReturnArray(), AIMode, captureFunction); //pass values into AI class
                if (AIValue == "1") //if AI chooses value 1
                {
                    playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleOne()), 1); //move player two's shells based on the hole chosen by AI
                }
                else if (AIValue == "2") //if AI chooses value 2
                {
                    playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleTwo()), 2);
                }
                else if (AIValue == "3")//if AI chooses value 3
                {
                    playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleThree()), 3);
                }
                else if (AIValue == "4")//if AI chooses value 4
                {
                    playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFour()), 4);
                }
                else if (AIValue == "5") //if AI chooses value 5
                {
                    playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleFive()), 5);
                }
                else if (AIValue == "6") //if AI chooses value 6
                {
                    playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSix()), 6);
                }
                else if (AIValue == "7") //if AI chooses value 7
                {
                    playerMoveAsync("UserTwo", int.Parse(userTwoPoints.ReturnUserHoleSeven()), 7);
                }
                GameOverAsync(); //check if game is over
            }
        }
        private void saveGameBtn_Click(object sender, EventArgs e)
        {
            if (!gameOver && gameStarted) //if the game is not over and the game has started
            {
                SaveGameNow(Username, UserID, AuthKey); //make api call to save game
            }
        }

        private async Task GetOpenLeaderboard() //makes API call and opens leaderboard form
        {
            SerializationGetLB serialGetLB = new SerializationGetLB(); //instatiation of class
            string jsonString = JsonConvert.SerializeObject(serialGetLB); //convert values to JSON
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json"); //stores content to be sent to backend

            var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/leaderboard", content);//sends api call 
            var RString = await result.Content.ReadAsStringAsync(); //read response as string
            SerializationGetLB deserialObj = JsonConvert.DeserializeObject<SerializationGetLB>(RString); //convert string to json

            LeaderboardForm leaderboardForm = new LeaderboardForm(deserialObj.userOneName, deserialObj.userOnePoints,
                deserialObj.userTwoName, deserialObj.userTwoPoints, deserialObj.userThreeName, deserialObj.userThreePoints); //create new leaderboard form
            leaderboardForm.Show(); //show leaderboard form
        }
        private void setupUser(string Username, string Wins, string Losses, string TotalScore) //setup logged in user (user one)
        {
            try
            {
                float winToLoss = 0; //store win to loss ratio

                if (Wins == "null" || Wins == null || Wins == "0") //if user has 0 wins
                {
                    Wins = "0"; //set wins to 0
                }
                if (Losses == "null" || Losses == null || Losses == "0")
                {
                    Losses = "0";
                    winToLoss = float.Parse(Wins); //convert to float
                }
                else
                {
                    winToLoss = float.Parse(Wins) / float.Parse(Losses); //calculate win to loss ratio
                }
                if (TotalScore == "null" || TotalScore == null || TotalScore == "0")
                {
                    TotalScore = "0";
                }

                playerOneNameRTB.Text = Username; //set player one name to logged in user username
                playerOneWinLossRTB.Text = winToLoss.ToString(); //set win to loss ratio
                playerOneAllTimeScoreRTB.Text = TotalScore; //set all time score 
            }
            catch (Exception error) //if error occurs
            {
                playerOneAllTimeScoreRTB.Text = error.ToString();
            };
        }
        private void CentreItems() //centre items
        {
            playerTwoBankRTB.SelectionAlignment = HorizontalAlignment.Center; //center all text in text boxes
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
            int[] scoreSetupOne = new int[] { 0, 7, 7, 7, 7, 7, 7, 7 }; //default values
            userOnePoints = new UserPoints(scoreSetupOne); //setup user one

            int[] scoreSetupTwo = new int[] { 0, 7, 7, 7, 7, 7, 7, 7 }; //default values 
            userTwoPoints = new UserPoints(scoreSetupTwo); //set user two

            UserTurn = 1; //user one goes first
            gameStarted = true; //start game
            gameOver = false; //game has not ended
            sentFinishedData = false; //data has not been sent
            RefreshBoard(); //refresh board
        }
        private async Task SaveGameNow(string Username, string UserID, string AuthKey) //sends API call to save current game
        {
            //API CALL stuff
            SerializationSaveGame serialSaveGame = new SerializationSaveGame(Username, UserID, AuthKey, userOnePoints.ReturnArray(), userTwoPoints.ReturnArray(), UserTurn);
            string jsonString = JsonConvert.SerializeObject(serialSaveGame);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/savegame", content);
            var RString = await result.Content.ReadAsStringAsync();
            SerializationSaveRes deserialObj = JsonConvert.DeserializeObject<SerializationSaveRes>(RString);
            //API END
            if(deserialObj.ApiResponse == "true") //if API successfully works
            {
                errorBoxRTB.Text = "Saved successfully"; //show saves successfully
            }
            else
            {
                errorBoxRTB.Text = "An error occurred when trying to save."; //show error
            }
        }
        private async Task GetSavedGameAsync(string Username, string UserID, string AuthKey) //sends API call to get latest saved game
        {
            int[] UserSave; //stores user one's data
            int[] AISave; //stores user two's/AI data
            //API CALL
            SerializationGetInfo serialGetInfo = new SerializationGetInfo(Username, UserID, AuthKey);
            string jsonString = JsonConvert.SerializeObject(serialGetInfo);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/getinfo", content);
            var RString = await result.Content.ReadAsStringAsync();
            SerializationGetInfo deserialObj = JsonConvert.DeserializeObject<SerializationGetInfo>(RString);
            string userSaveString = deserialObj.UserSave; //set incoming JSON saved data to variables
            string AISaveString = deserialObj.AISave;
            string WhichTurn = deserialObj.WhichTurn;
            UserInfoSplit UserSplitSave = new UserInfoSplit(userSaveString); //split incoming string into an array so that it can be used in the game
            UserInfoSplit AISplitSave = new UserInfoSplit(AISaveString);
            UserSave = UserSplitSave.SendSplit(); //set data
            AISave = AISplitSave.SendSplit();
            
            userOnePoints = new UserPoints(UserSave); //set userOnePoints to new UserPoints instance
            userTwoPoints = new UserPoints(AISave);

            if(WhichTurn == "1") //if incoming API call says user turn is one
            {
                UserTurn = 1; //set user turn to user one
            }
            else if(WhichTurn == "2") //if incoming API call says user turn is two
            {
                UserTurn = 2; //set user turn to user two
            }
            else //if error occurs
            {
                errorBoxRTB.Text = "No user turn found. Reverting to user one.";
                UserTurn = 1; //default to user one
            }
            gameStarted = true; //start game
            RefreshBoard(); //refresh board with updated data
        }
        private void RefreshBoard() //refreshes game board
        {
            playerTwoBankRTB.Text = userOnePoints.ReturnUserBank(); //set user banks
            playerOneBankRTB.Text = userTwoPoints.ReturnUserBank();

            playerOneSquareOneRTB.Text = userOnePoints.ReturnUserHoleOne(); //set user holes
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

            if (UserTurn == 1) //setup text so user knows whose turn it is
            {
                playerOneRTBTurn.Text = "Player 1's Turn";
                playerTwoRTBTurn.Text = ""; //empty text
            }
            else if (UserTurn == 2)
            {
                playerOneRTBTurn.Text = ""; //empty text
                playerTwoRTBTurn.Text = "Player 2's Turn";
            }
            if (gameOver) //if game has ended
            {
                playerOneRTBTurn.Text = "Game Over"; //display game over
                playerTwoRTBTurn.Text = "Game Over";
            }
            CentreItems(); //centre text items on refresh
        }
        private async Task playerMoveAsync(string playerMoving, int shells, int currentPosition) //moves the player based on values
        {
            if (shells == 0) //if no shells when button is clicked
            {
                return; //do nothing
            }
            else if (gameOver) //if game is over
            {
                return; //do nothing
            }
            else
            {
                int sideOfBoard; //stores which side of the board the shell is on
                int nextPosition; //stores the next position of the shell
                if (playerMoving == "UserOne") //checks which user is moving
                {
                    nextPosition = currentPosition + 1; //game goes counter clockwise, so increment to next position
                    sideOfBoard = 1; //user one side of board 
                    userOnePoints.RemoveShells(currentPosition); //remove shells from hole
                    UserTurn = 2; //next player turn is user two so set it
                }
                else
                {
                    nextPosition = currentPosition - 1; //game goes counter clockwise so decrement to next position
                    sideOfBoard = 2; //user two side of board
                    userTwoPoints.RemoveShells(currentPosition); //remove shells from hole
                    UserTurn = 1; //next player turn is user one so set it
                }

                for (int i = 0; i < shells; i++) //for loop to loop through the number of shells in the hole
                {
                    if (sideOfBoard == 1) //if user one side of board 
                    {
                        if (i == shells - 1) //CHECKS FOR LAST SHELL
                        {
                            bool capturePieces = false; //variable for storing if shells should be captured
                            if (captureFunction) //IF CAPTURE FUNCTION ENABLED
                            {
                                if (playerMoving == "UserOne") //if user one is moving
                                {
                                    if (nextPosition < 8 && userOnePoints.ReturnUserHole(nextPosition) == "0") //checks if we have reached the end of the board (board is only 7 long)
                                    {
                                        capturePieces = true; //set capture pieces to true
                                    }
                                }
                            }

                            if (nextPosition == 8 && playerMoving == "UserOne") //if reached end of board and next pos is 8, update user one bank by one
                            {
                                UserTurn = 1; //since last shell goes in user bank, player gets another turn
                                await userOnePoints.UpdateHole(8, playerMoving); //update user one bank by one
                            }
                            else if (nextPosition == 8 && playerMoving == "UserTwo") //if user two moving
                            {
                                await userTwoPoints.UpdateHole(7, playerMoving); //if reaches end of board, shift to other side of the board
                            }
                            else //normal gameplay
                            {
                                if (capturePieces) //if capture pieces is enabled 
                                {
                                    if (playerMoving == "UserOne") //if player two is moving
                                    {
                                        string shellCapture = userTwoPoints.ReturnUserHole(nextPosition);  //capture shells in opposing hole
                                        userOnePoints.UpdateBank(shellCapture);  //update user bank
                                        userTwoPoints.RemoveShells(nextPosition); //remove shells from opposing side
                                    }
                                }
                                await userOnePoints.UpdateHole(nextPosition, playerMoving); //update user hole
                                nextPosition++; //increment to next position
                            }
                        }
                        else if (nextPosition == 8 && playerMoving == "UserOne") //check if next shells goes in the bank for that player or skips opposing team bank
                        {
                            await userOnePoints.UpdateHole(8, playerMoving);//update bank
                            nextPosition = 7; //decrement as now moving to opposing side
                            sideOfBoard = 2; //shells are on user two side of board
                        }
                        else if (nextPosition == 8 && playerMoving == "UserTwo") //check to see if user has gone around the board
                        {
                            await userTwoPoints.UpdateHole(7, playerMoving); //skip user one bank since user two is moving
                            nextPosition = 6; //we updated hole 7 already so move to 6 
                            sideOfBoard = 2; //move to opposing side of board
                        }
                        else //for normal game play
                        {
                            await userOnePoints.UpdateHole(nextPosition, playerMoving);
                            nextPosition++;
                        }
                    }
                    else if (sideOfBoard == 2)//if shell is on user two side of board
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
                    RefreshBoard(); //refresh the board
                    await GameOverAsync(); //check if game is over
                }
            }
        }
        private async Task<bool> GameOverAsync() //checks if game is over
        {
            if (userOnePoints.ReturnUserHoleOne() == "0" && userOnePoints.ReturnUserHoleTwo() == "0" && userOnePoints.ReturnUserHoleThree() == "0" &&
                userOnePoints.ReturnUserHoleFour() == "0" && userOnePoints.ReturnUserHoleFive() == "0" && userOnePoints.ReturnUserHoleSix() == "0" &&
                userOnePoints.ReturnUserHoleSeven() == "0") //if all shells one user one side empty
            {
                gameOver = true; //set game over
                
            }
            else if (userTwoPoints.ReturnUserHoleOne() == "0" && userTwoPoints.ReturnUserHoleTwo() == "0" && userTwoPoints.ReturnUserHoleThree() == "0" &&
                userTwoPoints.ReturnUserHoleFour() == "0" && userTwoPoints.ReturnUserHoleFive() == "0" && userTwoPoints.ReturnUserHoleSix() == "0" &&
                userTwoPoints.ReturnUserHoleSeven() == "0") //if all shells on user two side empty
            {
                gameOver = true; //set game over
            }
            else //if game is not over return false
            {
                return false;
            }

            bool Win;
            if (int.Parse(userOnePoints.ReturnUserBank()) > int.Parse(userTwoPoints.ReturnUserBank())) //if user has more points than user two
            {
                Win = true; //set win to true
            }
            else
            {
                Win = false; //set win to false (a loss)
            }
            try
            {
                if (gameOver && !sentFinishedData) //if game is over and data has not been sent, run API call to update
                {
                    string response = await UpdateDataAsync(Username, UserID, AuthKey, userOnePoints.ReturnUserBank(), Win); //run API call to update
                    if (response == "true") //if successful API made
                    {
                        errorBoxRTB.Text = "Update data in database successfully!"; //display success message to user
                    }
                    else
                    {
                        errorBoxRTB.Text = "An error occurred when trying to update data.";
                    }
                    sentFinishedData = true; //set sendFinishedData to true
                    return true; //if game
                }
                else
                {
                    return false; //if game not over
                }
            }
            catch //if error occurred 
            {
                errorBoxRTB.Text = "An error occurred when trying to update data.";
                return false;
            }
        }
        private async Task<string> UpdateDataAsync(string Username, string UserID, string AuthKey, string Shells, bool Win) //updates user data using API call
        {
            try
            {
                //API CALL stuff
                SerializationUpdateData serialSaveGame = new SerializationUpdateData(Username, UserID, AuthKey, Shells, Win);
                string jsonString = JsonConvert.SerializeObject(serialSaveGame);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/savedata", content);
                var RString = await result.Content.ReadAsStringAsync();
                SerializationUpdateData deserialObj = JsonConvert.DeserializeObject<SerializationUpdateData>(RString);
                return deserialObj.ApiResponse;
            }
            catch //if error occurred
            {
                return "false";
            }
        }

        private void AIModeBtn_Click(object sender, EventArgs e) //if AI button has been clicked
        {
            if(AIMode == 1 || AIMode == 2) //if AI mode is 1 or 2, increment
            {
                AIMode++;
            }
            else //if AI mode is 3 and clicked
            {
                AIMode = 1; //set AI mode to 1
            }

            if (AIMode == 1) //display text for each AI mode
            {
                AIModeBtn.Text = "AI Mode: Easy";
            }
            else if(AIMode == 2)
            {
                AIModeBtn.Text = "AI Mode: Medium";
            }
            else if(AIMode == 3)
            {
                AIModeBtn.Text = "AI Mode: Hard";
            }
        }

        private async void LeaderboardBtnOpen_Click(object sender, EventArgs e) //on click of leaderboard button
        {
            await GetOpenLeaderboard(); //run function
        }
    }
}
