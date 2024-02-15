namespace yahtzee
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.summaryTitleLabel = new System.Windows.Forms.Label();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.scoringTitleLabel = new System.Windows.Forms.Label();
            this.scoringLabel = new System.Windows.Forms.Label();
            this.howToPlayTitleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // summaryTitleLabel
            // 
            this.summaryTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryTitleLabel.Location = new System.Drawing.Point(13, 11);
            this.summaryTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summaryTitleLabel.Name = "summaryTitleLabel";
            this.summaryTitleLabel.Size = new System.Drawing.Size(255, 44);
            this.summaryTitleLabel.TabIndex = 1;
            this.summaryTitleLabel.Text = "Game Summary";
            // 
            // summaryLabel
            // 
            this.summaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryLabel.Location = new System.Drawing.Point(16, 55);
            this.summaryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(765, 67);
            this.summaryLabel.TabIndex = 2;
            this.summaryLabel.Text = resources.GetString("summaryLabel.Text");
            // 
            // scoringTitleLabel
            // 
            this.scoringTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoringTitleLabel.Location = new System.Drawing.Point(14, 116);
            this.scoringTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoringTitleLabel.Name = "scoringTitleLabel";
            this.scoringTitleLabel.Size = new System.Drawing.Size(255, 44);
            this.scoringTitleLabel.TabIndex = 1;
            this.scoringTitleLabel.Text = "Scoring";
            // 
            // scoringLabel
            // 
            this.scoringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoringLabel.Location = new System.Drawing.Point(15, 160);
            this.scoringLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoringLabel.Name = "scoringLabel";
            this.scoringLabel.Size = new System.Drawing.Size(237, 246);
            this.scoringLabel.TabIndex = 2;
            this.scoringLabel.Text = resources.GetString("scoringLabel.Text");
            // 
            // howToPlayTitleLabel
            // 
            this.howToPlayTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToPlayTitleLabel.Location = new System.Drawing.Point(331, 122);
            this.howToPlayTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.howToPlayTitleLabel.Name = "howToPlayTitleLabel";
            this.howToPlayTitleLabel.Size = new System.Drawing.Size(255, 44);
            this.howToPlayTitleLabel.TabIndex = 1;
            this.howToPlayTitleLabel.Text = "How To Play";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(334, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 246);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scoringLabel);
            this.Controls.Add(this.summaryLabel);
            this.Controls.Add(this.howToPlayTitleLabel);
            this.Controls.Add(this.scoringTitleLabel);
            this.Controls.Add(this.summaryTitleLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label summaryTitleLabel;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.Label scoringTitleLabel;
        private System.Windows.Forms.Label scoringLabel;
        private System.Windows.Forms.Label howToPlayTitleLabel;
        private System.Windows.Forms.Label label1;
    }
}