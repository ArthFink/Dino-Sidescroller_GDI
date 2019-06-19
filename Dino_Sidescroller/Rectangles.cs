using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dino_Sidescroller
{
    public class Rectangles : Obstacles
    {
        public Rectangles()
        {

        }

        public RectangleF[] GenerateObstacels(SizeF size, int frameCount)
        {
            RectangleF[] rectangleFs = new RectangleF[50];

            // Obstacles Singelobstacles = new Obstacles(40,40,40,40);
            // Obstacles doubellObstacles = new Obstacles(60, 40, 80, 40);
            int h = 10;
            int w = 10;      

            Random generator = new Random(500);
            int rand = generator.Next();

            /*Rectangle rectangle = new Rectangle(Convert.ToInt32(size.Width - f)*(frameCount +1), Convert.ToInt32(size.Height / 3 + 100 ), h, w);*/

            for (int i = 0; i < rectangleFs.Length; i++)
            {
                Rectangle singeOblstacles = new Rectangle(40 + 10*i, 40, w, h);
                Rectangle doubellObstacles = new Rectangle(50 , 40, w, h * 2);

                if (rand % 2 == 0)
                {
                    rectangleFs[i] = singeOblstacles;
                }
                else
                {
                    rectangleFs[i]  = doubellObstacles;
                }
            }


            return rectangleFs;
        }
    }
}