using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3.LEC1
{
    public partial class Lines : Form
    {
        public Lines()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs paintEvnt)
        {
            // Get the graphics object 
            Graphics gfx = paintEvnt.Graphics;
            // Create a new pen that we shall use for drawing the line 
            Pen myPen = new Pen(Color.Black);
            // Loop and create a new line 10 pixels below the last one 
            for (int i = 20; i < 250; i = i + 10)
            {
                gfx.DrawLine(myPen, 20, i, 270, i);
            }
        }

    }

    public partial class Checkerboard : Lines
    {
        protected override void OnPaint(PaintEventArgs paintEvnt)
        {
            Graphics gfx = paintEvnt.Graphics;
            Pen myPen = new Pen(Color.Black);
            base.OnPaint(paintEvnt);
            gfx.DrawLine(myPen, 20, 250, 270, 250);
            // Loop and create a vertical line 10 pixels next to the last one 
            for (int x = 20; x < 280; x = x + 10)
            {
                gfx.DrawLine(myPen, x, 20, x, 250);
            }
        }

        public Checkerboard()
        {
            this.Text = "Checkerboard";
        }
    }
}
