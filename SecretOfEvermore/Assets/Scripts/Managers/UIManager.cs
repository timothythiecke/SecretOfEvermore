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
        private InventoryPanel _invPan;
        private CharacterPanel _charPan;

        // Properties //
        public InventoryPanel InventoryPanel
        {
            get { return _invPan; }
            set { _invPan = value; }
        }

        public CharacterPanel CharacterPanel
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
            _invPan.Initialize();
            _charPan.Initialize();
        }

        public void DisablePanels()
        {
            _invPan.gameObject.SetActive(false);
            _charPan.gameObject.SetActive(false);
        }

        public void CheckInput()
        {
            // Enable / disable panels
            if (Input.GetKeyDown(KeyCode.I))
            {
                _invPan.gameObject.SetActive(!_invPan.gameObject.activeSelf);
                _invPan.GetComponent<InventoryPanel>().Refresh();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                _charPan.gameObject.SetActive(!_charPan.gameObject.activeSelf);
                _charPan.GetComponent<CharacterPanel>().Refresh();
            }
        }
    }
}
