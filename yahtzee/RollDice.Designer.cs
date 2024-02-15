namespace yahtzee
{
    partial class RollDice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rollButton = new System.Windows.Forms.Button();
            this.dice5PictureBox = new System.Windows.Forms.PictureBox();
            this.dice4PictureBox = new System.Windows.Forms.PictureBox();
            this.dice3PictureBox = new System.Windows.Forms.PictureBox();
            this.dice2PictureBox = new System.Windows.Forms.PictureBox();
            this.dice1PictureBox = new System.Windows.Forms.PictureBox();
            this.dice1SelectedPictureBox = new System.Windows.Forms.PictureBox();
            this.dice2SelectedPictureBox = new System.Windows.Forms.PictureBox();
            this.dice3SelectedPictureBox = new System.Windows.Forms.PictureBox();
            this.dice4SelectedPictureBox = new System.Windows.Forms.PictureBox();
            this.dice5SelectedPictureBox = new System.Windows.Forms.PictureBox();
            this.playerTurnLabel = new System.Windows.Forms.Label();
            this.rollCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dice5PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice4PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice3PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1SelectedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2SelectedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice3SelectedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice4SelectedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice5SelectedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rollButton
            // 
            this.rollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollButton.Location = new System.Drawing.Point(221, 169);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(97, 31);
            this.rollButton.TabIndex = 1;
            this.rollButton.Text = "Roll";
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
            // 
            // dice5PictureBox
            // 
            this.dice5PictureBox.Location = new System.Drawing.Point(449, 76);
            this.dice5PictureBox.Name = "dice5PictureBox";
            this.dice5PictureBox.Size = new System.Drawing.Size(77, 77);
            this.dice5PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dice5PictureBox.TabIndex = 0;
            this.dice5PictureBox.TabStop = false;
            this.dice5PictureBox.Click += new System.EventHandler(this.dice5PictureBox_Click);
            // 
            // dice4PictureBox
            // 
            this.dice4PictureBox.Location = new System.Drawing.Point(339, 76);
            this.dice4PictureBox.Name = "dice4PictureBox";
            this.dice4PictureBox.Size = new System.Drawing.Size(77, 77);
            this.dice4PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dice4PictureBox.TabIndex = 0;
            this.dice4PictureBox.TabStop = false;
            this.dice4PictureBox.Click += new System.EventHandler(this.dice4PictureBox_Click);
            // 
            // dice3PictureBox
            // 
            this.dice3PictureBox.Location = new System.Drawing.Point(229, 76);
            this.dice3PictureBox.Name = "dice3PictureBox";
            this.dice3PictureBox.Size = new System.Drawing.Size(77, 77);
            this.dice3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dice3PictureBox.TabIndex = 0;
            this.dice3PictureBox.TabStop = false;
            this.dice3PictureBox.Click += new System.EventHandler(this.dice3PictureBox_Click);
            // 
            // dice2PictureBox
            // 
            this.dice2PictureBox.Location = new System.Drawing.Point(119, 76);
            this.dice2PictureBox.Name = "dice2PictureBox";
            this.dice2PictureBox.Size = new System.Drawing.Size(77, 77);
            this.dice2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dice2PictureBox.TabIndex = 0;
            this.dice2PictureBox.TabStop = false;
            this.dice2PictureBox.Click += new System.EventHandler(this.dice2PictureBox_Click);
            // 
            // dice1PictureBox
            // 
            this.dice1PictureBox.Location = new System.Drawing.Point(13, 76);
            this.dice1PictureBox.Name = "dice1PictureBox";
            this.dice1PictureBox.Size = new System.Drawing.Size(77, 77);
            this.dice1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dice1PictureBox.TabIndex = 0;
            this.dice1PictureBox.TabStop = false;
            this.dice1PictureBox.Click += new System.EventHandler(this.dice1PictureBox_Click);
            // 
            // dice1SelectedPictureBox
            // 
            this.dice1SelectedPictureBox.Image = global::yahtzee.Properties.Resources.green;
            this.dice1SelectedPictureBox.Location = new System.Drawing.Point(7, 72);
            this.dice1SelectedPictureBox.Name = "dice1SelectedPictureBox";
            this.dice1SelectedPictureBox.Size = new System.Drawing.Size(88, 85);
            this.dice1SelectedPictureBox.TabIndex = 2;
            this.dice1SelectedPictureBox.TabStop = false;
            this.dice1SelectedPictureBox.Visible = false;
            // 
            // dice2SelectedPictureBox
            // 
            this.dice2SelectedPictureBox.Image = global::yahtzee.Properties.Resources.green;
            this.dice2SelectedPictureBox.Location = new System.Drawing.Point(113, 72);
            this.dice2SelectedPictureBox.Name = "dice2SelectedPictureBox";
            this.dice2SelectedPictureBox.Size = new System.Drawing.Size(88, 85);
            this.dice2SelectedPictureBox.TabIndex = 2;
            this.dice2SelectedPictureBox.TabStop = false;
            this.dice2SelectedPictureBox.Visible = false;
            // 
            // dice3SelectedPictureBox
            // 
            this.dice3SelectedPictureBox.Image = global::yahtzee.Properties.Resources.green;
            this.dice3SelectedPictureBox.Location = new System.Drawing.Point(223, 72);
            this.dice3SelectedPictureBox.Name = "dice3SelectedPictureBox";
            this.dice3SelectedPictureBox.Size = new System.Drawing.Size(88, 85);
            this.dice3SelectedPictureBox.TabIndex = 2;
            this.dice3SelectedPictureBox.TabStop = false;
            this.dice3SelectedPictureBox.Visible = false;
            // 
            // dice4SelectedPictureBox
            // 
            this.dice4SelectedPictureBox.Image = global::yahtzee.Properties.Resources.green;
            this.dice4SelectedPictureBox.Location = new System.Drawing.Point(333, 72);
            this.dice4SelectedPictureBox.Name = "dice4SelectedPictureBox";
            this.dice4SelectedPictureBox.Size = new System.Drawing.Size(88, 85);
            this.dice4SelectedPictureBox.TabIndex = 2;
            this.dice4SelectedPictureBox.TabStop = false;
            this.dice4SelectedPictureBox.Visible = false;
            // 
            // dice5SelectedPictureBox
            // 
            this.dice5SelectedPictureBox.Image = global::yahtzee.Properties.Resources.green;
            this.dice5SelectedPictureBox.Location = new System.Drawing.Point(443, 72);
            this.dice5SelectedPictureBox.Name = "dice5SelectedPictureBox";
            this.dice5SelectedPictureBox.Size = new System.Drawing.Size(88, 85);
            this.dice5SelectedPictureBox.TabIndex = 2;
            this.dice5SelectedPictureBox.TabStop = false;
            this.dice5SelectedPictureBox.Visible = false;
            // 
            // playerTurnLabel
            // 
            this.playerTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTurnLabel.Location = new System.Drawing.Point(86, 20);
            this.playerTurnLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playerTurnLabel.Name = "playerTurnLabel";
            this.playerTurnLabel.Size = new System.Drawing.Size(142, 31);
            this.playerTurnLabel.TabIndex = 3;
            this.playerTurnLabel.Text = "Player 1\'s Turn";
            this.playerTurnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rollCountLabel
            // 
            this.rollCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollCountLabel.Location = new System.Drawing.Point(301, 20);
            this.rollCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rollCountLabel.Name = "rollCountLabel";
            this.rollCountLabel.Size = new System.Drawing.Size(142, 31);
            this.rollCountLabel.TabIndex = 3;
            this.rollCountLabel.Text = "Rolls: 0";
            this.rollCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RollDice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 211);
            this.Controls.Add(this.rollCountLabel);
            this.Controls.Add(this.playerTurnLabel);
            this.Controls.Add(this.rollButton);
            this.Controls.Add(this.dice5PictureBox);
            this.Controls.Add(this.dice4PictureBox);
            this.Controls.Add(this.dice3PictureBox);
            this.Controls.Add(this.dice2PictureBox);
            this.Controls.Add(this.dice1PictureBox);
            this.Controls.Add(this.dice5SelectedPictureBox);
            this.Controls.Add(this.dice4SelectedPictureBox);
            this.Controls.Add(this.dice3SelectedPictureBox);
            this.Controls.Add(this.dice2SelectedPictureBox);
            this.Controls.Add(this.dice1SelectedPictureBox);
            this.Name = "RollDice";
            this.Text = "Roll Dice";
            ((System.ComponentModel.ISupportInitialize)(this.dice5PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice4PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice3PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1SelectedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2SelectedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice3SelectedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice4SelectedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice5SelectedPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button rollButton;
        public System.Windows.Forms.PictureBox dice1PictureBox;
        public System.Windows.Forms.PictureBox dice2PictureBox;
        public System.Windows.Forms.PictureBox dice3PictureBox;
        public System.Windows.Forms.PictureBox dice4PictureBox;
        public System.Windows.Forms.PictureBox dice5PictureBox;
        public System.Windows.Forms.PictureBox dice1SelectedPictureBox;
        public System.Windows.Forms.PictureBox dice2SelectedPictureBox;
        public System.Windows.Forms.PictureBox dice3SelectedPictureBox;
        public System.Windows.Forms.PictureBox dice4SelectedPictureBox;
        public System.Windows.Forms.PictureBox dice5SelectedPictureBox;
        public System.Windows.Forms.Label playerTurnLabel;
        public System.Windows.Forms.Label rollCountLabel;
    }
}