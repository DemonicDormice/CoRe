using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//In this script and the related GameObject "DataControllerEditor" are all the things stored, which get inputted into the 
//creation menus and which the editor needs to create a world and the realms in the next szenes.


public class DataControllerEditor : MonoBehaviour {
	
	public static DataControllerEditor instance;

	private WorldData world;

	//Variables we get from World Menu
	public static string worldName;
	public static int worldSizeX = 20;
	public static int worldSizeY = 20;
	public static int realmSizeX = 50;
	public static int realmSizeY = 50;

	public static int startCalendarDate;
	public static int startTimeOfDay; //TODO: 19 Uhr bzw. 7:00 pm setzen
	public static bool startOnCreation = false;
	public static int endCalendarDate; //TODO: wird am Anfang automatisch berechnet aus Systemzeit und 183 Tage run-time.
	public static int endTimeOfDay;

	public static int randomCreationSeed = 1;


	//Variables we get from Climate Menu
	public static int portionColdClimate = 20;
	public static int portionWarmClimate = 20;
	public static int portionMediterraneanClimate = 20;
	public static int portionDesertClimate = 20;
	public static int portionTropicClimate = 20;

	public static bool activeColdPlain = true;
	public static bool activeColdHill = true;
	public static bool activeColdMountain = true;
	public static bool activeColdConiferous = true;
	public static bool activeColdBarren = true;
	public static bool activeWarmPlain = true;
	public static bool activeWarmHill = true;
	public static bool activeWarmMountain = true;
	public static bool activeWarmConiferous = true;
	public static bool activeWarmDeciduous = true;
	public static bool activeWarmBarren = true;
	public static bool activeMediterraneanPlain = true;
	public static bool activeMediterraneanHill = true;
	public static bool activeMediterraneanMountain = true;
	public static bool activeMediterraneanDeciduous = true;
	public static bool activeMediterraneanBarren = true;
	public static bool activeDesertPlain = true;
	public static bool activeDesertHill = true;
	public static bool activeDesertMountain = true;
	public static bool activeDesertDeciduous = true;
	public static bool activeDesertHammada = true;
	public static bool activeDesertSand = true;
	public static bool activeTropicPlain = true;
	public static bool activeTropicHill = true;
	public static bool activeTropicMountain = true;
	public static bool activeTropicDeciduous = true;
	public static bool activeTropicBarren = true;
	public static bool activeWater = true;

	//Variables we get from NPC Menu
	public static int villagesRealm = 10;
	public static int castlesRealm = 3;
	public static int citiesRealm = 2;
	public static int villagesRandom = 0;
	public static int castlesRandom = 0;
	public static int citiesRandom = 0;

	public static bool highlanderNPC = true; //All settlements and npc armies are controlled by one and only one AI-Player - ignoring cultures and realms etc.
	public static int quantityNPC = 0; //If highlandernNPC is true, quantityNPC is automatically set to 0

	public static bool activeCultureNordic = true;
	public static bool activeCultureMedieval = true;
	public static bool activeCultureAncient = true;
	public static bool activeCultureAsian = true;
	public static bool activeCultureAfrican = true;
	public static bool activeCultureHorde = true;

	public static bool activeUnitSpecial = true;
	public static bool activeUnitElite = true;
	public static bool activeUnitAntiUnborn = true;


	void Awake(){
		instance = this;
	}

	void Start () {

		GameObject.DontDestroyOnLoad (this.gameObject);
	}

	/* 	public void createWorld(string name, string endtime, int xsize, int ysize, float coldC, float warmC, float medC, float desertC, float tropicC){
		world = new WorldData ();
		world.name = name;
		//Call Random World Creation...

	} */
}
