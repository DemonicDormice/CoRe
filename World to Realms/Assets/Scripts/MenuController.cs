using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public Text worldName;
	public Text endTime;
	public Text realmX;
	public Text realmY;
	public Text coldC;
	public Text warmC;
	public Text medC;
	public Text desertC;
	public Text tropicC;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	public void CreateWorld(){
		DataController.instance.createWorld (worldName.text, endTime.text, int.Parse(realmX.text), int.Parse (realmY.text), float.Parse (coldC.text), float.Parse (warmC.text), float.Parse (medC.text), float.Parse (desertC.text), float.Parse (tropicC.text));
	}
}
