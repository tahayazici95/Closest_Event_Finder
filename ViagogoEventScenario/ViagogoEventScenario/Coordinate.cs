using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author:          Taha Mahmut Yazici
//                  http://tahayazici959.wix.com/main-page
// Date Modified:   03/06/2016
// File:            Coordinate.cs
//                   The class contains the X and Y coordinates for events.
// 
//                  All Copyrights Reserved
// Version:         1.3.6

namespace ViagogoEventScenario
{
    class Coordinate
    {
        int x, y;

        public Coordinate ()
        { }

        public Coordinate (int newX, int newY)
        {
            this.x = newX;
            this.y = newY;
        }

        public void setX (int newX)
        {
            this.x = newX;
        }

        public int getX()
        {
            return x;
        }

        public void setY (int newY)
        {
            this.y = newY;
        }

        public int getY ()
        {
            return y;
        }
    }
}
