using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CommandPrompt : MonoBehaviour {
	public Text input;
	public Text output;
	public ScrollRect outputScroll;
	public GameObject commandPromptPanel;

	private List<GameObject> listeners = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		AddListener (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			commandPromptPanel.SetActive (!commandPromptPanel.activeSelf);
		}
		outputScroll.verticalNormalizedPosition = 1;
	}

	public void AddListener(GameObject listener){
		if (!listeners.Contains (listener)) {
			listeners.Add (listener);
		}
	}

	public void commandInput(){
		string[] parts = input.text.Split (new char[]{ '.', '(', ')' }, 3);
		GameObject go = listeners.Where(obj => obj.name == parts[0]).SingleOrDefault();
		if (go != null) {
			go.SendMessage (parts [1], parts [2]);
		}

		writeLine (input.text);
	}

	public void writeLine(string line){
		output.text = line + "\n" + output.text;
	}
}
