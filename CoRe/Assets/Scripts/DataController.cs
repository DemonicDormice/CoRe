using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attitude{
	angel = 1,
	demon = 2
}

public class DataController : MonoBehaviour {
	private User userData;

	public static DataController instance;

	protected DataController(){}

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	public bool createUser(string jsondata){
		userData = JsonUtility.FromJson<User> (jsondata);
		if (userData.player.playername == "") {
			return false;
		} else {
			return true;
		}
	}

	public string getUsername(){
		return userData.username;
	}

	public string getPassword(){
		return userData.password;
	}

	public string getEmail(){
		return userData.email;
	}

	public void changePlayer(string data){
		Debug.Log ("evaluate playerdata");
	}
		
}
