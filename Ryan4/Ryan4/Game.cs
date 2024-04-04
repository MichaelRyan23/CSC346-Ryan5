/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSc 346
*** ASSIGNMENT :    4
*** DUE DATE :      4/5/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : <detailed English description of the current assignment>
********************************************************************/
using System;
using System.Collections.Generic;
namespace StoreNS;

public class Game {

    public string Name { get; set; }
    public int Price { get; set; }
    public int Units { get; set; }

/********************************************************************
*** METHOD <name of method> 
*********************************************************************
*** DESCRIPTION : <detailed English description of the method> 
*** INPUT ARGS : <list of all input parameter names> 
*** OUTPUT ARGS : <list of all output parameter names> 
*** IN/OUT ARGS : <list of all input/output parameter names> 
*** RETURN : <return type and return value name> 
********************************************************************/
    public Game(string name = "", int price = 0, int units = 0) {
        Name = name;
        Price = price;
        Units = units;
    }

/********************************************************************
*** METHOD <name of method> 
*********************************************************************
*** DESCRIPTION : <detailed English description of the method> 
*** INPUT ARGS : <list of all input parameter names> 
*** OUTPUT ARGS : <list of all output parameter names> 
*** IN/OUT ARGS : <list of all input/output parameter names> 
*** RETURN : <return type and return value name> 
********************************************************************/
    public Game(Game oldGame) {
        Name = oldGame.Name;
        Price = oldGame.Price;
        Units = oldGame.Units;
    }

}