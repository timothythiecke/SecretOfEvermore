using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager {

    // Not mono
    // 2 distinct characters (human and dog)
    // list of enemies
    // selected character

    // Fields //
    private Character _selectedCharacter;
    private Character _human;
    private Character _dog;

    private List<Character> _enemies; // character or enemy? -> enemy
    
    // Properties //
    public Character SelectedCharacter
    {
        get { return _selectedCharacter; }
        private set { _selectedCharacter = value; }
    }

    public Character Human
    {
        get { return _human; }
        private set { _human = value; }
    }

    public Character Dog
    {
        get { return _dog; }
        private set { _dog = value; }
    }


    // Ctor & Methods //
    public CharacterManager()
    {
        _human = new Character();
        _dog = new Character();

        _selectedCharacter = _human;

        _enemies = new List<Character>();
    }
}
