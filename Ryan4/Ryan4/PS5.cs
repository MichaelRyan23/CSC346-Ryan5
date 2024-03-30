namespace StoreNS;
using System;
using System.Collections.Generic;

public class PS5 : Platform {

    // default constructor
    public PS5() : base(new List<Game>()) {

    }

    public override void Introduction() {
        Writeline("Welcome to the PS5 store section!");
    }

    public override void Payment() {
        
    }
}
