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
        Charakter charakter;
        int animationIndex;
        Image DinoAnimationImage;

        public Graphics_Paint(Game_Logic game_Logic)
        {
            charakter = game_Logic.Charakter;
            rectangles = game_Logic.Rectangles;
            DinoAnimationImage = Properties.Resources.Dinoanimation;

            animationIndex = 0;

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
            g.FillRectangles(Brushes.Blue, rectangles.RectanglesFs.ToArray());
        }

        public void Paint_Environment(Graphics g, SizeF size)
        {
            //Base Line
            g.FillRectangle(Brushes.Black, 0, 2 * (size.Height / 3), size.Width, 5);
        }


        public void DinoAnimation(Graphics g, SizeF cSize)
        {


            GraphicsUnit units = GraphicsUnit.Pixel;

            //animationIndex = animationIndex == 2 ? 0 : animationIndex++;

            if (animationIndex < 2)
            {
                animationIndex += 1;
            }
            else if (animationIndex == 2)
            {
                animationIndex = 0;
            }

            RectangleF srcRect = new RectangleF(45.0F * animationIndex, 0.0F, 43.0F, 51.0F);

            charakter.CharakterJumpFall();

            float y = charakter.Rect.Y;
            float x = charakter.Rect.X;

            g.DrawImage(DinoAnimationImage, x, y, srcRect, units);
        }

    }
}