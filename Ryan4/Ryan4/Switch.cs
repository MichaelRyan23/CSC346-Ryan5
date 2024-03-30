namespace StoreNS;
using System;
using System.Collections.Generic;

public class Switch : Platform {

    public Switch() : base(new List<Game>()) {

    }

    public override void introduction() {
        Writeline("Welcome to the Nintendo Switch store section!");
    }

    public override void Change() {
        
    }
}