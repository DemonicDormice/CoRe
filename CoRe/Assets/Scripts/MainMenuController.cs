using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public GameObject mainMenuButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf) {
			mainMenuButton.SetActive (false);
			if (Input.GetKey (KeyCode.Escape)) {
				Continue ();
			}
		}
	}

	public void Continue(){
		mainMenuButton.SetActive (true);
		MenuController.instance.ChangeMenu (Menu.None);
	}

	public void Quit(){
		DataController.instance.SaveData ();
		Application.Quit ();
	}
}
