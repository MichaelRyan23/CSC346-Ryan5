namespace StoreNS;
using System;

public class Game {

    public string Name { get; set; };
    public int Price { get; set; };
    public int Units { get; set; };

    // default parameterized constructor
    public Game(string name = "", int price = 0, int units = 0) {
        Name = name;
        Price = price;
        Units = units;
    }

    // Copy construcotr
    public Game(Game oldGame) {
        Name = oldGame.Name;
        Price = oldGame.Price;
        Units = oldGame.Units;
    }

}