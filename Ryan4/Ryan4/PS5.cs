namespace StoreNS;
using System;
using System.Collections.Generic;

public class PS5 : Platform {

    // default constructor
    public PS5() : base(new List<Game> {
        new Game("Call of Duty", 54, 3),
        new Game("Elden Ring", 50, 4),
        new Game("Horizon", 46, 5),
        new Game("Uncharted", 57, 2)
    }) {}

    // copy constructor
    private PS5(PS5 oldPS5) : base(oldPS5) {}

    public override void Introduction() {
        Writeline("Welcome to the PS5 store section!");
    }

    public override void Payment() {
        Writeline("TRANSACTION HANDLING");
        Writeline($"Cost of game: {games[selected].Price}");

        int price = games[selected].Price;
        int total = 0;
        int tens, fives, ones;
        string input;

        do {
            tens = 0;
            fives = 0;
            ones = 0;

            Writeline("Enter the amount of $10 bills: ");
            input = Console.Readline();
            if(!int.TryParse(input, out tens)) {
                tens = 0;
            } 

            Writeline("Enter the amount of $5 bills: ");
            input = Console.Readline();
            if(!int.TryParse(input, out fives)) {
                fives = 0;
            }

            Writeline("Enter the amount of $1 bills: ");
            input = Console.Readline();
            if(!int.TryParse(input, out ones)) {
                ones = 0;
            }

            total += tens*10 + fives*5 + ones;

            if(total < price) {
                Writeline("Total paid is less than amount due. Please continue paying!");
                Writeline($"Amount still owed: ${price - total}");
            }
        } while(total < price);

        Writeline($"Amount paid: ${total}");
        paid = total;
    }
}
