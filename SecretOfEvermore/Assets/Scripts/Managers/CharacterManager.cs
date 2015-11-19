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

    private Vector3 _movementDir;
    private VisualCharacter _playerCharacter;
    private VisualCharacter _dogCharacter;

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

        SelectedCharacter = _human;

        _enemies = new List<Character>(); // enemy
    }

    // Toggle between the human and the dog
    // If SelectCharacter == human then dog else human
    public void ChangeSelectedCharacter()
    {
        SelectedCharacter = (SelectedCharacter == _human) ? _dog : _human;
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ChangeSelectedCharacter();

        // Character movements
        _movementDir = SelectedCharacter.CalculateMoveDirection();
        GameManager.Instance.FindVisualCharacter(SelectedCharacter).CharacterController.Move(_movementDir * SelectedCharacter.MovementSpeed * Time.deltaTime); // keep in private VisualCharacter field? -> bad

        // Slave movement
        Character slave = (_selectedCharacter == _human) ? _dog : _human;
        var slaveVisChar = GameManager.Instance.FindVisualCharacter(slave);
        Vector3 dir = GameManager.Instance.FindMainCharacter().transform.position - slaveVisChar.transform.position;
        if (dir.sqrMagnitude > 9)
            slaveVisChar.CharacterController.Move(dir.normalized * slave.MovementSpeed * Time.deltaTime);
    }

}
