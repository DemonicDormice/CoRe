using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//The goal of the creation menu is, that at one time you can open the creation menu, type in a world name
//hit "enter" (or better the create button) and whole world is created, uploaded, and will automatically
//start - all in 30 seconds work.


public class CreationMenu : MonoBehaviour {

	//All Canvases and panels of the menus
	public GameObject CanvasSuperordinate;
	public GameObject PanelMissingWorldname;
	public GameObject PanelRandomWorldQuestion;
	public GameObject PanelResetQuestion;
	public GameObject PanelLoadDatabase;
	public GameObject PanelLoadFile;
	public GameObject PanelTimeZonePopUp;
	public GameObject PanelRandomClimateQuestion;
	public GameObject PanelRandomNPCQuestion;

	public GameObject CanvasWorldMenuI;

	public GameObject CanvasWorldMenuII;

	public GameObject CanvasClimateMenu;
	public GameObject PanelColdTileTypes;
	public GameObject PanelWarmTileTypes;
	public GameObject PanelMediterraneanTileTypes;
	public GameObject PanelDesertTileTypes;
	public GameObject PanelTropicTileTypes;

	public GameObject CanvasNPCMenu;

	//For the Input Fields of the menus
	public InputField worldNameField;
	public InputField playerExpectationField;
	int playerExpectation;
	public InputField startDateField;
	public InputField startTimeField;
	public InputField endDateField;
	public InputField endTimeField;
	public InputField runTimeDaysField;
	int runTimeDays;
	public InputField worldSizeXField;
	int worldSizeX;
	public InputField worldSizeYField;
	int worldSizeY;
	public InputField realmSizeXField;	
	int realmSizeX;
	public InputField realmSizeYField;
	int realmSizeY;
	public InputField randomSeedField;

	public InputField climateColdField;
	int climateCold;
	public InputField climateWarmField;
	int climateWarm;
	public InputField climateMediterraneanField;
	int climateMediterranean;
	public InputField climateDesertField;
	int climateDesert;
	public InputField climateTropicField;
	int climateTropic;

	public InputField villagesRealmField;
	int villagesRealm;
	public InputField castlesRealmField;
	int castlesRealm;
	public InputField citiesRealmField;
	int citiesRealm;
	public InputField villageRandomField;
	int villageRandom;
	public InputField castleRandomField;
	int castleRandom;
	public InputField cityRandomField;
	int cityRandom;
	public InputField quantityNPCField;
	int quantityNPC;

	//Toggle of the world menus I and II
	public Toggle toggleStartCreation;

	//Toggle of the climate menu
	public Toggle toggleColdPlain;
	public Toggle toggleColdHill;
	public Toggle toggleColdMountain;
	public Toggle toggleColdConiferous;
	public Toggle toggleColdBarren;
	public Toggle toggleWarmPlain;
	public Toggle toggleWarmHill;
	public Toggle toggleWarmMountain;
	public Toggle toggleWarmConiferous;
	public Toggle toggleWarmDeciduous;
	public Toggle toggleWarmBarren;
	public Toggle toggleMediterraneanPlain;
	public Toggle toggleMediterraneanHill;
	public Toggle toggleMediterraneanMountain;
	public Toggle toggleMediterraneanDeciduous;
	public Toggle toggleMediterraneanBarren;
	public Toggle toggleDesertPlain;
	public Toggle toggleDesertHill;
	public Toggle toggleDesertMountain;
	public Toggle toggleDesertDeciduous;
	public Toggle toggleDesertHammada;
	public Toggle toggleDesertSand;
	public Toggle toggleTropicPlain;
	public Toggle toggleTropicHill;
	public Toggle toggleTropicMountain;
	public Toggle toggleTropicDeciduous;
	public Toggle toggleTropicBarren;
	public Toggle toggleWater;

	//Toggle of the NPC menu
	public Toggle toggleHighlander;
	public Toggle toggleNordic;
	public Toggle toggleMedieval;
	public Toggle toggleAncient;
	public Toggle toggleAsian;
	public Toggle toggleAfrican;
	public Toggle toggleHorde;
	public Toggle toggleSpecial;
	public Toggle toggleElite;
	public Toggle toggleAntiUnborn;


