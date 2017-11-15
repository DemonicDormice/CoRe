using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MenuController.instance._menu = MenuController.Menu.Login;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
