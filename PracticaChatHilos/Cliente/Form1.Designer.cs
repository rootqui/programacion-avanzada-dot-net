namespace Cliente
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
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnMensaje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(156, 59);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(395, 22);
            this.txtMensaje.TabIndex = 0;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(58, 59);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(59, 16);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Mensaje";
            // 
            // btnMensaje
            // 
            this.btnMensaje.Location = new System.Drawing.Point(269, 127);
            this.btnMensaje.Name = "btnMensaje";
            this.btnMensaje.Size = new System.Drawing.Size(142, 31);
            this.btnMensaje.TabIndex = 2;
            this.btnMensaje.Text = "Enviar";
            this.btnMensaje.UseVisualStyleBackColor = true;
            this.btnMensaje.Click += new System.EventHandler(this.btnMensaje_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 210);
            this.Controls.Add(this.btnMensaje);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.txtMensaje);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnMensaje;
    }
}

