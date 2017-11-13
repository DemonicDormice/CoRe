using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System;
using UnityEngine.Networking;

public class Network : MonoBehaviour {
	
	public static Network instance;
	private CommandPrompt cmd;
	private MenuController menuCtrl; 

	[Header("Network Settings")]
	public string serverAdress = "127.0.0.1";
	public bool isConnected;

	protected Network(){}

	//Starts Code before GO is created
	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		cmd = GameObject.FindGameObjectWithTag("CommandPrompt").GetComponent<CommandPrompt>();
		menuCtrl = GameObject.FindGameObjectWithTag ("MenuController").GetComponents<MenuController>();
	}

	public void getPlayerData(string email, string password){

	}

	/**
	 *Calls the function for registration of new users
	 *
	 */
	public void registerplayer(string email, string username, string password, Dictionary<string, string> attributes){
		StartCoroutine(register(email, username, password, attributes));
	}

	IEnumerator register(string email, string username, string password, Dictionary<string, string> attributes){
		List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
		formData.Add (new MultipartFormDataSection("username="+username+"&email="+email+"&password="+password) );
		UnityWebRequest www = UnityWebRequest.Post(serverAdress+"/playermanager/register.php", formData);
		cmd.writeLine ("Starting registration...");
		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError) {
			cmd.writeLine (www.error);
		} else {
			menuCtrl.toggleInfoBox(www.downloadHandler.text);
			menuCtrl._menu = MenuController.Menu.Login;
		}
	}
}
