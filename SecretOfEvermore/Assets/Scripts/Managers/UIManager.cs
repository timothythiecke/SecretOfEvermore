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

        public void InitializePanels()
        {
            _invPan.GetComponent<InventoryPanel>().Initialize();
            _charPan.GetComponent<CharacterPanel>().Initialize();
        }

        public void CheckInput()
        {
            // Enable / disable panels
            if (Input.GetKeyDown(KeyCode.I))
            {
                _invPan.SetActive(!_invPan.activeSelf);
                _invPan.GetComponent<InventoryPanel>().Refresh();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                _charPan.SetActive(!_charPan.activeSelf);
                _charPan.GetComponent<CharacterPanel>().Refresh();
            }
        }
    }
}
