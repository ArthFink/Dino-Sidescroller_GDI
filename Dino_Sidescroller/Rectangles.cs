using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dino_Sidescroller
{
    public class Rectangles : Obstacles
    {
        int baseHight;
        RectangleF singeOblstacles;
        RectangleF doubellObstacles;

        Random generator;
        int rand;

        public Rectangles(SizeF cSize)
        {
            rectanglesFs = new RectangleF[50];
            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 10;

            singeOblstacles = new RectangleF(cSize.Width - 30, baseHight - 30, 10, 40);
            doubellObstacles = new RectangleF(cSize.Width - 30, baseHight - 10, 10, 20);

            generator = new Random(500);

            rectanglesFs[1] = new RectangleF(cSize.Width - 30, baseHight - 30, 10, 40);

            GenerateObstacelsArry();
        }

        public void MoveObstecals()
        {
          /*  for (int i = 0; i < rectanglesFs.Length; i++)
            {
                if (rectanglesFs[i].X > cSize.Width - 10 )
                {
                    rectanglesFs[i].X += 10;
                }
            }*/
  
            if (rectanglesFs[1].X > cSize.Width - 10)
            {
                rectanglesFs[1].X += -4;
            }
        }
        public void GenerateObstacelsArry()
        {

            rand = generator.Next();

           for (int i = 0; i < rectanglesFs.Length; i++)
            {

                if (rand % 2 == 0)
                {
                    singeOblstacles.X = singeOblstacles.X - (2 * i);
                    rectanglesFs[i] = singeOblstacles;
                }
                else
                {
                    rectanglesFs[i] = doubellObstacles;
                }
            }



        }
        #region Properties
        private RectangleF[] rectanglesFs;

        public RectangleF[] RectangleFs
        {
            get { return rectanglesFs; }
            set { rectanglesFs = value; }
        }

        public SizeF cSize { get; set; }
        #endregion
    }
}