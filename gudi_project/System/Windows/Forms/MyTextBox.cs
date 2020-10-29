using System.CodeDom.Compiler;
using System.Drawing;

namespace System.Windows.Forms
{
    internal class MyTextBox : TextBox
    {
        
        private Color setColor = Color.Black;

        public override Font Font { get => base.Font; set => base.Font = value; }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    string showtext = "";
        //    for (int i = 0; i < Text.Length; i++)
        //        showtext += PasswordChar.ToString();
        //    Pen penBorder = new Pen(setColor, 3);
        //    e.Graphics.DrawRectangle(penBorder, e.ClipRectangle);
           

        //    Rectangle textRec = new Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);

        //    if (showtext.Length == 0)
        //    {
        //        TextRenderer.DrawText(e.Graphics, Text, this.Font, textRec, base.ForeColor, base.BackColor, TextFormatFlags.Default);
        //    }
        //    else
        //    {
        //        TextRenderer.DrawText(e.Graphics, showtext, this.Font, textRec, base.ForeColor, base.BackColor, TextFormatFlags.Default);
        //    }
        //}
    }
}