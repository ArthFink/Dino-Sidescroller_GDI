using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public partial class Main_Form : Form
    {
        Timer timer;
        int frameCount = 1;
        Graphics_Paint graphics_Paint;
        Game_Logic game_Logic;

        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;

            game_Logic = new Game_Logic(ClientSize);
            graphics_Paint = new Graphics_Paint(game_Logic);

            timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 30;
            timer.Start();

            KeyDown += new KeyEventHandler(Key_Press);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Has always to be the first line of the overriden OnPaint-Method.
            base.OnPaint(e);
            // Get the graphics object.        
            Graphics graphics = e.Graphics;


            graphics_Paint.Paint_Environment(graphics, ClientSize);

            graphics_Paint.Paint_Character(graphics, ClientSize);

            graphics_Paint.Paint_Obstacles(graphics, ClientSize, frameCount);

            //graphics_Paint.Paint_Übung(graphics, ClientSize);
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            frameCount += 1;


            game_Logic.Charakter.Fall();
            //the timer starts and increments the counter.

            //Refresh();
            Invalidate();

        }

        /// <summary>
        ///Detects If key is Presst
        /// </summary>
        private void Key_Press(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
            {
                game_Logic.Charakter.Jump();
            }
        }


    }
}
