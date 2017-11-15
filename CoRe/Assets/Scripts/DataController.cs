using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		if (userData.player.playername == null) {
			return false;
		} else {
			return true;
		}
	}
		
}
