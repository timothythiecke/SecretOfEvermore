using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class VisualCharacter : MonoBehaviour {

    // Member of Character (link UI & logic)
    // Single model (cube/capsule)

    // Fields //
    private Character _character;
    private CharacterController _characterController;

    // Properties //
    public Character Character
    {
        get;
        set;
    }

    public CharacterController CharacterController
    {
        get;
        private set;
    }

    // Methods //
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }
}
