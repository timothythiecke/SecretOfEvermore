using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Items;
using Assets.Scripts.Managers;
using Assets.Scripts.Panels;

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
    private List<VisualCharacter> _visCharacters;

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

    public Inventory Inventory
    {
        get { return _inventory; }
        private set { _inventory = value; }
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
        _UIManager.InitializePanels();

        _inventory.AddToInventory(new Staff());
        _inventory.AddToInventory(new Sword());

        _visCharacters = new List<VisualCharacter>();
        _visCharacters.AddRange(GameObject.FindObjectsOfType<VisualCharacter>());
    }

    void Update()
    {
        ////////////////////
        // Input checkers //
        _cameraManager.UpdateCameraLocation();
        _characterManager.CheckInput();
        _UIManager.CheckInput();

        if (Input.GetKeyDown(KeyCode.K)) _inventory.CycleWeaponDecremental();
        if (Input.GetKeyDown(KeyCode.L)) _inventory.CycleWeaponIncremental();
    }

    private void BuildCharacters()
    {
        // Move to builder function
        /*_characterManager.Human.VisChar = (Instantiate(_visualCharacterPrefab, new Vector3(-3, 1, 0), new Quaternion()) as GameObject).GetComponent<VisualCharacter>();
        _characterManager.Dog.VisChar = (Instantiate(_visualCharacterPrefab, new Vector3(3, 1, 0), new Quaternion()) as GameObject).GetComponent<VisualCharacter>();*/

        (Instantiate(_visualCharacterPrefab, new Vector3(-3, 1, 0), new Quaternion()) as GameObject).GetComponent<VisualCharacter>().Character = _characterManager.Human;
        (Instantiate(_visualCharacterPrefab, new Vector3(1, 1, 0), new Quaternion()) as GameObject).GetComponent<VisualCharacter>().Character = _characterManager.Dog;

        // Do same for list enemies...
        /*foreach (var item in _characterManager.Enemies)
        {
            
        }*/
    }

    private void BuildUI()
    {
        // Build panels from UIManager
        Instantiate(Resources.Load("EvermorePanelPrefab") as GameObject);
        var panelHook = GameObject.FindGameObjectWithTag("PanelHook").transform;

        UIManager.CharacterPanel = Instantiate(Resources.Load("CharacterPanelPrefab") as GameObject).GetComponent<CharacterPanel>();
        UIManager.CharacterPanel.transform.SetParent(panelHook);
        
        UIManager.InventoryPanel = Instantiate(Resources.Load("InventoryPanelPrefab") as GameObject).GetComponent<InventoryPanel>();
        UIManager.InventoryPanel.transform.SetParent(panelHook);
    }

    
    public VisualCharacter FindVisualCharacter(Character character)
    {
        return _visCharacters.Find(x => x.Character.Equals(character));
    }

    public VisualCharacter FindMainCharacter()
    {
        return _visCharacters.Find(x => x.Character.Equals(CharacterManager.SelectedCharacter));
    }
}
