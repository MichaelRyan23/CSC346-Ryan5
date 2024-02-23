// this is the driver program file, mostly used to test the ADT created
using System;
using VikingNS;

Viking viking1 = new Viking("Leif", Global.Status.JARL, 100, Global.Weapon.SWORD, true);

        // Display the details of viking1
        Console.WriteLine($"Viking Name: {viking1.Name}");
        Console.WriteLine($"Status: {viking1.Status}");
        Console.WriteLine($"Health: {viking1.Health}");
        Console.WriteLine($"Weapon: {viking1.Weapon}");
        Console.WriteLine($"Has Shield: {viking1.Shield}");

        Console.WriteLine();

        // Create a Viking instance using the default constructor
        Viking viking2 = new Viking();

        // Display the details of viking2
        Console.WriteLine($"Viking Name: {viking2.Name}");
        Console.WriteLine($"Status: {viking2.Status}");
        Console.WriteLine($"Health: {viking2.Health}");
        Console.WriteLine($"Weapon: {viking2.Weapon}");
        Console.WriteLine($"Has Shield: {viking2.Shield}");