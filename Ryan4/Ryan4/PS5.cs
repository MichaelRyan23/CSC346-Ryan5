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
    private PS5(PS5 oldPS5) : base(oldPS5) {
        selected = oldPS5.selected;
        paid = oldPS5.paid;
    }

    public override void Introduction() {
        Writeline("Welcome to the PS5 store section!");
    }

    public override void Payment() {
        
    }
}
