namespace FormDinamico231003
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
            this.lblBaseDatos = new System.Windows.Forms.Label();
            this.cbBaseDatos = new System.Windows.Forms.ComboBox();
            this.btnTablas = new System.Windows.Forms.Button();
            this.lblTablas = new System.Windows.Forms.Label();
            this.cbTablas = new System.Windows.Forms.ComboBox();
            this.btnCampos = new System.Windows.Forms.Button();
            this.MyControls = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseDatos.Location = new System.Drawing.Point(47, 27);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(140, 25);
            this.lblBaseDatos.TabIndex = 0;
            this.lblBaseDatos.Text = "Base de Datos";
            // 
            // cbBaseDatos
            // 
            this.cbBaseDatos.FormattingEnabled = true;
            this.cbBaseDatos.Location = new System.Drawing.Point(243, 27);
            this.cbBaseDatos.Name = "cbBaseDatos";
            this.cbBaseDatos.Size = new System.Drawing.Size(354, 24);
            this.cbBaseDatos.TabIndex = 1;
            // 
            // btnTablas
            // 
            this.btnTablas.Location = new System.Drawing.Point(633, 27);
            this.btnTablas.Name = "btnTablas";
            this.btnTablas.Size = new System.Drawing.Size(47, 25);
            this.btnTablas.TabIndex = 2;
            this.btnTablas.Text = "...";
            this.btnTablas.UseVisualStyleBackColor = true;
            this.btnTablas.Click += new System.EventHandler(this.btnTablas_Click);
            // 
            // lblTablas
            // 
            this.lblTablas.AutoSize = true;
            this.lblTablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTablas.Location = new System.Drawing.Point(47, 79);
            this.lblTablas.Name = "lblTablas";
            this.lblTablas.Size = new System.Drawing.Size(72, 25);
            this.lblTablas.TabIndex = 3;
            this.lblTablas.Text = "Tablas";
            // 
            // cbTablas
            // 
            this.cbTablas.FormattingEnabled = true;
            this.cbTablas.Location = new System.Drawing.Point(243, 79);
            this.cbTablas.Name = "cbTablas";
            this.cbTablas.Size = new System.Drawing.Size(354, 24);
            this.cbTablas.TabIndex = 4;
            // 
            // btnCampos
            // 
            this.btnCampos.Location = new System.Drawing.Point(633, 79);
            this.btnCampos.Name = "btnCampos";
            this.btnCampos.Size = new System.Drawing.Size(47, 25);
            this.btnCampos.TabIndex = 5;
            this.btnCampos.Text = "...";
            this.btnCampos.UseVisualStyleBackColor = true;
            this.btnCampos.Click += new System.EventHandler(this.btnCampos_Click);
            // 
            // MyControls
            // 
            this.MyControls.Location = new System.Drawing.Point(26, 138);
            this.MyControls.Name = "MyControls";
            this.MyControls.Size = new System.Drawing.Size(974, 596);
            this.MyControls.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 758);
            this.Controls.Add(this.MyControls);
            this.Controls.Add(this.btnCampos);
            this.Controls.Add(this.cbTablas);
            this.Controls.Add(this.lblTablas);
            this.Controls.Add(this.btnTablas);
            this.Controls.Add(this.cbBaseDatos);
            this.Controls.Add(this.lblBaseDatos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaseDatos;
        private System.Windows.Forms.ComboBox cbBaseDatos;
        private System.Windows.Forms.Button btnTablas;
        private System.Windows.Forms.Label lblTablas;
        private System.Windows.Forms.ComboBox cbTablas;
        private System.Windows.Forms.Button btnCampos;
        private System.Windows.Forms.Panel MyControls;
    }
}

