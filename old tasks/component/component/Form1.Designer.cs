﻿namespace component
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
            this.userControl11 = new MyScroll.UserControl1();
            this.button1 = new System.Windows.Forms.Button();
            this.windowsControlLibrary1 = new MYCOMP.WindowsControlLibrary();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Current = 0;
            this.userControl11.Location = new System.Drawing.Point(47, 38);
            this.userControl11.Max = 2147483647;
            this.userControl11.Min = -2147483648;
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(150, 150);
            this.userControl11.TabIndex = 0;
            this.userControl11.Load += new System.EventHandler(this.userControl11_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // windowsControlLibrary1
            // 
            this.windowsControlLibrary1.Location = new System.Drawing.Point(134, 53);
            this.windowsControlLibrary1.Message = null;
            this.windowsControlLibrary1.Name = "windowsControlLibrary1";
            this.windowsControlLibrary1.Size = new System.Drawing.Size(135, 66);
            this.windowsControlLibrary1.TabIndex = 2;
            this.windowsControlLibrary1.Text = "windowsControlLibrary1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.windowsControlLibrary1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MyScroll.UserControl1 userControl11;
        private System.Windows.Forms.Button button1;
        private MYCOMP.WindowsControlLibrary windowsControlLibrary1;
    }
}

