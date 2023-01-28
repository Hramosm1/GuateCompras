namespace SysCoNPresentacion
{
    partial class frmIntervalo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItervaloActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nupActual = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupActual)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(174, 153);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(150, 31);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Intervalo Actual";
            // 
            // txtItervaloActual
            // 
            this.txtItervaloActual.Enabled = false;
            this.txtItervaloActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItervaloActual.Location = new System.Drawing.Point(174, 55);
            this.txtItervaloActual.Name = "txtItervaloActual";
            this.txtItervaloActual.Size = new System.Drawing.Size(204, 26);
            this.txtItervaloActual.TabIndex = 2;
            this.txtItervaloActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Intervalo Actual";
            // 
            // nupActual
            // 
            this.nupActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupActual.Location = new System.Drawing.Point(174, 104);
            this.nupActual.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.nupActual.Name = "nupActual";
            this.nupActual.Size = new System.Drawing.Size(204, 26);
            this.nupActual.TabIndex = 4;
            this.nupActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmIntervalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 278);
            this.Controls.Add(this.nupActual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtItervaloActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIntervalo";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmIntervalo";
            this.Load += new System.EventHandler(this.frmIntervalo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupActual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItervaloActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupActual;
    }
}
