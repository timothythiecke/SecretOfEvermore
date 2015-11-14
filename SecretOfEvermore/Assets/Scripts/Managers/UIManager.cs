using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using Assets.Scripts.Panels;

namespace Assets.Scripts.Managers
{
    public class UIManager
    {
        // Responsible to open panels -> user input
        // Keeps track of panels as members
        // Initializes panels

        // Fields //
        private GameObject _invPan;
        private GameObject _charPan;

        // Properties //
        public GameObject InventoryPanel
        {
            get { return _invPan; }
            set { _invPan = value; }
        }

        public GameObject CharacterPanel
        {
            get { return _charPan; }
            set { _charPan = value; }
        }

        // Ctor & methods //
        public UIManager()
        {
            
        }

        public void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                // Enable disable inventory panel
                _invPan.SetActive(!_invPan.activeSelf);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                // Enable disable character panel

                _charPan.SetActive(!_charPan.activeSelf);
            }

            
        }
    }
}