	// Use this for initialization
	void Start () {
//playerExpectation = 200;

		//All the canvases and panels that are active - or not..
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = false;
		PanelMissingWorldname.SetActive(false);
		PanelRandomWorldQuestion.SetActive(false);
		PanelResetQuestion.SetActive(false); 
		PanelLoadDatabase.SetActive(false);
		PanelLoadFile.SetActive(false);
		PanelTimeZonePopUp.SetActive(false);
		PanelRandomClimateQuestion.SetActive(false);
		PanelRandomNPCQuestion.SetActive(false);

		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = true;

		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
	
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;
		PanelColdTileTypes.SetActive(true);
		PanelWarmTileTypes.SetActive(true);
		PanelMediterraneanTileTypes.SetActive(true);
		PanelDesertTileTypes.SetActive(true);
		PanelTropicTileTypes.SetActive(true);

		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;

		//The following fills most of the Input Fields and placeholders with the right values from DataControllerEditor till they are changed
		//some Input Fields get filled in seperate functions (example startDateField, because it has to be calculated first).
		playerExpectation = 200;
		playerExpectationField.GetComponent<InputField> ().placeholder.GetComponent<Text> ().text = "" + playerExpectation; //playerExpectation;
		playerExpectationField.GetComponent<InputField>().text = "" + playerExpectation;

		//startTimeField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = ;
		//endDateField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = ;
		//endTimeField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = ;

		runTimeDays = 120;
		runTimeDaysField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + runTimeDays;
		runTimeDaysField.GetComponent<InputField>().text = "" + runTimeDays;

		worldSizeX = DataControllerEditor.worldSizeX;
		worldSizeXField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + worldSizeX;
		worldSizeXField.GetComponent<InputField>().text = "" + worldSizeX;

		worldSizeY = DataControllerEditor.worldSizeY;
		worldSizeYField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + worldSizeY;
		worldSizeYField.GetComponent<InputField>().text = "" + worldSizeY;

		realmSizeX = DataControllerEditor.realmSizeX;
		realmSizeXField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + realmSizeX;
		realmSizeXField.GetComponent<InputField>().text = "" + realmSizeX;

		realmSizeY = DataControllerEditor.realmSizeY;
		realmSizeYField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + realmSizeY;
		realmSizeYField.GetComponent<InputField>().text = "" + realmSizeY;

		climateCold = DataControllerEditor.portionColdClimate;
		//climateColdField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + climateCold;
		climateColdField.GetComponent<InputField>().text = "" + climateCold;

		climateWarm = DataControllerEditor.portionWarmClimate;
		//climateWarmField.GetComponent<InputField> ().placeholder.GetComponent<Text> ().text = "" + climateWarm;
		climateWarmField.GetComponent<InputField>().text = "" + climateWarm;

		climateMediterranean = DataControllerEditor.portionMediterraneanClimate;
		//climateMediterraneanField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + climateMediterranean;
		climateMediterraneanField.GetComponent<InputField>().text = "" + climateMediterranean;

		climateDesert = DataControllerEditor.portionDesertClimate;
		//climateDesertField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + climateDesert;
		climateDesertField.GetComponent<InputField>().text = "" + climateDesert;

		climateTropic = DataControllerEditor.portionTropicClimate;
		//climateTropicField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + climateTropic;
		climateTropicField.GetComponent<InputField>().text = "" + climateTropic;

		villagesRealm = DataControllerEditor.villagesRealm;
		villagesRealmField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + villagesRealm;
		villagesRealmField.GetComponent<InputField>().text = "" + villagesRealm;

		castlesRealm = DataControllerEditor.castlesRealm;
		castlesRealmField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + castlesRealm;
		castlesRealmField.GetComponent<InputField>().text = "" + castlesRealm;

		citiesRealm = DataControllerEditor.citiesRealm;
		citiesRealmField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + citiesRealm;
		citiesRealmField.GetComponent<InputField>().text = "" + citiesRealm;

		villageRandom = DataControllerEditor.villagesRandom;
		villageRandomField.GetComponent<InputField> ().placeholder.GetComponent<Text> ().text = "" + villageRandom;
		villageRandomField.GetComponent<InputField>().text = "" + villageRandom;

		castleRandom = DataControllerEditor.castlesRandom;
		castleRandomField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + castleRandom;
		castleRandomField.GetComponent<InputField>().text = "" + castleRandom;

		cityRandom = DataControllerEditor.citiesRandom;
		cityRandomField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + cityRandom;
		cityRandomField.GetComponent<InputField>().text = "" + cityRandom;

		quantityNPC = DataControllerEditor.quantityNPC;
		quantityNPCField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "" + quantityNPC;
		quantityNPCField.GetComponent<InputField>().text = "" + quantityNPC;
	}

