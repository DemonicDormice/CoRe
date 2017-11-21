﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	public static MenuController instance;

	[Header ("Menu GameObjects")]
	public GameObject loginMenu;
	public GameObject registerMenu;
	public GameObject playerCreationMenu;
	public GameObject soulforgeMenu;
	public InputField regusername;
	public InputField regemail;
	public InputField regpassword2;
	public InputField regpassword1;
	public InputField email;
	public InputField password;
	public Text infoText;
	public GameObject infoBox;

	public Menu _menu;

	public enum Menu
	{
		Login = 1,
		Register,
		PlayerCreation,
		Soulforge,
		None
	}

	// Use this for initialization
	void Awake ()
	{
		instance = this;
		_menu = Menu.Login;
	}

	void Start ()
	{
		DontDestroyOnLoad (gameObject);
	}

	// Update is called once per frame
	void Update ()
	{
		switch (_menu) {
		case Menu.Login:
			loginMenu.SetActive (true);
			playerCreationMenu.SetActive (false);
			registerMenu.SetActive (false);
			soulforgeMenu.SetActive (false);
			break;

		case Menu.Register:
			loginMenu.SetActive (false);
			playerCreationMenu.SetActive (false);
			soulforgeMenu.SetActive (false);
			registerMenu.SetActive (true);
			break;

		case Menu.PlayerCreation:
			playerCreationMenu.SetActive (true);
			loginMenu.SetActive (false);
			registerMenu.SetActive (false);
			soulforgeMenu.SetActive (false);
			break;

		case Menu.Soulforge:
			playerCreationMenu.SetActive (false);
			loginMenu.SetActive (false);
			registerMenu.SetActive (false);
			soulforgeMenu.SetActive (true);
			break;

		case Menu.None:
			playerCreationMenu.SetActive (false);
			loginMenu.SetActive (false);
			registerMenu.SetActive (false);
			soulforgeMenu.SetActive (false);
			break;
		}
	}

	public void ChangeMenu (int menu)
	{
		_menu = (Menu)menu;
	}

	public void Login ()
	{
		if (email.text == "" || password.text == "") {
			toggleInfoBox ("Insert e-Mail and password, please.");
		} else {
			//generate sha512 hash of password
			string pwdHash = cryptPassword(password.text);
			JSONMessage response = Network.instance.getPlayerData (email.text, pwdHash);
			if (response.http_status < 400) {
				_menu = Menu.None;

				//bool hasPlayer = DataController.instance.createUser (response.data);
				bool hasPlayer = true;

				if (hasPlayer) {
					SceneManager.LoadScene ("PlayerScene");
				} else {
					_menu = Menu.PlayerCreation;
				}
			} else {
				toggleInfoBox (response.msg);
			}
		}
	}

	public void Register ()
	{
		ColorBlock cbRed = regusername.colors;
		cbRed.normalColor = Color.red;
		ColorBlock cbNormal = regusername.colors;

		//check InputFields
		if (regpassword1.text == regpassword2.text || regpassword1.text.Length >= 8) {
			if (regemail.text != "") {
				if (regusername.text != "") {
					//generate a sha512 hash of the password
					string pwdHash = cryptPassword(regpassword1.text);
					JSONMessage response = Network.instance.registeruser (regemail.text, regusername.text, pwdHash);
					toggleInfoBox(response.msg);
					if (response.http_status < 400) {
						_menu = Menu.Login;
					}

					regusername.colors = cbNormal;
				} else {
					regusername.colors = cbRed;
				}
				regemail.colors = cbNormal;
			} else {
				regemail.colors = cbRed;
			}
			regpassword1.colors = cbNormal;
			regpassword2.colors = cbNormal;
		} else {
			regpassword1.colors = cbRed;
			regpassword2.colors = cbRed;
			toggleInfoBox ("The passwords are not correct! Please check them and try again. \n You have to use at least 8 Characters.");
		}
	}

	public void toggleInfoBox (string msg)
	{
		if (infoBox.activeSelf) {
			infoBox.SetActive (false);
		} else {
			infoText.text = msg;
			infoBox.SetActive (true);
		}

	}

	/**
	 * Takes a string and generates a sha512 hex hash
	 * 
	 */
	private string cryptPassword(string pwd){
		byte[] pwdBytes = Encoding.UTF8.GetBytes (pwd);
		SHA512 shaM = new SHA512Managed ();
		string pwdHash = (new SoapHexBinary(shaM.ComputeHash (pwdBytes))).ToString();
		shaM.Clear ();
		return pwdHash;
	}

}
