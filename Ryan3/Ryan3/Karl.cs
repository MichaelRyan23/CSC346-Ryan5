using System;

namespace VikingNS;

public class Karl : Viking {

    // Auto property for Duty, gets a default value of FARMER
    public Global.Duty Duty { get; set;} = Global.Duty.FARMER;

/********************************************************************
*** METHOD Karl (Default constructor)
*********************************************************************
*** DESCRIPTION : Initializes a new instance of Karl class by using the
*** default constructor of the Viking base class. Duty property is set to
*** FARMER by default, as you can see above.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :
*** RETURN : N/A
********************************************************************/
    public Karl() : base() {}

/********************************************************************
*** METHOD Karl (Parameterized Constructor)
*********************************************************************
*** DESCRIPTION : Initializes a new instance of the Karl class with 
*** specified parameterized properties. Calls parameterized constructor
*** of Viking base class for inheritance, sets duty property (default FARMER)
*** INPUT ARGS : name, health, weapon, shield, duty
*** OUTPUT ARGS : 
*** IN/OUT ARGS :
*** RETURN : N/A
********************************************************************/
    public Karl(string name,
                short health,
                Global.Weapon weapon,
                bool shield, 
                Global.Duty duty = Global.Duty.FARMER) 
                : base(name, health, weapon, shield) {
                    Duty = duty;
                }


/********************************************************************
*** METHOD Karl (Copy constructor)
*********************************************************************
*** DESCRIPTION : Copies the properties from an existing Karl instance into
*** a new instance.
*** INPUT ARGS : oldKarl(Karl)
*** OUTPUT ARGS : 
*** IN/OUT ARGS :
*** RETURN : N/A
********************************************************************/
    public Karl(Karl oldKarl) : base(oldKarl) {
        Duty = oldKarl.Duty;
    }

/********************************************************************
*** METHOD ToString 
*********************************************************************
*** DESCRIPTION : Overrides default ToString method to provide a formatted
*** string representation of Karl instance, including all inherited
*** Viking properties plus Duty property to that Karl.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS :
*** RETURN : string
********************************************************************/
    public override string? ToString() {

        return $"{base.ToString()}\nDuty:\t\t{Duty}";

    }
}