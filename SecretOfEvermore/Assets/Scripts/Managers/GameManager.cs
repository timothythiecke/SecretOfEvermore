using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Inherits from Mono
    // Creates other Managers
    // Holds static info
    // Holds inventory
    // Creates visual prefabs based on info from other managers

    private CharacterManager _characterManager;

    void Start()
    {
        _characterManager = new CharacterManager();

        // Build visual prefabs based on info from other managers
        // Deze klasse gaat de prefabs maken aan de hand van de info uit charactermanager
        // Instantiate

        Instantiate(Resources.Load("VisualCharacter"), new Vector3(), new Quaternion());
        
    }
}
