using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreationMenuController : MonoBehaviour {

	public InputField playernameField;
	public Toggle demonTgl;
	public Toggle angleTgl;
	ColorBlock cbNormal = playernameField.colors;

	public void submitPlayerData(){
		ColorBlock cbRed = playernameField.colors;
		cbRed.normalColor = Color.red;

		if (playernameField.text.Length > 2) {
			Attitude a = Attitude.angel;
			if (demonTgl.isOn)
				a = Attitude.demon;
			Network.instance.changePlayerData (DataController.instance.getEmail (), DataController.instance.getPassword (), playernameField.text, a);
			playernameField.colors = cbNormal;
		} else {
			playernameField.colors = cbRed;
			MenuController.instance.toggleInfoBox ("You have to choose a playername with at least 2 characters.");
		}
	}

	public void backButtonClicked(){
		playernameField.text = "";
		playernameField.colors = cbNormal;
		angleTgl.isOn = true;
		MenuController.instance._menu = MenuController.Menu.None;
	}
}
