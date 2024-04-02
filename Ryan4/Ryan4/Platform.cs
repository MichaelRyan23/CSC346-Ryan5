namespace StoreNS;
using System;
using System.Collections.Generic;

public abstract class Platform : IPlatform {

    protected List<Game> games;     // '#' in UML diagram means 'protected'
    protected int selected;
    protected int paid;

    // default constructor
    protected Platform(List<Game> gamesList, int selected = -1, int paid = 0) {
        games = gamesList;
        selected = selected;
        paid = paid;
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
            Payment();
            Change();
            Deliver();

            //Writeline("Would you like to continue shopping? (yes/no)");
            //string userChoice = Console.Readline();
            //isRunning = userChoice?.ToLower() == "yes"; // true if userChoice = 'yes', false otherwise
        }
    }

    public virtual void Introduction() {
        Writeline("Welcome to the Gaming store!");
    }

    protected void Selection() {

        Writeline("Games in stock\n");
    
        int i = 1;
        foreach(var game in games) {
            Writeline($"{i}: {game.Name}\t${game.Price}\t{game.Units} units available");
            i++;
        }
        
        do {
            Writeline("Enter the number of the game you wish to purchase!");
            string input = Console.Readline();

            try {
                int uChoice = int.Parse(input);
                uChoice -= 1;   // 0 based indexing

                if(uChoice >= 0 && uChoice < games.Count) { // games.Count returns number of 'Game' objects in the List

                    var gameChoice = games[uChoice];    // VAR IS GENERAL. Stack overflow source

                    if(gameChoice.Units > 0) {
                        gameChoice.Units--;
                        selected = uChoice;
                        break;  // exiting the loop when an appropriate value is selected
                    }
                    else {
                        Writeline("Game is out of stock! Please select a different game.");
                    }
                }
                else {
                    Writeline("Invalid selection, please select again.");
                }
            }
            catch(FormatException) {
                Writeline("Invalid input. Please enter an integer value.");
            }

        } while(true);  // loop continues until appropriate seleciton
    }

    protected virtual void Payment() {

        Writeline("TRANSACTION HANDLING");
        Writeline($"Cost of game: {games[selected].Price}");

        int price = games[selected].Price;
        int total = 0;
        int twenties;
        int tens;
        string input;

        do {
            twenties = 0;
            tens = 0;

            Writeline("Enter the amount of $20 bills: ");

            input = Console.Readline();
            if(!int.TryParse(input, out twenties)) {        // stack overflow
                twenties = 0;   // ONLY if invalid input
            }

            Writeline("Enter the amount of $10 bills: ");
            input = Console.Readline();
            if(!int.TryParse(input, out tens)) {
                tens = 0;
            }
    
            total += twenties*20 + tens*10;

            if(total < price) {
                Writeline("Total paid is less than amount due. Please continue paying!");
                Writeline($"Amount still owed: ${price - total}");
            }
            
        } while (total < price);

        Writeline($"Amount paid: ${total}");
        paid = total;
    }

    protected virtual void Change() {

        int change = paid - games[selected].Price;
        int tens;
        int ones;

        if(change > 0) {

            tens = change / 10;
            ones = change % 10;

            Writeline($"Change due: ${change}");
            Writeline($"$10 bills:    {tens}");
            Writeline($"$1 bills:     {ones}");
        }
        else {
            Writeline("No change is needed!");
        }
    }

    protected void Deliver() {
        Writeline($"Your {games[selected].Name} game has been successfully purchased, and is currently being delivered!");
        Writeline("Thank you for shopping with us!");
    }
}
