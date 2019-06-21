using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public class Graphics_Paint
    {
        Rectangles rectangles;
        Charakter charakter ;
        float a;

        public Graphics_Paint(Game_Logic game_Logic)
        {
            charakter = game_Logic.Charakter;
            rectangles = game_Logic.Rectangles;
            a = 0f;
        }
        /// <summary>
        /// Draws The Character relative to the current Position
        /// </summary>
        public void Paint_Character(Graphics g, SizeF size)
        {
            g.FillRectangle(Brushes.Brown, charakter.Rect);
        }

        /// <summary>
        /// Draws The obstacles relative to the current Position
        /// </summary>
        public void Paint_Obstacles(Graphics g, SizeF size, int frameCount)
        {
            g.FillRectangles(Brushes.Blue, rectangles.RectangleFs);
        }

        public void Paint_Environment(Graphics g, SizeF size)
        {
            //Base Line
            g.FillRectangle(Brushes.Black, 0, 2 * (size.Height / 3), size.Width, 5);
        }

      /*  public void Paint_Übung(Graphics g, SizeF size)
        {
            float r = 100;
            float w = 10;           
            float h = 10;

            g.FillRectangle(Brushes.Black, Convert.ToInt32( Math.Sin(a)*r)+size.Width/2, Convert.ToInt32(Math.Cos(a) * r)+size.Height/2, w, h);

            a++;

        }*/
    }
}