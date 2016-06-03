using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author:          Taha Mahmut Yazici
//                  http://tahayazici959.wix.com/main-page
// Date Modified:   03/06/2016
// File:            Program.cs
//                   The main class for the ViagogoEventScenario Application. The 'Random' functioned was used to generate every single detail of every event and it was assigned
//                  at class-level for better randoms when called many times. A very little amount of LINQ has been used to make comparissons in the array the holds the event to
//                  1. Not create another event sharing the same location as another and 2. to not display arrays multiple times at the user's request. The code contains detailed
//                  comments where necessary. For any clarification or questions e-mail: tahayazici95@gmail.com
// 
//                  All Copyrights Reserved
// Version:         1.3.6

namespace ViagogoEventScenario
{
    class Program
    {
        // This will be used to generate random number to used to create the Events. 
        // It is created at class-level so that when this
        //                                  ... method is called many times, it still has
        //                                  ... good Randoms.
        static Random randomNumber = new Random();

        static void Main(string[] args)
        {
            /* ~~~ Declaring Variables ~~~ */


            // The Event code will increase by 1 each time a new Event is created
            int eventCode = 1;

            // The grid ranges from -10 to +10 (Y axis) and -10 to +10 (X axis)
            //  ... that means ~ 21 x 21 = 441 is the max. no. of Events there could be.
            Event[] events = new Event[220];


            /* ~~~ Creating the Events ~~~ */


            // The aim is to get half of the spaces ocuppied by Events.
            while (eventCode <= 220)
            {
                string eventName = "Event " + eventCode;
                
                // For each event a random number of tickets are generated
                int eventNoTickets = randomNumber.Next(0, 10);
                Ticket[] eventTickets = new Ticket[eventNoTickets];

                for (int i = 0; i < eventTickets.Length; i++)
                {
                    // Two randomisers are used to generate a random int and a random double (the mantissa - with 2 decimal placces).
                    //  ... they are then added together.
                    double ticketPrice = randomNumber.Next(1, 100) + Math.Round(randomNumber.NextDouble(), 2);

                    eventTickets[i] = new Ticket(ticketPrice);
                }

                int eventXcoordinate = randomNumber.Next(-10, 11);
                int eventYcoordinate = randomNumber.Next(-10, 11);

                // This will create the 1st event without proceeding to the next 'if' as there aren't any created events yet.
                //  ... Without this, there would be an exception as 'FindLastIndex' wouldn't have any created events to iterate on
                if (eventCode == 1)
                {
                    // Thus, all of the newly created variables are used to create a new Event.
                    events[eventCode - 1] = new Event(eventName, eventTickets, eventXcoordinate, eventYcoordinate);

                    eventCode++;
                }

                // Checking if there already is an Event in the desired location:
                //  ... if the location is empty 'FindIndex' will return '-1'.
                //  extra: Why use 'FindLastIndex' and not 'FindIndex'? Because if we start from the beginning, it will iterate through the whole array and it will reach --
                //         -- a null item and give an error
                //  extra: Why 'eventCode - 2' as the start index? Because: EventCode = last created Event's Index in the array + 2.
                else if (Array.FindLastIndex(events, eventCode - 2, theEvent => theEvent.getXcoordinate() == eventXcoordinate
                                                                             && theEvent.getYcoordinate() == eventYcoordinate) == -1)
                {
                    // Thus, all of the newly created variables are used to create a new Event.
                    events[eventCode - 1] = new Event(eventName, eventTickets, eventXcoordinate, eventYcoordinate);

                    eventCode++;
                }
            }


            /* ~~~ Finding and outputting the 5 nearest Events ~~~ */


            // Reading input from user as the format specified in the email: ex: 4,2.
            string userInput = Console.ReadLine();
            string[] userInputParts = userInput.Split(',');

            // This array will store the closest Events to the user's search that HAVE ALREADY BEEN SHOWN.
            // ... So that the program won't show the same event multiple times.
            Event[] displayedEvents = new Event[0];

            int counter = 0;

            while (counter < 5)
            {
                int userXcoordinate = Convert.ToInt32(userInputParts[0]);
                int userYcoordinate = Convert.ToInt32(userInputParts[1]);

                // For now and for initialisation purposes setting the 'closestEvent' to the 1st Event of the 'events' array;
                // This variable will contain the closest Event that has at least one ticket and hasn't been used before
                Event closestEvent = events[0];

                int closestXcoordinate = closestEvent.getXcoordinate();
                int closestYcoordinate = closestEvent.getYcoordinate();

                int distanceToClosest = Math.Abs(userXcoordinate - closestXcoordinate) + Math.Abs(userYcoordinate - closestYcoordinate);

                foreach (Event theEvent in events)
                {
                    int eventXcoordinate = theEvent.getXcoordinate();
                    int eventYcoordinate = theEvent.getYcoordinate();

                    int distance = Math.Abs(userXcoordinate - eventXcoordinate) + Math.Abs(userYcoordinate - eventYcoordinate);

                    // The 'if' only allows the change of the 'closestEvent' only and only if:
                    // 1. It is closer than the current 'closestEvent' to the user's search.
                    // 2. It contains at least one ticket.
                    // 3. It hasn't been used before.
                    if (distance < distanceToClosest && theEvent.getTickets().Length != 0
                        &&Array.FindIndex(displayedEvents, anEvent => anEvent.getXcoordinate() == eventXcoordinate
                                                                   && anEvent.getYcoordinate() == eventYcoordinate) == -1)
                    {
                        closestEvent = theEvent;
                        distanceToClosest = distance;
                    }
                    
                }

                // Again, for now and for initialisation purposes setting the 'cheapestTicket' to the 1st Ticket of the 'tickets' array of the 'closestEvent';
                Ticket cheapestTicket = closestEvent.getTickets()[0];

                foreach (Ticket theTicket in closestEvent.getTickets())
                    if (theTicket.getPrice() < cheapestTicket.getPrice())
                        cheapestTicket = theTicket;

                // Output the requested information
                Console.WriteLine("{0} - ${1}, Distance {2}", closestEvent.getName(), cheapestTicket.getPrice(), distanceToClosest);

                // Increase the array size of 'displayedEvents' so that the current 'closestEvent' can be inserted, so it won't be used again in the future.
                Array.Resize(ref displayedEvents, counter + 1);
                displayedEvents[counter] = closestEvent;

                counter++;
            }

            Console.ReadLine();
        }
    }
}
