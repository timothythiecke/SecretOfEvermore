using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Items;

public class InventoryPanelItem : MonoBehaviour {

	public Item linkedItem;

	public void Refresh()
	{
		gameObject.SetActive (true);

		var textElements = GetComponentsInChildren<Text> ();

		foreach (var item in textElements)
		{
			if (item.tag.Equals("InventoryAmount"))
			{
				item.text = linkedItem.Amount.ToString();
			}

			else if (item.tag.Equals("InventoryName"))
			{
				if((linkedItem as Bow) != null) item.text = "Bow";
				else if((linkedItem as Sword) != null) item.text = "Sword";
				else if((linkedItem as Staff) != null) item.text = "Staff";
				else if((linkedItem as Armor) != null) item.text = "Armor";
			}
		}
	}
}
