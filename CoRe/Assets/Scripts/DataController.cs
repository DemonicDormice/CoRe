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

	public User getPlayerData(string email, string password){
		if (userData != null) {

		} else {

		}
		return null;
	}
}
