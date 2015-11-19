using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	private static string[] _headings = {"E", "NE", "N", "NW", "W", "SW", "S", "SE"};

	private Text _txtHPPlayer;
	private Text _txtWeaponPlayer;
	private Text _txtHpDog;
	private Text _notifications;

	private Character _human;
	private Character _dog;

	private GameObject _evacZone;
	private Vector3 _direction;

	void Start()
	{
		_txtHPPlayer = GameObject.Find ("TxtHpPlayer").GetComponent<Text>();
		_txtWeaponPlayer = GameObject.Find ("TxtWeapon").GetComponent<Text>();
		_txtHpDog = GameObject.Find ("TxtHpDog").GetComponent<Text>();
		_notifications = GameObject.FindGameObjectWithTag ("Notification").GetComponent<Text>();

		_human = GameManager.Instance.CharacterManager.Human;
		_dog = GameManager.Instance.CharacterManager.Dog;

		_evacZone = GameObject.FindGameObjectWithTag ("EvacuationZone");

		InvokeRepeating ("Refresh", 0.25f, 0.25f);
	}

	private void Refresh()
	{
		_txtHPPlayer.text = _human.HP.ToString() + "/" + _human.MaxHP.ToString();
		_txtWeaponPlayer.text = _human.Weapon.ToString ();
		_txtHpDog.text = _dog.HP.ToString() + "/" + _dog.MaxHP.ToString();

		_notifications.text = _headings[CalculateOctant ()];
	}

	private int CalculateOctant()
	{
		_direction = new Vector3 ();
		_direction = _evacZone.transform.position - GameManager.Instance.FindVisualCharacter (GameManager.Instance.CharacterManager.SelectedCharacter).transform.position;
		float angle = Mathf.Atan2(_direction.z, _direction.x);
		return (int)(Mathf.Round(8 * angle / (2 * Mathf.PI) + 8) % 8);
	}
}
