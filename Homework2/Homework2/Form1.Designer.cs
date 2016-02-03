namespace Homework2
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonShowAnswer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "You there, with the colorful hat! ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonShowAnswer
            // 
            this.buttonShowAnswer.Location = new System.Drawing.Point(90, 160);
            this.buttonShowAnswer.Name = "buttonShowAnswer";
            this.buttonShowAnswer.Size = new System.Drawing.Size(100, 33);
            this.buttonShowAnswer.TabIndex = 1;
            this.buttonShowAnswer.Text = "Fine, I guess...";
            this.buttonShowAnswer.UseVisualStyleBackColor = true;
            this.buttonShowAnswer.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.MaximumSize = new System.Drawing.Size(280, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = "Or is it a festive bowl? You strike me as a man who endulges in only the finest o" +
    "f headwear.  Step up to my crystal ball and I\'ll reveal to you the ancient art o" +
    "f guessing a number between 0 and 100!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 268);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonShowAnswer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Homework 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonShowAnswer;
        private System.Windows.Forms.Label label2;
    }
}

