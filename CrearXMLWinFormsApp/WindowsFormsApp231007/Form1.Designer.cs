﻿namespace WindowsFormsApp231007
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
            this.createXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createXML
            // 
            this.createXML.Location = new System.Drawing.Point(88, 66);
            this.createXML.Name = "createXML";
            this.createXML.Size = new System.Drawing.Size(151, 45);
            this.createXML.TabIndex = 0;
            this.createXML.Text = "Crear XML";
            this.createXML.UseVisualStyleBackColor = true;
            this.createXML.Click += new System.EventHandler(this.createXML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.createXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createXML;
    }
}

