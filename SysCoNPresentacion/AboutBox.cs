using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace SysCoNPresentacion
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();         
        }

        
        private void btnok_Click(object sender, EventArgs e)
        {
            EnvioDatos Enviar = new EnvioDatos();

            string resultado = Enviar.activar(txtclave.Text.Trim());
            if (resultado != "OK")
            {
                MessageBox.Show("Error en la activación","Error");
                    }
            else
            {
                MessageBox.Show("Activación exitosa", "Información");
            }
        }
    }
}
