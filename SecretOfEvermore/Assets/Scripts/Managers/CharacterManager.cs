using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{

    // Fields //
    private Character _selectedCharacter;
    private Character _human; // * change to Human later on
    private Character _dog; // * change to dog
    private List<Character> _enemies; // * change to enemies

    private Vector3 _movementDir = new Vector3();
    private Vector3 _displacement = new Vector3();
    private float _movementSpeed = 5F;

    // Properties //
    public Character SelectedCharacter
    {
        get { return _selectedCharacter; }
        private set { _selectedCharacter = value; }
    }

    public Character Human // *
    {
        get { return _human; }
        private set { _human = value; }
    }

    public Character Dog // *
    {
        get { return _dog; }
        private set { _dog = value; }
    }

    public List<Character> Enemies // *
    {
        get { return _enemies; }
        private set { _enemies = value; }
    }


    // Ctor & Methods //
    public CharacterManager()
    {
        _human = new Character("Bobby"); // * human
        _dog = new Character("Billy"); // * dog

        _selectedCharacter = _human;

        _enemies = new List<Character>(); // enemy
    }

    // Toggle between the human and the dog
    // If SelectCharacter == human then dog else human
    public void ChangeSelectedCharacter()
    {
        SelectedCharacter = (SelectedCharacter == _human) ? _dog : _human;
    }

    public void UpdateCharacterLocations()
    {
        // Selected character displacement //
        _movementDir = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _movementDir.z = 1F;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _movementDir.z = -1F;
        }

        else _movementDir.z = 0F;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _movementDir.x = -1F;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _movementDir.x = 1F;
        }

        else _movementDir.x = 0F;

        _displacement = _movementDir * _movementSpeed * Time.deltaTime;
        SelectedCharacter.VisualCharacter.GetComponent<CharacterController>().Move(_displacement);

        // Non selected character displacement //
        Character slave = (_selectedCharacter == _human) ? _dog : _human;
        Vector3 dir = _selectedCharacter.VisualCharacter.transform.position - slave.VisualCharacter.transform.position;

        if (dir.sqrMagnitude > 9)
            slave.VisualCharacter.GetComponent<CharacterController>().Move(dir.normalized * _movementSpeed * Time.deltaTime);

    }
}
