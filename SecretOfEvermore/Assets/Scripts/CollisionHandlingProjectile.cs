using UnityEngine;
using System.Collections;

public class CollisionHandlingProjectile : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 5F);
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag.Equals("Enemy"))
        {
            // Hurt enemy
            collision.gameObject.GetComponent<EnemyStats>().ReceiveDamage(Damage);
        }

        else if (collision.gameObject.tag.Equals("Civilian"))
        {
            // Hurt civilian
            collision.gameObject.GetComponent<CivilianStats>().ReceiveDamage(Damage);
        }

        else if (collision.gameObject.tag.Equals("Player"))
        {
            // Hurt player
            collision.gameObject.GetComponent<PlayerStats>().ReceiveDamage(Damage);
        }*/

        Destroy(gameObject);
    }
}
