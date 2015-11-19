using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Debug.Log("You won the game!");
            }
        }
    }
}
