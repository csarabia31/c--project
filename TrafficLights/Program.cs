//
//COP4365-Fall Semester, 2019
//
//Homework #3: The Chatterbox Light System 
//
//This program is designed to make the light colors change depending on the passage of time, removing functionality from main
//
//file name: TrafficLights
//
//By:Camilo Sarabia
//
//

using System;
using System.Threading;
using System.Diagnostics;

namespace TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            //setting north light green and all other lights red
            StopLight north = new StopLight("North", "Green");
            StopLight south = new StopLight("South", "Red");
            StopLight east = new StopLight("East", "Red");
            StopLight west = new StopLight("West", "Red");

            //creating stopwatch object and starting the stopwatch;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts = stopWatch.Elapsed;

            //count that will have the seconds that have gone by
            int timeCount = 0;
            stopWatch.Start();



            //lines to format the output
            Console.WriteLine("Current Time \t North Light \t South Light \t East Light \t West Light");
            Console.WriteLine("------------- \t ------------ \t --------- \t -----------\t ----------");

            //print the system with initial values
            Console.WriteLine(timeCount + "\t\t" + north.getColor() + "\t\t " + south.getColor() + "\t\t " + east.getColor() + "\t\t " + west.getColor());
            north.count++;

            //while time is less than 60 seconds
            while (timeCount <= 60)
            {
                //get the time elapsed
                ts = stopWatch.Elapsed;


                //if one second has gone by
                if (ts.Seconds == 1)
                {
                    //increase count by one 
                    timeCount++;

                    //restart the stopwatch (it will always be between 0 and 1) 
                    //once it is 1 we know that one second has gone by so we increase timeCount by 1
                    //and restart the stopWatch
                    stopWatch.Restart();

                    //if time is between 45 and 50, simulate an emergency vehicle going by
                    if (timeCount >= 40 && timeCount <= 50)
                    {
                        //if time == 40 simulate vehicle coming by, it approaches east light which turns green 
                        //and all other lights go red
                        //east count initialized again because it went green
                        if (timeCount == 40)
                        {
                            east.isApproaching();
                            east.count = 1;
                            north.ApproachedOther();
                            west.ApproachedOther();
                            south.ApproachedOther();

                            Console.WriteLine("There is a emergency vehicle approaching the {0} light", east.getName());
                            Console.WriteLine(timeCount + "\t\t" + north.getColor() + "\t\t" + south.getColor() + "\t\t " + east.getColor() + "\t\t" + west.getColor());

                        }
                        //if time == 50 emergency vehicle left
                        if (timeCount == 50)
                        {
                            Console.WriteLine("The emergency vehicle has left the area ");
                            Console.WriteLine(timeCount + "\t\t" + north.getColor() + "\t\t " + south.getColor() + "\t\t " + east.getColor() + "\t\t " + west.getColor());
                            Console.WriteLine("\n");
                        }
                        //continue so that it doesnt call the functions below
                        continue;
                    }

                    //calling functions and parameters by reference
                    north.northLight(ref north, ref south);
                    south.southLight(ref south, ref east);
                    east.eastLight(ref east, ref west);
                    west.westLight(ref west, ref north);



                    //if any of the lights has changed color, print
                    //if(!string.Equals(north.north2,north.getColor()) || !string.Equals(south.south2, south.getColor()) || !string.Equals(east.east2, east.getColor()) || !string.Equals(west.west2, west.getColor()))
                    if (north.lightChanged == true || west.lightChanged == true || south.lightChanged == true || east.lightChanged == true)
                        Console.WriteLine(timeCount + "\t\t" + north.getColor() + "\t\t " + south.getColor() + "\t\t " + east.getColor() + "\t\t " + west.getColor());

                    north.lightChanged = false;
                    west.lightChanged = false;
                    east.lightChanged = false;
                    south.lightChanged = false;
                }

            }
            //stop the watch after one minute has gone by
            stopWatch.Stop();




        }
    }
}
