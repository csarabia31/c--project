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
using System.Diagnostics;


public class StopLight
{


    private string name;
    private string color;


    public bool lightChanged = false;
    //count that will have the seconds that have gone by
    public int count = 0;

    //strings to see if color changed
    public string west2, north2, south2, east2;

    // TODO: Add constructor logic here
    //

    //Method name: TrafficLight
    //Method description: This is the default constructor with no parameters, when the object is created it will create it 
    //with the following name and color
    public StopLight()
    {
        this.name = "";
        this.color = "";
    }
    //Method name: TrafficLight
    //Method description: constructoe with parameters, it will set name and color to whatever arguments it gets as parameters
    public StopLight(String _name, String _color)
    {
        this.name = _name;
        this.color = _color;
    }

    //Method name: setName
    //Method description: it will set the objects name to the argument that is passed to it
    public void setName(String _name)
    {
        this.name = _name;
    }

    //Method name: getName
    //Method description: this method will return the name of the current object
    public String getName()
    {
        return name;
    }

    //Method name: setGreen
    //Method description: this method will set the objects color to green
    public void setGreen()
    {
        this.color = "Green";
    }

    //Method name: setRed
    //Method description: this method will set the objects color to red
    public void setRed()
    {
        this.color = "Red";
    }

    // // Method Name: setYellow 
    // Description: this method will set the objects color to red
    public void setYellow()
    {
        this.color = "Yellow";
    }

    //Method name: getColor
    //Method description: this method will return the color of the current object being used
    public String getColor()
    {
        return color;
    }

    //Method name: timer
    //Method description: this method gets an integer and changes the Lights color depending on how much time passes
    public void timer(int sw)
    {

        if (String.Equals(this.color, "Green") && sw != 0 && sw % 9 == 0)
        {
            setYellow();

        }
        else if (String.Equals(this.color, "Yellow") && sw != 0 && sw % 3 == 0)
            setRed();

    }

    //Method name: isApproaching
    //Method description: If the emergency vehicle is approaching this light, turn it green
    public void isApproaching()
    {

        this.color = "Green";

    }
    //Method name: ApproachedOther
    //Method description: When the emergency vehicle approachs another light, turn it red
    public void ApproachedOther()
    {
        this.color = "Red";
    }


    //Method name: northLigth
    //Method description: functionality from north light
    public void northLight(ref StopLight north, ref StopLight south)
    {
        //get norths color before calling function
        north2 = north.getColor();
        north.timer(north.count);

        //check to see if color has changed
        if (string.Equals(north2, "Green") && string.Equals("Yellow", north.getColor()))
            north.lightChanged = true;

        //light changed
        if (string.Equals(north2, "Yellow") && string.Equals("Red", north.getColor()))
        {
            north.lightChanged = true;
            count = 0;

        }

        //increase count if ligth is green or yellow
        if (string.Equals("Green", north.getColor()) || string.Equals("Yellow", north.getColor()))
            count++;

        if (count == 7)
        {
            south.setGreen();
            south.lightChanged = true;
            south.count = 0;
        }

    }

    //Method name: southLigth
    //Method description: functionality from south light
    public void southLight(ref StopLight south, ref StopLight east)
    {
        //get souths color
        south2 = south.getColor();
        south.timer(south.count);


        //check to see if color changed
        if (string.Equals(south2, "Green") && string.Equals("Yellow", south.getColor()))
            south.lightChanged = true;

        //if south is red set east to green
        if (string.Equals(south2, "Yellow") && string.Equals("Red", south.getColor()))
        {
            south.count = 0;
            east.setGreen();
            south.lightChanged = true;
            east.count = 0;

        }

        //increase count if south is green or yellow
        if (string.Equals("Green", south.getColor()) || string.Equals("Yellow", south.getColor()))
            south.count++;



    }


    //Method name: eastLigth
    //Method description: functionality from east light
    public void eastLight(ref StopLight east, ref StopLight west)
    {
        //get easts color
        east2 = east.getColor();
        east.timer(east.count);


        //check to see if color changed
        if (string.Equals(east2, "Green") && string.Equals("Yellow", east.getColor()))
            east.lightChanged = true;


        if (string.Equals(east2, "Yellow") && string.Equals("Red", east.getColor()))
        {
            east.lightChanged = true;
            east.count = 0;

        }
        //increase east count if green or yellow
        if (string.Equals("Green", east.getColor()) || string.Equals("Yellow", east.getColor()))
            east.count++;

        //set west to green
        if (east.count == 7)
        {
            west.setGreen();
            west.lightChanged = true;
            west.count = 0;
        }

    }

    //Method name: westLigth
    //Method description: functionality from west light
    public void westLight(ref StopLight west, ref StopLight north)
    {

        //get west color
        west2 = west.getColor();
        west.timer(west.count);

        //check if color changed
        if (string.Equals(west2, "Green") && string.Equals("Yellow", west.getColor()))
            west.lightChanged = true;

        //west changed to red set north to green
        if (string.Equals(west2, "Yellow") && string.Equals("Red", west.getColor()))
        {
            west.count = 0;
            north.setGreen();
            west.lightChanged = true;
            north.count = 0;
        }

        //increase count if green or yellow
        if (string.Equals("Green", west.getColor()) || string.Equals("Yellow", west.getColor()))
            west.count++;



    }




}
