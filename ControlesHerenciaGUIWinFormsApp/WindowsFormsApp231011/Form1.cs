using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp231011
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }

    public class MyTextBoxNumeric : TextBox
    {
        public MyTextBoxNumeric()
        {
            this.KeyPress += MyTextBoxNumeric_KeyPress;
        }
        private void MyTextBoxNumeric_KeyPress(object sende, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    public class MyButton : Button
    {
        public MyButton()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.LimeGreen;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);



            int cradius = 35;



            Rectangle buttonrect = this.ClientRectangle;



            GraphicsPath buttonpath = new GraphicsPath();



            buttonpath.AddArc(buttonrect.X, buttonrect.Y, cradius, cradius, 180, 90);
            buttonpath.AddArc(buttonrect.Right - cradius, buttonrect.Y - cradius, cradius, cradius, 270, 90);
            buttonpath.AddArc(buttonrect.Right - cradius, buttonrect.Bottom - cradius, cradius, cradius, 0, 90);
            buttonpath.AddArc(buttonrect.X, buttonrect.Bottom - cradius, cradius, cradius, 90, 90);



            buttonpath.CloseAllFigures();



            pevent.Graphics.FillPath(new SolidBrush(this.BackColor), buttonpath);
            //TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, buttonrect, this.ForeColor, TextFormatFlags.HorizontalCenter, TextFormatFlags.VerticalCenter);




        }



    }


}
