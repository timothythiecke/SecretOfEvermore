using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager {

    // Fields //
    private Character _selectedCharacter;
    private Character _human; // * change to Human later on
    private Character _dog; // * change to dog
    private List<Character> _enemies; // * change to enemies
    
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
        _human = new Character(); // * human
        _dog = new Character(); // * dog

        _selectedCharacter = _human;

        _enemies = new List<Character>(); // enemy
    }
}
