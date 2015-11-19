using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Bow : Weapon
    {
        public override void PerformAction(Character character)
        {
            Debug.Log("Noscope!");

			// Get forward vector,
			// Notify gameManager that a bullet should be spawned
			// If we 

			// I need MonoBehaviour for this :/
        }

        public override string ToString()
        {
            return "Bow";
        }
    }
}
