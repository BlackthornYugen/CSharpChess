﻿namespace Chess
{
    partial class Debugging
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
            this.noDoubleJumpPawnButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.noCastleKingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // noDoubleJumpPawnButton
            // 
            this.noDoubleJumpPawnButton.Location = new System.Drawing.Point(41, 12);
            this.noDoubleJumpPawnButton.Name = "noDoubleJumpPawnButton";
            this.noDoubleJumpPawnButton.Size = new System.Drawing.Size(75, 44);
            this.noDoubleJumpPawnButton.TabIndex = 0;
            this.noDoubleJumpPawnButton.Text = "Pawn no 2x Jump";
            this.noDoubleJumpPawnButton.UseVisualStyleBackColor = true;
            this.noDoubleJumpPawnButton.Click += new System.EventHandler(this.ChessPiece_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(337, 182);
            this.textBox1.TabIndex = 1;
            // 
            // noCastleKingButton
            // 
            this.noCastleKingButton.Location = new System.Drawing.Point(122, 12);
            this.noCastleKingButton.Name = "noCastleKingButton";
            this.noCastleKingButton.Size = new System.Drawing.Size(75, 44);
            this.noCastleKingButton.TabIndex = 0;
            this.noCastleKingButton.Text = "King no Castle";
            this.noCastleKingButton.UseVisualStyleBackColor = true;
            this.noCastleKingButton.Click += new System.EventHandler(this.ChessPiece_Click);
            // 
            // Debugging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(397, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.noCastleKingButton);
            this.Controls.Add(this.noDoubleJumpPawnButton);
            this.Name = "Debugging";
            this.Text = "Debug Chess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button noDoubleJumpPawnButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button noCastleKingButton;
    }
}

