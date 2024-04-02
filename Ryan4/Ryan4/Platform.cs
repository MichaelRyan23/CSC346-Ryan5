namespace StoreNS;
using System;
using System.Collections.Generic;

public abstract class Platform : IPlatform {

    protected List<Game> games;     // '#' in UML diagram means 'protected'
    protected int selected;
    protected int paid;

    // default constructor
    protected Platform(List<Game> gamesList, int selected = -1, int paid = 0) {
        this.games = gamesList;
        this.selected = selected;
        this.paid = paid;
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

            Writeline("Would you like to continue shopping? (yes/no)");
            string userChoice = Console.ReadLine();
            isRunning = userChoice?.ToLower() == "yes"; // true if userChoice = 'yes', false otherwise
        }
    }

    public virtual void Introduction() {
        Writeline("Welcome to the Gaming store!");
    }

    protected void Selection() {

        int i = 1;
        foreach(var game in games) {
            Writeline($"{i}: {game.Name}\t${game.Price}\t{game.Units} units available");
            i++;
        }
        
        do {
            Writeline("Enter the number of the game you wish to purchase!");
            string input = Console.ReadLine();

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

    }

    protected virtual void Change() {

    }

    protected void Deliver() {
        
    }
}
