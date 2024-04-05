/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSc 346
*** ASSIGNMENT :    4
*** DUE DATE :      4/5/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : Implements through the platform class specifically
*** for Switch. It defines the game selections, has a custom introduction
*** and change option through inheritence and polymorphism.
********************************************************************/
using System.Collections.Generic;
using System;
namespace StoreNS;

public class Switch : Platform {

/********************************************************************
*** METHOD Constructor
*********************************************************************
*** DESCRIPTION : Initializes Switch platform instance with a list of Switch
*** games with pre-determined Names, price, and units.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A 
********************************************************************/
    public Switch() : base(new List<Game> {
        new Game("Animal Crossing", 46, 3),
        new Game("Link's Awakening", 50, 5),
        new Game("Pokemon Legends", 57, 1)
    }) {}

/********************************************************************
*** METHOD Copy constructor
*********************************************************************
*** DESCRIPTION : Creates a copy of an existing Switch platform instance 
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    private Switch(Switch oldSwitch) : base(oldSwitch) {}

/********************************************************************
*** METHOD Introduction
*********************************************************************
*** DESCRIPTION : Displays a welcome message specific to the Switch platform. 
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    public override void Introduction() {
        WriteLine("\nWelcome to the Nintendo Switch store section!");
    }

/********************************************************************
*** METHOD Change 
*********************************************************************
*** DESCRIPTION : Calculates and provides change using numbers
*** specific to the Switch's change implementation (5's, 2's, 1's). Overrides
*** platform method.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    protected override void Change() {
        
        int change = paid - games[selected].Price;
        int fives, twos, ones;

        if(change > 0) {
            fives = change / 5;
            change %= 5;

            twos = change / 2;
            change %= 2;

            ones = change;

            WriteLine($"Change due: ${paid - games[selected].Price}");
            WriteLine($"$5 bills:    {fives}");
            WriteLine($"$2 bills:    {twos}");
            WriteLine($"$1 bills:     {ones}");
        }
        else {
            fives = 0;
            twos = 0;
            ones = 0;
            WriteLine($"Change due: ${paid - games[selected].Price}");
            WriteLine($"$5 bills:    {fives}");
            WriteLine($"$2 bills:    {twos}");
            WriteLine($"$1 bills:     {ones}");
        }
        
    }
}