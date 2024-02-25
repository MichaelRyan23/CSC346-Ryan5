// Viking class implementation file
using System;

namespace VikingNS
{
    public class Viking : IView {
        
        public string? Name { get; set; }
        public short Health { get; set; }
        public bool Shield { get; set; }
        public Global.Status Status { get; set; }
        public Global.Weapon Weapon { get; set; }

        public Viking(
            string name = "Bjorn",
            Global.Status status = Global.Status.KARL,
            short health = 150,
            Global.Weapon weapon = Global.Weapon.AXE,
            bool shield = false
        ) {

            Name = name;
            Status = status;
            Health = health;
            Weapon = weapon;
            Shield = shield;

        }

        public Viking(Viking oldViking) {
            Name = oldViking.Name;
            Status = oldViking.Status;
            Health = oldViking.Health;
            Weapon = oldViking.Weapon;
            Shield = oldViking.Shield;
        }

        public void ViewH() {
            WriteLine("Name     Status     Health    Weapon    Shield");
            WriteLine("=================================================");
            WriteLine("{0, -10}{1,-10}{2,-10}{3,-10}{4,-10}", Name, Status, Health, Weapon, Shield);
        }

        public void ViewV() {
            WriteLine("Name:\t\t{0}\nStatus:\t\t{1}\nHealth:\t\t{2}\nWeapon:\t\t{3}\nShield:\t\t{4}", Name, Status, Health, Weapon, Shield);
        }

    };
}