/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSc 346
*** ASSIGNMENT :    4
*** DUE DATE :      4/5/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : <detailed English description of the current assignment>
********************************************************************/
using System.Collections.Generic;
using System;
namespace StoreNS;

public class PS5 : Platform {

/********************************************************************
*** METHOD <name of method> 
*********************************************************************
*** DESCRIPTION : <detailed English description of the method> 
*** INPUT ARGS : <list of all input parameter names> 
*** OUTPUT ARGS : <list of all output parameter names> 
*** IN/OUT ARGS : <list of all input/output parameter names> 
*** RETURN : <return type and return value name> 
********************************************************************/
    public PS5() : base(new List<Game> {
        new Game("Call of Duty", 54, 3),
        new Game("Elden Ring", 50, 4),
        new Game("Horizon", 46, 5),
        new Game("Uncharted", 57, 2)
    }) {}

/********************************************************************
*** METHOD <name of method> 
*********************************************************************
*** DESCRIPTION : <detailed English description of the method> 
*** INPUT ARGS : <list of all input parameter names> 
*** OUTPUT ARGS : <list of all output parameter names> 
*** IN/OUT ARGS : <list of all input/output parameter names> 
*** RETURN : <return type and return value name> 
********************************************************************/
    private PS5(PS5 oldPS5) : base(oldPS5) {}

/********************************************************************
*** METHOD <name of method> 
*********************************************************************
*** DESCRIPTION : <detailed English description of the method> 
*** INPUT ARGS : <list of all input parameter names> 
*** OUTPUT ARGS : <list of all output parameter names> 
*** IN/OUT ARGS : <list of all input/output parameter names> 
*** RETURN : <return type and return value name> 
********************************************************************/
    public override void Introduction() {
        WriteLine("\nWelcome to the PS5 store section!");
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
    protected override void Payment() {
        WriteLine("\n*******TRANSACTION HANDLING*******");
        WriteLine("Cost of game: ${0}\n", games[selected].Price);

        int price = games[selected].Price;
        int total = 0;
        int tens, fives, ones;
        string? input;

        do {
            tens = 0;
            fives = 0;
            ones = 0;

            WriteLine("Enter the amount of $10 bills: ");
            input = Console.ReadLine();
            if(!int.TryParse(input, out tens)) {
                tens = 0;
            } 

            WriteLine("Enter the amount of $5 bills: ");
            input = Console.ReadLine();
            if(!int.TryParse(input, out fives)) {
                fives = 0;
            }

            WriteLine("Enter the amount of $1 bills: ");
            input = Console.ReadLine();
            if(!int.TryParse(input, out ones)) {
                ones = 0;
            }

            total += tens*10 + fives*5 + ones;

            if(total < price) {
                WriteLine("Total paid is less than amount due. Please continue paying!");
                WriteLine($"Amount still owed: ${price - total}");
            }
        } while(total < price);

        WriteLine($"Amount paid: ${total}");
        paid = total;
    }
}
