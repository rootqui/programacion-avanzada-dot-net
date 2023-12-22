using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DemoWindowsForms230929
{
    public partial class Form1 : Form
    {
        bool dragScreen = false;
        Point startPointScreen = Point.Empty;

        bool dragElement = false;
        private Size mouseOffset;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Draggable<Button> btnLogin = new Draggable<Button>(this.btnLogin);
            Draggable<Label> lblUser = new Draggable<Label>(this.lblUser);
            Draggable<Label> lblPassword = new Draggable<Label>(this.lblPassword);
            Draggable<TextBox> txtUsername = new Draggable<TextBox>(this.txtUsername);
            Draggable<TextBox> txtPassword= new Draggable<TextBox>(this.txtPassword);          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragScreen = true;
                startPointScreen = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragScreen)
            {
                // toda la pantalla pc
                Point actPoint = this.PointToScreen(new Point(e.X, e.Y));
                actPoint.Offset(-startPointScreen.X, -startPointScreen.Y);
                this.Location = actPoint;

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragScreen = false;
            }
        }

    }
    class Draggable <T> where T : Control
    {
        T control;
        bool dragElement = false;
        private Size mouseOffset;

        public Draggable(T control)
        {
            this.control = control;

            control.MouseDown += new MouseEventHandler(controlMouseDown);
            control.MouseMove += new MouseEventHandler(controlMouseMove);
            control.MouseUp += new MouseEventHandler(controlMouseUp);
        }

        private void controlMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragElement = true;
                mouseOffset = new Size(e.Location);
            }
        }

        private void controlMouseMove(object sender, MouseEventArgs e)
        {
            if (dragElement)
            {
                Point newLocation = e.Location - mouseOffset;
                control.Left += newLocation.X;
                control.Top += newLocation.Y;
            }
        }

        private void controlMouseUp(object sender, MouseEventArgs e)
        {
            dragElement = false;
        }

        //public static void offsetElement<T>(T control, Point location, Size mouseOffset) where T : Control
        //{
        //    Point newLocation = location - mouseOffset;
        //    control.Left += newLocation.X;
        //    control.Top += newLocation.Y;
        //}

    }
}
