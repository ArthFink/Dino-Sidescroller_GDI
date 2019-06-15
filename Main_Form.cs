using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_PLUS_Game_V1
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int y = 500;
            int x = 800;


            this.DoubleBuffered = true;            
            this.Paint += new PaintEventHandler(Main_From_Paint);
            x = this.Width;
            y = this.Height;
        }

        private void Main_From_Paint(object sender, PaintEventArgs e)
        {
            //Charakter
            e.Graphics.FillRectangle(Brushes.Black, 10, 260, 10, 30);

            //Grund Liene
            e.Graphics.FillRectangle(Brushes.Black, 0, 300, 800, 7);

            /*  float x = 0;

              for (float i = 0; i < 99; i++)
              {
                  x = (i * i)/2;

              }*/

            e.Graphics.DrawRectangle(Pens.Black, (Width / 2), (Height / 2), 50, 50);

        }

        private void Stdrd_Timer_Tick(object sender, EventArgs e)
        {
            //Fame Erstellen 
            this.Refresh();
        }
    }

    public class Main_From
    {

    }
}
