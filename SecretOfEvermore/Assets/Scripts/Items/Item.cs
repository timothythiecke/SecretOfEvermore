using UnityEngine;
using System.Collections;

public abstract class Item {

    public enum ItemType
    { 
        Armor, Weapon
    };

    public ItemType Type
    { get; set; }

    public int Amount
    { get; set; }

    public virtual void IncreaseStat(Character character)
    { 
    
    }
}
