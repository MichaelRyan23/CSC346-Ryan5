using System;

namespace VikingNS;

public abstract class Viking {
        
    public string? Name { get; set; }
    public short Health { get; set; }
    public bool Shield { get; set; }
    public Global.Weapon Weapon { get; set; }

/********************************************************************
*** METHOD Constructor
*********************************************************************
*** DESCRIPTION : Initializes a new instance of the viking class, giving
*** the user the option to make each property their own. Default value is
*** implemented if none is entered, and the constructor includes exception handling
*** INPUT ARGS : name, health, weapon, shield
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
    public Viking(
        string name = "Olaf",
        short health = 100,
        Global.Weapon weapon = Global.Weapon.NONE,
        bool shield = false
    ) {

        Name = name;
        if(string.IsNullOrEmpty(name)) {
            throw new ArgumentException("This Viking has no name, or has yet to earn it...", nameof(name));
        }

        Health = health;
        if(health <= 0) {
            throw new ArgumentOutOfRangeException(nameof(health), "Health must be greater than 0.");
        }

        Weapon = weapon;
        if(!Enum.IsDefined(typeof(Global.Weapon), weapon)) {
            throw new ArgumentOutOfRangeException(nameof(weapon), "Invalid weapon value.");
        }

        Shield = shield;
        

    }

/********************************************************************
*** METHOD Copy constructor 
*********************************************************************
*** DESCRIPTION : Copies a new viking instance by copying the properties
*** from an already-existing viking instance.
*** INPUT ARGS : oldViking
*** OUTPUT ARGS : 
*** IN/OUT ARGS :
*** RETURN : N/A
********************************************************************/
    public Viking(Viking oldViking) {

        Name = oldViking.Name;
        Health = oldViking.Health;
        Weapon = oldViking.Weapon;
        Shield = oldViking.Shield;

    }

/********************************************************************
*** METHOD ToString 
*********************************************************************
*** DESCRIPTION : Overrides default ToString method to provide a string
*** that displays the Viking's attributes, basically for easy reading and
*** printing of a viking's properties.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :
*** RETURN : string (Formatted description)
********************************************************************/
    public override string? ToString() {

        return $"Name:\t\t{Name}\nHealth:\t\t{Health}\nWeapon:\t\t{Weapon}\nShield:\t\t{Shield}";
    }

};