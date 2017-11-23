using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCreationMenuController : MonoBehaviour {

	public InputField playernameField;
	public Toggle demonTgl;
	public Toggle angelTgl;
	ColorBlock cbNormal;

	void Start(){
		cbNormal = playernameField.colors;
	}

	public void submitPlayerData(){
		ColorBlock cbRed = playernameField.colors;
		cbRed.normalColor = Color.red;

		if (playernameField.text.Length > 2) {
			Attitude a = Attitude.angel;
			if (demonTgl.isOn)
				a = Attitude.demon;
			JSONMessage response = Network.instance.changePlayerData (DataController.instance.getEmail (), DataController.instance.getPassword (), playernameField.text, (int)a);
			MenuController.instance.toggleInfoBox (response.msg);
			if (response.http_status < 400) {
				DataController.instance.changePlayer (response.data);
				MenuController.instance.ChangeMenu (Menu.None);
				SceneManager.LoadScene ("PlayerScene");
			}
			playernameField.colors = cbNormal;
		} else {
			playernameField.colors = cbRed;
			MenuController.instance.toggleInfoBox ("You have to choose a playername with at least 2 characters.");
		}
	}

	public void backButtonClicked(){
		playernameField.text = "";
		playernameField.colors = cbNormal;
		angelTgl.isOn = true;
		MenuController.instance.ChangeMenu(Menu.None);
	}
}
