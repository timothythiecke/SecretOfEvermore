using UnityEngine;
using System.Collections;

public class Armor : Item {

    public enum ArmorType
    { 
        Wooden, Bronze
    }

    public ArmorType TypeOfArmor
    {
        get;
        set;
    }

    public Armor()
    { 
        
    }

    // * increases character defence

    public override string ToString()
    {
        return "Armor";
    }

    public override void IncreaseStat(Character character)
    {
        character.IncreaseDefence(2);
    }
}
