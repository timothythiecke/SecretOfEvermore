using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Sword : Weapon
    {
        public override void PerformAction()
        {
            // Increase attack of player
            // Melee attack

            Debug.Log("Slash!");
        }

        public override string ToString()
        {
            return "Sword";
        }
    }
}
