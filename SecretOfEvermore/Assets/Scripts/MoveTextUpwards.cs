using UnityEngine;
using System.Collections;

public class MoveTextUpwards : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 4F);
    }

	// Update is called once per frame
	void Update () {
	    // v = a * t
        // s = v * t

        float speed = 70 * Time.deltaTime;

        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
	}
}
