/********************************************************************
*** NAME :          Michael Ryan   
*** CLASS :         CSC 346
*** ASSIGNMENT :    A2
*** DUE DATE :      2/26/2024
*** INSTRUCTOR :    GAMRADT
*********************************************************************
*** DESCRIPTION : This assignment involved creating an ADT within a namespace
*** called VikingNS. The ADT is made from a viking class that has 5 "characteristics"
*** There is also a global class for global enums Status and Weapon, along with
*** an interface called IView. Alongside the constructor is also some basic
*** exception handling techniques we learned in class.
********************************************************************/
using System;

namespace VikingNS
{
    public class Viking : IView {
        
        public string? Name { get; set; }
        public short Health { get; set; }
        public bool Shield { get; set; }
        public Global.Status Status { get; set; }
        public Global.Weapon Weapon { get; set; }

/********************************************************************
*** METHOD Constructor
*********************************************************************
*** DESCRIPTION : Initializes a new instance of the viking class, giving
*** the user the option to make each property their own. Default value is
*** implemented if none is entered, and the constructor includes exception handling
*** INPUT ARGS : name, status, health, weapon, shield
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : N/A
********************************************************************/
        public Viking(
            string name = "Bjorn",
            Global.Status status = Global.Status.KARL,
            short health = 150,
            Global.Weapon weapon = Global.Weapon.AXE,
            bool shield = false
        ) {

            Name = name;
            if(string.IsNullOrEmpty(name)) {
                throw new ArgumentException("This Viking has no name, or has yet to earn it...", nameof(name));
            }
            
            Status = status;
            if(!Enum.IsDefined(typeof(Global.Status), status)) {
                throw new ArgumentOutOfRangeException(nameof(status), "Invalid status value.");
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
            // shield exception?

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
            Status = oldViking.Status;
            Health = oldViking.Health;
            Weapon = oldViking.Weapon;
            Shield = oldViking.Shield;
        }

/********************************************************************
*** METHOD ViewH
*********************************************************************
*** DESCRIPTION : Displays the properties of a Viking instance in a horizontal
*** format.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : void
********************************************************************/
        public void ViewH() {
            WriteLine("Name     Status     Health    Weapon    Shield");
            WriteLine("=================================================");
            WriteLine("{0, -10}{1,-10}{2,-10}{3,-10}{4,-10}", Name, Status, Health, Weapon, Shield);
        }

/********************************************************************
*** METHOD ViewV
*********************************************************************
*** DESCRIPTION : Displays the properties of a viking instance in a vertical
*** format.
*** INPUT ARGS : 
*** OUTPUT ARGS : 
*** IN/OUT ARGS : 
*** RETURN : void
********************************************************************/
        public void ViewV() {
            WriteLine("Name:\t\t{0}\nStatus:\t\t{1}\nHealth:\t\t{2}\nWeapon:\t\t{3}\nShield:\t\t{4}", Name, Status, Health, Weapon, Shield);
        }

    };
}