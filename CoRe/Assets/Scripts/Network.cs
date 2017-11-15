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

	[Header("Network Settings")]
	public string serverAdress = "http://localhost/";
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
	}

	/**
	 * Get the player data from server. If player do not exist change to player configuration Mode to create a new one.
	 */
	public JSONMessage getPlayerData(string email, string password){
		JSONMessage response = null;
		WWWForm formData = new WWWForm();
		formData.AddField ("email",email);
		formData.AddField ("p", password);
		UnityWebRequest www = UnityWebRequest.Post(serverAdress+"/core/playermanager/getplayerdata.php", formData);
		cmd.writeLine ("Requesting playerdata from server...");
		www.SendWebRequest();

		WaitForSeconds w;
		while (!www.isDone)
			w = new WaitForSeconds (0.1f);

		if (www.isNetworkError || www.isHttpError) {
			cmd.writeLine (www.error);
		} else {
			response = JsonUtility.FromJson<JSONMessage> (www.downloadHandler.text);
		}
		return response;
	}

	/**
	 *Calls the function for registration of new users
	 *
	 */
	public JSONMessage registeruser(string email, string username, string password, Dictionary<string, string> attributes){
		JSONMessage response = null;
		WWWForm formData = new WWWForm();
		formData.AddField ("email",email);
		formData.AddField ("username",username);
		formData.AddField ("p", password);
		UnityWebRequest www = UnityWebRequest.Post(serverAdress+"/core/playermanager/register.php", formData);
		cmd.writeLine ("Starting registration...");
		www.SendWebRequest();

		WaitForSeconds w;
		while (!www.isDone)
			w = new WaitForSeconds (0.1f);

		if (www.isNetworkError || www.isHttpError) {
			cmd.writeLine (www.error);
		} else {
			response = JsonUtility.FromJson<JSONMessage> (www.downloadHandler.text);
		}
		return response;
	}

}
