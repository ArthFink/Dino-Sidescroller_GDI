using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dino_Sidescroller
{
    public class Cloud
    {
        Point cloudPoint;
        
        public Cloud()
        {
            cloudPoint = new Point(10, 10);

        }
 

        public Point CloudPoint
        {
            get { return cloudPoint; }
            set { cloudPoint = value; }
        }

    }
}
