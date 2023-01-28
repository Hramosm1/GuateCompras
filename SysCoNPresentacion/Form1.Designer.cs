namespace SysCoNPresentacion
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
            this.txtNit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Consulta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Correlativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nit:";
            // 
            // txtNit
            // 
            this.txtNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNit.Location = new System.Drawing.Point(106, 62);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(266, 26);
            this.txtNit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(106, 94);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(495, 26);
            this.txtNombre.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(106, 136);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 30);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "B&uscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Consulta,
            this.Imprimir,
            this.Correlativo,
            this.nit,
            this.Nombre});
            this.dgvDatos.Location = new System.Drawing.Point(40, 195);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(962, 298);
            this.dgvDatos.TabIndex = 5;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // Consulta
            // 
            this.Consulta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Consulta.HeaderText = "Consultar";
            this.Consulta.Name = "Consulta";
            this.Consulta.Text = "Consultar";
            this.Consulta.UseColumnTextForButtonValue = true;
            // 
            // Imprimir
            // 
            this.Imprimir.HeaderText = "Imprimir";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.UseColumnTextForButtonValue = true;
            // 
            // Correlativo
            // 
            this.Correlativo.DataPropertyName = "correlativo";
            this.Correlativo.HeaderText = "Correlativo";
            this.Correlativo.Name = "Correlativo";
            this.Correlativo.ReadOnly = true;
            this.Correlativo.Visible = false;
            // 
            // nit
            // 
            this.nit.DataPropertyName = "nit";
            this.nit.HeaderText = "Nit";
            this.nit.Name = "nit";
            this.nit.ReadOnly = true;
            this.nit.Width = 200;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 600;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 528);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNit);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewButtonColumn Consulta;
        private System.Windows.Forms.DataGridViewButtonColumn Imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correlativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}

