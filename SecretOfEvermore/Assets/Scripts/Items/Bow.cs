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
            GameManager.Instance.FireBow(character);
        }

        public override string ToString()
        {
            return "Bow";
        }

        public override void IncreaseStat(Character character)
        {
            character.IncreaseDamage(2);
        }
    }
}
