// Viking class implementation file
using System;

namespace VikingNS
{
    public class Viking {
        
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

        public Viking(Viking previousViking) {
            Name = previousViking.Name;
            Status = previousViking.Status;
            Health = previousViking.Health;
            Weapon = previousViking.Weapon;
            Shield = previousViking.Shield;
        }
    };
}