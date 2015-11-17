using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour {

    // Member of Character (link UI & logic)
    // Single model (cube/capsule)

    private Character _character;

    public Character Character
    {
        get;
        set;
    }
}
