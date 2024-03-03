using System;

namespace VikingNS;

public class Karl : Viking {

    // Auto property for Duty, gets a default value of FARMER
    public Global.Duty Duty { get; set;} = Global.Duty.FARMER;

    public Karl() : base() {}

    public Karl(string name,
                short health,
                Global.Weapon weapon,
                bool shield, 
                Global.Duty duty = Global.Duty.FARMER) 
                : base(name, health, weapon, shield) {
                    Duty = duty;
                }

    public Karl(Karl oldKarl) : base(oldKarl) {
        Duty = oldKarl.Duty;
    }

    public override string? ToString() {

        return $"{base.ToString()}\nDuty:\t\t{Duty}";

    }
}