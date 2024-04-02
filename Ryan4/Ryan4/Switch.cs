namespace StoreNS;
using System;
using System.Collections.Generic;

public class Switch : Platform {

    // default constructor
    public Switch() : base(new List<Game> {
        new Game("Animal Crossing", 46, 3),
        new Game("Link's Awakening", 50, 5),
        new Game("Pokemon Legends", 57, 1)
    }) {}

    // copy constructor
    private Switch(Switch oldSwitch) : base(oldSwitch) {}

    public override void introduction() {
        Writeline("Welcome to the Nintendo Switch store section!");
    }

    public override void Change() {
        
        int change = paid - games[selected].Price;
        
    }
}