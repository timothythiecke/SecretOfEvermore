using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager
{
    // Fields //
    private Character _selectedCharacter;
    private Human _human; // * change to Human later on
    private Dog _dog; // * change to dog
    private List<Enemy> _enemies; // * change to enemies

    private Vector3 _movementDir;
    private VisualCharacter _playerCharacter;
    private VisualCharacter _dogCharacter;

    // Properties //
    public Character SelectedCharacter
    {
        get { return _selectedCharacter; }
        private set { _selectedCharacter = value; }
    }

    public Human Human // *
    {
        get { return _human; }
        private set { _human = value; }
    }

    public Dog Dog // *
    {
        get { return _dog; }
        private set { _dog = value; }
    }

    public List<Enemy> Enemies // *
    {
        get { return _enemies; }
        private set { _enemies = value; }
    }


    // Ctor & Methods //
    public CharacterManager()
    {
        _human = new Human("Bobby"); // * human
        _dog = new Dog("Billy"); // * dog

        SelectedCharacter = _human;

        _enemies = new List<Enemy>(); // enemy
    }

    // Toggle between the human and the dog
    // If SelectCharacter == human then dog else human
    public void ChangeSelectedCharacter()
    {
        if (SelectedCharacter == Human)
        {
            SelectedCharacter = Dog;
        }

        else SelectedCharacter = Human;
    }

    public Character GetOtherCharacter(Character previous)
    {
        if (previous == _human)
        {
            return _dog;
        }

        return _human;
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ChangeSelectedCharacter();
        if (Input.GetKeyDown(KeyCode.F) && (SelectedCharacter == Human)) Human.UseWeapon();

        // Character movements
        _movementDir = SelectedCharacter.CalculateMoveDirection();
        GameManager.Instance.FindVisualCharacter(SelectedCharacter).CharacterController.Move(_movementDir * SelectedCharacter.MovementSpeed * Time.deltaTime); // keep in private VisualCharacter field? -> bad

        // Slave movement
        Character slave;
        if (SelectedCharacter == Human)
        {
            slave = Dog;
        }
        else slave = Human;
        var slaveVisChar = GameManager.Instance.FindVisualCharacter(slave);
        Vector3 dir = GameManager.Instance.FindMainCharacter().transform.position - slaveVisChar.transform.position;
        if (dir.sqrMagnitude > 9)
            slaveVisChar.CharacterController.Move(dir.normalized * slave.MovementSpeed * Time.deltaTime);
    }

}
