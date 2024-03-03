using System;
using VikingNS;

class Program
{
    static void Main()
    {

        // Test creating a Karl with default values
        Karl defaultKarl = new Karl();
        Console.WriteLine(defaultKarl.ToString());
        Console.WriteLine("\n");

        // Test creating a Karl with custom values
        Karl customKarl = new Karl("Leif", 150, Global.Weapon.AXE, false, Global.Duty.WARRIOR);
        Console.WriteLine(customKarl.ToString());
        Console.WriteLine("\n");

        // Test copying a Karl
        Karl copiedKarl = new Karl(customKarl);
        Console.WriteLine(copiedKarl.ToString());
        Console.WriteLine("\n");

        // Test with invalid name for Karl
        try
        {
            Karl noNameKarl = new Karl();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Caught expected exception for name: {e.Message}");
        }

        // Test with invalid health for Karl
        try
        {
            Karl invalidHealthKarl = new Karl("Ivar", -50, Global.Weapon.NONE, false);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Caught expected exception for health: {e.Message}");
        }

        // Test with invalid weapon for Karl
        try
        {
            Karl invalidWeaponKarl = new Karl("Erik", 100, (Global.Weapon)999, true);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Caught expected exception for weapon: {e.Message}");
        }
    }
}

