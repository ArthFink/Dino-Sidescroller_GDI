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
        Image CactiAnimationImag;
        Image LargCactiAnimationImag;
        Random generator;

        float xRect, yRect;

        public Graphics_Paint(Game_Logic game_Logic)
        {
            charakter = game_Logic.Charakter;
            rectangles = game_Logic.Rectangles;

            DinoAnimationImage = Properties.Resources.Dinoanimation;
            CactiAnimationImag = Properties.Resources.Cacti_Imges;
            LargCactiAnimationImag = Properties.Resources.LargCacti;

            animationIndex = 0;
            generator = new Random();
            xRect = 100; yRect = 100;
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
            g.DrawRectangles(Pens.Gray, rectangles.RectanglesFs.ToArray());
        }

        public void Paint_Environment(Graphics g, SizeF size)
        {
            //Base Line
            g.FillRectangle(Brushes.Black, 0, 2 * (size.Height / 3), size.Width, 5);
        }


        public void DinoAnimation(Graphics g, SizeF cSize)
        {
            g.DrawRectangle(Pens.Red, charakter.Rect);

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
            float x = charakter.Rect.X - 10;

            g.DrawImage(DinoAnimationImage, x, y, srcRect, units);
        }

        public void CactiAnimation(Graphics g, SizeF cSize)
        {
            GraphicsUnit units = GraphicsUnit.Pixel;
            int random = generator.Next(6);

            for (int i = 0; i < rectangles.RectanglesFs.Count; i++)
            {
                xRect = rectangles.RectanglesFs[i].X;
                yRect = rectangles.RectanglesFs[i].Y;


                RectangleF srcRect = new RectangleF(17.0F * random, 0.0F, 17.0F, 50.0F);
                g.DrawImage(CactiAnimationImag, xRect, yRect, srcRect, units);
            }

            float x = 50;
            float y = 50;

            RectangleF largSrcRect1 = new RectangleF(0.0F, 0.0F, 25.0F, 50.0F);
            RectangleF largSrcRect2 = new RectangleF(25.0F, 0.0F, 25.0F, 50.0F);
            RectangleF largSrcRect3 = new RectangleF(50.0F, 0.0F, 25.0F, 50.0F);
            RectangleF largSrcRect4 = new RectangleF(75.0F, 0.0F, 25.0F, 50.0F);

            RectangleF largSrcRect5 = new RectangleF(100.0F, 0.0F, 55.0F, 50.0F);

            g.DrawImage(LargCactiAnimationImag, x, y, largSrcRect1, units);
            g.DrawImage(LargCactiAnimationImag, x, y + 50, largSrcRect2, units);
            g.DrawImage(LargCactiAnimationImag, x, y + 100, largSrcRect3, units);
            g.DrawImage(LargCactiAnimationImag, x, y + 150, largSrcRect4, units);
            g.DrawImage(LargCactiAnimationImag, x + 200, y + 150, largSrcRect5, units);


        }

    }
}