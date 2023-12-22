namespace WindowsFormsApp1
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
            this.lblTablas = new System.Windows.Forms.Label();
            this.cbTablas = new System.Windows.Forms.ComboBox();
            this.btnObtenerTablas = new System.Windows.Forms.Button();
            this.btnObtenerRegistros = new System.Windows.Forms.Button();
            this.PanelRegistros = new System.Windows.Forms.Panel();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.Location = new System.Drawing.Point(40, 34);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(95, 16);
            this.lblBaseDatos.TabIndex = 0;
            this.lblBaseDatos.Text = "Base de datos";
            // 
            // cbBaseDatos
            // 
            this.cbBaseDatos.FormattingEnabled = true;
            this.cbBaseDatos.Location = new System.Drawing.Point(156, 26);
            this.cbBaseDatos.Name = "cbBaseDatos";
            this.cbBaseDatos.Size = new System.Drawing.Size(410, 24);
            this.cbBaseDatos.TabIndex = 1;
            // 
            // lblTablas
            // 
            this.lblTablas.AutoSize = true;
            this.lblTablas.Location = new System.Drawing.Point(40, 89);
            this.lblTablas.Name = "lblTablas";
            this.lblTablas.Size = new System.Drawing.Size(50, 16);
            this.lblTablas.TabIndex = 2;
            this.lblTablas.Text = "Tablas";
            // 
            // cbTablas
            // 
            this.cbTablas.FormattingEnabled = true;
            this.cbTablas.Location = new System.Drawing.Point(156, 81);
            this.cbTablas.Name = "cbTablas";
            this.cbTablas.Size = new System.Drawing.Size(410, 24);
            this.cbTablas.TabIndex = 3;
            // 
            // btnObtenerTablas
            // 
            this.btnObtenerTablas.Location = new System.Drawing.Point(599, 27);
            this.btnObtenerTablas.Name = "btnObtenerTablas";
            this.btnObtenerTablas.Size = new System.Drawing.Size(75, 23);
            this.btnObtenerTablas.TabIndex = 4;
            this.btnObtenerTablas.Text = "...";
            this.btnObtenerTablas.UseVisualStyleBackColor = true;
            this.btnObtenerTablas.Click += new System.EventHandler(this.btnObtenerTablas_Click);
            // 
            // btnObtenerRegistros
            // 
            this.btnObtenerRegistros.Location = new System.Drawing.Point(599, 81);
            this.btnObtenerRegistros.Name = "btnObtenerRegistros";
            this.btnObtenerRegistros.Size = new System.Drawing.Size(75, 23);
            this.btnObtenerRegistros.TabIndex = 5;
            this.btnObtenerRegistros.Text = "...";
            this.btnObtenerRegistros.UseVisualStyleBackColor = true;
            this.btnObtenerRegistros.Click += new System.EventHandler(this.btnObtenerRegistros_Click);
            // 
            // PanelRegistros
            // 
            this.PanelRegistros.Location = new System.Drawing.Point(32, 191);
            this.PanelRegistros.Name = "PanelRegistros";
            this.PanelRegistros.Size = new System.Drawing.Size(798, 599);
            this.PanelRegistros.TabIndex = 6;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(156, 141);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 7;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(266, 141);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(89, 23);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(388, 142);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(85, 23);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(509, 142);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 820);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.PanelRegistros);
            this.Controls.Add(this.btnObtenerRegistros);
            this.Controls.Add(this.btnObtenerTablas);
            this.Controls.Add(this.cbTablas);
            this.Controls.Add(this.lblTablas);
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
        private System.Windows.Forms.Label lblTablas;
        private System.Windows.Forms.ComboBox cbTablas;
        private System.Windows.Forms.Button btnObtenerTablas;
        private System.Windows.Forms.Button btnObtenerRegistros;
        private System.Windows.Forms.Panel PanelRegistros;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

