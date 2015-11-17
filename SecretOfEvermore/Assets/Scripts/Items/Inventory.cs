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
                    if (item.GetType().Equals(typeof(Weapon)))
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
                    if (item.GetType().Equals(typeof(Armor)))
                    {
                        list.Add(item as Armor);
                    }
                }
                _invArmor = list;
                return list;
            }
            private set { _invArmor = value; }
        }

        public Inventory()
        {
            if (_inventoryList == null) _inventoryList = new List<Item>();
            _currentWeaponIndex = 0;
        }

        public void AddToInventory(Item itemToAdd)
        {
            // Multiple items added -> increase amount property of the item

            var item = _inventoryList.Find(x => x.Equals(itemToAdd));

            if (item == null) _inventoryList.Add(itemToAdd);
            else ++item.Amount;
        }

        // Increment index
        // Check for out of bounds
        // Assign current weapon property to WeaponsInventory at location currentweaponindex
        public void CycleWeaponIncremental()
        {
            ++_currentWeaponIndex;
            if (_currentWeaponIndex >= InventoryWeapons.Count)
            {
                _currentWeaponIndex = 0;
            }

            CurrentWeapon = InventoryWeapons[_currentWeaponIndex];
        }

        // Repeat in reverse order
        public void CycleWeaponDecremental()
        {
            --_currentWeaponIndex;
            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = 0;
            }

            CurrentWeapon = InventoryWeapons[_currentWeaponIndex];
        }
    }
}
