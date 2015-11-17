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

    public void MoveByUserInput()
    {
        // Selected character displacement //
        Vector3 movementDir = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementDir.z = 1F;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movementDir.z = -1F;
        }

        else movementDir.z = 0F;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementDir.x = -1F;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movementDir.x = 1F;
        }

        else movementDir.x = 0F;

        GameManager.Instance.FindVisualCharacter(this).GetComponent<CharacterController>().Move(movementDir * MovementSpeed * Time.deltaTime);
    }

    public void SlaveMovement()
    {
        Vector3 dir = GameManager.Instance.FindMainCharacter().transform.position - GameManager.Instance.FindVisualCharacter(this).transform.position;

        if (dir.sqrMagnitude > 9)
            GameManager.Instance.FindVisualCharacter(this).GetComponent<CharacterController>().Move(dir.normalized * MovementSpeed * Time.deltaTime);
    }


}
