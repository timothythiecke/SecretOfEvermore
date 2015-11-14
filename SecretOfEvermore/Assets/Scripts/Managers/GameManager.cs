using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;
using Assets.Scripts.Managers;

public class GameManager : MonoBehaviour {

    // Creates other Managers
    // Holds static info
    // Holds inventory
    // Creates visual prefabs based on info from other managers (characters, HUD, ...)

    // Fields //
    public static GameManager Instance;

    private CharacterManager _characterManager;
    private CameraManager _cameraManager;
    private UIManager _UIManager;
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

    public UIManager UIManager
    {
        get { return _UIManager; }
        private set { _UIManager = value; }
    }


    // Methods //
    void Start()
    {
        if (Instance == null) Instance = this;

        _characterManager = new CharacterManager();
        _cameraManager = new CameraManager(15F, 15F);
        _UIManager = new UIManager();

        _visualCharacterPrefab = Resources.Load("VisualCharacter");

        BuildCharacters();
        BuildUI();
    }

    void Update()
    {
        _cameraManager.UpdateCameraLocation();
        _characterManager.CheckInput();
        _UIManager.CheckInput();
    }

    private void BuildCharacters()
    {
        // Move to builder function
        _characterManager.Human.VisualCharacter = Instantiate(_visualCharacterPrefab, new Vector3(-3, 1, 0), new Quaternion()) as GameObject;
        _characterManager.Dog.VisualCharacter = Instantiate(_visualCharacterPrefab, new Vector3(0, 1, 0), new Quaternion()) as GameObject;

        // Do same for list enemies...

    }

    private void BuildUI()
    {
        // Build panels from UIManager
        Instantiate(Resources.Load("EvermorePanelPrefab") as GameObject);
        var panelHook = GameObject.FindGameObjectWithTag("PanelHook").transform;

        UIManager.CharacterPanel = Instantiate(Resources.Load("CharacterPanelPrefab") as GameObject);
        UIManager.CharacterPanel.transform.SetParent(panelHook);
        
        UIManager.InventoryPanel = Instantiate(Resources.Load("InventoryPanelPrefab") as GameObject);
        UIManager.InventoryPanel.transform.SetParent(panelHook);
    }
}
