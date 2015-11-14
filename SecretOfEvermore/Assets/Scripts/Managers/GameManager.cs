using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Creates other Managers
    // Holds static info
    // Holds inventory
    // Creates visual prefabs based on info from other managers (characters, HUD, ...)

    private CharacterManager _characterManager;

    void Start()
    {
        _characterManager = new CharacterManager();

        Instantiate(_characterManager.Human.VisualCharacter, new Vector3(), new Quaternion());
        Instantiate(_characterManager.Dog.VisualCharacter, new Vector3(0,10,0), new Quaternion());

        // Do same for list enemies...
    }
}
