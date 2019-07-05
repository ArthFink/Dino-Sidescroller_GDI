using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

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
        Image GameOverSceenImg;
        Image Base;
        Image CloudImg;
        
        Random generator;
        Rectangle gameOverHitbox;

        float xRect, yRect, x;

         bool hitboxShow;

 

        public Graphics_Paint(Game_Logic game_Logic)
        {
            charakter = game_Logic.Charakter;
            rectangles = game_Logic.Rectangles;

            DinoAnimationImage = Properties.Resources.Dinoanimation;
            CactiAnimationImag = Properties.Resources.Cacti_Imges;
            LargCactiAnimationImag = Properties.Resources.LargCacti;
            GameOverSceenImg = Properties.Resources.GameOverSceen;
            CloudImg = Properties.Resources.clound;
            this.Base = Properties.Resources.BaseLine;

            animationIndex = 0;
            generator = new Random();
            xRect = 100; yRect = 100; x = 0; 

            hitboxShow = false;

        }


        /// <summary>
        /// Shows the hitBox If b is Pressed
        /// </summary>
        public void Paint_HitBox(Graphics g, SizeF size, int frameCount)
        {

            if (hitboxShow)
            {
                g.DrawRectangle(Pens.Red, charakter.Rect);
                foreach (Cactus cactus in rectangles.Cacti)
                {
                    g.DrawRectangle(Pens.Red, cactus.HitBoxRectangle);
                  
                }
            }

        }

        public void Paint_Environment(Graphics g, SizeF size, int FrameCount)
        {
            g.DrawImage(CloudImg, 100, 37);
            g.DrawImage(CloudImg, size.Width / 3 * 2, 40);
            g.DrawImage(CloudImg, size.Width - 60, 50);
            g.DrawImage(CloudImg, size.Width / 2 - 160, 70);
            

        } 

        public void DinoAnimation(Graphics g, SizeF cSize, int FrameCount)
        {

            GraphicsUnit units = GraphicsUnit.Pixel;

            
            
                if (FrameCount % 3 == 0 && !charakter.Space  && !charakter.Jump)
                {
                    if (animationIndex < 2)
                    {
                        animationIndex += 1;
                    }
                    else if (animationIndex == 2)
                    {
                        animationIndex = 0;
                    }
                }

                Rectangle rectangle = new Rectangle(45 * animationIndex, 0, 43, 51);

                charakter.CharakterJumpFall();

                float y = charakter.Rect.Y;
                float x = charakter.Rect.X - 10;
                g.DrawImage(DinoAnimationImage, x, y, rectangle, units);      

        }

        public void CactiAnimation(Graphics g, SizeF cSize)
        {
            GraphicsUnit units = GraphicsUnit.Pixel;

            for (int i = 0; i < rectangles.Cacti.Count; i++)
            {

                if (rectangles.Cacti[i].HitBoxRectangle.Height == 39)
                {
                    xRect = rectangles.Cacti[i].HitBoxRectangle.X;
                    yRect = rectangles.Cacti[i].HitBoxRectangle.Y;

                    RectangleF largSrcRect5 = new RectangleF(100.0F, 0.0F, 55.0F, 50.0F);
                    g.DrawImage(LargCactiAnimationImag, xRect, yRect, largSrcRect5, units);
                }
                else if (rectangles.Cacti[i].HitBoxRectangle.Height == 25)
                {
                    xRect = rectangles.Cacti[i].HitBoxRectangle.X;
                    yRect = rectangles.Cacti[i].HitBoxRectangle.Y - 12;

                    RectangleF srcRect = new RectangleF(17.0F * rectangles.Cacti[i].ImgIndex, 0.0F, 17.0F, 45.0F);
                    g.DrawImage(CactiAnimationImag, xRect, yRect, srcRect, units);
                }
                else if (rectangles.Cacti[i].HitBoxRectangle.Height == 40)
                {
                    xRect = rectangles.Cacti[i].HitBoxRectangle.X;
                    yRect = rectangles.Cacti[i].HitBoxRectangle.Y - 50;

                    RectangleF largSrcRect2 = new RectangleF(25.0F * rectangles.Cacti[i].ImgIndex, 0.0F, 25.0F, 50.0F);
                    g.DrawImage(LargCactiAnimationImag, xRect, yRect + 50, largSrcRect2, units);
                }

            }

        }

        public void BaseLine(Graphics g, SizeF cSize, bool move)
        {

            GraphicsUnit units = GraphicsUnit.Pixel;

            RectangleF srcRect = new RectangleF(2.0F, 5.0F, 2408.0F, 30.0F);

            if (move)
            {
                x -= 4 + (rectangles.FrameCount / 500);
                if (x <= -Base.Width + 1200)
                {
                    x = 0;
                }
            }


            float y = 2 * (cSize.Height / 3) - 7;


            g.DrawImage(Base, x, y, srcRect, units);

        }

        public void GameOver(Graphics g, SizeF cSize)
        {

            GraphicsUnit units = GraphicsUnit.Pixel;

            Rectangle srcRect = new Rectangle(0, 0, 500, 50);

            float y = (cSize.Height / 2) - 70;
            float x = cSize.Width / 2 - 130;

            g.DrawImage(GameOverSceenImg, x, y, srcRect, units);

            gameOverHitbox.X = (int)x;
            gameOverHitbox.Y = (int)y;
            gameOverHitbox.Width = srcRect.Width;
            gameOverHitbox.Height = srcRect.Height;

        }

        public Rectangle GameOverHitbox
        {
            get { return gameOverHitbox; }
            set { gameOverHitbox = value; }
        }

     
      

        public bool HitBoxShow
        {
            get { return hitboxShow; }
            set { hitboxShow = value; }
        }

    }
}