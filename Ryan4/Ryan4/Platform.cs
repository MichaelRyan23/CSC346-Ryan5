namespace StoreNS;
using System;
using System.Collections.Generic;

public abstract class Platform : IPlatform {

    protected List<Game> games;     // # in UML diagram signified 'protected'
    protected int selected;
    protected int paid;

    // default constructor
    protected Platform(List<Game> gamesList, int Selected = 0, int Paid = 0) {
        games = gamesList;
        selected = Selected;
        paid = Paid;
    }

    // copy constructor
    protected Platform(Platform oldPlatform) {
        games = new List<Game>(oldPlatform.games);
        selected = oldPlatform.selected;
        paid = oldPlatform.paid;
    }

    public void Start() {

    }

    public void Introduction() {
        Writeline("Welcome to the Gamer Store!");
    }

    protected void Selection() {

    }

    protected void Payment() {

    }

    protected void Change() {

    }

    protected void Deliver() {

    }
}
