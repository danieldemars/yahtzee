using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace yahtzee
{

    public partial class RollDice : Form
    {
        public static int rollCount = 0;
        
        bool dice1Keep = false,
            dice2Keep = false,
            dice3Keep = false,
            dice4Keep = false,
            dice5Keep = false;

        public static bool rolled = false; // makes sure the player doesnt score without rolling at least once 
        
        int dice1 = 0,
            dice2 = 0,
            dice3 = 0,
            dice4 = 0,
            dice5 = 0;

        public static int onesScore, twosScore, threesScore, foursScore, fivesScore, sixesScore,
            threeOfAKindScore, fourOfAKindScore, fullHouseScore, smallStraightScore,
            largeStraightScore, yahtzeeScore, chanceScore;
        
        public RollDice()
        {
            InitializeComponent();
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            if (rollCount < 3)
            {
                Random rand = new Random();

                // gets new values for each die if not keeping it
                if (dice1Keep == false)
                {
                    dice1 = rand.Next(1, 7);
                }
                if (dice2Keep == false)
                {
                    dice2 = rand.Next(1, 7);
                }
                if (dice3Keep == false)
                {
                    dice3 = rand.Next(1, 7);
                }
                if (dice4Keep == false)
                {
                    dice4 = rand.Next(1, 7);
                }
                if (dice5Keep == false)
                {
                    dice5 = rand.Next(1, 7);
                }

                // displays the image of the dice 
                dice1PictureBox.Image = getImage(dice1);
                dice2PictureBox.Image = getImage(dice2);
                dice3PictureBox.Image = getImage(dice3);
                dice4PictureBox.Image = getImage(dice4);
                dice5PictureBox.Image = getImage(dice5);

                rollCount++;

                rolled = true; 
            }

            // calculate scores of this role
            int[] dice = { dice1, dice2, dice3, dice4, dice5 };
            
            calculateOnes(dice);
            calculateTwos(dice);
            calculateThrees(dice);
            calculateFours(dice);
            calculateFives(dice);
            calculateSixes(dice);
            calculateThreeOfAKind(dice);
            calculateFourOfAKind(dice);
            calculateFullHouse(dice);
            calculateSmallStraight(dice);
            calculateLargeStraight(dice);
            calculateYahtzee(dice);
            chanceScore = dice.Sum();
            
            rollCountLabel.Text = "Rolls: " + rollCount;
        }

        
        // gets correct image to display
        private System.Drawing.Image getImage(int dice) 
        {
            if (dice == 1)
            {
                return yahtzee.Properties.Resources.dice_1_red;
            }
            else if (dice == 2)
            {
                return yahtzee.Properties.Resources.dice_2_red;
            }
            else if (dice == 3)
            {
                return yahtzee.Properties.Resources.dice_3_red;
            }
            else if (dice == 4)
            {
                return yahtzee.Properties.Resources.dice_4_red;
            }
            else if (dice == 5)
            {
                return yahtzee.Properties.Resources.dice_5_red;
            }
            else
            {
                return yahtzee.Properties.Resources.dice_6_red;
            }
        }


        public void resetDice()
        {
            rolled = false;

            dice1PictureBox.Image = null;
            dice2PictureBox.Image = null;
            dice3PictureBox.Image = null;
            dice4PictureBox.Image = null;
            dice5PictureBox.Image = null;

            dice1SelectedPictureBox.Visible = false;
            dice2SelectedPictureBox.Visible = false;
            dice3SelectedPictureBox.Visible = false;
            dice4SelectedPictureBox.Visible = false;
            dice5SelectedPictureBox.Visible = false; 

            rollCount = 0;
            rollCountLabel.Text = "Rolls: " + rollCount;

            dice1Keep = false;
            dice2Keep = false;
            dice3Keep = false;
            dice4Keep = false;
            dice5Keep = false;
        }

        // If picture clicked after first roll, dice it kept 
        // if picture is clicked when dice is already kept, un keep it 
        private void dice1PictureBox_Click(object sender, EventArgs e)
        {
            if (rollCount > 0 && dice1Keep == false)
            {
                dice1SelectedPictureBox.Visible = true;
                dice1Keep = true;
            }
            else if (dice1Keep == true)
            {
                dice1SelectedPictureBox.Visible = false;
                dice1Keep = false;
            }
        }

        private void dice2PictureBox_Click(object sender, EventArgs e)
        {
            if (rollCount > 0 && dice2Keep == false)
            {
                dice2SelectedPictureBox.Visible = true;
                dice2Keep = true;
            }
            else if (dice2Keep == true)
            {
                dice2SelectedPictureBox.Visible = false;
                dice2Keep = false;
            }
        }

        private void dice3PictureBox_Click(object sender, EventArgs e)
        {
            if (rollCount > 0 && dice3Keep == false)
            {
                dice3SelectedPictureBox.Visible = true;
                dice3Keep = true;
            }
            else if (dice3Keep == true)
            {
                dice3SelectedPictureBox.Visible = false;
                dice3Keep = false;
            }
        }

        private void dice4PictureBox_Click(object sender, EventArgs e)
        {
            if (rollCount > 0 && dice4Keep == false)
            {
                dice4SelectedPictureBox.Visible = true;
                dice4Keep = true;
            }
            else if (dice4Keep == true)
            {
                dice4SelectedPictureBox.Visible = false;
                dice4Keep = false;
            }
        }

        private void dice5PictureBox_Click(object sender, EventArgs e)
        {
            if (rollCount > 0 && dice5Keep == false)
            {
                dice5SelectedPictureBox.Visible = true;
                dice5Keep = true;
            }
            else if (dice5Keep == true)
            {
                dice5SelectedPictureBox.Visible = false;
                dice5Keep = false;
            }
        }



        // Calculate every possible score for this roll
        private void calculateOnes(int[] dice)
        {
            int count = 0;
            int score = 0;

            while (count < 5)
            {
                if (dice[count].Equals(1)) // score = sum of all dice with value 1 
                {
                    score++;
                }

                count++;
            }
            onesScore = score;
        }

        private void calculateTwos(int[] dice)
        {
            int count = 0;
            int score = 0;

            while (count < 5)
            {
                if (dice[count].Equals(2)) // score = sum of all dice with value 2 
                {
                    score += 2;
                }

                count++;
            }
            twosScore = score;
        }

        private void calculateThrees(int[] dice)
        {
            int count = 0;
            int score = 0;

            while (count < 5)
            {
                if (dice[count].Equals(3)) // score = sum of all dice with value 3
                {
                    score += 3;
                }

                count++;
            }
            threesScore = score;
        }

        private void calculateFours(int[] dice)
        {
            int count = 0;
            int score = 0;

            while (count < 5)
            {
                if (dice[count].Equals(4)) // score = sum of all dice with value 4
                {
                    score += 4;
                }

                count++;
            }
            foursScore = score;
        }

        private void calculateFives(int[] dice)
        {
            int count = 0;
            int score = 0;

            while (count < 5)
            {
                if (dice[count].Equals(5)) // score = sum of all dice with value 5
                {
                    score += 5;
                }

                count++;
            }
            fivesScore = score;
        }

        private void calculateSixes(int[] dice)
        {
            int count = 0;
            int score = 0;

            while (count < 5)
            {
                if (dice[count].Equals(6)) // score = sum of all dice with value 6
                {
                    score += 6;
                }

                count++;
            }
            sixesScore = score;
        }

        private void calculateThreeOfAKind(int[] dice)
        {
            int[] repeatCount = {0,0,0,0,0};
            threeOfAKindScore = 0; // 3 of a kind score is 0 by default

            // checks how many times each element in dice repeats, stores these values in repeatCount array 
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (dice[x] == dice[y])
                    {
                        repeatCount[x]++;
                    }
                }
            }

            // if any element in repeatCount >= 3, there is a 3 of a kind
            for (int i = 0;i < 5; i++)
            {
                if (repeatCount[i] >= 3)
                {
                    threeOfAKindScore = dice.Sum(); 
                }
            }
        }

        private void calculateFourOfAKind(int[] dice)
        {
            int[] repeatCount = { 0, 0, 0, 0, 0 };
            fourOfAKindScore = 0; // 4 of a kind score is 0 by default

            // checks how many times each element in dice repeats, stores these values in repeatCount array 
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (dice[x] == dice[y])
                    {
                        repeatCount[x]++;
                    }
                }
            }

            // if any element in repeatCount >= 4, there is a 4 of a kind
            for (int i = 0; i < 5; i++)
            {
                if (repeatCount[i] >= 4)
                {
                    fourOfAKindScore = dice.Sum();
                }
            }
        }

        // decide if there is a full house by checking if one element repeats 2 times and the other repeats 3 times
        // if this is not the case then there is no full house
        private void calculateFullHouse(int[] dice)
        {
            int repeats = 0;
            Array.Sort(dice);

            for (int i = 0; i < 5; i++) // check how many times first element in dice repeats 
            {
                if (dice[0] == dice[i])
                {
                    repeats++;
                }
            }

            if (repeats == 2) // if first element repeats twice, check if next element repeats 3 times 
            {
                repeats = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (dice[2] == dice[i])
                    {
                        repeats++;
                    }

                    if (repeats == 3) // one number repeats 2 times, another repeats 3, there is a full house
                    {
                        fullHouseScore = 25;
                    }
                    else
                    {
                        fullHouseScore = 0;
                    }

                }
                
            }
            else if (repeats == 3) // if first element repeats 3 times, check if next element repeats 2 times 
            {
                repeats = 0;
                for (int i = 0;i < 5; i++)
                {
                    if (dice[3] == dice[i])
                    {
                        repeats++;
                    }

                    if (repeats == 2) // one number repeats 2 times, another repeats 3, there is a full house
                    {
                        fullHouseScore = 25;
                    }
                    else
                    {
                        fullHouseScore = 0;
                    }
                }
            }
            else // if first number does not repeat 2 or 3 times, there cannot be a full house
            {
                fullHouseScore = 0;
            }
        }

        private void calculateSmallStraight(int[] dice) // if there are 5 sequential dice, return 40 points 
        {
            int count = 0;
            bool straight = false;
            int straightCount = 0;

            Array.Sort(dice);

            // check if dice are sequential
            while (count < 4 && straight == false) 
            {
                if (dice[count] != dice[count + 1]) // if two sequential dice are the same value, do nothing for this iteration
                {
                    if (dice[count] + 1 == dice[count + 1])
                    {
                        straightCount++;

                        if (straightCount >= 3) // if straightCount >= 3, there is a small straight
                        {
                            straight = true;
                        }
                    }
                    else
                    {
                        straightCount = 0;
                    }
                }
                count++;   
            }

            if (straight == false)
            {
                smallStraightScore = 0;
            }
            else
            {
                smallStraightScore = 30;
            }
        }
        
        private void calculateLargeStraight(int[] dice)
        {
            int count = 0;
            bool straight = false;
            int straightCount = 0;

            Array.Sort(dice);


            while (count < 4 && straight == false) // check if dice are sequential
            {
                if (dice[count] != dice[count + 1]) // if two sequential dice are the same value, do nothing for this iteration
                {
                    if (dice[count] + 1 == dice[count + 1])
                    {
                        straightCount++;

                        if (straightCount >= 4) // if straightCount >= 4, there is a large straight
                        {
                            straight = true;
                        }
                    }
                }
                count++;
            }

            if (straight == false)
            {
                largeStraightScore = 0;
            }
            else
            {
                largeStraightScore = 40;
            }
        }

        private void calculateYahtzee(int[] dice)
        {
            int repeats = 0;

            for (int i = 0; i < 5; i++)
            {
                if (dice[0] == dice[i])
                {
                    repeats++;
                }
            }

            if (repeats == 5)
            {
                yahtzeeScore = 50;
            }
            else
            {
                yahtzeeScore = 0;
            }
        }

    }
}
