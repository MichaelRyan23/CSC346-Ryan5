/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSc 346
*** ASSIGNMENT :    4
*** DUE DATE :      4/5/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : This file defines the game class that is used throughout
*** the StoreNS namespace, consisting of a name, price, and amount of units.
*** Also includes a constructor for creating a new instance and copying an
*** existing one.
********************************************************************/
using System;
using System.Collections.Generic;
namespace StoreNS;

public class Game {

    public string Name { get; set; }
    public int Price { get; set; }
    public int Units { get; set; }

/********************************************************************
*** METHOD Constructor
*********************************************************************
*** DESCRIPTION : Initializes a new game instance with default values.
*** INPUT ARGS : name, price, and units
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A 
********************************************************************/
    public Game(string name = "", int price = 0, int units = 0) {
        Name = name;
        Price = price;
        Units = units;
    }

/********************************************************************
*** METHOD Copy constructor
*********************************************************************
*** DESCRIPTION : Creates a copy of a game instance using an existing instance 
*** INPUT ARGS : oldGame 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    public Game(Game oldGame) {
        Name = oldGame.Name;
        Price = oldGame.Price;
        Units = oldGame.Units;
    }

}