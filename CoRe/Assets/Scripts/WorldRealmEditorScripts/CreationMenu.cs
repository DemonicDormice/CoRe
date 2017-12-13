using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//The goal of the creation menu is, that at one time you can open the creation menu, type in a world name
//hit "enter" (or better the create button) and whole world is created, uploaded, and will automatically
//start - all in 30 seconds work.


public class CreationMenu : MonoBehaviour {

	public InputField playerExpectation;
	public InputField worldName;
	public InputField startCalendarDate;
	public InputField endCalendarDate;
	public InputField randomEditorSeed;

	public GameObject CanvasWorldMenuI;
	public GameObject PanelRandomWorldQuestionI;
	public GameObject PanelResetQuestion;
	public GameObject PanelLoadDatabase;
	public GameObject PanelLoadFile;

	public GameObject CanvasWorldMenuII;
	public GameObject PanelRandomWorldQuestionII;
	public GameObject PanelTimeZonePopUp;

	public GameObject CanvasClimateMenu;
	public GameObject PanelRandomClimateQuestion;

	public GameObject CanvasNPCMenu;
	public GameObject PanelRandomNPCQuestion;


	// Use this for initialization
	void Start () {
//playerExpectation = 200;

		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = true;
		PanelRandomWorldQuestionI.SetActive(false);
		PanelResetQuestion.SetActive(false); 
		PanelLoadDatabase.SetActive(false);
		PanelLoadFile.SetActive(false);

		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
		PanelRandomWorldQuestionII.SetActive(false);
		PanelTimeZonePopUp.SetActive(false);

		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;
		PanelRandomClimateQuestion.SetActive(false);
	
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;
		PanelRandomNPCQuestion.SetActive(false);
	}

	// Update is called once per frame
	void Update () {


	}


	public void openWorldFirstCanvas () {
		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = true;
		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;
	}

	public void openWorldSecondCanvas () {
		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = true;
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;
	}

	public void openClimateCanvas () {
		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = true;
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;
	}

	public void openNPCCanvas () {
		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = true;
	}

	public void openRandWorldQuestI () {
		PanelRandomWorldQuestionI.SetActive(true);
	}

	public void openRandWorldQuestII () {
		PanelRandomWorldQuestionI.SetActive(true);
	}

	public void openResetQuestion () {
		PanelResetQuestion.SetActive(true);
	}

	public void openLoadDatabase () {
		PanelLoadDatabase.SetActive(true);
	}

	public void openLoadFile () {
		PanelLoadFile.SetActive(true);
	}

	public void openTimeZone () {
		PanelTimeZonePopUp.SetActive(true);
	}

	public void openRandClimateQuest () {
		PanelRandomClimateQuestion.SetActive(true);
	}

	public void openRandNPCQuest () {
		PanelRandomNPCQuestion.SetActive(true);
	}

	public void closeAllPanels ()
	{
		//Well, this function just closes all open panels. So it's the close/no button for all panels.
		PanelRandomWorldQuestionI.SetActive(false);
		PanelRandomWorldQuestionI.SetActive(false);
		PanelResetQuestion.SetActive(false);
		PanelLoadDatabase.SetActive(false);
		PanelLoadFile.SetActive(false);
		PanelTimeZonePopUp.SetActive(false);
		PanelRandomClimateQuestion.SetActive(false);
		PanelRandomNPCQuestion.SetActive(false);
	}

	public void LoadWorldEditorScene(string WorldEditorScene) {
		SceneManager.LoadScene (WorldEditorScene);
	}

	//In World Menu First: This function will on start of the creation menu scene put a random integer number into the "Random-Seed" textfield.
	//World Menu Second will automatically be set to the same status. 
	public void randomTheSeed () {

	}

	//In World Menu First: This function will random all the things "randomable" in the editor like what climate zones are active or if
	//there are all military units playable in the human cultures, how many settlements there are in a realm etc. But it will leave 
	//other things like standard start or end time of day on standard. It will NOT create the world. So the player still has to click
	//on create...
	//TODO: Pop-Up for Climate Menu and NPC Menu á la "Do you want to randomly set OTHERMENU?" and for World Menus "Do you want to randomly
	//set climate and NPC?"
	public void randomTheRest () {

	}

	//In World Menu First: This function will calculate and change the world size and realm size depending on expected players for
	//the next round. This will just fill the textfields in World Menu Second with fitting numbers, the user still has to confirm
	//or can change the numbers.
	//World Menu Second will automatically be set to the same status. 
	public void PlayerExpectation (int playerExpectation) {

		//We will expect that a round over 120 days should start with two realms per player á 50 by 50 tiles.
		playerExpectation = ((DataControllerEditor.realmSizeX * DataControllerEditor.realmSizeY) / 2500) * (DataControllerEditor.worldSizeX * DataControllerEditor.worldSizeY);
	}

	//In World Menu First: This function will calculate on starting the creation editor a Start Calendar Date - based on the real world
	//calendar date PLUS five days. A Toggle "Start Now" will set the start date (when true) to the real world time and date the second 
	//the user hits create.
	//World Menu Second will automatically be set to the same status.
	//Preview DayOfTheWeek will automatically be updated.
	public void StartCalendarDate () {

	}

	//In World Menu First: This function will calculate on starting the creation editor a End Calendar Date - based on the on start
	//calculated Start Calendar Date PLUS 120 Days (4 Months).
	//World Menu Second will automatically be set to the same status.
	//Preview DayOfTheWeek will automatically be updated.
	public void EndCalendarDate () {

	}

	//In World Menu Second: This function für the run-time in days textfield will change the end date calendar textfield and the 
	//end time of day textfield - and if the user changes things inside those fields the run-time textfield will be changed - 
	//so that you can put a number of days in there and it will calculate the right calendar date for you. 
	//Because run-time in days will be set to 120 by standard (4 months) the function will also on start of the CreationScene
	//set a End Calendar Date based on the real world system time and the 120 days run-time.
	public void RunTimeDays () {

	}

	//In NPC Menu: This little function will set NPC per Realm Quantity automaticalle to 1 every time, the "Only one NPC in the World?" 
	//toggle is set true. And every time someone puts an number in "NPC per Realm Quantity" the 'highlander-toggle' will set on false
	public void HighlanderNPC () {

	}
}
