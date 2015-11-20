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
            GameManager.Instance.SwordAttack(character);
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
