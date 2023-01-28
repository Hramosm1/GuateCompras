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

namespace SysCoNPresentacion
{
    public partial class MDIMenu : Form
    {
        private int childFormNumber = 0;

        public MDIMenu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

       

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    

       

       

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newMDIChild = new Form1();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
            
            
        }

        private void MDIMenu_Load(object sender, EventArgs e)
        {

           
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox newMDIChild = new AboutBox();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();

        }

        private void actualizarIntervaloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIntervalo newMDIChild = new frmIntervalo();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }
    }
}
