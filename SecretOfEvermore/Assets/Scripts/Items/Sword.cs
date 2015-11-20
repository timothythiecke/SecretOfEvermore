using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Sword : Weapon
    {
        public override void PerformAction(Character character)
        {
            // Increase attack of player
            // Melee attack

            Debug.Log("Slash!");
            /*Physics.SphereCast()
            GameManager.Instance.FindVisualCharacter(character)*/
        }

        public override string ToString()
        {
            return "Sword";
        }

        public override void IncreaseStat(Character character)
        {
            character.IncreaseDamage(5);
        }
    }
}
