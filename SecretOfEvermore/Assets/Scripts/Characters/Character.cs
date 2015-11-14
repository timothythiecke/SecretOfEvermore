using UnityEngine;
using System.Collections;

public class Character {

    // Fields //
    private string _name;
    private int _HP;
    private int _MP;
    //private Weapon _weapon;
    private int _level;
    private int _attack;
    private GameObject _gameObject;

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

    public GameObject VisualCharacter
    {
        get { return _gameObject; }
        private set { _gameObject = value; }
    }

    // Ctor & Methods //
    public Character()
    {
        // Consider doing the load in gamemanager?
        // Or a static field of character
        VisualCharacter = Resources.Load("VisualCharacter") as GameObject;
    }
}
