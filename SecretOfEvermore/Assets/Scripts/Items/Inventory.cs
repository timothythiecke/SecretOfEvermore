using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Items
{
    public class Inventory
    {
        private List<Item> _inventoryList;

        public Inventory()
        {
            if (_inventoryList == null) _inventoryList = new List<Item>();
        }

        public void AddToInventory(Item itemToAdd)
        {
            _inventoryList.Add(itemToAdd);
            // Multiple items added -> increase amount property of the item
        }
    }
}
