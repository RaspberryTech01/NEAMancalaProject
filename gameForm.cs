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
        public GameForm()
        {
            InitializeComponent();
            playerOneBankRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareOneRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareTwoRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareThreeRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareFourRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareFiveRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareSixRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerOneSquareSevenRTB.SelectionAlignment = HorizontalAlignment.Center;
            playerTwoBankRTB.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void bankOneRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
