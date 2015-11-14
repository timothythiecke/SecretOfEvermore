using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;

public class GameManager : MonoBehaviour {

    // Creates other Managers
    // Holds static info
    // Holds inventory
    // Creates visual prefabs based on info from other managers (characters, HUD, ...)

    // Fields //
    public static GameManager Instance;

    private CharacterManager _characterManager;
    private CameraManager _cameraManager;
    private Object _visualCharacterPrefab;
    private Inventory _inventory;


    // Properties //
    public CharacterManager CharacterManager
    {
        get { return _characterManager; }
        private set { _characterManager = value; }
    }

    public CameraManager CameraManager
    {
        get { return _cameraManager; }
        private set { _cameraManager = value; }
    }


    // Methods //
    void Start()
    {
        if (Instance == null) Instance = this;

        _characterManager = new CharacterManager();
        _cameraManager = new CameraManager(15F, 15F);

        _visualCharacterPrefab = Resources.Load("VisualCharacter");

        // Move to builder function
        _characterManager.Human.VisualCharacter = Instantiate(_visualCharacterPrefab, new Vector3(-3, 1, 0), new Quaternion()) as GameObject;
        _characterManager.Dog.VisualCharacter = Instantiate(_visualCharacterPrefab, new Vector3(0, 1, 0), new Quaternion()) as GameObject;

        // Do same for list enemies...
    }

    void Update()
    {
        _cameraManager.UpdateCameraLocation();
        _characterManager.UpdateCharacterLocations();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _characterManager.ChangeSelectedCharacter();
            Debug.Log("Current selected character = " + _characterManager.SelectedCharacter.Name);
        }
    }

    

}
