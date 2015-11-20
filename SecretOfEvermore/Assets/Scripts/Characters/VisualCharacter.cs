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

    public void LateInitialize()
    {
        if (Character is Human)
        {
            GetComponent<Renderer>().material.color = new Color(76 / 255F, 208 / 255F, 0F);
            gameObject.layer = 9;
        }
        else if (Character is Dog)
        {
            GetComponent<Renderer>().material.color = new Color(208 / 255F, 111 / 255F, 0);
            gameObject.layer = 9;
        }

        else if (Character is Enemy)
        {
            GetComponent<Renderer>().material.color = new Color(1F, 0F, 0F);
            gameObject.layer = 11;
        }
    }
}
