/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSc 346
*** ASSIGNMENT :    4
*** DUE DATE :      4/5/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : Implements through the platform class specifically
*** for PS5. It defines the game selections, has a custom introduction
*** and payment option through inheritence and polymorphism.
********************************************************************/
using System.Collections.Generic;
using System;
namespace StoreNS;

public class PS5 : Platform {

/********************************************************************
*** METHOD Constructor
*********************************************************************
*** DESCRIPTION : Initializes PS5 platform instance with a list of PS5
*** games with pre-determined Names, price, and units. 
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :  
*** RETURN : N/A 
********************************************************************/
    public PS5() : base(new List<Game> {
        new Game("Call of Duty", 54, 3),
        new Game("Elden Ring", 50, 4),
        new Game("Horizon", 46, 5),
        new Game("Uncharted", 57, 2)
    }) {}

/********************************************************************
*** METHOD Copy constructor
*********************************************************************
*** DESCRIPTION : Creates a copy of an existing PS5 platform instance
*** INPUT ARGS : <oldPS5
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    private PS5(PS5 oldPS5) : base(oldPS5) {}

/********************************************************************
*** METHOD Introduction
*********************************************************************
*** DESCRIPTION : Displays a welcome message specific to the PS5 platform.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :  
*** RETURN : N/A
********************************************************************/
    public override void Introduction() {
        WriteLine("\nWelcome to the PS5 store section!");
    }

/********************************************************************
*** METHOD Payment
*********************************************************************
*** DESCRIPTION : Overrides the payment process from Platform into custom
*** behavior, only aceptings 10's, 5's, and 1's, and finally calculate the
*** total from that.
*** INPUT ARGS : 
*** OUTPUT ARGS :
*** IN/OUT ARGS : 
*** RETURN : N/A
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
            if(!int.TryParse(input, out tens) || tens < 0) {
                WriteLine("\nInvalid entry!\n");
                tens = 0;
            } 

            WriteLine("Enter the amount of $5 bills: ");
            input = Console.ReadLine();
            if(!int.TryParse(input, out fives) || fives < 0) {
                WriteLine("\nInvalid entry!\n");
                fives = 0;
            }

            WriteLine("Enter the amount of $1 bills: ");
            input = Console.ReadLine();
            if(!int.TryParse(input, out ones) || ones < 0) {
                WriteLine("\nInvalid entry!\n");
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