	// Update is called once per frame
	void Update () {


	}


	public void openWorldFirstCanvas () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;

		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = true;
	}

	public void openWorldSecondCanvas () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = false;
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;

		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = true;
	}

	public void openClimateCanvas () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
		CanvasNPCMenu.GetComponent<Canvas> ().enabled = false;

		CanvasClimateMenu.GetComponent<Canvas> ().enabled = true;
	}

	public void openNPCCanvas () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuI.GetComponent<Canvas> ().enabled = false;
		CanvasWorldMenuII.GetComponent<Canvas> ().enabled = false;
		CanvasClimateMenu.GetComponent<Canvas> ().enabled = false;

		CanvasNPCMenu.GetComponent<Canvas> ().enabled = true;
	}

	public void openRandWorldQuest () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = true;
		PanelRandomWorldQuestion.SetActive(true);
	}

	public void openResetQuestion () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = true;
		PanelResetQuestion.SetActive(true);
	}

	public void openLoadDatabase () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = true;
		PanelLoadDatabase.SetActive(true);
	}

	public void openLoadFile () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = true;
		PanelLoadFile.SetActive(true);
	}

	public void openTimeZone () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = true;
		PanelTimeZonePopUp.SetActive(true);
	}

	public void openRandClimateQuest () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = true;
		PanelRandomClimateQuestion.SetActive(true);
	}

	public void openRandNPCQuest () {
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = true;
		PanelRandomNPCQuestion.SetActive(true);
	}

	public void closeAllPanels ()
	{
		//Well, this function just closes all open panels. So it's the close/no button for all panels.
		PanelMissingWorldname.SetActive(false);
		PanelRandomWorldQuestion.SetActive(false);
		PanelResetQuestion.SetActive(false);
		PanelLoadDatabase.SetActive(false);
		PanelLoadFile.SetActive(false);
		PanelTimeZonePopUp.SetActive(false);
		PanelRandomClimateQuestion.SetActive(false);
		PanelRandomNPCQuestion.SetActive(false);
		CanvasSuperordinate.GetComponent<Canvas> ().enabled = false;
	}

	public void InputWorldname () {
		
	}

	//In World Menu First: This function will calculate and change the world size and realm size depending on expected players for
	//the next round. This will just fill the textfields in World Menu Second with fitting numbers, the user still has to confirm
	//or can change the numbers.
	//World Menu Second will automatically be set to the same status. 
	public void PlayerExpectation (int playerExpectation) {

		//We will expect that a round over 120 days should start with two realms per player á 50 by 50 tiles.
		playerExpectation = ((DataControllerEditor.realmSizeX * DataControllerEditor.realmSizeY) / 2500) * (DataControllerEditor.worldSizeX * DataControllerEditor.worldSizeY);
	}
		
	public void ArenaCreation () {

	}

	public void LoadDatabase () {

	}

	public void LoadFile () {

	}
		
	//In World Menu First: This function will calculate on starting the creation editor a Start Calendar Date - based on the real world
	//calendar date PLUS five days. A Toggle "Start Now" will set the start date (when true) to the real world time and date the second 
	//the user hits create.
	//World Menu Second will automatically be set to the same status.
	//Preview DayOfTheWeek will automatically be updated.
	public void StartCalendarDate () {
		/*
		DateTime startDate = DateTime.Today.AddDays (5); //  TimeSpan(5, 0, 0, 0); //This adds 5 Days, 0 Hours, 0 Minutes and 0 Seconds to today.
		startDateField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = startDate;
		startDateField.GetComponent<InputField>().text = startDate;

		if (toggleStartCreation == true) { //If toggle Start on Creation is true, startDate is set to DateTime.Now
		startDateField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = DateTime.Now;
		startDateField.GetComponent<InputField>().text = DateTime.Now;
		} else
		{
			startDateField.text = startDate;
		} */
	}

	//In World Menu First: This function will calculate on starting the creation editor a End Calendar Date - based on the on start
	//calculated Start Calendar Date PLUS 120 Days (4 Months).
	//World Menu Second will automatically be set to the same status.
	//Preview DayOfTheWeek will automatically be updated.
	public void EndCalendarDate () {



	}

	public void ResetToStandard () {

	}

	//In World Menu First: This function will on start of the creation menu scene put a random integer number into the "Random-Seed" textfield.
	//World Menu Second will automatically be set to the same status. 
	public void randomTheSeed () {

		//randomSeedField.GetComponent<InputField>().placeholder.GetComponent<Text>().text = XXX;
		//randomSeedField.GetComponent<InputField>().text = XXX;
		//DataControllerEditor.randomCreationSeed = XXX;

	}

	//TODO: World with no name - Warning popup, that a world name is needed. Maybe in the popup panel a convenient input field to get the name...
	public void LoadWorldEditorScene(string WorldEditorScene) {

		if (DataControllerEditor.worldSizeX == null) {
			PanelMissingWorldname.SetActive (true);
		} else {
			SceneManager.LoadScene (WorldEditorScene);
		}
	}

	//In World Menu First: This function will random all the things "randomable" in the editor like what climate zones are active or if
	//there are all military units playable in the human cultures, how many settlements there are in a realm etc. But it will leave 
	//other things like standard start or end time of day on standard. It will NOT create the world. So the player still has to click
	//on create...
	//TODO: Pop-Up for Climate Menu and NPC Menu á la "Do you want to randomly set OTHERMENU?" and for World Menus "Do you want to randomly
	//set climate and NPC?"
	public void randomTheRest () {

		//The stuff that gets randomized in world menu
		DataControllerEditor.randomCreationSeed = UnityEngine.Random.Range(0,99999); 

		//The stuff that gets randomized in climate menu
		DataControllerEditor.portionColdClimate = UnityEngine.Random.Range(0, 100); 
		DataControllerEditor.portionWarmClimate = UnityEngine.Random.Range(0, (100 - DataControllerEditor.portionColdClimate));
		DataControllerEditor.portionMediterraneanClimate = UnityEngine.Random.Range(0, (100 - DataControllerEditor.portionWarmClimate));
		DataControllerEditor.portionDesertClimate = UnityEngine.Random.Range(0, (100 - DataControllerEditor.portionMediterraneanClimate));
		DataControllerEditor.portionTropicClimate = UnityEngine.Random.Range(0, (100 - DataControllerEditor.portionDesertClimate));

		//The stuff that gets randomized in NPC menu
		DataControllerEditor.villagesRealm = UnityEngine.Random.Range(7, 13); 
		DataControllerEditor.castlesRealm = UnityEngine.Random.Range(2, 4); 
		DataControllerEditor.citiesRealm = UnityEngine.Random.Range(1, 3);
		DataControllerEditor.villagesRandom = UnityEngine.Random.Range(0, 5); 
		DataControllerEditor.castlesRandom = UnityEngine.Random.Range(0, 3); 
		DataControllerEditor.citiesRandom = UnityEngine.Random.Range(0, 2);
	}


	//In World Menu Second: This function für the run-time in days textfield will change the end date calendar textfield and the 
	//end time of day textfield - and if the user changes things inside those fields the run-time textfield will be changed - 
	//so that you can put a number of days in there and it will calculate the right calendar date for you. 
	//Because run-time in days will be set to 120 by standard (4 months) the function will also on start of the CreationScene
	//set a End Calendar Date based on the real world system time and the 120 days run-time.
	public void RunTimeDays () {

	}

	//In Climate Menu: This little function will deactivate the panel for the tyle types of a climate zone, if the climate zone is set
	//to zero
	public void DeactivateTileTypes () {
		/* if (climateColdField <= 0) {
			PanelColdTileTypes.SetActive (false);
		} else {
			PanelColdTileTypes.SetActive (true);
		}

		if (climateWarmField <= 0) { 
			PanelWarmTileTypes.SetActive(false);
		} else {
		PanelColdTileTypes.SetActive (true);
		}

		if (climateMediterraneanField <= 0) {
			PanelMediterraneanTileTypes.SetActive(false);
		} else {
			PanelColdTileTypes.SetActive (true);
		}

		if (climateDesertField <= 0) {
			PanelDesertTileTypes.SetActive(false);
		} else {
			PanelColdTileTypes.SetActive (true);
		}

		if (climateTropicField <= 0) {
			PanelTropicTileTypes.SetActive(false);
		} else {
			PanelColdTileTypes.SetActive (true);
		} */
	}

	//In NPC Menu: This little function will set NPC per Realm Quantity automaticalle to 1 every time, the "Only one NPC in the World?" 
	//toggle is set true. And every time someone puts an number in "NPC per Realm Quantity" the 'highlander-toggle' will be set to false
	public void HighlanderNPC () {

	}


	//This will be used to commit all current data to the DataControllerEditor when the scene gets changed to the world or realm scene.
	public void OnDestroy()
	{

	}
}
