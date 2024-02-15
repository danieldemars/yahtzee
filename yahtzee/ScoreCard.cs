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
    public partial class ScoreCard : Form
    {
        int[] player = new int[Start.players + 1];
        public static int currentPlayer;

        bool[,] scored = new bool[4, 13]; // tracks what the players have scored 

        int p1TotalScore = 0;
        int p2TotalScore = 0;
        int p3TotalScore = 0;
        int p4TotalScore = 0;

        int rounds = 0; // tracks when to end game, incremented in changeTurn()

        public ScoreCard()
        {
            InitializeComponent();
            fillPlayer();
            fillScored();
            player1TotalLabel.Text = p1TotalScore.ToString();
            player2TotalLabel.Text = p2TotalScore.ToString();
            player3TotalLabel.Text = p3TotalScore.ToString();
            player4TotalLabel.Text = p4TotalScore.ToString();
            disableLabels(currentPlayer);
        }

        // fills player[] with however many the user chose at Start
        public void fillPlayer()
        {
            for (int i = 0; i < player.Length; i++)
            {
                player[i] = i;
            }

            currentPlayer = player[0];
        }

        // fills scored[] with falses at the start of the game 
        private void fillScored()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    scored[i, j] = false;
                }
            }
        }
        
        // Every time a player scores, this fucntion is called which changes whose turn it is 
        // and resets the dice
        private void changeTurn(int cPlayer)
        {
            // if current player is last one in the array, go back to player 1
            // else go to next player
            if (cPlayer == player.Length - 1) 
            {
                currentPlayer = player[0];
                rounds++; // every time the last player scores, new round starts 
            }
            else
            {
                currentPlayer++; 
            }

            disableLabels(currentPlayer);

            // resets everything on RollDice form
            // rollCountLabel is updated in RollDice.rollButton_Click()
            var rollDice = Application.OpenForms.OfType<RollDice>().FirstOrDefault();
            rollDice.resetDice();
            int displayPlayer = currentPlayer + 1;
            rollDice.playerTurnLabel.Text = "Player " + displayPlayer + "'s Turn";

            // checks if game is over 
            endGame();
        }

        // disables all the labels of the players who are not currently rolling 
        private void disableLabels(int currentPlayer)
        {
            if (currentPlayer == 0)
            {
                player1Turn(); 
            }
            else if (currentPlayer == 1)
            {
                player2Turn(); 
            }
            else if (currentPlayer == 2)
            {
                player3Turn(); 
            }
            else if (currentPlayer == 3)
            {
                player4Turn(); 
            }
        }
        
        // ends the game after 13 rounds 
        // a round ends after the last player scores 
        private void endGame()
        {
            if (rounds == 13)
            {
                // if there is only 1 player, dipslay their score in a MessageBox
                // if there is more than 1, decide who won (or tied)
                if (player.Length == 1)
                {
                    MessageBox.Show("Your final score was " + p1TotalScore + "!", "Game Over", MessageBoxButtons.OK);
                }
                else 
                {
                    getWinner();
                }
            }
        }

        private void getWinner()
        {
            int highScore = 0;
            int[] scores = { p1TotalScore, p2TotalScore, p3TotalScore, p4TotalScore };
            int winnerCount = 0;
            string winnerMessage = null; 

            // find the highest score 
            for (int i = 0; i < scores.Length; i++) 
            {
                if (scores[i] > highScore)
                {
                    highScore = scores[i];
                }
            }

            // check for any ties
            for (int i = 0; i < scores.Length; i++) 
            {
                if (scores[i] == highScore)
                {
                    winnerCount++;
                }
            }

            if (winnerCount > 1) // if there is any ties, call displayTie
            {
                displayTie(highScore);
            }
            else
            {
                // if there is no tie, find out how won
                if (scores[0] == highScore)
                {
                    winnerMessage = "Player 1 won with a score of " + highScore + "!";
                }
                else if (scores[1] == highScore)
                {
                    winnerMessage = "Player 2 won with a score of " + highScore + "!";
                }
                else if (scores[2] == highScore)
                {
                    winnerMessage = "Player 3 won with a score of " + highScore + "!";
                }
                else if (scores[3] == highScore)
                {
                    winnerMessage = "Player 4 won with a score of " + highScore + "!";
                }
                MessageBox.Show(winnerMessage, "Game Over", MessageBoxButtons.OK);
            }
        }

        // checks which players tied then displays it in a MessageBox
        private void displayTie(int score)
        {
            List<int> tied = new List<int>();
            string tieGameMessage = null;

            // if their total score = score, they tied 
            if (p1TotalScore == score)
            {
                tied.Add(player[0] + 1);
            }
            if (p2TotalScore == score)
            {
                tied.Add(player[1] + 1); 
            }
            if (p3TotalScore == score)
            {
                tied.Add(player[2] + 1);
            }
            if (p4TotalScore == score)
            {
                tied.Add(player[3] + 1);
            }

            // dipslays who tied 
            if (tied.Count == 2)
            { 
                tieGameMessage = $"Players {tied.ElementAt(0)} and {tied.ElementAt(1)} tied! Their score was {score}";
            }
            else if (tied.Count == 3)
            {
                tieGameMessage = $"Players {tied.ElementAt(0)}, {tied.ElementAt(1)}, and {tied.ElementAt(2)} tied! Their score was {score}";
            }
            else if (tied.Count == 4)
            {
                tieGameMessage = $"Players {tied.ElementAt(0)}, {tied.ElementAt(1)}, {tied.ElementAt(2)}, and {tied.ElementAt(3)} tied! Their score was {score}";
            }

            MessageBox.Show(tieGameMessage, "Tie Game", MessageBoxButtons.OK); 
        }

        // Everytime a player clicks on their label, the label text, their total score,
        // totalLabel.Text, and scored[,] is updated then changeTurn() is called 
        private void player1OnesLabel_Click(object sender, EventArgs e)
        { 
            if (!scored[0, 0] && RollDice.rolled)
            {
                player1OnesLabel.Text = RollDice.onesScore.ToString();
                p1TotalScore += RollDice.onesScore; 
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 0] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1TwosLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 1] && RollDice.rolled)
            {
                player1TwosLabel.Text = RollDice.twosScore.ToString();
                p1TotalScore += RollDice.twosScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 1] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1ThreesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 2] && RollDice.rolled)
            {
                player1ThreesLabel.Text = RollDice.threesScore.ToString();
                p1TotalScore += RollDice.threesScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 2] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1FoursLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 3] && RollDice.rolled)
            {
                player1FoursLabel.Text = RollDice.foursScore.ToString();
                p1TotalScore += RollDice.foursScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 3] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1FivesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 4] && RollDice.rolled)
            {
                player1FivesLabel.Text = RollDice.fivesScore.ToString();
                p1TotalScore += RollDice.fivesScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 4] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1SixesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 5] && RollDice.rolled)
            {
                player1SixesLabel.Text = RollDice.sixesScore.ToString();
                p1TotalScore += RollDice.sixesScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 5] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1ThreeOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 6] && RollDice.rolled)
            {
                player1ThreeOfAKindLabel.Text = RollDice.threeOfAKindScore.ToString();
                p1TotalScore += RollDice.threeOfAKindScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 6] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1FourOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 7] && RollDice.rolled)
            {
                player1FourOfAKindLabel.Text = RollDice.fourOfAKindScore.ToString();
                p1TotalScore += RollDice.fourOfAKindScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 7] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1FullHouseLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 8] && RollDice.rolled)
            {
                player1FullHouseLabel.Text = RollDice.fullHouseScore.ToString();
                p1TotalScore += RollDice.fullHouseScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 8] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1SmallStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 9] && RollDice.rolled)
            {
                player1SmallStraightLabel.Text = RollDice.smallStraightScore.ToString();
                p1TotalScore += RollDice.smallStraightScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 9] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1LargeStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 10] && RollDice.rolled)
            {
                player1LargeStraightLabel.Text = RollDice.largeStraightScore.ToString();
                p1TotalScore += RollDice.largeStraightScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 10] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1YahtzeeLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 11] && RollDice.rolled)
            {
                player1YahtzeeLabel.Text = RollDice.yahtzeeScore.ToString();
                p1TotalScore += RollDice.yahtzeeScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 11] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1ChanceLabel_Click(object sender, EventArgs e)
        {
            if (!scored[0, 12] && RollDice.rolled)
            {
                player1ChanceLabel.Text = RollDice.chanceScore.ToString();
                p1TotalScore += RollDice.chanceScore;
                player1TotalLabel.Text = p1TotalScore.ToString();
                scored[0, 12] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2OnesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 0] && RollDice.rolled)
            {
                player2OnesLabel.Text = RollDice.onesScore.ToString();
                p2TotalScore += RollDice.onesScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 0] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2TwosLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 1] && RollDice.rolled)
            {
                player2TwosLabel.Text = RollDice.twosScore.ToString();
                p2TotalScore += RollDice.twosScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 1] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2ThreesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 2] && RollDice.rolled)
            {
                player2ThreesLabel.Text = RollDice.threesScore.ToString();
                p2TotalScore += RollDice.threesScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 2] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2FoursLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 3] && RollDice.rolled)
            {
                player2FoursLabel.Text = RollDice.foursScore.ToString();
                p2TotalScore += RollDice.foursScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 3] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2FivesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 4] && RollDice.rolled)
            {
                player2FivesLabel.Text = RollDice.fivesScore.ToString();
                p2TotalScore += RollDice.fivesScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 4] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2SixesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 5] && RollDice.rolled)
            {
                player2SixesLabel.Text = RollDice.sixesScore.ToString();
                p2TotalScore += RollDice.sixesScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 5] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2ThreeOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 6] && RollDice.rolled)
            {
                player2ThreeOfAKindLabel.Text = RollDice.threeOfAKindScore.ToString();
                p2TotalScore += RollDice.threeOfAKindScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 6] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2FourOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 7] && RollDice.rolled)
            {
                player2FourOfAKindLabel.Text = RollDice.fourOfAKindScore.ToString();
                p2TotalScore += RollDice.fourOfAKindScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 7] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2FullHouseLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 8] && RollDice.rolled)
            {
                player2FullHouseLabel.Text = RollDice.fullHouseScore.ToString();
                p2TotalScore += RollDice.fullHouseScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 8] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2SmallStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 9] && RollDice.rolled)
            {
                player2SmallStraightLabel.Text = RollDice.smallStraightScore.ToString();
                p2TotalScore += RollDice.smallStraightScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 9] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2LargeStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 10] && RollDice.rolled)
            {
                player2LargeStraightLabel.Text = RollDice.largeStraightScore.ToString();
                p2TotalScore += RollDice.largeStraightScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 10] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2YahtzeeLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 11] && RollDice.rolled)
            {
                player2YahtzeeLabel.Text = RollDice.yahtzeeScore.ToString();
                p2TotalScore += RollDice.yahtzeeScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 11] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player2ChanceLabel_Click(object sender, EventArgs e)
        {
            if (!scored[1, 12] && RollDice.rolled)
            {
                player2ChanceLabel.Text = RollDice.chanceScore.ToString();
                p2TotalScore += RollDice.chanceScore;
                player2TotalLabel.Text = p2TotalScore.ToString();
                scored[1, 12] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3OnesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 0] && RollDice.rolled)
            {
                player3OnesLabel.Text = RollDice.onesScore.ToString();
                p3TotalScore += RollDice.onesScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 0] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3TwosLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 1] && RollDice.rolled)
            {
                player3TwosLabel.Text = RollDice.twosScore.ToString();
                p3TotalScore += RollDice.twosScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 1] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3ThreesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 2] && RollDice.rolled)
            {
                player3ThreesLabel.Text = RollDice.threesScore.ToString();
                p3TotalScore += RollDice.threesScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 2] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3FoursLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 3] && RollDice.rolled)
            {
                player3FoursLabel.Text = RollDice.foursScore.ToString();
                p3TotalScore += RollDice.foursScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 3] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3FivesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 4] && RollDice.rolled)
            {
                player3FivesLabel.Text = RollDice.fivesScore.ToString();
                p3TotalScore += RollDice.fivesScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 4] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3SixesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 5] && RollDice.rolled)
            {
                player3SixesLabel.Text = RollDice.sixesScore.ToString();
                p3TotalScore += RollDice.sixesScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 5] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3ThreeOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 6] && RollDice.rolled)
            {
                player3ThreeOfAKindLabel.Text = RollDice.threeOfAKindScore.ToString();
                p3TotalScore += RollDice.threeOfAKindScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 6] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3FourOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 7] && RollDice.rolled)
            {
                player3FourOfAKindLabel.Text = RollDice.fourOfAKindScore.ToString();
                p3TotalScore += RollDice.fourOfAKindScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 7] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3FullHouseLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 8] && RollDice.rolled)
            {
                player3FullHouseLabel.Text = RollDice.fullHouseScore.ToString();
                p3TotalScore += RollDice.fullHouseScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 8] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3SmallStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 9] && RollDice.rolled)
            {
                player3SmallStraightLabel.Text = RollDice.smallStraightScore.ToString();
                p3TotalScore += RollDice.smallStraightScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 9] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3LargeStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 10] && RollDice.rolled)
            {
                player3LargeStraightLabel.Text = RollDice.largeStraightScore.ToString();
                p3TotalScore += RollDice.largeStraightScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 10] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3YahtzeeLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 11] && RollDice.rolled)
            {
                player3YahtzeeLabel.Text = RollDice.yahtzeeScore.ToString();
                p3TotalScore += RollDice.yahtzeeScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 11] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player3ChanceLabel_Click(object sender, EventArgs e)
        {
            if (!scored[2, 12] && RollDice.rolled)
            {
                player3ChanceLabel.Text = RollDice.chanceScore.ToString();
                p3TotalScore += RollDice.chanceScore;
                player3TotalLabel.Text = p3TotalScore.ToString();
                scored[2, 12] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4OnesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 0] && RollDice.rolled)
            {
                player4OnesLabel.Text = RollDice.onesScore.ToString();
                p4TotalScore += RollDice.onesScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 0] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4TwosLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 1] && RollDice.rolled)
            {
                player4TwosLabel.Text = RollDice.twosScore.ToString();
                p4TotalScore += RollDice.twosScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 1] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4ThreesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 2] && RollDice.rolled)
            {
                player4ThreesLabel.Text = RollDice.threesScore.ToString();
                p4TotalScore += RollDice.threesScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 2] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4FoursLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 3] && RollDice.rolled)
            {
                player4FoursLabel.Text = RollDice.foursScore.ToString();
                p4TotalScore += RollDice.foursScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 3] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4FivesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 4] && RollDice.rolled)
            {
                player4FivesLabel.Text = RollDice.fivesScore.ToString();
                p4TotalScore += RollDice.fivesScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 4] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4SixesLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 5] && RollDice.rolled)
            {
                player4SixesLabel.Text = RollDice.sixesScore.ToString();
                p4TotalScore += RollDice.sixesScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 5] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4ThreeOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 6] && RollDice.rolled)
            {
                player4ThreeOfAKindLabel.Text = RollDice.threeOfAKindScore.ToString();
                p4TotalScore += RollDice.threeOfAKindScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 6] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4FourOfAKindLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 7] && RollDice.rolled)
            {
                player4FourOfAKindLabel.Text = RollDice.fourOfAKindScore.ToString();
                p4TotalScore += RollDice.fourOfAKindScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 7] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4FullHouseLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 8] && RollDice.rolled)
            {
                player4FullHouseLabel.Text = RollDice.fullHouseScore.ToString();
                p4TotalScore += RollDice.fullHouseScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 8] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4SmallStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 9] && RollDice.rolled)
            {
                player4SmallStraightLabel.Text = RollDice.smallStraightScore.ToString();
                p4TotalScore += RollDice.smallStraightScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 9] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4LargeStraightLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 10] && RollDice.rolled)
            {
                player4LargeStraightLabel.Text = RollDice.largeStraightScore.ToString();
                p4TotalScore += RollDice.largeStraightScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 10] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4YahtzeeLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 11] && RollDice.rolled)
            {
                player4YahtzeeLabel.Text = RollDice.yahtzeeScore.ToString();
                p4TotalScore += RollDice.yahtzeeScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 11] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player4ChanceLabel_Click(object sender, EventArgs e)
        {
            if (!scored[3, 12] && RollDice.rolled)
            {
                player4ChanceLabel.Text = RollDice.chanceScore.ToString();
                p4TotalScore += RollDice.chanceScore;
                player4TotalLabel.Text = p4TotalScore.ToString();
                scored[3, 12] = true;
                changeTurn(currentPlayer);
            }
        }

        private void player1Turn()
        {
            // enable player 1 
            player1OnesLabel.Enabled = true;
            player1TwosLabel.Enabled = true;
            player1ThreesLabel.Enabled = true;
            player1FoursLabel.Enabled = true;
            player1FivesLabel.Enabled = true;
            player1SixesLabel.Enabled = true;
            player1ThreeOfAKindLabel.Enabled = true;
            player1FourOfAKindLabel.Enabled = true;
            player1FullHouseLabel.Enabled = true;
            player1SmallStraightLabel.Enabled = true;
            player1LargeStraightLabel.Enabled = true;
            player1YahtzeeLabel.Enabled = true;
            player1ChanceLabel.Enabled = true;
            player1TotalLabel.Enabled = true;

            // disable player 2
            player2OnesLabel.Enabled = false;
            player2TwosLabel.Enabled = false;
            player2ThreesLabel.Enabled = false;
            player2FoursLabel.Enabled = false;
            player2FivesLabel.Enabled = false;
            player2SixesLabel.Enabled = false;
            player2ThreeOfAKindLabel.Enabled = false;
            player2FourOfAKindLabel.Enabled = false;
            player2FullHouseLabel.Enabled = false;
            player2SmallStraightLabel.Enabled = false;
            player2LargeStraightLabel.Enabled = false;
            player2YahtzeeLabel.Enabled = false;
            player2ChanceLabel.Enabled = false;
            player2TotalLabel.Enabled = false;

            // disable player 3
            player3OnesLabel.Enabled = false;
            player3TwosLabel.Enabled = false;
            player3ThreesLabel.Enabled = false;
            player3FoursLabel.Enabled = false;
            player3FivesLabel.Enabled = false;
            player3SixesLabel.Enabled = false;
            player3ThreeOfAKindLabel.Enabled = false;
            player3FourOfAKindLabel.Enabled = false;
            player3FullHouseLabel.Enabled = false;
            player3SmallStraightLabel.Enabled = false;
            player3LargeStraightLabel.Enabled = false;
            player3YahtzeeLabel.Enabled = false;
            player3ChanceLabel.Enabled = false;
            player3TotalLabel.Enabled = false;

            // disable player 4
            player4OnesLabel.Enabled = false;
            player4TwosLabel.Enabled = false;
            player4ThreesLabel.Enabled = false;
            player4FoursLabel.Enabled = false;
            player4FivesLabel.Enabled = false;
            player4SixesLabel.Enabled = false;
            player4ThreeOfAKindLabel.Enabled = false;
            player4FourOfAKindLabel.Enabled = false;
            player4FullHouseLabel.Enabled = false;
            player4SmallStraightLabel.Enabled = false;
            player4LargeStraightLabel.Enabled = false;
            player4YahtzeeLabel.Enabled = false;
            player4ChanceLabel.Enabled = false;
            player4TotalLabel.Enabled = false;
        }

        private void player2Turn()
        {
            // disable player 1 
            player1OnesLabel.Enabled = false;
            player1TwosLabel.Enabled = false;
            player1ThreesLabel.Enabled = false;
            player1FoursLabel.Enabled = false;
            player1FivesLabel.Enabled = false;
            player1SixesLabel.Enabled = false;
            player1ThreeOfAKindLabel.Enabled = false;
            player1FourOfAKindLabel.Enabled = false;
            player1FullHouseLabel.Enabled = false;
            player1SmallStraightLabel.Enabled = false;
            player1LargeStraightLabel.Enabled = false;
            player1YahtzeeLabel.Enabled = false;
            player1ChanceLabel.Enabled = false;
            player1TotalLabel.Enabled = false;

            // enable player 2
            player2OnesLabel.Enabled = true;
            player2TwosLabel.Enabled = true;
            player2ThreesLabel.Enabled = true;
            player2FoursLabel.Enabled = true;
            player2FivesLabel.Enabled = true;
            player2SixesLabel.Enabled = true;
            player2ThreeOfAKindLabel.Enabled = true;
            player2FourOfAKindLabel.Enabled = true;
            player2FullHouseLabel.Enabled = true;
            player2SmallStraightLabel.Enabled = true;
            player2LargeStraightLabel.Enabled = true;
            player2YahtzeeLabel.Enabled = true;
            player2ChanceLabel.Enabled = true;
            player2TotalLabel.Enabled = true;

            // disable player 3
            player3OnesLabel.Enabled = false;
            player3TwosLabel.Enabled = false;
            player3ThreesLabel.Enabled = false;
            player3FoursLabel.Enabled = false;
            player3FivesLabel.Enabled = false;
            player3SixesLabel.Enabled = false;
            player3ThreeOfAKindLabel.Enabled = false;
            player3FourOfAKindLabel.Enabled = false;
            player3FullHouseLabel.Enabled = false;
            player3SmallStraightLabel.Enabled = false;
            player3LargeStraightLabel.Enabled = false;
            player3YahtzeeLabel.Enabled = false;
            player3ChanceLabel.Enabled = false;
            player3TotalLabel.Enabled = false;

            // disable player 4
            player4OnesLabel.Enabled = false;
            player4TwosLabel.Enabled = false;
            player4ThreesLabel.Enabled = false;
            player4FoursLabel.Enabled = false;
            player4FivesLabel.Enabled = false;
            player4SixesLabel.Enabled = false;
            player4ThreeOfAKindLabel.Enabled = false;
            player4FourOfAKindLabel.Enabled = false;
            player4FullHouseLabel.Enabled = false;
            player4SmallStraightLabel.Enabled = false;
            player4LargeStraightLabel.Enabled = false;
            player4YahtzeeLabel.Enabled = false;
            player4ChanceLabel.Enabled = false;
            player4TotalLabel.Enabled = false;
        }

        private void player3Turn()
        {
            // disable player 1 
            player1OnesLabel.Enabled = false;
            player1TwosLabel.Enabled = false;
            player1ThreesLabel.Enabled = false;
            player1FoursLabel.Enabled = false;
            player1FivesLabel.Enabled = false;
            player1SixesLabel.Enabled = false;
            player1ThreeOfAKindLabel.Enabled = false;
            player1FourOfAKindLabel.Enabled = false;
            player1FullHouseLabel.Enabled = false;
            player1SmallStraightLabel.Enabled = false;
            player1LargeStraightLabel.Enabled = false;
            player1YahtzeeLabel.Enabled = false;
            player1ChanceLabel.Enabled = false;
            player1TotalLabel.Enabled = false;

            // disable player 2
            player2OnesLabel.Enabled = false;
            player2TwosLabel.Enabled = false;
            player2ThreesLabel.Enabled = false;
            player2FoursLabel.Enabled = false;
            player2FivesLabel.Enabled = false;
            player2SixesLabel.Enabled = false;
            player2ThreeOfAKindLabel.Enabled = false;
            player2FourOfAKindLabel.Enabled = false;
            player2FullHouseLabel.Enabled = false;
            player2SmallStraightLabel.Enabled = false;
            player2LargeStraightLabel.Enabled = false;
            player2YahtzeeLabel.Enabled = false;
            player2ChanceLabel.Enabled = false;
            player2TotalLabel.Enabled = false;

            // enable player 3
            player3OnesLabel.Enabled = true;
            player3TwosLabel.Enabled = true;
            player3ThreesLabel.Enabled = true;
            player3FoursLabel.Enabled = true;
            player3FivesLabel.Enabled = true;
            player3SixesLabel.Enabled = true;
            player3ThreeOfAKindLabel.Enabled = true;
            player3FourOfAKindLabel.Enabled = true;
            player3FullHouseLabel.Enabled = true;
            player3SmallStraightLabel.Enabled = true;
            player3LargeStraightLabel.Enabled = true;
            player3YahtzeeLabel.Enabled = true;
            player3ChanceLabel.Enabled = true;
            player3TotalLabel.Enabled = true;

            // disable player 4
            player4OnesLabel.Enabled = false;
            player4TwosLabel.Enabled = false;
            player4ThreesLabel.Enabled = false;
            player4FoursLabel.Enabled = false;
            player4FivesLabel.Enabled = false;
            player4SixesLabel.Enabled = false;
            player4ThreeOfAKindLabel.Enabled = false;
            player4FourOfAKindLabel.Enabled = false;
            player4FullHouseLabel.Enabled = false;
            player4SmallStraightLabel.Enabled = false;
            player4LargeStraightLabel.Enabled = false;
            player4YahtzeeLabel.Enabled = false;
            player4ChanceLabel.Enabled = false;
            player4TotalLabel.Enabled = false;
        }

        private void player4Turn()
        {
            // disable player 1 
            player1OnesLabel.Enabled = false;
            player1TwosLabel.Enabled = false;
            player1ThreesLabel.Enabled = false;
            player1FoursLabel.Enabled = false;
            player1FivesLabel.Enabled = false;
            player1SixesLabel.Enabled = false;
            player1ThreeOfAKindLabel.Enabled = false;
            player1FourOfAKindLabel.Enabled = false;
            player1FullHouseLabel.Enabled = false;
            player1SmallStraightLabel.Enabled = false;
            player1LargeStraightLabel.Enabled = false;
            player1YahtzeeLabel.Enabled = false;
            player1ChanceLabel.Enabled = false;
            player1TotalLabel.Enabled = false;

            // disable player 2
            player2OnesLabel.Enabled = false;
            player2TwosLabel.Enabled = false;
            player2ThreesLabel.Enabled = false;
            player2FoursLabel.Enabled = false;
            player2FivesLabel.Enabled = false;
            player2SixesLabel.Enabled = false;
            player2ThreeOfAKindLabel.Enabled = false;
            player2FourOfAKindLabel.Enabled = false;
            player2FullHouseLabel.Enabled = false;
            player2SmallStraightLabel.Enabled = false;
            player2LargeStraightLabel.Enabled = false;
            player2YahtzeeLabel.Enabled = false;
            player2ChanceLabel.Enabled = false;
            player2TotalLabel.Enabled = false;

            // disable player 3
            player3OnesLabel.Enabled = false;
            player3TwosLabel.Enabled = false;
            player3ThreesLabel.Enabled = false;
            player3FoursLabel.Enabled = false;
            player3FivesLabel.Enabled = false;
            player3SixesLabel.Enabled = false;
            player3ThreeOfAKindLabel.Enabled = false;
            player3FourOfAKindLabel.Enabled = false;
            player3FullHouseLabel.Enabled = false;
            player3SmallStraightLabel.Enabled = false;
            player3LargeStraightLabel.Enabled = false;
            player3YahtzeeLabel.Enabled = false;
            player3ChanceLabel.Enabled = false;
            player3TotalLabel.Enabled = false;

            // enable player 4
            player4OnesLabel.Enabled = true;
            player4TwosLabel.Enabled = true;
            player4ThreesLabel.Enabled = true;
            player4FoursLabel.Enabled = true;
            player4FivesLabel.Enabled = true;
            player4SixesLabel.Enabled = true;
            player4ThreeOfAKindLabel.Enabled = true;
            player4FourOfAKindLabel.Enabled = true;
            player4FullHouseLabel.Enabled = true;
            player4SmallStraightLabel.Enabled = true;
            player4LargeStraightLabel.Enabled = true;
            player4YahtzeeLabel.Enabled = true;
            player4ChanceLabel.Enabled = true;
            player4TotalLabel.Enabled = true;
        }

        // prompt user with message box asking if they want to restart game
        private void endGameButton_Click(object sender, EventArgs e)
        {
            DialogResult resetGameBox = MessageBox.Show("Are you sure you want to end the game?", "End Game", MessageBoxButtons.YesNo);
            if (resetGameBox == DialogResult.Yes)
            {
                if (Application.OpenForms.OfType<RollDice>().FirstOrDefault() != null)
                {
                    var rollDice = Application.OpenForms.OfType<RollDice>().FirstOrDefault();
                    rollDice.Close();
                }
                this.Close();
            }
        }

        // finds whatever the highest score for that roll is then display it for the current player 
        private void bestScoreButton_Click(object sender, EventArgs e)
        {
            if (RollDice.rolled == true)
            {
                int[] currentScores = {RollDice.onesScore, RollDice.twosScore, RollDice.threesScore, RollDice.foursScore,
                            RollDice.fivesScore, RollDice.sixesScore, RollDice.threeOfAKindScore, RollDice.fourOfAKindScore,
                            RollDice.fullHouseScore, RollDice.smallStraightScore, RollDice.largeStraightScore,
                            RollDice.yahtzeeScore, RollDice.chanceScore};

                string highScoreMessage = null;
                int highScore = 0;

                // if a score is greater than the current highScore and the category is not taken, that is the new high score 
                for (int i = 0; i < currentScores.Length; i++)
                {
                    if (currentScores[i] > highScore && scored[currentPlayer, i] == false)
                    {
                        highScore = currentScores[i];
                    }
                }
                
                if (highScore == RollDice.onesScore && !scored[player[currentPlayer], 0])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Ones category.";
                }
                else if (highScore == RollDice.twosScore && !scored[player[currentPlayer], 1])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Twos category.";
                }
                else if (highScore == RollDice.threesScore && !scored[player[currentPlayer], 2])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Threes category.";
                }
                else if (highScore == RollDice.foursScore && !scored[player[currentPlayer], 3])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Fours category.";
                }
                else if (highScore == RollDice.fivesScore && !scored[player[currentPlayer], 4])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Fives category.";
                }
                else if (highScore == RollDice.sixesScore && !scored[player[currentPlayer], 5])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Sixes category.";
                }
                else if (highScore == RollDice.threeOfAKindScore && !scored[player[currentPlayer], 6])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Three of a Kind category.";
                }
                else if (highScore == RollDice.fourOfAKindScore && !scored[player[currentPlayer], 7])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Four of a Kind category.";
                }
                else if (highScore == RollDice.fullHouseScore && !scored[player[currentPlayer], 8])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Full House category.";
                }
                else if (highScore == RollDice.smallStraightScore && !scored[player[currentPlayer], 9])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Small Straight category.";
                }
                else if (highScore == RollDice.largeStraightScore && !scored[player[currentPlayer], 10])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Large Straight category.";
                }
                else if (highScore == RollDice.yahtzeeScore && !scored[player[currentPlayer], 11])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Yahtzee category.";
                }
                else if (highScore == RollDice.chanceScore && !scored[player[currentPlayer], 12])
                {
                    highScoreMessage = "The highest score for this roll is " + highScore + " in the Chance category.";
                }

                MessageBox.Show(highScoreMessage, "Best Score", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please roll first", "Best Score", MessageBoxButtons.OK);
            }
        }
    }
}
