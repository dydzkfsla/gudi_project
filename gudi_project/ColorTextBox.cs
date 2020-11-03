using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace gudi_project
{
    public partial class ColorTextBox : UserControl
    {

        public override Font Font { get => base.Font; set => base.Font = value; }
        public override string Text { get => textBox1.Text; set => textBox1.Text = value; }
        public char PasswordChar { get => textBox1.PasswordChar; set => textBox1.PasswordChar = value; }

        //public event EventHandler TextChanged;

        public void SetTextChangedEvent(EventHandler @event)
        {
            textBox1.TextChanged += @event;
        }

        public ColorTextBox()
        {
            InitializeComponent();
        }

        private void ColorTextBox_SizeChanged(object sender, EventArgs e)
        {
            textBox1.Location = new Point(3, 3);
            textBox1.Width = this.Width - 6;
            this.Height = textBox1.Height + 6;
        }

    }
}
