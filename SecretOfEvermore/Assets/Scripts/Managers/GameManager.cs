using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Items;
using Assets.Scripts.Managers;
using Assets.Scripts.Panels;

public class GameManager : MonoBehaviour
{

    // Creates other Managers
    // Holds static info
    // Holds inventory
    // Creates visual prefabs based on info from other managers (characters, HUD, ...)

    // Fields //
    public static GameManager Instance;

    private CharacterManager _characterManager;
    private CameraManager _cameraManager;
    private UIManager _UIManager;
    private BulletManager _bulletManager;
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

    public BulletManager BulletManager
    {
        get { return _bulletManager; }
        private set { _bulletManager = value; }
    }


    // Methods //
    void Start()
    {
        // Create static instance
        if (Instance == null) Instance = this;

        // Create inventory, add additional stuff for debug testing
        _inventory = new Inventory();
        _inventory.AddToInventory(new Sword());
        
        // Create managers
        _characterManager = new CharacterManager();
        _cameraManager = new CameraManager(15F, 15F);
        _UIManager = new UIManager();
        gameObject.AddComponent<BulletManager>();

        // Load prefabs from memory
        _visualCharacterPrefab = Resources.Load("VisualCharacter");

        // Builders
        BuildCharacters();
        BuildUI();
        _UIManager.InitializePanels();
        _UIManager.DisablePanels();

        // Fetch all visual characters from the scene
        _visCharacters = new List<VisualCharacter>();
        _visCharacters.AddRange(GameObject.FindObjectsOfType<VisualCharacter>());


        // Other stuff
        _characterManager.Human.SetCurrentWeapon(_inventory.CurrentWeapon);
    }

    void Update()
    {
        ////////////////////
        // Input checkers //
        _cameraManager.UpdateCameraLocation();
        _characterManager.CheckInput();
        _UIManager.CheckInput();

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_inventory.CycleWeaponDecremental())
            {
                CharacterManager.Human.SetCurrentWeapon(_inventory.CurrentWeapon);
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_inventory.CycleWeaponIncremental())
            {
                CharacterManager.Human.SetCurrentWeapon(_inventory.CurrentWeapon);
            }
        }
        ///////////////////
    }

    private void BuildCharacters()
    {
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
