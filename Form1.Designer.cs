namespace Airports
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.waitMessage = new System.Windows.Forms.Label();
            this.waitProgressBar = new System.Windows.Forms.ProgressBar();
            this.waitTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // waitMessage
            // 
            this.waitMessage.AutoSize = true;
            this.waitMessage.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.waitMessage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.waitMessage.Location = new System.Drawing.Point(304, 156);
            this.waitMessage.Name = "waitMessage";
            this.waitMessage.Size = new System.Drawing.Size(171, 37);
            this.waitMessage.TabIndex = 0;
            this.waitMessage.Text = "Please Wait...";
            // 
            // waitProgressBar
            // 
            this.waitProgressBar.Location = new System.Drawing.Point(286, 196);
            this.waitProgressBar.Name = "waitProgressBar";
            this.waitProgressBar.Size = new System.Drawing.Size(198, 23);
            this.waitProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.waitProgressBar.TabIndex = 1;
            // 
            // waitTimeLabel
            // 
            this.waitTimeLabel.AutoSize = true;
            this.waitTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.waitTimeLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.waitTimeLabel.Location = new System.Drawing.Point(277, 231);
            this.waitTimeLabel.Name = "waitTimeLabel";
            this.waitTimeLabel.Size = new System.Drawing.Size(222, 15);
            this.waitTimeLabel.TabIndex = 2;
            this.waitTimeLabel.Text = "This usually takes 30 seconds to a minute";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.waitTimeLabel);
            this.Controls.Add(this.waitProgressBar);
            this.Controls.Add(this.waitMessage);
            this.Name = "Form1";
            this.Text = "Airports";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label waitMessage;
        private ProgressBar waitProgressBar;
        private Label waitTimeLabel;
    }
}