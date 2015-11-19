using UnityEngine;
using System.Collections;

public abstract class Weapon : Item {

    public virtual void PerformAction()
    { 
        
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
