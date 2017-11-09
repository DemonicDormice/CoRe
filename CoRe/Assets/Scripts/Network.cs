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

	public TcpClient playerSocket;
	public NetworkStream myStream;
	public StreamReader myReader;
	public StreamWriter myWriter;

	private byte[] asyncBuffer;
	public bool shouldHandleData;

	//Starts Code before GO is created
	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		cmd = GameObject.FindGameObjectWithTag("CommandPrompt").GetComponent<CommandPrompt>();
		ConnectGameServer ();
	}

	void ConnectGameServer(){
		if (playerSocket != null) {
			if (playerSocket.Connected || isConnected) {
				return;
			}
			playerSocket.Close ();
			playerSocket = null;
		}

		playerSocket = new TcpClient ();
		playerSocket.ReceiveBufferSize = 4096;
		playerSocket.SendBufferSize = 4096;
		playerSocket.NoDelay = false;
		Array.Resize (ref asyncBuffer, 8192);
		playerSocket.BeginConnect (ServerIP, ServerPort, new AsyncCallback(ConnectCallback), playerSocket);
		isConnected = true;
	}

	void ConnectCallback(IAsyncResult ar){
		if (playerSocket != null) {
			playerSocket.EndConnect (ar);
			if (!playerSocket.Connected) {
				isConnected = false;
				return;
			} else {
				playerSocket.NoDelay = true;
				myStream = playerSocket.GetStream ();
				myStream.BeginRead (asyncBuffer, 0, 8192, OnReceive, null);
			}
			cmd.writeLine("Connection to server "+ServerIP +" established");
		}
	}

	void OnReceive(IAsyncResult ar){
		if (playerSocket != null) {
			if (playerSocket == null)
				return;

			int byteArray = myStream.EndRead (ar);
			byte[] myBytes = null;
			Array.Resize (ref myBytes, byteArray);
			Buffer.BlockCopy (asyncBuffer, 0, myBytes, 0, byteArray);

			if (byteArray == 0) {
				cmd.writeLine("You got disconnected from Server.");
				playerSocket.Close ();
				return;
			}
		}


		//Handle Data

		if (playerSocket == null) {
			return;
		}
		myStream.BeginRead (asyncBuffer,0,8192,OnReceive,null);

	}

}
