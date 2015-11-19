using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Panels
{
    public class CharacterPanel : EvermorePanel
    {
        private List<Text> _textPanels;
        private Character _target;

        public override void Initialize()
        {
            _textPanels = new List<Text>();
            //_textPanels.AddRange(GetComponentsInChildren<Text>());
			var k = GetComponentsInChildren<Text> ();
			_textPanels.AddRange (k);
            _target = GameManager.Instance.CharacterManager.SelectedCharacter;
        }

        public override void Refresh()
        {
            _textPanels.Find(x => x.gameObject.name.Equals("TxtPlayerName")).text = _target.Name + ", the " + _target.GetType().ToString();
            _textPanels.Find(x => x.gameObject.name.Equals("TxtHP")).text = "HP: " + _target.HP.ToString();
            _textPanels.Find(x => x.gameObject.name.Equals("TxtMP")).text = "MP: " + _target.MP.ToString();
            _textPanels.Find(x => x.gameObject.name.Equals("TxtLevel")).text = "Level: " + _target.Level.ToString();
            _textPanels.Find(x => x.gameObject.name.Equals("TxtATK")).text = "ATK: " + _target.Attack.ToString();
            _textPanels.Find(x => x.gameObject.name.Equals("TxtDef")).text = "DEF: " + _target.Defence.ToString();
			_textPanels.Find (x => x.gameObject.name.Equals ("TxtMovSpeed")).text = "Movement speed: " + _target.MovementSpeed.ToString ();

			var text = _textPanels.Find (x => x.gameObject.name.Equals ("TxtWeapon"));
			if (_target.Weapon == null) 
			{
				text.text = "Weapon: Bearhands";
			} 
			else
				text.text = "Weapon: " + _target.Weapon.ToString ();

      	}

        public void SwitchPlayer()
        {
            _target = GameManager.Instance.CharacterManager.GetOtherCharacter(_target);
            Refresh();
        }
    }
}
