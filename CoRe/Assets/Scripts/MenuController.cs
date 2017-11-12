using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public static MenuController instance;

	[Header("Menu GameObjects")]
	public GameObject loginMenu;
	public GameObject registerMenu;
	public InputField regusername;
	public InputField regemail;
	public InputField regpassword2;
	public InputField regpassword1;
	public InputField email;
	public InputField password;
	public Text infoText;

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

	public void Login(){
		if (email.text == "" || password.text == "") {
			toggleInfoBox ("Insert e-Mail and password, please.");
		}
	}

	public void Register(){

	}

	public void toggleInfoBox(string msg){
		GameObject infoBox = GameObject.FindGameObjectWithTag ("InfoBox") as GameObject;

		if (infoBox.activeSelf) {
			infoBox.SetActive (false);
		} else {
			infoText.text = msg;
			infoBox.SetActive (true);
		}

	}

}
