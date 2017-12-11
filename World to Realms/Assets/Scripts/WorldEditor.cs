using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//This is build on the RealmEditor.cs script. It should allow you to choose the size of the world in
//realm * realm.
//TODO: In a later version you should be able to choose how mush space in the world different  
//climates take. You should be able to choose what time-multiplier the world is running on. You should
//be able to choose the deadline/runtime of the world. You should be able to choose which cultures of NPC
//are placed where. You should be able to start the random realm-generator or choose pre-build-realms and then
//dive into the RealmEditor to micromanage the tiles there

public class WorldEditor : MonoBehaviour {
	

	public GameObject selectedObject;

	//Canvas for opening realms
	public Canvas realmOpenerCanvas;
	public bool realmOpenerActive = false; //display is not shown before clicking

	private WorldMap worldMap;
	public GameObject realmGameObject;

	public Material MatRealm;

	void Start ()
	{
		realmOpenerCanvas.gameObject.SetActive(realmOpenerActive);
	}

	void Update()
	{
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		if (Physics.Raycast (mouseRay, out hitInfo)) {
			//Debug.Log ("Mouse is over: " + hitInfo.collider.transform.parent.name);
			GameObject hitChange_Realm = hitInfo.transform.parent.gameObject;

			if (hitChange_Realm.GetComponent<RealmData> () != null) {
				// We are over a realm
				MouseOver_RealmChange (hitChange_Realm);
			}

			SelectObject (hitChange_Realm);
		} else {
			//ClearSelection ();
		}
	}


	//Mouse over object - it gets highlighted and initial color is saved
	void SelectObject(GameObject obj) {
		if (Input.GetMouseButtonDown (0)) {

			selectedObject = obj;

			realmOpenerActive = true; //change the state of realmOpenerActive bool
			realmOpenerCanvas.gameObject.SetActive(realmOpenerActive); //display the canvas following state of bool
		}
	}

	void MouseOver_RealmChange (GameObject hitChange_Realm) 
	{
		//This changes the hex when clicked on and if dropdown menu
		//is not "None"

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");
			//MeshRenderer rs = selectedObject.GetComponentInChildren<MeshRenderer>();
			//Material[] mats = rs.materials; 
			//foreach(Material mat in mats) { 
			//	mat.color = Material.SetColor.MatHills;
		}

		if (Input.GetMouseButtonDown(0))
			Debug.Log("Pressed left click.");

		if (Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");

		if (Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");
	} 
}

