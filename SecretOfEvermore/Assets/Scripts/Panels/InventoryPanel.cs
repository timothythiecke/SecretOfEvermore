using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Panels
{
    public class InventoryPanel : EvermorePanel
    {
		private List<GameObject> _inventoryImageItems;

        public override void Initialize()
        {
			// Create InventoryPanelItems from the start, they might be needed later on when the player picks up additional weapons
			if (_inventoryImageItems == null)
				_inventoryImageItems = new List<GameObject> ();

            // Magic number 4 > Armor, Sword, Bow, Staff
			for (int i = 0; i < 4; i++)
			{
				var instance = Instantiate(Resources.Load("InventoryPanelItem") as GameObject);
				instance.transform.SetParent(transform);
				_inventoryImageItems.Add (instance);
			}

            // Organize elements
			float offset = 75F;
			_inventoryImageItems [0].GetComponent<RectTransform> ().anchoredPosition = new Vector2(-offset, -offset);
			_inventoryImageItems [1].GetComponent<RectTransform> ().anchoredPosition = new Vector2(offset, -offset);
			_inventoryImageItems [2].GetComponent<RectTransform> ().anchoredPosition = new Vector2(-offset, offset);
			_inventoryImageItems [3].GetComponent<RectTransform> ().anchoredPosition = new Vector2(offset, offset);

			// Code works sometimes ?? weird
			_inventoryImageItems [0].GetComponent<Image> ().color = new Color (209, 71, 71);
			_inventoryImageItems [1].GetComponent<Image> ().color = new Color (71, 71, 71);
			_inventoryImageItems [2].GetComponent<Image> ().color = new Color (209, 71, 71);
			_inventoryImageItems [3].GetComponent<Image> ().color = new Color (209, 71, 71);

			Refresh ();
      }
        
        public override void Refresh()
        {
            // Assume we start the game with no items
			foreach (var item in _inventoryImageItems)
			{
				item.SetActive(false);	
			}

			var inventory = GameManager.Instance.Inventory.FullInventory;
			int index = 0;
			foreach (var item in inventory) 
			{
				_inventoryImageItems[index].GetComponent<InventoryPanelItem>().linkedItem = item;
				_inventoryImageItems[index].GetComponent<InventoryPanelItem>().Refresh();
				++index;
			}
        }
    }
}
