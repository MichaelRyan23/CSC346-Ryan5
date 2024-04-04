using System.Collections.Generic;
using System;
namespace StoreNS;

public class Switch : Platform {

    // default constructor
    public Switch() : base(new List<Game> {
        new Game("Animal Crossing", 46, 3),
        new Game("Link's Awakening", 50, 5),
        new Game("Pokemon Legends", 57, 1)
    }) {}

    // copy constructor
    private Switch(Switch oldSwitch) : base(oldSwitch) {}

    public override void Introduction() {
        WriteLine("\nWelcome to the Nintendo Switch store section!");
    }

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