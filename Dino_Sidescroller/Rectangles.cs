using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Dino_Sidescroller
{
    public class Rectangles
    {
        int baseHight;
        float lastHighes;
        private int frameCount;
        private List<Cactus> cacti;
        int imgIndex;


        public Rectangles(SizeF cSize)
        {
            cacti = new List<Cactus>();

            baseHight = Convert.ToInt32(cSize.Height / 3) * 2 - 10;
            lastHighes = 0;
            GenerateObstacelsArry();
            Random r = new Random();

            imgIndex = 0;

        }

        public void GenerateObstacelsArry()
        {
            Random generator = new Random();
            //Crating the first Rectangle 
            cacti.Add(new Cactus());



            cacti[0].HitBoxRectangle = new Rectangle(240, baseHight - 29, 13, 40);

            for (int i = 1; i < 10; i++)
            {
                CrateObstical(cacti[i - 1].HitBoxRectangle.X, i);

            }

        }

        public void MoveObstecals()
        {

            lastHighes = cacti.Max(x => x.HitBoxRectangle.X);

            for (int i = 0; i < cacti.Count; i++)
            {
                if (cacti[i].HitBoxRectangle.X > -20)
                {
                    Rectangle temp = cacti[i].HitBoxRectangle;
                    temp.X -= 4 + (frameCount / 500);
                    cacti[i].HitBoxRectangle = temp;

                }

                if (cacti[i].HitBoxRectangle.X < -3)
                {
                    CrateObstical(lastHighes, i);
                    cacti.RemoveAt(i);
                }
            }

        }

        private void CrateObstical(float lastHighes, int i)
        {

            Random generator = new Random();

            int rand = generator.Next(10);
            Thread.Sleep(1);
            int rand2 = generator.Next(0, 44);


            double spaceX = (double)lastHighes + generator.Next(80, 120) * Math.PI + 150;
            cacti.Add(new Cactus());
            bool f = false;

            if (rand % 2 == 0)
            {
                cacti[cacti.Count - 1].HitBoxRectangle = new Rectangle((int)(spaceX), baseHight - 15, 10, 25);
                cacti[cacti.Count - 1].ImgIndex = generator.Next(0, 6);

            }
            else if (rand % 2 != 0)
            {

                if (rand2 == 33 || rand == 1)
                {
                    cacti[cacti.Count - 1].HitBoxRectangle = new Rectangle((int)(spaceX), baseHight - 30, 37, 39);
                    cacti[cacti.Count - 1].ImgIndex = 0;
                }
                else
                {
                    cacti[cacti.Count - 1].HitBoxRectangle = new Rectangle((int)(spaceX), baseHight - 29, 13, 40);
                    cacti[cacti.Count - 1].ImgIndex = generator.Next(0, 3);
                }
            }

            Thread.Sleep(1);
        }


        #region Properties

        public List<Cactus> Cacti
        {
            get { return cacti; }
            set { cacti = value; }
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