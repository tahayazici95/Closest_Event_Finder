using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author:          Taha Mahmut Yazici
//                  http://tahayazici959.wix.com/main-page
// Date Modified:   03/06/2016
// File:            Event.cs
//                   The class that contains the events themselves.
// 
//                  All Copyrights Reserved
// Version:         1.3.6

namespace ViagogoEventScenario
{
    class Event
    {
        string name;

        Ticket[] tickets;

        Coordinate coordinate = new Coordinate();

        public Event ()
        { }

        public Event (string newName, Ticket[] newTickets, int xCoordinate, int yCoordinate)
        {
            this.name = newName;

            this.tickets = newTickets;

            coordinate.setX(xCoordinate);
            coordinate.setY(yCoordinate);
        }

        public string getName ()
        {
            return name;
        }

        public int getXcoordinate ()
        {
            return coordinate.getX();
        }

        public int getYcoordinate ()
        {
            return coordinate.getY();
        }

        public Ticket[] getTickets ()
        {
            return tickets;
        }
    }
}
