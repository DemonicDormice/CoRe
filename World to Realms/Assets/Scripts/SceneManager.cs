using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* public class SceneManager : MonoBehaviour {

	public static SceneManager Instance{ set; get; }

private void OnMouseDown()
//	{
		private void Awake ()
		{
			Instance = this;
			//Load("WorldScene");
			//Load("LoadingQuestion");
		}


		//When clicked the user will be asked if he
		//wants to open the realm. The click also
		//starts the LoadSceneMode.Additive, so that
		//the Scene is loaded in the background without
		//the user knowing it. If the user confirms the
		//WorldScene will be destroyed and the new Scene
		//finally loaded. If he denies the loading of the
		//new Scene will be stopped by destroing it.
		//Goal is a) prevent opening of realms on accident
		//and b) getting the loadingprocess to feel shorter

//		Debug.Log ("Clicked on the Realm!");


		public void Load (string sceneName)
		{
			if(!SceneManager.GetSceneByName(sceneName).isLoaded)
				SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);

		Debug.Log ("Scene" + sceneName + "is not loaded and got loaded");
		}

		public void Unload (string sceneName)
		{
			if(!SceneManager.GetSceneByName(sceneName).isLoaded)
				SceneManager.UnloadScene(sceneName);
		Debug.Log ("Scene" + sceneName + "was loaded and got unloaded");
		}
//	} 
} */
