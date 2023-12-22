namespace WindowsFormsAppWCF
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.lblArchivoImagen = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtArchivoImagen = new System.Windows.Forms.TextBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.dgvPachacamac = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPachacamac)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(31, 38);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(20, 16);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(31, 82);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Location = new System.Drawing.Point(31, 139);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(54, 16);
            this.lblDescrip.TabIndex = 2;
            this.lblDescrip.Text = "Descrip";
            // 
            // lblArchivoImagen
            // 
            this.lblArchivoImagen.AutoSize = true;
            this.lblArchivoImagen.Location = new System.Drawing.Point(31, 184);
            this.lblArchivoImagen.Name = "lblArchivoImagen";
            this.lblArchivoImagen.Size = new System.Drawing.Size(100, 16);
            this.lblArchivoImagen.TabIndex = 3;
            this.lblArchivoImagen.Text = "Archivo Imagen";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(153, 38);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(295, 22);
            this.txtId.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(153, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(295, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(153, 132);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(295, 22);
            this.txtDescrip.TabIndex = 6;
            // 
            // txtArchivoImagen
            // 
            this.txtArchivoImagen.Location = new System.Drawing.Point(156, 184);
            this.txtArchivoImagen.Name = "txtArchivoImagen";
            this.txtArchivoImagen.Size = new System.Drawing.Size(295, 22);
            this.txtArchivoImagen.TabIndex = 7;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(538, 36);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(145, 39);
            this.btnInsertar.TabIndex = 8;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // dgvPachacamac
            // 
            this.dgvPachacamac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPachacamac.Location = new System.Drawing.Point(34, 347);
            this.dgvPachacamac.Name = "dgvPachacamac";
            this.dgvPachacamac.RowHeadersWidth = 51;
            this.dgvPachacamac.RowTemplate.Height = 24;
            this.dgvPachacamac.Size = new System.Drawing.Size(733, 304);
            this.dgvPachacamac.TabIndex = 9;
            this.dgvPachacamac.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPachacamac_CellClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(538, 96);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(145, 39);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(538, 161);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(145, 39);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(538, 237);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(145, 39);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 705);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvPachacamac);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.txtArchivoImagen);
            this.Controls.Add(this.txtDescrip);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblArchivoImagen);
            this.Controls.Add(this.lblDescrip);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblId);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPachacamac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.Label lblArchivoImagen;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtArchivoImagen;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.DataGridView dgvPachacamac;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

