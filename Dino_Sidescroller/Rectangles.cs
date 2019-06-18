using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dino_Sidescroller
{
    public class Rectangles : Obstacles
    {
        public RectangleF[] GenerateObstacels(SizeF size,int frameCount)
        {
            RectangleF[] rectangleFs = new RectangleF[50];

           // Obstacles Singelobstacles = new Obstacles(40,40,40,40);
           // Obstacles doubellObstacles = new Obstacles(60, 40, 80, 40);


           Rectangle sR = new Rectangle(40,40,40,40);
           Rectangle sR2 = new Rectangle(50, 40, 40, 40);

            int h = 10;
            int w = 10;
            

            //rectangleFs[1] = sR;
            //rectangleFs[2] = sR2;

            for (int f = 0; f < rectangleFs.Length; f++)
            {

                Rectangle rectangle = new Rectangle(Convert.ToInt32(size.Width - f)*(frameCount +1), Convert.ToInt32(size.Height / 3 + 100 ), h, w);

                rectangleFs[f] = rectangle;
            }

            return rectangleFs;
        }
    }
}