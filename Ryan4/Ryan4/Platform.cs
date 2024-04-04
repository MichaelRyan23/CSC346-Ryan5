using System;
using System.Collections.Generic;
namespace StoreNS;

public abstract class Platform : IPlatform {

    protected List<Game> games;     // '#' in UML diagram means 'protected'
    protected int selected;
    protected int paid;

    // default constructor
    protected Platform(List<Game> gamesList) {
        this.games = gamesList ?? new List<Game>();
    }

    // copy constructor
    protected Platform(Platform oldPlatform) {
        games = new List<Game>(oldPlatform.games);
        selected = oldPlatform.selected;
        paid = oldPlatform.paid;
    }

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

            //WriteLine("Would you like to continue shopping? (yes/no)");
            //string userChoice = Console.ReadLine();
            //isRunning = userChoice?.ToLower() == "yes"; // true if userChoice = 'yes', false otherwise
        }
    }

    public abstract void Introduction();

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
            string input = Console.ReadLine();

            try {
                int uChoice = int.Parse(input);

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

    protected virtual void Payment() {

        WriteLine("\n*******TRANSACTION HANDLING*******");
        WriteLine("Cost of game: ${0}\n", games[selected].Price);

        int price = games[selected].Price;
        int total = 0;
        int twenties;
        int tens;
        string input;

        do {
            twenties = 0;
            tens = 0;
            WriteLine("Enter the amount of $20 bills: ");

            input = Console.ReadLine();
            if(!int.TryParse(input, out twenties)) {        // stack overflow
                twenties = 0;   // ONLY if invalid input
            }

            WriteLine("Enter the amount of $10 bills: ");
            input = Console.ReadLine();
            if(!int.TryParse(input, out tens)) {
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

    protected void Deliver() {

        WriteLine($"Your {games[selected].Name} game has been successfully purchased, and is currently being delivered!");
        WriteLine("Thank you for shopping with us!");
    }
}
