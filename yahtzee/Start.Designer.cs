namespace yahtzee
{
    partial class Start
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
            this.titlePictureBox = new System.Windows.Forms.PictureBox();
            this.playersComboBox = new System.Windows.Forms.ComboBox();
            this.selectPlayersLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePictureBox
            // 
            this.titlePictureBox.Image = global::yahtzee.Properties.Resources.title;
            this.titlePictureBox.Location = new System.Drawing.Point(60, 15);
            this.titlePictureBox.Name = "titlePictureBox";
            this.titlePictureBox.Size = new System.Drawing.Size(322, 87);
            this.titlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.titlePictureBox.TabIndex = 0;
            this.titlePictureBox.TabStop = false;
            // 
            // playersComboBox
            // 
            this.playersComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.playersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playersComboBox.FormattingEnabled = true;
            this.playersComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.playersComboBox.Location = new System.Drawing.Point(173, 154);
            this.playersComboBox.Name = "playersComboBox";
            this.playersComboBox.Size = new System.Drawing.Size(80, 21);
            this.playersComboBox.TabIndex = 1;
            // 
            // selectPlayersLabel
            // 
            this.selectPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPlayersLabel.Location = new System.Drawing.Point(60, 122);
            this.selectPlayersLabel.Name = "selectPlayersLabel";
            this.selectPlayersLabel.Size = new System.Drawing.Size(322, 23);
            this.selectPlayersLabel.TabIndex = 2;
            this.selectPlayersLabel.Text = "Select the number of players:";
            this.selectPlayersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(64, 191);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(98, 32);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(284, 192);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(98, 32);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.Location = new System.Drawing.Point(172, 192);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(98, 32);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 252);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.selectPlayersLabel);
            this.Controls.Add(this.playersComboBox);
            this.Controls.Add(this.titlePictureBox);
            this.Name = "Start";
            this.Text = "Start";
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox titlePictureBox;
        private System.Windows.Forms.ComboBox playersComboBox;
        private System.Windows.Forms.Label selectPlayersLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button helpButton;
    }
}

