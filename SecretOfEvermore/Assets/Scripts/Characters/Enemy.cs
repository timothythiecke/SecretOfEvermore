using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;

public class Enemy : Character
{
    // Ctor & Methods //
    public Enemy(string name, int hp = 10, int mp = 10, int level = 1, int attack = 1, int defence = 0, float movementSpeed = 5F)
        : base(name, hp, mp, 1, 1, 0, movementSpeed)
    {
       
    }
}
