using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System;

public class Network : MonoBehaviour {
	
	public static Network instance;
	private CommandPrompt cmd;

	[Header("Network Settings")]
	public string ServerIP = "127.0.0.1";
	public int ServerPort = 5500;
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

	public void getPlayerData(string email, string password){

	}

}
