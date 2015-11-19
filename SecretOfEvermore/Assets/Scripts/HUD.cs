using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	private Text _txtHPPlayer;
	private Text _txtWeaponPlayer;
	private Text _txtHpDog;

	private Character _human;
	private Character _dog;

	void Start()
	{
		_txtHPPlayer = GameObject.Find ("TxtHpPlayer").GetComponent<Text>();
		_txtWeaponPlayer = GameObject.Find ("TxtWeapon").GetComponent<Text>();
		_txtHpDog = GameObject.Find ("TxtHpDog").GetComponent<Text>();

		_human = GameManager.Instance.CharacterManager.Human;
		_dog = GameManager.Instance.CharacterManager.Dog;

		//InvokeRepeating (Refresh(), 0.5f, 0.5f);
		InvokeRepeating ("Refresh", 0.25f, 0.25f);
	}

	private void Refresh()
	{
		_txtHPPlayer.text = _human.HP.ToString() + "/" + _human.MaxHP.ToString();
		_txtWeaponPlayer.text = _human.Weapon.ToString ();
		_txtHpDog.text = _dog.HP.ToString() + "/" + _dog.MaxHP.ToString();
	}


}
