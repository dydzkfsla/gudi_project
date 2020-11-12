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
    }
}
