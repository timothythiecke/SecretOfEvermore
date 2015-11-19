using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Items
{
    public class Inventory
    {
        private List<Item> _inventoryList;
        private Weapon _currentWeapon;
        private int _currentWeaponIndex;

        public Weapon CurrentWeapon
        {
            get;
            private set;
        }

        private List<Weapon> _invWeapon;
        public List<Weapon> InventoryWeapons
        {
            get 
            {
                var list = new List<Weapon>();

                foreach (var item in _inventoryList)
                {
                    if (item is Weapon)
                    {
                        list.Add(item as Weapon);
                    }
                }
                _invWeapon = list;
                return list; 
            }
            private set { _invWeapon = value; }
        }

        private List<Armor> _invArmor;
        public List<Armor> InventoryArmor
        {
            get
            {
                var list = new List<Armor>();

                foreach (var item in _inventoryList)
                {
                    if (item is Armor)
                    {
                        list.Add(item as Armor);
                    }
                }
                _invArmor = list;
                return list;
            }
            private set { _invArmor = value; }
        }

		public List<Item> FullInventory
		{
			get { return _inventoryList;}
			private set { _inventoryList = value;}
		}

        public Inventory()
        {
            if (_inventoryList == null) _inventoryList = new List<Item>();
            if (_invWeapon == null) _invWeapon = new List<Weapon>();
            if (_invArmor == null) _invArmor = new List<Armor>();
            _currentWeaponIndex = 0;
        }

        public void AddToInventory(Item itemToAdd)
        {
            // Multiple items added -> increase amount property of the item

            var item = _inventoryList.Find(x => x.GetType().Equals(itemToAdd.GetType()));

            if (item == null) 
			{
                if ((_inventoryList.Count == 0) && (itemToAdd is Weapon))
                {
                    CurrentWeapon = itemToAdd as Weapon;
                }
   
				_inventoryList.Add (itemToAdd);
				++itemToAdd.Amount;
			}
            else ++item.Amount;
        }

        // Increment index
        // Check for out of bounds
        // Assign current weapon property to WeaponsInventory at location currentweaponindex
        public bool CycleWeaponIncremental()
        {
            ++_currentWeaponIndex;
            if (_currentWeaponIndex >= InventoryWeapons.Count)
            {
                _currentWeaponIndex = 0;
            }

            CurrentWeapon = InventoryWeapons[_currentWeaponIndex];
            return true;
        }

        // Repeat in reverse order
        public bool CycleWeaponDecremental()
        {
            --_currentWeaponIndex;
            if ((_currentWeaponIndex < 0) && (InventoryWeapons.Count > 0))
            {
                _currentWeaponIndex = InventoryWeapons.Count - 1;
            }

            CurrentWeapon = InventoryWeapons[_currentWeaponIndex];
            return true;
        }
    }
}
