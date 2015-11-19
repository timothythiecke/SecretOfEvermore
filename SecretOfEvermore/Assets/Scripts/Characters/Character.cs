using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;

public class Character
{
    // Fields //
    private string _name;
    private int _HP;
    private int _MP;
    private Weapon _weapon;
    private int _level;
    private int _attack;
    private int _defence;
    private float _movSpeed;


    // Properties //
    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public int HP
    {
        get { return _HP; }
        private set { _HP = value; }
    }

    public int MP
    {
        get { return _MP; }
        private set { _MP = value; }
    }

    public int Level
    {
        get { return _level; }
        private set { _level = value; }
    }

    public int Attack
    {
        get { return _attack; }
        private set { _attack = value; }
    }

    public int Defence
    {
        get { return _defence; }
        private set { _defence = value; }
    }

    public float MovementSpeed
    {
        get { return _movSpeed; }
        private set { _movSpeed = value; }
    }


    // Ctor & Methods //
    public Character(string name, int hp = 10, int mp = 10, int level = 1, int attack = 1, int defence = 0, float movementSpeed = 5F)
    {
        Name = name;
        HP = hp;
        MP = mp;
        Level = level;
        Attack = attack;
        Defence = defence;
        MovementSpeed = movementSpeed;
    }

    public Vector3 CalculateMoveDirection()
    {
        var movementDir = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementDir.z = 1F;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movementDir.z = -1F;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementDir.x = -1F;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movementDir.x = 1F;
        }

        return movementDir;
    }
}
