using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public class Rectangles
    {
        int baseHight;
        float lastHighes;
        private int frameCount;
        int ajustSpacing;


        public Rectangles(SizeF cSize)
        {

            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 10;
            rectanglesFs = new List<RectangleF>();
            lastHighes = 0;
            ajustSpacing = 0;
            GenerateObstacelsArry();

        }

        public void GenerateObstacelsArry()
        {
            Random generator = new Random();
            //Crating the first Rectangle 
            rectanglesFs.Add(new RectangleF(140, baseHight - 40, 25, 50));

            for (int i = 1; i < 10; i++)
            {
                CrateObstical(i, rectanglesFs[i - 1].X);
            }

        }

        public void MoveObstecals()
        {

            lastHighes = rectanglesFs.Max(x => x.X);

            for (int i = 0; i < rectanglesFs.Count; i++)
            {
                if (rectanglesFs[i].X > -10)
                {
                    RectangleF temp = rectanglesFs[i];
                    temp.X -= 4 + (frameCount / 500);
                    rectanglesFs[i] = temp;

                }

                if (rectanglesFs[i].X < -3)
                {
                    CrateObstical(i, lastHighes);
                    rectanglesFs.RemoveAt(i);
                }
            }

        }

        private void CrateObstical(int i, float lastHighes)
        {

            Random generator = new Random();
            int rand = generator.Next(10);
            int rand2 = generator.Next(0, 44);

            double spaceX = (double)lastHighes + generator.Next(70, 90) * Math.PI +100;

            if (rand % 2 == 0)
            {
                rectanglesFs.Add(new RectangleF((int)(spaceX), baseHight - 15, 17, 25));
            }
            else if (rand % 2 != 0)
            {
                rectanglesFs.Add(new RectangleF((int)(spaceX), baseHight - 40, 25, 50));
            }
            if (i == rand2 || rand2 == 33 || rand == rand2 || rand2  == 18)
            {
                rectanglesFs.Add(new RectangleF((int)(spaceX), baseHight - 45, 50, 55));
            }
        }



        #region Properties


        private List<RectangleF> rectanglesFs;

        public List<RectangleF> RectanglesFs
        {
            get { return rectanglesFs; }
            set { rectanglesFs = value; }
        }



        public int FrameCount
        {
            get { return frameCount; }
            set { frameCount = value; }
        }


        public SizeF cSize { get; set; }
        #endregion
    }
}