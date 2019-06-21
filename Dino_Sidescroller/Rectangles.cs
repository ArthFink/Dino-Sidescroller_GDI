using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public class Rectangles : Obstacles
    {
        int baseHight;       

        public Rectangles(SizeF cSize)
        {
            rectanglesFs = new RectangleF[150];
            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 10;

            GenerateObstacelsArry();
        }

        public void MoveObstecals()
        {
            Random generator = new Random();

            float lastHighes = 0;



            for (int i = 0; i < rectanglesFs.Length; i++)
            {

                if (lastHighes < rectanglesFs[i].X)
                {
                    lastHighes = rectanglesFs[i].X;
                }

            }

            for (int i = 0; i < rectanglesFs.Length; i++)
            {
                int rand = generator.Next(10);

                if (rectanglesFs[i].X > cSize.Width - 10)
                {
                    rectanglesFs[i].X += -4;
                }

                if (rectanglesFs[i].X < -10)
                {                 

                    int rand2 = generator.Next(10, 44);
                    double spaceX = generator.Next(40, 90) * Math.PI + (double)lastHighes;

                    if (rand % 2 == 0)
                    {
                        rectanglesFs[i] = new RectangleF((int)(spaceX), baseHight - 30, 10, 40);
                    }
                    else if (rand % 2 != 0)
                    {
                        rectanglesFs[i] = new RectangleF((int)(spaceX), baseHight - 10, 10, 20);
                    }
                    if (i == rand2)
                    {
                        rectanglesFs[i] = new RectangleF((int)(spaceX), baseHight - 30, 20, 20);
                    }

                }

            }

        }


        public void GenerateObstacelsArry()
        {
            Random generator = new Random();

            rectanglesFs[0] = new RectangleF(150, baseHight - 30, 10, 40);

            for (int i = 1; i < rectanglesFs.Length; i++)
            {

                int rand = generator.Next(10);
                int rand2 = generator.Next(10, 44);
                double spaceX = generator.Next(40, 90) * Math.PI + rectanglesFs[i - 1].X;

                if (rand % 2 == 0)
                {
                    rectanglesFs[i] = new RectangleF((int)(spaceX), baseHight - 30, 10, 40);
                }
                else if (rand % 2 != 0)
                {
                    rectanglesFs[i] = new RectangleF((int)(spaceX), baseHight - 10, 10, 20);
                }
                if (i == rand2 || rand2 == 33)
                {
                    rectanglesFs[i] = new RectangleF((int)(spaceX), baseHight - 30, 20, 20);
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