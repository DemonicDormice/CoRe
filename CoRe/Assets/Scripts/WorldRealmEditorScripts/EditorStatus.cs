using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In this script and the related GameObject "EditorStatus" are all the things stored, which get inputted into the 
//creation menus and which the editor needs to create a world and the realms in the next szenes.

public class EditorStatus : MonoBehaviour {

	//Variables we get from World Menu
	public string worldName;
	public int worldSizeX = 20;
	public int worldSizeY = 20;
	public int realmSizeX = 50;
	public int realmSizeY = 50;

	public int startCalendarDate;
	public int startTimeOfDay; //TODO: 19 Uhr bzw. 7:00 pm setzen
	public int endCalendarDate; //TODO: wird am Anfang automatisch berechnet aus Systemzeit und 183 Tage run-time.
	public int endTimeOfDay;

	public int randomSeed = 1;


	//Variables we get from Climate Menu
	public int portionColdClimate = 20;
	public int portionWarmClimate = 20;
	public int portionMediterraneanClimate = 20;
	public int portionDesertClimate = 20;
	public int portionTropicClimate = 20;

	public bool activeColdPlain = true;
	public bool activeColdHill = true;
	public bool activeColdMountain = true;
	public bool activeColdConiferous = true;
	public bool activeColdBarren = true;
	public bool activeWarmPlain = true;
	public bool activeWarmHill = true;
	public bool activeWarmMountain = true;
	public bool activeWarmConiferous = true;
	public bool activeWarmDeciduous = true;
	public bool activeWarmBarren = true;
	public bool activeMediterraneanPlain = true;
	public bool activeMediterraneanHill = true;
	public bool activeMediterraneanMountain = true;
	public bool activeMediterraneanDeciduous = true;
	public bool activeMediterraneanBarren = true;
	public bool activeDesertPlain = true;
	public bool activeDesertHill = true;
	public bool activeDesertMountain = true;
	public bool activeDesertDeciduous = true;
	public bool activeDesertHammada = true;
	public bool activeDesertSand = true;
	public bool activeTropicPlain = true;
	public bool activeTropicHill = true;
	public bool activeTropicMountain = true;
	public bool activeTropicDeciduous = true;
	public bool activeTropicBarren = true;
	public bool activeWater = true;

	//Variables we get from NPC Menu
	public int villagesRealm = 10;
	public int castlesRealm = 3;
	public int citiesRealm = 2;
	public int villagesRandom = 0;
	public int castlesRandom = 0;
	public int citiesRandom = 0;

	public bool highlanderNPC = true; //All settlements and npc armies are controlled by one and only one KI-Player - ignoring cultures and realms etc.
	public int quantityNPC = 1; //If highlandernNPC is true, quantityNPC is automatically set to 1

	public bool activeCultureNordic = true;
	public bool activeCultureMedieval = true;
	public bool activeCultureAncient = true;
	public bool activeCultureAsian = true;
	public bool activeCultureAfrican = true;
	public bool activeCultureHorde = true;

	public bool activeUnitSpecial = true;
	public bool activeUnitElite = true;
	public bool activeUnitAntiUnborn = true;



	// Use this for initialization
	void Start () {

		GameObject.DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//In World Menu: This function will calculate and change the world size and realm size depending on expected players for
	//the next round. This will just fill the textfields with fitting numbers, the user still has to confirm
	//or can change the numbers.
	void PlayerExpectation () {

	}

	//In World Menu: This function für the run-time in days textfield will change the end date calendar textfield and the 
	//end time of day textfield - and if the user changes things inside those fields the run-time textfield will be changed - 
	//so that you can put a number of days in there and it will calculate the right calendar date for you. 
	//Because run-time in days will be set to 183 by standard (6 months) the function will also on start of the CreationScene
	//set a End Calendar Date based on the real world system time and the 183 days run-time.
	void RunTimeDays () {

	}

	//In NPC Menu: This little function will set NPC per Realm Quantity automaticalle to 1 every time, the "Only one NPC in the World?" 
	//toggle is set true. And every time someone puts an number in "NPC per Realm Quantity" the 'highlander-toggle' will set on false
	void HighlanderNPC () {

	}
}
