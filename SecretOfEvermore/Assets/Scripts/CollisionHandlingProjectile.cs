using UnityEngine;
using System.Collections;

public class CollisionHandlingProjectile : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 5F);
    }

    void OnCollisionEnter(Collision collision)
    {
        var visChar = collision.gameObject.GetComponent<VisualCharacter>();

        if (visChar != null)
	    {
            GameManager.Instance.SpawnText(collision.gameObject.transform.position, visChar.Character.Attack.ToString(), Color.red);
            GameManager.Instance.CharacterManager.HurtCharacter(visChar.Character);
	    }
        
        Destroy(gameObject);
    }
}
