using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour {
	public GameObject commandPromptPanel;

	// Use this for initialization
	void Start () {
		MenuController.instance._menu = MenuController.Menu.Login;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			commandPromptPanel.SetActive (!commandPromptPanel.activeSelf);
		}
	}
}
