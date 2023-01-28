using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using Negocio;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using CrystalDecisions.CrystalReports.Engine;

namespace SysCoNPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EnvioDatos Enviar = new EnvioDatos();

            string sql = "";
            if (txtNit.Text.Trim() != "") { sql = " where nit='" + txtNit.Text.Trim() + "'"; }

            if (txtNombre.Text.Trim() != "")
            {
                string[] nombre = txtNombre.Text.Trim().Split(' ');
                string resultadoLike = "";
                int i = 0;
                foreach (var sub in nombre)
                {
                    if (i == 0)
                    { resultadoLike = "nombre like'%"  + sub + "%'"; }
                    else {
                        resultadoLike = resultadoLike + " and nombre like'%" + sub + "%'";
                    }
                  
                    i++;
                }

                if (sql != "")
                {

                    sql = sql + " and " + resultadoLike;
                }
                else
                {
                    sql = " where "+ resultadoLike;
                }
            }
            if (sql == "")
            {
                MessageBox.Show("Debe de agregar un criterio de busqueda ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvDatos.AutoGenerateColumns = false;
            List<Encabezado> resultado = new List<Encabezado>();
            resultado = Enviar.busqueda(sql.ToUpper());
            dgvDatos.DataSource = resultado;

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            Int64 correlativo = 0;
            var nit = "";
            EnvioDatos reporte = new EnvioDatos();
            CrystalDecisions.CrystalReports.Engine.ReportDocument mirepo;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                correlativo = Int64.Parse(dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString());
                nit = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                DataSet Datos = new DataSet();
                Datos = reporte.ReporteCrystal(correlativo, nit);

                if (dgvDatos.Columns[e.ColumnIndex].HeaderText == "Consultar")
                {
                    Stream myStream;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "txt files (*.xls)|*.xls";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                       string nom= saveFileDialog1.FileName;
                       
                        exportar(Datos.Tables[0], nom);
                    }

                        }

                if (dgvDatos.Columns[e.ColumnIndex].HeaderText == "Imprimir")
                {   
                    mirepo = new Reportes.rpNit();
                    mirepo.SetDataSource(Datos);
                    frmReporte frm = new frmReporte();
                    frm.crystalReportViewer1.ReportSource = mirepo;
                    frm.crystalReportViewer1.RefreshReport();
                    frm.Show();
                }

            }


        }


        private void exportar(DataTable dt,string pat)
        {
            try
            { 
            var excelApplication = new Microsoft.Office.Interop.Excel.Application();
            var excelWorkBook = excelApplication.Application.Workbooks.Add(Type.Missing);
            DataColumnCollection dataColumnCollection = dt.Columns;
            for (int i = 1; i <= dt.Rows.Count + 1; i++)
            {
                for (int j = 1; j <= dt.Columns.Count; j++)
                {
                    if (i == 1)
                        excelApplication.Cells[i, j] = dataColumnCollection[j - 1].ToString();
                    else
                        excelApplication.Cells[i, j] = dt.Rows[i - 2][j - 1].ToString();
                }
            }            
            excelApplication.ActiveWorkbook.SaveCopyAs(pat);
            excelApplication.ActiveWorkbook.Saved = true;
            excelApplication.Quit();
                MessageBox.Show("Exportacion Finalizada","Información");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al exportar la información"+ ex.ToString(), "Error");
            }
        }
  

    }
}
