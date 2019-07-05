using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Dino_Sidescroller
{
    public class Game_Logic
    {
        private Charakter charakter;
        private Rectangles rectangles;
    
        private float firstObstical;
        private bool collision;


        public Game_Logic(SizeF clinetSize)
        {
            charakter = new Charakter(clinetSize);
            charakter.CharakterReset();
            rectangles = new Rectangles(clinetSize);
           // graphics_Paint = new Graphics_Paint();
            collision = false;

        }

      

        public void Update()
        {

            CollisionDetectrion();
            ObstacelsMove();
            CharJumpFall();
       
        }

        public void CollisionDetectrion()
        {

           /* firstObstical = rectangles.RectanglesFs.Min(x => x.X);
            RectangleF firstObst = rectangles.RectanglesFs.Find(x => x.X == firstObstical);
            */
            collision = rectangles.Cacti[0].HitBoxRectangle.IntersectsWith(charakter.Rect);

        }

        public void RectangelsGenarate()
        {
            if (!collision)
            {
                rectangles.GenerateObstacelsArry();

            }
        }

        public void ObstacelsMove()
        {
            if (!collision)
            {
                rectangles.MoveObstecals();
            }


        }

        public void CharJumpFall()
        {
            //if (!collision)
            //{
                charakter.CharakterJumpFall();

            //}
        }

        #region Properties


        private RectangleF obstacles;

        public RectangleF Obstacles
        {
            get { return obstacles; }
            set { obstacles = value; }
        }


        public Charakter Charakter
        {
            get { return charakter; }
            set { charakter = value; }
        }



        public Rectangles Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }



        public float LastObstical
        {
            get { return firstObstical; }
            set { firstObstical = value; }
        }

        public bool Collision
        {
            get { return collision; }
            set { collision = value; }
        }
        #endregion

    }
}