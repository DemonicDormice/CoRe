using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class MenuController : MonoBehaviour
{

	public static MenuController instance;

	[Header ("Menu GameObjects")]
	public GameObject loginMenu;
	public GameObject registerMenu;
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
		Register
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
			registerMenu.SetActive (false);
			break;

		case Menu.Register:
			loginMenu.SetActive (false);
			registerMenu.SetActive (true);
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
					byte[] pwdBytes = Encoding.UTF8.GetBytes (regpassword1.text);
					SHA512 shaM = new SHA512Managed ();
					string pwdHash = Encoding.UTF8.GetString(shaM.ComputeHash (pwdBytes));

					Network.instance.registerplayer (regemail.text, regusername.text, pwdHash, null);
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

}
