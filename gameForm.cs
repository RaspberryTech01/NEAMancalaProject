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

        private string[] userSave;
        private string[] AISave;

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

                if (Wins == "null" || Wins == null || Wins == "0")
                {
                    Wins = "0";
                }
                if(Losses == "null" || Losses == null || Losses == "0")
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
            NewGame();
        }

        private void savedGameBtn_Click(object sender, EventArgs e)
        {
            GetSavedData(UserID, AuthKey);
            InsertData(userSave, AISave);
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

            int[] scoreSetup = new int[] { 0, 4, 4, 4, 4, 4, 4, 4 };
            userOnePoints = new UserPoints(scoreSetup);
            userTwoPoints = new UserPoints(scoreSetup);
            RefreshBoard();
        }
        public void GetSavedGame()
        {

            string[] scoreSetup = new string[] { "0", "0", "0", "0", "0", "0", "0", "0"};
            InsertData(scoreSetup, scoreSetup);
            //UserPoints userOnePoints = new UserPoints(scoreSetup); //not needed 
            //UserPoints userTwoPoints = new UserPoints(scoreSetup);
        }

        private async void GetSavedData(string userID, string authKey) // gets data, if true passes it into variable
        {
            try
            {
                SerializationGetInfo serialGetInfo = new SerializationGetInfo(Username, userID, authKey);
                string jsonString = JsonConvert.SerializeObject(serialGetInfo);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://eu1.sunnahvpn.com:8888/api/getinfo", content);
                var RString = await result.Content.ReadAsStringAsync();
                SerializationGetInfo deserialObj = JsonConvert.DeserializeObject<SerializationGetInfo>(RString);

                if (deserialObj.ApiResponse == "true")
                {

                    UserInfoSplit userInfoSplit = new UserInfoSplit(deserialObj.UserSave);
                    UserInfoSplit AIInfoSplit = new UserInfoSplit(deserialObj.AISave);
                    userSave = userInfoSplit.SendSplit();
                    AISave = AIInfoSplit.SendSplit();
                }
                else
                {
                    errorBoxRTB.Text = "Error getting saved data.";
                }
            }
            catch (Exception err)
            {
                errorBoxRTB.Text = err.ToString();
            }
        }
        private void InsertData(string[] userSave, string[] AISave)
        {
            try
            {
                playerOneBankRTB.Text = userSave[0]; //insert player one data
                playerOneSquareOneRTB.Text = userSave[1];
                playerOneSquareTwoRTB.Text = userSave[2];
                playerOneSquareThreeRTB.Text = userSave[3];
                playerOneSquareFourRTB.Text = userSave[4];
                playerOneSquareFiveRTB.Text = userSave[5];
                playerOneSquareSixRTB.Text = userSave[6];
                playerOneSquareSevenRTB.Text = userSave[7];

                playerTwoBankRTB.Text = AISave[0]; //insert ai data
                playerTwoSquareOneRTB.Text = AISave[1];
                playerTwoSquareTwoRTB.Text = AISave[2];
                playerTwoSquareThreeRTB.Text = AISave[3];
                playerTwoSquareFourRTB.Text = AISave[4];
                playerTwoSquareFiveRTB.Text = AISave[5];
                playerTwoSquareSixRTB.Text = AISave[6];
                playerTwoSquareSevenRTB.Text = AISave[7];
            }
            catch(Exception err)
            {
                errorBoxRTB.Text = err.ToString();
            }

        }
        public void RefreshBoard()
        {
            playerOneBankRTB.Text = userOnePoints.ReturnUserBank();
            playerTwoBankRTB.Text = userTwoPoints.ReturnUserBank();

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
        
    }
}
