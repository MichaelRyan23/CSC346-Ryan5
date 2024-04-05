/********************************************************************
*** NAME :          Michael Ryan
*** CLASS :         CSc 346
*** ASSIGNMENT :    4
*** DUE DATE :      4/5/2024
*** INSTRUCTOR :    GAMRADT 
*********************************************************************
*** DESCRIPTION : This file defines the platform class, and serves as a 
*** base class for PS5 and Switch. It defines the methods Start, game selection,
*** payment, change, and delivery of the game.
********************************************************************/
using System;
using System.Collections.Generic;
namespace StoreNS;

public abstract class Platform : IPlatform {

    protected List<Game> games;     // '#' in UML diagram means 'protected'
    protected int selected;
    protected int paid;

/********************************************************************
*** METHOD Default/overloaded/parameterized constructor
*********************************************************************
*** DESCRIPTION : Initializes the platform with a list of games respective
*** to either PS5 or switch, depending on how it is defined in program.cs
*** INPUT ARGS : gamesList
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    protected Platform(List<Game> gamesList) {
        this.games = gamesList ?? new List<Game>();
    }

/********************************************************************
*** METHOD copy constructor
*********************************************************************
*** DESCRIPTION : Creates a new platform copy using already existing
*** instance
*** INPUT ARGS : oldPlatform
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    protected Platform(Platform oldPlatform) {
        games = new List<Game>(oldPlatform.games);
        selected = oldPlatform.selected;
        paid = oldPlatform.paid;
    }

/********************************************************************
*** METHOD Start
*********************************************************************
*** DESCRIPTION : Manages the flow of the program
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A 
********************************************************************/
    public void Start() {

        bool isRunning = true;      
        while(isRunning) {
            Introduction();
            Selection();

            if(selected == -1) {
                WriteLine("\nExiting shopping screen, returning to main menu.");
                break;
            }

            Payment();
            Change();
            Deliver();

        }
    }

/********************************************************************
*** METHOD Introduction
*********************************************************************
*** DESCRIPTION : Provides an introduction message corresponding to the
*** respective instance that was created (PS5 or Switch)
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :  
*** RETURN : N/A
********************************************************************/
    public abstract void Introduction();

/********************************************************************
*** METHOD Selection
*********************************************************************
*** DESCRIPTION : Lets the user select an available game, or quit to 
*** the main menu
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :  
*** RETURN : N/A
********************************************************************/
    protected void Selection() {
    
        WriteLine("\nHere is the list of Available games:\n");
        WriteLine("{0, -4} {1, -25} {2, 10} {3, 18}", "#", "Name", "Price", "Units Available");
        int i = 1;
        foreach(var game in games) {
            WriteLine("{0, -4} {1, -25} ${2, 8:N2} {3, 18}", i + ":", game.Name, game.Price, game.Units);
            i++;
        }
        WriteLine($"{i}: QUIT SHOPPING");
        
        do {
            WriteLine($"\nEnter the number of the game you wish to purchase, or {i} to quit shopping!");
            string? input = Console.ReadLine();

            try {

                if(!int.TryParse(input, out int uChoice)) {
                    WriteLine("\nInvalid input. Please enter an integer value.\n");
                    continue;
                }

                if(uChoice == i) {
                    selected = -1;
                    break;
                }

                uChoice -= 1;   // 0 based indexing

                if(uChoice >= 0 && uChoice < games.Count) { // games.Count returns number of 'Game' objects in the List

                    var gameChoice = games[uChoice];    // VAR IS GENERAL. Stack overflow source

                    if(gameChoice.Units > 0) {
                        gameChoice.Units--;
                        selected = uChoice;
                        break;  // exiting the loop when an appropriate value is selected
                    }
                    else {
                        WriteLine("Game is out of stock! Please select a different game.");
                        //WriteLine("Or you can exit the shop (yes/no)");

                    }
                }
                else {
                    WriteLine("\nInvalid selection, please select again.");
                }
            }
            catch(FormatException) {
                WriteLine("Invalid input. Please enter an integer value.");
            }

        } while(true);  // loop continues until appropriate seleciton
    }

/********************************************************************
*** METHOD Payment
*********************************************************************
*** DESCRIPTION : Processes and handles payment for selected game. Can
*** only take in twenties and 10's!
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    protected virtual void Payment() {

        WriteLine("\n*******TRANSACTION HANDLING*******");
        WriteLine("Cost of game: ${0}\n", games[selected].Price);

        int price = games[selected].Price;
        int total = 0;
        int twenties;
        int tens;
        string? input;

        do {
            twenties = 0;
            tens = 0;
            WriteLine("Enter the amount of $20 bills: ");

            input = Console.ReadLine();
            if(!int.TryParse(input, out twenties) || twenties < 0) {        // stack overflow
                WriteLine("\nInvalid entry!\n");
                twenties = 0;   // ONLY if invalid input
            }

            WriteLine("Enter the amount of $10 bills: ");
            input = Console.ReadLine();
            if(!int.TryParse(input, out tens) || tens < 0) {
                WriteLine("\nInvalid entry!\n");
                tens = 0;
            }
    
            total += twenties*20 + tens*10;

            if(total < price) {
                WriteLine("Total paid is less than amount due. Please continue paying!");
                WriteLine($"Amount still owed: ${price - total}");
            }
            
        } while (total < price);

        WriteLine($"Amount paid: ${total}");
        paid = total;
    }

/********************************************************************
*** METHOD Change 
*********************************************************************
*** DESCRIPTION : Calculates change in 10's and 1's, and returns them to the user 
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :  
*** RETURN : N/A
********************************************************************/
    protected virtual void Change() {

        int change = paid - games[selected].Price;
        int tens;
        int ones;

        if(change > 0) {

            tens = change / 10;
            ones = change % 10;

            WriteLine($"Change due: ${change}");
            WriteLine($"$10 bills:    {tens}");
            WriteLine($"$1 bills:     {ones}");
        }
        else {
            tens = 0;
            ones = 0;
            WriteLine($"Change due: ${change}");
            WriteLine($"$10 bills:    {tens}");
            WriteLine($"$1 bills:     {ones}");
            WriteLine("No change is needed!");
        }
    }

/********************************************************************
*** METHOD Deliver
*********************************************************************
*** DESCRIPTION : Sends a nice lil message saying that the purchase was
*** successfull, and that the delivery is being completed.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :  
*** RETURN : N/A 
********************************************************************/
    protected void Deliver() {

        WriteLine($"Your {games[selected].Name} game has been successfully purchased, and is currently being delivered!");
        WriteLine("Thank you for shopping with us!");
    }
}
