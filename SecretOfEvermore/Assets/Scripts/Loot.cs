using UnityEngine;
using System.Collections;
using Assets.Scripts.Items;

public class Loot : MonoBehaviour {

    private Item _lootItem;

    void Start()
    {
        int random = Random.Range(0, 101);
        if ((random >= 0) && (random <= 25))
        {
            _lootItem = new Armor();
        }

        if ((random >= 26) && (random <= 50))
        {
            _lootItem = new Bow();
        }

        if ((random >= 51) && (random <= 75))
        {
            _lootItem = new Staff();
        }

        if ((random >= 76) && (random <= 100))
        {
            _lootItem = new Sword();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Pickup & destroy
                (Instantiate(Resources.Load("TextPrefab"), transform.position + new Vector3(0, 2.5f, 0), new Quaternion()) as GameObject).GetComponent<TextMesh>().text = _lootItem.ToString() + " looted!";
                GameManager.Instance.Inventory.AddToInventory(_lootItem);
                Destroy(gameObject);
            }
        }
    }
}
