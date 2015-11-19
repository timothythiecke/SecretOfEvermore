using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Staff : Weapon
    {
        public override void PerformAction()
        {
            // Heal player
            Debug.Log("Heal!");
        }

        public override string ToString()
        {
            return "Staff";
        }
    }
}
