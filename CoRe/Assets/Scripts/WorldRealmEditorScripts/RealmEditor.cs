using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RealmEditor : MonoBehaviour {

	public GameObject selectedObject;
	public GameObject someObjects;
	public GameObject settlementGameObject; 
	public GameObject newSettlement;

	public GameObject SettlementPlaceholderPrefab;
	//public GameObject PlaceholderPrefab;

	public GameObject VillageNordicForestPrefab;
	public GameObject VillageNordicPlainPrefab;
	public GameObject VillageNordicHillPrefab;
	public GameObject VillageNordicMountainPrefab;

	public GameObject VillageMedievalForestPrefab;
	public GameObject VillageMedievalPlainPrefab;
	public GameObject VillageMedievalHillPrefab;
	public GameObject VillageMedievalMountainPrefab;

	public GameObject VillageAncientForestPrefab;
	public GameObject VillageAncientPlainPrefab;
	public GameObject VillageAncientHillPrefab;
	public GameObject VillageAncientMountainPrefab;

	public GameObject VillageAsianForestPrefab;
	public GameObject VillageAsianPlainPrefab;
	public GameObject VillageAsianHillPrefab;
	public GameObject VillageAsianMountainPrefab;

	public GameObject VillageAfricanForestPrefab;
	public GameObject VillageAfricanPlainPrefab;
	public GameObject VillageAfricanHillPrefab;
	public GameObject VillageAfricanMountainPrefab;

	public GameObject VillageHordeForestPrefab;
	public GameObject VillageHordePlainPrefab;
	public GameObject VillageHordeHillPrefab;
	public GameObject VillageHordeMountainPrefab;

	public GameObject CastleNordicBarrenPrefab;
	public GameObject CastleNordicForestPrefab;
	public GameObject CastleNordicPlainPrefab;
	public GameObject CastleNordicHillPrefab;
	public GameObject CastleNordicMountainPrefab;

	public GameObject CastleMedievalBarrenPrefab;
	public GameObject CastleMedievalForestPrefab;
	public GameObject CastleMedievalPlainPrefab;
	public GameObject CastleMedievalHillPrefab;
	public GameObject CastleMedievalMountainPrefab;

	public GameObject CastleAncientBarrenPrefab;
	public GameObject CastleAncientForestPrefab;
	public GameObject CastleAncientPlainPrefab;
	public GameObject CastleAncientHillPrefab;
	public GameObject CastleAncientMountainPrefab;

	public GameObject CastleAsianBarrenPrefab;
	public GameObject CastleAsianForestPrefab;
	public GameObject CastleAsianPlainPrefab;
	public GameObject CastleAsianHillPrefab;
	public GameObject CastleAsianMountainPrefab;

	public GameObject CastleAfricanBarrenPrefab;
	public GameObject CastleAfricanForestPrefab;
	public GameObject CastleAfricanPlainPrefab;
	public GameObject CastleAfricanHillPrefab;
	public GameObject CastleAfricanMountainPrefab;

	public GameObject CastleHordeBarrenPrefab;
	public GameObject CastleHordeForestPrefab;
	public GameObject CastleHordePlainPrefab;
	public GameObject CastleHordeHillPrefab;
	public GameObject CastleHordeMountainPrefab;

	public GameObject CityNordicForestPrefab;
	public GameObject CityNordicPlainPrefab;
	public GameObject CityNordicHillPrefab;
	public GameObject CityNordicMountainPrefab;

	public GameObject CityMedievalForestPrefab;
	public GameObject CityMedievalPlainPrefab;
	public GameObject CityMedievalHillPrefab;
	public GameObject CityMedievalMountainPrefab;

	public GameObject CityAncientForestPrefab;
	public GameObject CityAncientPlainPrefab;
	public GameObject CityAncientHillPrefab;
	public GameObject CityAncientMountainPrefab;

	public GameObject CityAsianForestPrefab;
	public GameObject CityAsianPlainPrefab;
	public GameObject CityAsianHillPrefab;
	public GameObject CityAsianMountainPrefab;

	public GameObject CityAfricanForestPrefab;
	public GameObject CityAfricanPlainPrefab;
	public GameObject CityAfricanHillPrefab;
	public GameObject CityAfricanMountainPrefab;

	public GameObject CityHordeForestPrefab;
	public GameObject CityHordePlainPrefab;
	public GameObject CityHordeHillPrefab;
	public GameObject CityHordeMountainPrefab;

	//Extended Panel
	public GameObject PanelExtended;

	//Toggle Game Objects
	public Toggle isToggle_None;
	public Toggle isToggle_All;
	public Toggle isToggle_Cold;
	public Toggle isToggle_Warm;
	public Toggle isToggle_Mediterranean;
	public Toggle isToggle_Desert;
	public Toggle isToggle_Tropic;
	public Toggle isToggle_Nordic;
	public Toggle isToggle_Medieval;	
	public Toggle isToggle_Ancient;
	public Toggle isToggle_Asian;
	public Toggle isToggle_African;
	public Toggle isToggle_Horde;

	//Input Fields Game Objects
	public InputField populationInputField;
	public InputField settlementNameField;

	//Slider Game Objects
	public Slider populationSlider;

	//Dropdown Game Objects
	public Dropdown dropdownTileEditor;
	public Dropdown dropdownNPCID;
	public Dropdown dropdownLevelSettlement;
	public Dropdown dropdownSlot1Settlement;
	public Dropdown dropdownSlot2Settlement;
	public Dropdown dropdownSlot3Settlement;
	public Dropdown dropdownArmyTypeSettlement;

	private RealmMap realmMap;

	//Standard
	public Mesh MeshWater;
	public Material MatWater;

	//Cold climate
	public Mesh MeshColdPlain;
	public Material MatColdPlain;
	public Mesh MeshColdHill;
	public Material MatColdHill;
	public Mesh MeshColdMountain;
	public Material MatColdMountain;
	public Mesh MeshColdConiferous;
	public Material MatColdConiferous;
	public Mesh MeshColdBarren;
	public Material MatColdBarren;

	//Warm climate
	public Mesh MeshWarmPlain;
	public Material MatWarmPlain;
	public Mesh MeshWarmHill;
	public Material MatWarmHill;
	public Mesh MeshWarmMountain;
	public Material MatWarmMountain;
	public Mesh MeshWarmConiferous;
	public Material MatWarmConiferous;
	public Mesh MeshWarmDeciduous;
	public Material MatWarmDeciduous;
	public Mesh MeshWarmBarren;
	public Material MatWarmBarren;

	//Mediterranean climate
	public Mesh MeshMediterraneanPlain;
	public Material MatMediterraneanPlain;
	public Mesh MeshMediterraneanHill;
	public Material MatMediterraneanHill;
	public Mesh MeshMediterraneanMountain;
	public Material MatMediterraneanMountain;
	public Mesh MeshMediterraneanDeciduous;
	public Material MatMediterraneanDeciduous;
	public Mesh MeshMediterraneanBarren;
	public Material MatMediterraneanBarren;

	//Desert climate
	public Mesh MeshDesertPlain;
	public Material MatDesertPlain;
	public Mesh MeshDesertHill;
	public Material MatDesertHill;
	public Mesh MeshDesertMountain;
	public Material MatDesertMountain;
	public Mesh MeshDesertDeciduous;
	public Material MatDesertDeciduous;
	public Mesh MeshDesertHammada;
	public Material MatDesertHammada;
	public Mesh MeshDesertSand;
	public Material MatDesertSand;

	//Tropic climate
	public Mesh MeshTropicPlain;
	public Material MatTropicPlain;
	public Mesh MeshTropicHill;
	public Material MatTropicHill;
	public Mesh MeshTropicMountain;
	public Material MatTropicMountain;
	public Mesh MeshTropicDeciduous;
	public Material MatTropicDeciduous;
	public Mesh MeshTropicBarren;
	public Material MatTropicBarren;

	/*
	//Mostly to check what mesh or material a hex has and to act with for example settlements accordingly
	//First get the renderer from the selected object
	MeshRenderer selectedRenderer = selectedObject.GetComponentInChildren<MeshRenderer>().name;
	//Second get the material from the renderer of the selected object
	Material selectedMaterial = selectedRenderer.material;
	//now you can build if statements with the material like "if(selectedMaterial.name == "MatWater")
	*/


	//The following is for the settlement placement with the editor AND for the first time the random generator creates the map 
	bool settlementVillage = false;
	bool settlementCastle = false;
	bool settlementCity = false;
	bool cultureNONE = true;
	bool cultureNordic = false;
	bool cultureMedieval = false;
	bool cultureAncient = false;
	bool cultureAsian = false;
	bool cultureAfrican = false;
	bool cultureHorde = false;
	string settlementType = null;






	void Start ()
	{
		ToggleNone (true);

		globalPrefabs.LoadAll ("Prefabs/SettlementPrefabs");

		//	PopulateList_HexTileTypes ();
		//realmMap = GetComponentInChildren<MeshRenderer>();
		//RealmMap realmMap = hexGameObject.GetComponentsInChildren<MeshRenderer>();
		//ChangeHex = GetComponent<Renderer>();
		//ChangeHex.enabled = true;
		PanelExtended.SetActive(true);

		isToggle_None.onValueChanged.AddListener(ToggleNone);
		isToggle_All.onValueChanged.AddListener(ToggleAll);
		isToggle_Cold.onValueChanged.AddListener(ToggleCold);
		isToggle_Warm.onValueChanged.AddListener(ToggleWarm);
		isToggle_Mediterranean.onValueChanged.AddListener(ToggleMediterranean);
		isToggle_Desert.onValueChanged.AddListener(ToggleDesert);
		isToggle_Tropic.onValueChanged.AddListener(ToggleTropic);
		isToggle_Nordic.onValueChanged.AddListener(ToggleNordic);
		isToggle_Medieval.onValueChanged.AddListener(ToggleMedieval);
		isToggle_Ancient.onValueChanged.AddListener(ToggleAncient);
		isToggle_Asian.onValueChanged.AddListener(ToggleAsian);
		isToggle_African.onValueChanged.AddListener(ToggleAfrican);
		isToggle_Horde.onValueChanged.AddListener(ToggleHorde);

		dropdownTileEditor.onValueChanged.AddListener(PopulationSlider);
		dropdownTileEditor.onValueChanged.AddListener(LevelByDropdownSettlementType);
		dropdownLevelSettlement.onValueChanged.AddListener(PopulationSlider);
		populationSlider.onValueChanged.AddListener(PopulationToInputField);
		populationInputField.onValueChanged.AddListener(PopulationToSlider);


		List<string> SettlementLevels = new List<string>();
		SettlementLevels.Clear ();
		SettlementLevels.Add( "0" );
		SettlementLevels.Add( "1" );
		SettlementLevels.Add( "2" );
		SettlementLevels.Add( "3" );
		SettlementLevels.Add( "4" );
		SettlementLevels.Add( "5" );
		SettlementLevels.Add( "6" );
		SettlementLevels.Add( "7" );
		SettlementLevels.Add( "8" );
		SettlementLevels.Add( "9" );
		SettlementLevels.Add( "10" );
		dropdownLevelSettlement.AddOptions (SettlementLevels);
		dropdownLevelSettlement.value = 0;
		dropdownLevelSettlement.enabled = false;
		dropdownNPCID.enabled = false;
		settlementNameField.enabled = false;
		populationSlider.enabled = false;
		populationInputField.enabled = false;
		dropdownSlot1Settlement.enabled = false;
		dropdownSlot2Settlement.enabled = false;
		dropdownSlot3Settlement.enabled = false;
		dropdownArmyTypeSettlement.enabled = false;

	}

	public void PopulationSlider(int input) 
	{ 
		int settlementMultiplier = 0;

		if (dropdownTileEditor.captionText.text.Contains ("Village"))
		{
			settlementMultiplier = 10;
		} else if (dropdownTileEditor.captionText.text.Contains ("Castle"))
		{
			settlementMultiplier = 5;
		} else if (dropdownTileEditor.captionText.text.Contains ("City"))
		{
			settlementMultiplier = 500;
		}

		int population1 = int.Parse (dropdownLevelSettlement.captionText.text) * 1 * settlementMultiplier; 
		int population2 = int.Parse (dropdownLevelSettlement.captionText.text) * 2 * settlementMultiplier; 
		int population3 = int.Parse (dropdownLevelSettlement.captionText.text) * 3 * settlementMultiplier; 
		int population4 = int.Parse (dropdownLevelSettlement.captionText.text) * 4 * settlementMultiplier;
		int population5 = int.Parse (dropdownLevelSettlement.captionText.text) * 5 * settlementMultiplier; 
		int population6 = int.Parse (dropdownLevelSettlement.captionText.text) * 6 * settlementMultiplier; 
		int population7 = int.Parse (dropdownLevelSettlement.captionText.text) * 7 * settlementMultiplier; 
		int population8 = int.Parse (dropdownLevelSettlement.captionText.text) * 8 * settlementMultiplier; 
		int population9 = int.Parse (dropdownLevelSettlement.captionText.text) * 9 * settlementMultiplier; 
		int population10 = int.Parse (dropdownLevelSettlement.captionText.text) * 10 * settlementMultiplier;  

		populationSlider.minValue = 0;
		populationSlider.maxValue = population10;
		populationSlider.value = population10;

		populationInputField.text = "" + populationSlider.value;

		//populationInputField.text = value.ToString(); 
	}

	public void PopulationToInputField (float input)
	{
		populationInputField.text = "" + populationSlider.value;
	}

	public void PopulationToSlider (string input)
	{
		if (populationInputField.text != "") {
			populationSlider.value = float.Parse (populationInputField.text);
		} else {
			populationSlider.value = 0;
		}
	}

	public void LevelByDropdownSettlementType (int input)
	{
		if (dropdownTileEditor.captionText.text.Contains ("Village") | dropdownTileEditor.captionText.text.Contains ("Castle") | dropdownTileEditor.captionText.text.Contains ("City"))
		{
			dropdownLevelSettlement.enabled = true;
			dropdownLevelSettlement.value = 1;

			dropdownNPCID.enabled = true;
			settlementNameField.enabled = true;
			populationSlider.enabled = true;
			populationInputField.enabled = true;
			dropdownSlot1Settlement.enabled = true;
			dropdownSlot2Settlement.enabled = true;
			dropdownSlot3Settlement.enabled = true;
			dropdownArmyTypeSettlement.enabled = true;
		} else 
		{
			dropdownLevelSettlement.value = 0;
			dropdownLevelSettlement.enabled = false;
			dropdownNPCID.enabled = false;
			settlementNameField.enabled = false;
			populationSlider.enabled = false;
			populationInputField.enabled = false;
			dropdownSlot1Settlement.enabled = false;
			dropdownSlot2Settlement.enabled = false;
			dropdownSlot3Settlement.enabled = false;
			dropdownArmyTypeSettlement.enabled = false;
		}
	}

	//public void PopulationInputField (string text) { populationSlider.value = System.Convert.ToSingle(text); }


	//dropdownTileEditor.captionText.text == "Cold Icy Mountain"

	//public Dropdown dropdownPopulationSettlement;
	//public Dropdown dropdownSlot1Settlement;
	//public Dropdown dropdownSlot2Settlement;
	//public Dropdown dropdownSlot3Settlement;
	//public Dropdown dropdownArmyTypeSettlement;


	void Update()
	{

		/* if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");
			/*Renderer rs = selectedObject.GetComponentInChildren<Renderer>();
			Material[] mats = rs.materials; 
			foreach(Material mat in mats) { 
				mat.color = Color.red;
			}
		}

		if (Input.GetMouseButtonDown (1))
			Debug.Log ("Pressed right click.");

		if (Input.GetMouseButtonDown (2))
			Debug.Log ("Pressed middle click."); */

		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		if (Physics.Raycast (mouseRay, out hitInfo)) {
			//Debug.Log ("Mouse is over: " + hitInfo.collider.transform.parent.name);
			GameObject hitChange_Hex = hitInfo.transform.parent.gameObject;

			if (hitChange_Hex.GetComponent<TileData> () != null) {
				// We are over a hex
				MouseOver_HexChange (hitChange_Hex);
			}

			SelectObject (hitChange_Hex);
		} else {
			//ClearSelection ();
		}

		if (isToggle_Nordic == false & isToggle_Medieval == false & isToggle_Ancient == false & isToggle_Asian == false & isToggle_African == false & isToggle_Horde == false) 
		{ 
			PanelExtended.SetActive (false);
		} else if (isToggle_Nordic == true | isToggle_Medieval == true | isToggle_Ancient == true | isToggle_Asian == true | isToggle_African == true | isToggle_Horde == true) 
		{
			PanelExtended.SetActive (true);
		} 
	}

	void SelectObject(GameObject obj) {

		selectedObject = obj;

		if (Input.GetMouseButton (1)) {
			//this will be activated every frame on the right mouse button down. That makes 'painting' like with a brush possible. But is horrible with settlements.
			//because of this we have to differentiate between MouseDown/MouseHold and ButtonUp and the dropdownTileEditor-Text...

			if (dropdownTileEditor.captionText.text == "" | dropdownTileEditor.captionText.text.Contains ("None") | dropdownTileEditor.captionText.text.Contains ("Village") | dropdownTileEditor.captionText.text.Contains ("Castle") | dropdownTileEditor.captionText.text.Contains ("City")) {
				
			} else {
				SetTerrain ();
			}
		}

		if (Input.GetMouseButtonUp (1)) {
			//this will only be activated on the right mouse button getting up. That makes it possible to only build settlements once per click.
			//TODO: If there is already a settlement on a tile, that should be destroyed by a right click (the user than can set a new settlement with a new right click)

			//SetSettlement ();
		}

		if (Input.GetMouseButtonUp (1)) {

			EditorSettlementPlacer ();
		}
	}


	public void EditorSettlementPlacer()
	{
		if (dropdownTileEditor.captionText.text.Contains ("Village"))
			settlementVillage = true;
		if (dropdownTileEditor.captionText.text.Contains ("Castle"))
			settlementCastle = true;
		if (dropdownTileEditor.captionText.text.Contains ("City"))
			settlementCity = true;


		if (cultureNONE = true & dropdownTileEditor.captionText.text.Contains ("Nordic")) {
			cultureNordic = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & dropdownTileEditor.captionText.text.Contains ("Medieval")) {
			cultureMedieval = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & dropdownTileEditor.captionText.text.Contains ("Ancient")) {
			cultureAncient = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & dropdownTileEditor.captionText.text.Contains ("Asian")) {
			cultureAsian = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & dropdownTileEditor.captionText.text.Contains ("African")) {
			cultureAfrican = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & dropdownTileEditor.captionText.text.Contains ("Horde")) {
			cultureHorde = true;
			cultureNONE = false;
		}

		else if (cultureNONE = true & selectedObject.tag.Contains ("Cold")) {
			cultureNordic = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & selectedObject.tag.Contains ("Warm")) {
			cultureMedieval = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & selectedObject.tag.Contains ("Mediterranean")) {
			cultureAncient = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & selectedObject.tag.Contains ("Desert")) {
			cultureHorde = true;
			cultureNONE = false;
		}
		else if (cultureNONE = true & selectedObject.tag.Contains ("Tropic")) {
			cultureAfrican = true;
			cultureNONE = false;
		}

		if (settlementVillage != true & settlementCastle != true & settlementCity != true) {
			return;
		} else {
			SetTypeSettlement ();
		}
	}

	public void SetTypeSettlement()
	{
		if (selectedObject.tag.Contains ("Water")) //This will prevent from building on water
		{
			return;
		} else if (selectedObject.GetComponentInChildren<SettlementData>() != null) //This gives the option to destroy existing settlements on click
		{
			//TODO: Destroy the settlement child of the selected Object - and only this
		} else {

			if (settlementVillage == true)
				settlementType = "Village";
			if (settlementCastle == true)
				settlementType = "Castle";
			if (settlementCity == true)
				settlementType = "City";

			settlementGameObject = (GameObject)Instantiate (SettlementPlaceholderPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform.parent);
			settlementGameObject.tag = settlementType;

			SetCultureToSettlement ();
		}
	}

	public void SetCultureToSettlement()
	{
		if (selectedObject.tag.Contains ("Water")) {
			Destroy (settlementGameObject);
			return;
		} else {

			if (cultureNordic == true)
				settlementGameObject.tag = settlementGameObject.tag + "Nordic";
			if (cultureMedieval == true)
				settlementGameObject.tag = settlementGameObject.tag + "Medieval";
			if (cultureAncient == true)
				settlementGameObject.tag = settlementGameObject.tag + "Ancient";
			if (cultureAsian == true)
				settlementGameObject.tag = settlementGameObject.tag + "Asian";
			if (cultureAfrican == true)
				settlementGameObject.tag = settlementGameObject.tag + "African";
			if (cultureHorde == true)
				settlementGameObject.tag = settlementGameObject.tag + "Horde";

			SetTerrainToSettlement ();
		}
	}

	public void SetTerrainToSettlement()
	{
		if (selectedObject.tag.Contains ("Water")) {
			Destroy (settlementGameObject);
			return;
		} else {

			if (selectedObject.tag.Contains ("Plain"))
				settlementGameObject.tag = settlementGameObject.tag + "Plain";
			if (selectedObject.tag.Contains ("Deciduous") | selectedObject.tag.Contains ("Coniferous"))
				settlementGameObject.tag = settlementGameObject.tag + "Forest";
			if (selectedObject.tag.Contains ("Hill"))
				settlementGameObject.tag = settlementGameObject.tag + "Hill";
			if (selectedObject.tag.Contains ("Mountain"))
				settlementGameObject.tag = settlementGameObject.tag + "Mountain";

			if ((settlementType == "Village" | settlementType == "City") & (selectedObject.tag.Contains ("Barren") | selectedObject.tag.Contains ("Hammada") | selectedObject.tag.Contains ("Sand")))
			{	Destroy (settlementGameObject);
				return;
			} else if (selectedObject.tag.Contains ("Barren") | selectedObject.tag.Contains ("Hammada") | selectedObject.tag.Contains ("Sand"))
			{
				settlementGameObject.tag = settlementGameObject.tag + "Barren";
			}

			SetStatsToSettlement ();
		}
	}


	public void SetStatsToSettlement()
	{   
		if (selectedObject.tag.Contains ("Water")) {
			Destroy (settlementGameObject);
			return;
		} else {

			string SettlementSubtypeName = settlementGameObject.tag;

			settlementGameObject = (GameObject)Instantiate (globalPrefabs.getPrefab(SettlementSubtypeName + "Prefab"), selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
			settlementGameObject.tag = SettlementSubtypeName;

			//newSettlement = (GameObject)Instantiate (PrefabDictionary ["" + PlaceholderPrefabName], selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
			//newSettlement.name = PlaceholderPrefab;
			//PlaceholderPrefab.name = "PlaceholderPrefab";
			//Destroy (settlementGameObject);

			if (settlementGameObject != null) {
				settlementGameObject.GetComponent<SettlementData> ().tileX = selectedObject.GetComponent<TileData> ().tileX;
				settlementGameObject.GetComponent<SettlementData> ().tileY = selectedObject.GetComponent<TileData> ().tileY;
				settlementGameObject.GetComponent<SettlementData> ().realmX = selectedObject.GetComponent<TileData> ().realmX;
				settlementGameObject.GetComponent<SettlementData> ().realmY = selectedObject.GetComponent<TileData> ().realmY;
				//settlementGameObject.GetComponent<SettlementData> ().worldID = ;
				//settlementGameObject.GetComponent<SettlementData> ().playerID = ;
				//settlementGameObject.GetComponent<SettlementData> ().nameSettlement = ;
				settlementGameObject.GetComponent<SettlementData> ().typeSettlement = SettlementSubtypeName;
				settlementGameObject.GetComponent<SettlementData> ().levelSettlement = dropdownLevelSettlement.value;
				settlementGameObject.GetComponent<SettlementData> ().populationSettlement = int.Parse(populationInputField.text);
				//settlementGameObject.GetComponent<SettlementData> ().settlementSlot1 = ;
				//settlementGameObject.GetComponent<SettlementData> ().settlementSlot2 = ;
				//settlementGameObject.GetComponent<SettlementData> ().settlementSlot3 = ;
				//settlementGameObject.GetComponent<SettlementData> ().armyID = ;

			}
		}

		//Reset all
		settlementVillage = false;
		settlementCastle = false;
		settlementCity = false;
		cultureNONE = true;
		cultureNordic = false;
		cultureMedieval = false;
		cultureAncient = false;
		cultureAsian = false;
		cultureAfrican = false;
		cultureHorde = false;
		settlementType = null;
	}

	public void SetTerrain()
	{

		GameObject newHexGameObject;
		string newTerrain = null;

		if (dropdownTileEditor.captionText.text == "Cold Icy Mountain") {
			newTerrain = "ColdMountain";
		}
		if (dropdownTileEditor.captionText.text == "Cold Woodland Hill") {
			newTerrain = "ColdHill";
		}
		if (dropdownTileEditor.captionText.text == "Cold Winter Forest") {
			newTerrain = "ColdConiferous";
		}
		if (dropdownTileEditor.captionText.text == "Cold Sparse Grassland") {
			newTerrain = "ColdPlain";
		}
		if (dropdownTileEditor.captionText.text == "Cold Tundra") {
			newTerrain = "ColdBarren";
		}

		if (dropdownTileEditor.captionText.text == "Warm Mountain") {
			newTerrain = "WarmMountain";
		}
		if (dropdownTileEditor.captionText.text == "Warm Hill") {
			newTerrain = "WarmHill";
		}
		if (dropdownTileEditor.captionText.text == "Warm Coniferous Forest") {
			newTerrain = "WarmConiferous";
		}
		if (dropdownTileEditor.captionText.text == "Warm Deciduous Forest") {
			newTerrain = "WarmDeciduous";
		}
		if (dropdownTileEditor.captionText.text == "Warm Grassland") {
			newTerrain = "WarmPlain";
		}
		if (dropdownTileEditor.captionText.text == "Warm Barren Plain") {
			newTerrain = "WarmBarren";
		}

		if (dropdownTileEditor.captionText.text == "Mediterranean Mountain") {
			newTerrain = "MediterraneanMountain";
		}
		if (dropdownTileEditor.captionText.text == "Mediterranean Coniferous Hill") {
			newTerrain = "MediterraneanHill";
		}
		if (dropdownTileEditor.captionText.text == "Mediterranean Deciduous Forest") {
			newTerrain = "MediterraneanDeciduous";
		}
		if (dropdownTileEditor.captionText.text == "Mediterranean Grassland") {
			newTerrain = "MediterraneanPlain";
		}
		if (dropdownTileEditor.captionText.text == "Mediterranean Barren") {
			newTerrain = "MediterraneanBarren";
		}

		if (dropdownTileEditor.captionText.text == "Desert Mountain") {
			newTerrain = "DesertMountain";
		}
		if (dropdownTileEditor.captionText.text == "Desert Trees") {
			newTerrain = "DesertDeciduous";
		}
		if (dropdownTileEditor.captionText.text == "Desert Oasis") {
			newTerrain = "DesertPlain";
		}
		if (dropdownTileEditor.captionText.text == "Desert Hammada Stonedesert") {
			newTerrain = "DesertHammada";
		}
		if (dropdownTileEditor.captionText.text == "Desert Sanddesert") {
			newTerrain = "DesertSand";
		}
		if (dropdownTileEditor.captionText.text == "Desert Dunes") {
			newTerrain = "DesertHill";
		}

		if (dropdownTileEditor.captionText.text == "Tropic Mountain") {
			newTerrain = "TropicMountain";
		}
		if (dropdownTileEditor.captionText.text == "Tropic Jungle Hill") {
			newTerrain = "TropicHill";
		}
		if (dropdownTileEditor.captionText.text == "Tropic Jungle Forest") {
			newTerrain = "TropicDeciduous";
		}
		if (dropdownTileEditor.captionText.text == "Tropic Plain-Glade") {
			newTerrain = "TropicPlain";
		}
		if (dropdownTileEditor.captionText.text == "Tropic Barren") {
			newTerrain = "TropicBarren";
		}

		if (dropdownTileEditor.captionText.text == "Water") {
			newTerrain = "Water";
		}


		newHexGameObject = (GameObject)Instantiate(globalPrefabs.getPrefab("Hex_" + newTerrain), selectedObject.transform.position, Quaternion.identity, selectedObject.transform); //this gives every tile the generic tag "Hex_XXX" where X is the same as the material, which defines the tile perfectly. Later it is possible to ask tag.Contains() for example tag.Contains("Warm"), which gets you all tiles of this tag type
		newHexGameObject.transform.SetParent (selectedObject.transform.parent);
		newHexGameObject.name = selectedObject.name;
		//For making sure the hex knows its position on the map etc.
		newHexGameObject.GetComponent<TileData> ().tileX = selectedObject.GetComponent<TileData> ().tileX;
		newHexGameObject.GetComponent<TileData> ().tileY = selectedObject.GetComponent<TileData> ().tileY;
		//And for making sure it knows its world position, ids and type
		newHexGameObject.GetComponent<TileData> ().realmX = selectedObject.GetComponent<TileData> ().realmX;
		newHexGameObject.GetComponent<TileData> ().realmY = selectedObject.GetComponent<TileData> ().realmY;
		//newHexGameObject.GetComponent<TileData> ().realmID = selectedObject.GetComponent<TileData> ().realmID;
		//newHexGameObject.GetComponent<TileData> ().tileID = selectedObject.GetComponent<TileData> ().tileID;
		newHexGameObject.GetComponent<TileData> ().typeTile = newHexGameObject.tag;
		Destroy (selectedObject);
	}




	public void SettlementRandomPlacement()
	{
		ToggleAll (true);

		int numberVillages = DataControllerEditor.villagesRealm + Random.Range (0, DataControllerEditor.villagesRandom);
		int numberCastles = DataControllerEditor.castlesRealm + Random.Range (0, DataControllerEditor.castlesRandom);
		int numberCities = DataControllerEditor.citiesRealm + Random.Range (0, DataControllerEditor.citiesRandom);

		int numberSettlements = numberVillages + numberCastles + numberCities; 

		//for (int settlements = 0; settlements < numberSettlements; settlements++) {

		//string [] terrainArray = { "ColdPlain", "ColdHill" };

		List<GameObject> foundPlaces = new List<GameObject>();
		foundPlaces.AddRange (GameObject.FindGameObjectsWithTag ("Hex_ColdPlain"));
		foundPlaces.AddRange (GameObject.FindGameObjectsWithTag ("Hex_ColdHill"));
		foundPlaces.AddRange (GameObject.FindGameObjectsWithTag ("Hex_ColdMountain"));
		foundPlaces.AddRange (GameObject.FindGameObjectsWithTag ("Hex_ColdConiferous"));

		List<GameObject> foundPlacesForCastles = new List<GameObject>();
		foundPlacesForCastles.AddRange (GameObject.FindGameObjectsWithTag ("Hex_ColdBarren"));
		foundPlacesForCastles.AddRange (foundPlacesForCastles);



			for (int villages = 0; villages < numberVillages; villages++) {  
			dropdownTileEditor.value = 1;

				settlementVillage = true;
				settlementCastle = false;
				settlementCity = false;

				Random Random = new Random ();
				int index = Random.Range (0, foundPlaces.Count);
				someObjects = foundPlaces [index];

				selectedObject = someObjects.transform.gameObject;

				EditorSettlementPlacer ();
			}

			for (int castles = 0; castles < numberCastles; castles++) {
			dropdownTileEditor.value = 2;

				settlementVillage = false;
				settlementCastle = true;
				settlementCity = false;

				Random Random = new Random ();
				int index = Random.Range (0, foundPlacesForCastles.Count);
				someObjects = foundPlacesForCastles [index];

				selectedObject = someObjects.transform.gameObject;

				EditorSettlementPlacer ();
			}

			for (int cities = 0; cities < numberCities; cities++) {  
			dropdownTileEditor.value = 3;

				settlementVillage = false;
				settlementCastle = false;
				settlementCity = true;

				Random Random = new Random ();
				int index = Random.Range (0, foundPlaces.Count);
				someObjects = foundPlaces [index];

				selectedObject = someObjects.transform.gameObject;

				EditorSettlementPlacer ();

			} 


		settlementVillage = false;
		settlementCastle = false;
		settlementCity = false;

				//GameObject.FindGameObjectsWithTag.text.Contains ("Village"); 


		//for (int column = 0; column < RealmMap.numberColumns; column++) {
		//		for (int row = 0; row < RealmMap.numberRows; row++) {






		//}
		//}
		//}

	}



	/* if mouse leaves selected object, it gets initial color back
	void ClearSelection() {
		if(selectedObject == null)
			return;

		Renderer rs = selectedObject.GetComponentInChildren<Renderer>(); 
		Material[] mats = rs.materials; 
		foreach(Material mat in mats) { 
			mat.color = initialColor; 
		}
		selectedObject = null;
	} */




	// -------------------------------------------------------------------------

	public void ToggleNone(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//The edit function for hex-tiles is off
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleAll(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//All hex-types and settlements can be placed.
		//Settlements will automatically be set in the culture fitting to the climate. 
		//If you want a "foreign" culture in climate x, use the culture toggle
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Village" );
		HexTileTypes.Add( "Castle" );
		HexTileTypes.Add( "City" );
		HexTileTypes.Add( "Water" );
		HexTileTypes.Add( "Cold Icy Mountain" );
		HexTileTypes.Add( "Cold Woodland Hill" );
		HexTileTypes.Add( "Cold Winter Forest" );
		HexTileTypes.Add( "Cold Sparse Grassland" );
		HexTileTypes.Add( "Cold Tundra" );
		HexTileTypes.Add( "Warm Mountain" );
		HexTileTypes.Add( "Warm Hill" );
		HexTileTypes.Add( "Warm Coniferous Forest" );
		HexTileTypes.Add( "Warm Deciduous Forest" );
		HexTileTypes.Add( "Warm Grassland" );
		HexTileTypes.Add( "Warm Barren Plain" );
		HexTileTypes.Add( "Mediterranean Mountain" );
		HexTileTypes.Add( "Mediterranean Coniferous Hill" );
		HexTileTypes.Add( "Mediterranean Deciduous Forest" );
		HexTileTypes.Add( "Mediterranean Grassland" );
		HexTileTypes.Add( "Mediterranean Barren" );
		HexTileTypes.Add( "Desert Mountain" );
		HexTileTypes.Add( "Desert Hammada Stonedesert" );
		HexTileTypes.Add( "Desert Sanddesert" );
		HexTileTypes.Add( "Desert Dunes" );
		HexTileTypes.Add( "Desert Trees" );
		HexTileTypes.Add( "Desert Oasis" );
		HexTileTypes.Add( "Tropic Mountain" );
		HexTileTypes.Add( "Tropic Jungle Hill" );
		HexTileTypes.Add( "Tropic Jungle Forest" );
		HexTileTypes.Add( "Tropic Plain-Glade" );
		HexTileTypes.Add( "Tropic Barren" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleCold(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Cold hex-types can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Village" );
		HexTileTypes.Add( "Castle" );
		HexTileTypes.Add( "City" );
		HexTileTypes.Add( "Water" );
		HexTileTypes.Add( "Cold Icy Mountain" );
		HexTileTypes.Add( "Cold Woodland Hill" );
		HexTileTypes.Add( "Cold Winter Forest" );
		HexTileTypes.Add( "Cold Sparse Grassland" );
		HexTileTypes.Add( "Cold Tundra" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleWarm(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Warm hex-types can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Village" );
		HexTileTypes.Add( "Castle" );
		HexTileTypes.Add( "City" );
		HexTileTypes.Add( "Water" );
		HexTileTypes.Add( "Warm Mountain" );
		HexTileTypes.Add( "Warm Hill" );
		HexTileTypes.Add( "Warm Coniferous Forest" );
		HexTileTypes.Add( "Warm Deciduous Forest" );
		HexTileTypes.Add( "Warm Grassland" );
		HexTileTypes.Add( "Warm Barren Plain" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleMediterranean(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Mediterranean hex-types can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Village" );
		HexTileTypes.Add( "Castle" );
		HexTileTypes.Add( "City" );
		HexTileTypes.Add( "Water" );
		HexTileTypes.Add( "Mediterranean Mountain" );
		HexTileTypes.Add( "Mediterranean Coniferous Hill" );
		HexTileTypes.Add( "Mediterranean Deciduous Forest" );
		HexTileTypes.Add( "Mediterranean Grassland" );
		HexTileTypes.Add( "Mediterranean Barren" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleDesert(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Desert hex-types can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Village" );
		HexTileTypes.Add( "Castle" );
		HexTileTypes.Add( "City" );
		HexTileTypes.Add( "Water" );
		HexTileTypes.Add( "Desert Mountain" );
		HexTileTypes.Add( "Desert Hammada Stonedesert" );
		HexTileTypes.Add( "Desert Sanddesert" );
		HexTileTypes.Add( "Desert Dunes" );
		HexTileTypes.Add( "Desert Trees" );
		HexTileTypes.Add( "Desert Oasis" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleTropic(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Tropic hex-types can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Village" );
		HexTileTypes.Add( "Castle" );
		HexTileTypes.Add( "City" );
		HexTileTypes.Add( "Water" );
		HexTileTypes.Add( "Tropic Mountain" );
		HexTileTypes.Add( "Tropic Jungle Hill" );
		HexTileTypes.Add( "Tropic Jungle Forest" );
		HexTileTypes.Add( "Tropic Plain-Glade" );
		HexTileTypes.Add( "Tropic Barren" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleNordic(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Nordic settlements can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Nordic Village" );
		HexTileTypes.Add( "Nordic Castle" );
		HexTileTypes.Add( "Nordic City" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleMedieval(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Medieval settlements can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Medieval Village" );
		HexTileTypes.Add( "Medieval Castle" );
		HexTileTypes.Add( "Medieval City" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleAncient(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Ancient settlements can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Ancient Village" );
		HexTileTypes.Add( "Ancient Castle" );
		HexTileTypes.Add( "Ancient City" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleAsian(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Asian settlements can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Asian Village" );
		HexTileTypes.Add( "Asian Castle" );
		HexTileTypes.Add( "Asian City" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleAfrican(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//African settlements can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "African Village" );
		HexTileTypes.Add( "African Castle" );
		HexTileTypes.Add( "African City" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	public void ToggleHorde(bool input)
	{
		dropdownTileEditor.ClearOptions ();
		//Horde settlements can be placed
		List<string> HexTileTypes = new List<string>();
		HexTileTypes.Clear ();
		HexTileTypes.Add( "None" );
		HexTileTypes.Add( "Horde Village" );
		HexTileTypes.Add( "Horde Castle" );
		HexTileTypes.Add( "Horde City" );
		dropdownTileEditor.AddOptions (HexTileTypes);
	}

	void MouseOver_HexChange (GameObject hitChange_Hex) 
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




	/*	//Checks active toggle for dropdown
	public void PopulateList_HexTileTypes()
	{
		if (ToggleNone == true)
		{
			//The edit function for hex-tiles is off
			List<string> HexTileTypes = new List<string>() { "Test" };
			dropdownTileEditor.AddOptions (HexTileTypes);
		}
		else if (ToggleAll == true)
		{
			//All hex-types can be placed
			List<string> HexTileTypes = new List<string>() { "None", "Grassland", "Mountain" };
			dropdownTileEditor.AddOptions (HexTileTypes);
		} 
		else if (isToggle_Cold.onValueChanged)
		{
			//Cold climate hex tiles can be placed
			List<string> HexTileTypes = new List<string>() { "None", "Mountain" };
			dropdownTileEditor.AddOptions (HexTileTypes);

		} else if (isToggle_Warm.onValueChanged)
		{
			//Warm climate hex tiles can be placed
			List<string> HexTileTypes = new List<string>() { "None", "Grassland" };
			dropdownTileEditor.AddOptions (HexTileTypes);
		}
	} 




	/* void PopulateList_HexTileTypes()
	{
		//This list can later be modified to get the values from database
		List<string> HexTileTypes = new List<string>() { "None", "Grassland", "Mountain", "Settlement" };
		dropdownTileEditor.AddOptions (HexTileTypes);
	}*/



	/*	void Update()
	{
		switch (dropdownTileEditor.value) {
		case 1:
			MeshRenderer case1_mr = hexGameObject.GetComponentInChildren<MeshRenderer> ();
			case1_mr.material = MatPlains;

			MeshFilter case1_mf = hexGameObject.GetComponentInChildren<MeshFilter> ();
			case1_mf.mesh = MeshFlat;
			break;
		case 2:
			MeshRenderer case2_mr = hexGameObject.GetComponentInChildren<MeshRenderer> ();
			dropChange_mr.material = MatMountains;

			MeshFilter case2_mf = hexGameObject.GetComponentInChildren<MeshFilter> ();
			case2_mf.mesh = MeshMountain;
			break;
		case 3:
			MeshRenderer case3_mr = hexGameObject.GetComponentInChildren<MeshRenderer> ();
			case3_mr.material = MatWater;

			MeshFilter case3_mf = hexGameObject.GetComponentInChildren<MeshFilter> ();
			case3_mf.mesh = MeshWater;
			break;
		}

		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		if (Physics.Raycast (mouseRay, out hitInfo)) {
			GameObject hitObject = hitInfo.transform.parent.gameObject;

			if (hitObject.GetComponent<ThisHexTile> () != null) {
				// We are over a hex
				MouseOver_Hex (hitObject);
			}


		}

		*/
	}