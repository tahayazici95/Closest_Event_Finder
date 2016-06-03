using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author:          Taha Mahmut Yazici
//                  http://tahayazici959.wix.com/main-page
// Date Modified:   03/06/2016
// File:            Coordinate.cs
//                   The class that ccontains the tickets for events.
// 
//                  All Copyrights Reserved
// Version:         1.3.6

namespace ViagogoEventScenario
{
    class Ticket
    {
        double price;

        public Ticket ()
        { }

        public Ticket (double newPrice)
        {
            this.price = newPrice;
        }

        public void setPrice (double newPrice)
        {
            this.price = newPrice;
        }

        public double getPrice ()
        {
            return price;
        }
    }
}
