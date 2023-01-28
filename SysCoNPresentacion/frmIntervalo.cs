using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using Negocio;

namespace SysCoNPresentacion
{
    partial class frmIntervalo : Form
    {
        public frmIntervalo()
        {
            InitializeComponent();
          
        }

   

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            EnvioDatos Enviar = new EnvioDatos();

            string resultado = Enviar.ActualizarIntervalo(Int64.Parse(nupActual.Value.ToString()));
            if (resultado != "OK")
            {
                MessageBox.Show("Error en la actualizacion de intervalo", "Error");
            }
            else
            {
                MessageBox.Show("actualización de intervalo exitosa", "Información");
            }

        }

        private void frmIntervalo_Load(object sender, EventArgs e)
        {
            correlativo Ucorrelativo = new correlativo();
            EnvioDatos detalleCorrelativo = new EnvioDatos();
            Ucorrelativo = detalleCorrelativo.getCorrelativo(0);
            txtItervaloActual.Text = Ucorrelativo.intervalo.ToString();
        }
    }
}
