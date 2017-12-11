using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour {

	// The MouseManager controlls the mouse, clicks etc.
	public GameObject selectedObject;
	public static Material initialColor;
	public Material HighlightColor;

	bool isDraggingCamera = false;
	Vector3 lastMousePosition;

	void Start () {

	}


	//public Canvas CanvasOpenRealm;

	//void OnMouseDown()
	/* {
		Debug.Log("Pressed left click.");
		//CanvasOpenRealm.interactable(true);
		//CanvasOpenRealm.blocksRaycast(true);
		CanvasOpenRealm.alpha = 1;
	} */	

	// Update is called once per frame
	void Update () {

		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		//What's the point where mouse-ray intersects Y=0
		if (mouseRay.direction.y >= 0) 
		{
			Debug.LogError ("Mouse is pointing up?!?");
			return;
		}
		float rayLength = (mouseRay.origin.y / mouseRay.direction.y);
		Vector3 hitPos = mouseRay.origin - (mouseRay.direction * rayLength);

		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (2)) 
		{
			//Mousbutton went down, start to drag
			isDraggingCamera = true;

			lastMousePosition = hitPos;

		} else if (Input.GetMouseButtonUp (0) || Input.GetMouseButtonUp (2)) {
			//Mousebutton went up, stop dragging
			isDraggingCamera = false;
		}


		if (isDraggingCamera) 
		{
			Vector3 diff = lastMousePosition - hitPos;
			Camera.main.transform.Translate (diff, Space.World);
			mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			//What's the point where mouse-ray intersects Y=0
			if (mouseRay.direction.y >= 0) 
			{
				Debug.LogError ("Mouse is pointing up?!?");
				return;
			}
			rayLength = (mouseRay.origin.y / mouseRay.direction.y);
			lastMousePosition = mouseRay.origin - (mouseRay.direction * rayLength);
		}


		//Zoom to scrollwheel
		float scrollAmount = Input.GetAxis("Mouse ScrollWheel");
		float minHeight = 2;
		float maxHeight = 20;

		if (Mathf.Abs (scrollAmount) > 0.01f) {

			//Move camera towards hitPos
			Vector3 dir = hitPos - Camera.main.transform.position;

			Vector3 p = Camera.main.transform.position;

			//ignore/stop zoom when trying to zoom out to much
			if (scrollAmount > 0 || p.y < (maxHeight - 0.1f)) {
				Camera.main.transform.Translate (dir * scrollAmount, Space.World);
			}

			//Correct angle when zooming really close
			p = Camera.main.transform.position;
			if (p.y < minHeight) {
				p.y = minHeight;
			}
			if (p.y > maxHeight) {
				p.y = maxHeight;
			}
			Camera.main.transform.position = p;

			//Chance camera angle while zooming
			float lowZoom = minHeight + 3;
			float highZoom = maxHeight - 10;
		}

		//TODO: Make the following zoom with angle optional for the user and 
		//give him the option to choose 60° and 90° fix
		Camera.main.transform.rotation = Quaternion.Euler (
			Mathf.Lerp (35, 90, Camera.main.transform.position.y / (maxHeight/1.5f)),
			Camera.main.transform.rotation.eulerAngles.y,
			Camera.main.transform.rotation.eulerAngles.z
		);


		RaycastHit hitInfo;

		if (Physics.Raycast (mouseRay, out hitInfo)) {
			Debug.Log ("Mouse is over: " + hitInfo.collider.transform.parent.name);
			GameObject hitObject = hitInfo.transform.parent.gameObject;

			// The collider we hit may not be the "root" of the object
			// You can grab the most "root-est" gameobject using
			// transform.root, though if your objects are nested within
			// a larger parent GameObject (like "All Units") then this might
			// not work.  An alternative is to move up the transform.parent
			// hierarchy until you find something with a particular component.

			// "if" to ask what kind of object we are over
			// TODO: implement all other realm-objects
			if (hitObject.GetComponent<ThisHexTile> () != null) {
				// We are over a hex
				MouseOver_Hex (hitObject);
			}

			SelectObject (hitObject);
		} else {
			ClearSelection ();
		}
	}


	void MouseOver_Hex(GameObject hitObject) {

		//This allows us to do things when mousing over a hex
		//Like a tooltip. It could allows us to do something when
		//a unit is selected, but the mouse is over a hex.

		/* if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");
			Renderer rs = selectedObject.GetComponentInChildren<Renderer> ();
			initialColor = selectedObject.GetComponentInChildren<Renderer> ().material.color;
			Material[] mats = rs.materials; 
			foreach (Material mat in mats) { 
				mat.color = Color.white; 
			}
		} else {		
			Renderer rs = selectedObject.GetComponentInChildren<Renderer> ();
			initialColor = selectedObject.GetComponentInChildren<Renderer> ().material.color;
			Material[] mats = rs.materials; 
			foreach (Material mat in mats) { 
				mat.color = initialColor; 
			}
		} */



		if (EventSystem.current.IsPointerOverGameObject ()) {
		// This prefents user from clicking "trought" buttons and other
		// UI and interact trought them with the game world
			return;
		}


		//if (Input.GetMouseButtonDown (0)) {
		//Debug.Log ("Pressed left click.");
		//CanvasOpenRealm.enabled = true;
		//CanvasOpenRealm.alpha = 1;
		//}

	}



	    //Mouse over object - it gets highlighted and initial color is saved
		void SelectObject(GameObject obj) {
			if(selectedObject != null) {
				if(obj == selectedObject)
					return;

				ClearSelection();
			}

			selectedObject = obj;

			Renderer rs = selectedObject.GetComponentInChildren<Renderer>();
			initialColor = selectedObject.GetComponentInChildren<Renderer> ().material;
			Material[] mats = rs.materials; 
			foreach(Material mat in mats) { 
			rs.material = HighlightColor;
		}

		}
	    
	    // if mouse leaves selected object, it gets initial material back
		void ClearSelection() {
			if(selectedObject == null)
				return;

		Renderer rs = selectedObject.GetComponentInChildren<Renderer>(); 
		Material[] mats = rs.materials; 
		foreach(Material mat in mats) { 
			rs.material = initialColor; 
		}
					selectedObject = null;
		} 

}