using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    public partial class Start : Form
    {
        ScoreCard scoreCardForm; 
        RollDice rollDiceForm;
        HelpForm helpForm;

        public static int players; 

        public Start()
        {
            InitializeComponent();
            playersComboBox.SelectedIndex = 0; 
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            players = int.Parse(playersComboBox.SelectedIndex.ToString());

            scoreCardForm = new ScoreCard();
            scoreCardForm.Show();
            

            // Change size of ScoreCard depending on how many players - to cut off
            // any unecessary parts of the score card. 
            if (playersComboBox.SelectedIndex == 3)
            {
                scoreCardForm.MaximumSize = new System.Drawing.Size(590, 684);
                scoreCardForm.MinimumSize = new System.Drawing.Size(590, 684);
                scoreCardForm.Size = new System.Drawing.Size(590, 684);
                scoreCardForm.endGameButton.Location = new System.Drawing.Point(115, 604);
                scoreCardForm.bestScoreButton.Location = new System.Drawing.Point(344, 604);
            }
            else if (playersComboBox.SelectedIndex == 2)
            {
                scoreCardForm.MaximumSize = new System.Drawing.Size(476, 684);
                scoreCardForm.MinimumSize = new System.Drawing.Size(476, 684);
                scoreCardForm.Size = new System.Drawing.Size(476, 684);
                scoreCardForm.endGameButton.Location = new System.Drawing.Point(58, 604);
                scoreCardForm.bestScoreButton.Location = new System.Drawing.Point(287, 604);
            }
            else if (playersComboBox.SelectedIndex == 1)
            {
                scoreCardForm.MaximumSize = new System.Drawing.Size(361, 684);
                scoreCardForm.MinimumSize = new System.Drawing.Size(361, 684);
                scoreCardForm.Size = new System.Drawing.Size(361, 684);
                scoreCardForm.endGameButton.Location = new System.Drawing.Point(55, 604);
                scoreCardForm.bestScoreButton.Location = new System.Drawing.Point(176, 604);
            }
            else if (playersComboBox.SelectedIndex == 0)
            {
                scoreCardForm.MaximumSize = new System.Drawing.Size(247, 684);
                scoreCardForm.MinimumSize = new System.Drawing.Size(247, 684);
                scoreCardForm.Size = new System.Drawing.Size(247, 684);
                scoreCardForm.endGameButton.Location = new System.Drawing.Point(55, 588);
                scoreCardForm.bestScoreButton.Location = new System.Drawing.Point(55, 617);
            }

            rollDiceForm = new RollDice();
            rollDiceForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            helpForm = new HelpForm();
            helpForm.Show();
        }
    }
}
