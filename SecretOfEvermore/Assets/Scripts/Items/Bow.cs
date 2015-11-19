using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Bow : Weapon
    {
        public override void PerformAction()
        {
            // Increase attack of player
            // Ranged attack
            Debug.Log("Noscope!");
        }

        public override string ToString()
        {
            return "Bow";
        }
    }
}
