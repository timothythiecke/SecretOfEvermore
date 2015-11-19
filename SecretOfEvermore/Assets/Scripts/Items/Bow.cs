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

			//GameManager.Instance.BulletManager.Shoot()
        }

        public override string ToString()
        {
            return "Bow";
        }
    }
}
