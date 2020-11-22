using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class Master_Mainfrm : Form
    {
        private static Master_Mainfrm frm = null;
        public static void Master_MainfrmShow(Form form)
        {
            if(frm == null || frm.IsDisposed)
            {
                frm = new Master_Mainfrm();
                frm.Owner = form;
                frm.Show();
            }
        }

        private  Master_Mainfrm()
        {
            InitializeComponent();
        }

        private void Master_Mainfrm_Load(object sender, EventArgs e)
        {

        }

        private void Master_Mainfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void busMastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<Bus_Mast>();
        }

        private void codeMastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<Code_Mast>();
        }

        private void employeesMastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<Employees_Mast>();
        }

        private void travelMastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<Travel_Mast>();
        }

        private void salesMastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCreateForm<sales_Mast>();
        }


        private void OpenCreateForm<T>() where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(T))
                {
                    form.Activate();
                    return;
                }
            }

            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
