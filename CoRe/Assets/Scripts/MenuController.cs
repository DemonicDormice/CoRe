using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	public static MenuController instance;

	[Header("Menu GameObjects")]
	public GameObject loginMenu;
	public GameObject registerMenu;

	public Menu _menu;

	public enum Menu{
		Login = 1,
		Register
	}

	// Use this for initialization
	void Awake () {
		instance = this;
		_menu = Menu.Login;
	}
	
	// Update is called once per frame
	void Update () {
		switch (_menu) {
		case Menu.Login:
			loginMenu.SetActive (true);
			registerMenu.SetActive (false);
			break;

		case Menu.Register:
			loginMenu.SetActive (false);
			registerMenu.SetActive (true);
			break;
		}
	}

	public void ChangeMenu(int menu){
		_menu = (Menu)menu;
	}
}
