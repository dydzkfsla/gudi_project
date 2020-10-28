using System.Drawing;

namespace System.Windows.Forms
{
    internal class MyTextBox : TextBox
    {
        
        private Color setColor = Color.Black;

        public override Font Font { get => base.Font; set => base.Font = value; }

        public MyTextBox() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public Color SetColor { get => setColor; set => setColor = value; }

        protected override void OnPaint(PaintEventArgs e)
        {

            Pen penBorder = new Pen(setColor, 3);
            e.Graphics.DrawRectangle(penBorder, e.ClipRectangle);

            Rectangle textRec = new Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            TextRenderer.DrawText(e.Graphics, Text, base.Font, textRec, base.ForeColor, base.BackColor, TextFormatFlags.Default);
        }

    }
}