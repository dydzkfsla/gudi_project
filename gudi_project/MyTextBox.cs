using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    class MyTextBox : TextBox
    {
        public MyTextBox(): base()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.Bounds, Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
