using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RealmEditor : MonoBehaviour {

	public GameObject selectedObject;

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

	//Toggle Game Objects
	public Toggle isToggle_None;
	public Toggle isToggle_All;
	public Toggle isToggle_Cold;
	public Toggle isToggle_Warm;
	public Toggle isToggle_Mediterranean;
	public Toggle isToggle_Desert;
	public Toggle isToggle_Tropic;
	public Toggle isToggle_Medieval;

	//Dropdown Game Objects
	public Dropdown dropdownTileEditor;

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

	void Start ()
	{
		//	PopulateList_HexTileTypes ();
		//realmMap = GetComponentInChildren<MeshRenderer>();
		//RealmMap realmMap = hexGameObject.GetComponentsInChildren<MeshRenderer>();
		//ChangeHex = GetComponent<Renderer>();
		//ChangeHex.enabled = true;

		isToggle_None.onValueChanged.AddListener(ToggleNone);
		isToggle_All.onValueChanged.AddListener(ToggleAll);
		isToggle_Cold.onValueChanged.AddListener(ToggleCold);
		isToggle_Warm.onValueChanged.AddListener(ToggleWarm);
		isToggle_Mediterranean.onValueChanged.AddListener(ToggleMediterranean);
		isToggle_Desert.onValueChanged.AddListener(ToggleDesert);
		isToggle_Tropic.onValueChanged.AddListener(ToggleTropic);
		isToggle_Medieval.onValueChanged.AddListener(ToggleMedieval);

	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed left click.");
			/*Renderer rs = selectedObject.GetComponentInChildren<Renderer>();
			Material[] mats = rs.materials; 
			foreach(Material mat in mats) { 
				mat.color = Color.red;
			} */
		}

		if (Input.GetMouseButtonDown (1))
			Debug.Log ("Pressed right click.");

		if (Input.GetMouseButtonDown (2))
			Debug.Log ("Pressed middle click.");

		//}
		//void Update()
		//{

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
	}


	void SelectObject(GameObject obj) {

		selectedObject = obj;

		Renderer hexMaterial = selectedObject.GetComponentInChildren<Renderer>();
		MeshFilter hexMesh = selectedObject.GetComponentInChildren<MeshFilter>();


		if (Input.GetMouseButton (1)) {
			//this will be activated every frame on the right mouse button down. That makes 'painting' like with a brush possible. But is horrible with settlements.


			if (dropdownTileEditor.captionText.text == "Cold Icy Mountain") {
				hexMaterial.material = MatColdMountain;
				hexMesh.mesh = MeshColdMountain;
				MouseManager.initialColor = MatColdMountain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", ""); //this gives every tile the generic tag "Hex_XXX" where X is the same as the material, which defines the tile perfectly. Later it is possible to ask tag.Contains() for example tag.Contains("Warm"), which gets you all tiles of this tag type. To avoid problems while placing objects like settlements and highlight-color this has to be in every single if-clause
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;			
			}
			if (dropdownTileEditor.captionText.text == "Cold Woodland Hill") {
				hexMaterial.material = MatColdHill;
				hexMesh.mesh = MeshColdHill;
				MouseManager.initialColor = MatColdHill;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Cold Winter Forest") {
				hexMaterial.material = MatColdConiferous;
				hexMesh.mesh = MeshColdConiferous;
				MouseManager.initialColor = MatColdConiferous;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Cold Sparse Grassland") {
				hexMaterial.material = MatColdPlain;
				hexMesh.mesh = MeshColdPlain;
				MouseManager.initialColor = MatColdPlain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Cold Tundra") {
				hexMaterial.material = MatColdBarren;
				hexMesh.mesh = MeshColdBarren;
				MouseManager.initialColor = MatColdBarren;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}

			if (dropdownTileEditor.captionText.text == "Warm Mountain") {
				hexMaterial.material = MatWarmMountain;
				hexMesh.mesh = MeshWarmMountain;
				MouseManager.initialColor = MatWarmMountain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Warm Hill") {
				hexMaterial.material = MatWarmHill;
				hexMesh.mesh = MeshWarmHill;
				MouseManager.initialColor = MatWarmHill;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Warm Coniferous Forest") {
				hexMaterial.material = MatWarmConiferous;
				hexMesh.mesh = MeshWarmConiferous;
				MouseManager.initialColor = MatWarmConiferous;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Warm Deciduous Forest") {
				hexMaterial.material = MatWarmDeciduous;
				hexMesh.mesh = MeshWarmDeciduous;
				MouseManager.initialColor = MatWarmDeciduous;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Warm Grassland") {
				hexMaterial.material = MatWarmPlain;
				hexMesh.mesh = MeshWarmPlain;
				MouseManager.initialColor = MatWarmPlain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Warm Barren Plain") {
				hexMaterial.material = MatWarmBarren;
				hexMesh.mesh = MeshWarmBarren;
				MouseManager.initialColor = MatWarmBarren;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}

			if (dropdownTileEditor.captionText.text == "Mediterranean Mountain") {
				hexMaterial.material = MatMediterraneanMountain;
				hexMesh.mesh = MeshMediterraneanMountain;
				MouseManager.initialColor = MatMediterraneanMountain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Mediterranean Coniferous Hill") {
				hexMaterial.material = MatMediterraneanHill;
				hexMesh.mesh = MeshMediterraneanHill;
				MouseManager.initialColor = MatMediterraneanHill;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Mediterranean Deciduous Forest") {
				hexMaterial.material = MatMediterraneanDeciduous;
				hexMesh.mesh = MeshMediterraneanDeciduous;
				MouseManager.initialColor = MatMediterraneanDeciduous;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Mediterranean Grassland") {
				hexMaterial.material = MatMediterraneanPlain;
				hexMesh.mesh = MeshMediterraneanPlain;
				MouseManager.initialColor = MatMediterraneanPlain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Mediterranean Barren") {
				hexMaterial.material = MatMediterraneanBarren;
				hexMesh.mesh = MeshMediterraneanBarren;
				MouseManager.initialColor = MatMediterraneanBarren;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}

			if (dropdownTileEditor.captionText.text == "Desert Mountain") {
				hexMaterial.material = MatDesertMountain;
				hexMesh.mesh = MeshDesertMountain;
				MouseManager.initialColor = MatDesertMountain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Desert Trees") {
				hexMaterial.material = MatDesertDeciduous;
				hexMesh.mesh = MeshDesertDeciduous;
				MouseManager.initialColor = MatDesertDeciduous;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Desert Oasis") {
				hexMaterial.material = MatDesertPlain;
				hexMesh.mesh = MeshDesertPlain;
				MouseManager.initialColor = MatDesertPlain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Desert Hammada Stonedesert") {
				hexMaterial.material = MatDesertHammada;
				hexMesh.mesh = MeshDesertHammada;
				MouseManager.initialColor = MatDesertHammada;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Desert Sanddesert") {
				hexMaterial.material = MatDesertSand;
				hexMesh.mesh = MeshDesertSand;
				MouseManager.initialColor = MatDesertSand;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Desert Dunes") {
				hexMaterial.material = MatDesertHill;
				hexMesh.mesh = MeshDesertHill;
				MouseManager.initialColor = MatDesertHill;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}

			if (dropdownTileEditor.captionText.text == "Tropic Mountain") {
				hexMaterial.material = MatTropicMountain;
				hexMesh.mesh = MeshTropicMountain;
				MouseManager.initialColor = MatTropicMountain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Tropic Jungle Hill") {
				hexMaterial.material = MatTropicHill;
				hexMesh.mesh = MeshTropicHill;
				MouseManager.initialColor = MatTropicHill;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Tropic Jungle Forest") {
				hexMaterial.material = MatTropicDeciduous;
				hexMesh.mesh = MeshTropicDeciduous;
				MouseManager.initialColor = MatTropicDeciduous;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Tropic Plain-Glade") {
				hexMaterial.material = MatTropicPlain;
				hexMesh.mesh = MeshTropicPlain;
				MouseManager.initialColor = MatTropicPlain;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
			if (dropdownTileEditor.captionText.text == "Tropic Barren") {
				hexMaterial.material = MatTropicBarren;
				hexMesh.mesh = MeshTropicBarren;
				MouseManager.initialColor = MatTropicBarren;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}

			if (dropdownTileEditor.captionText.text == "Water") {
				hexMaterial.material = MatWater;
				hexMesh.mesh = MeshWater;
				MouseManager.initialColor = MatWater;
				selectedObject.tag = "Hex_" + hexMaterial.material.name.Replace (" (Instance)", "");
				selectedObject.GetComponent<TileData> ().typeTile = selectedObject.tag;
			}
		}

		if (Input.GetMouseButtonUp (1) ) {
			//this will only be activated on the right mouse button getting up. That makes it possible to only build settlements once per click.
			//TODO: If there is already a settlement on a tile, that should be destroyed by a right click (the user than can set a new settlement with a new right click)

			if (dropdownTileEditor.captionText.text == "Village") {
				/* if (selectedObject.transform.GetChild(1).gameObject.tag.Contains("Village")) { //(selectedObject.Child.tag.Contains("Village")) {
					Debug.Log("Destroy the settlement...");
				} else */
				foreach (Transform child in selectedObject.transform) {
					if(child.tag.Contains("Village"))
						GameObject.Destroy(child.gameObject);
					Debug.Log("Destroy the settlement...");
				}

				if (selectedObject.tag.Contains("Water")) {
					Debug.Log ("You can't build villages on water!");
				} else if (selectedObject.tag.Contains("Barren")) {
					Debug.Log ("You can't build villages on barren ground!");
				} else if (selectedObject.tag.Contains("Hammada")) {
					Debug.Log ("You can't build villages on stonedesert!");
				} else if (selectedObject.tag.Contains("Sand")) {
					Debug.Log ("You can't build villages on sanddesert!");
				} else if (selectedObject.tag.Contains("DesertHill")) {
					Debug.Log ("You can't build villages on sanddunes!");
				} else if (selectedObject.tag.Contains("ColdPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageNordicPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageNordicPlain";
				} else if (selectedObject.tag.Contains("ColdConiferous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageNordicForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageNordicForest";
				} else if (selectedObject.tag.Contains("ColdHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageNordicHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageNordicHill";
				} 
				else if (selectedObject.tag.Contains("ColdMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageNordicMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageNordicMountain";
				}
				else if (selectedObject.tag.Contains("WarmPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageMedievalPlain";
				} 
				else if (selectedObject.tag.Contains("WarmDeciduous") | selectedObject.tag.Contains("WarmConiferous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageMedievalForest";
				} 
				else if (selectedObject.tag.Contains("WarmHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageMedievalHill";
				} 
				else if (selectedObject.tag.Contains("WarmMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageMedievalMountain";
				}
				else if (selectedObject.tag.Contains("MediterraneanPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAncientPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAncientPlain";
				} 
				else if (selectedObject.tag.Contains("MediterraneanDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAncientForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAncientForest";
				} 
				else if (selectedObject.tag.Contains("MediterraneanHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAncientHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAncientHill";
				} 
				else if (selectedObject.tag.Contains("MediterraneanMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAncientMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAncientMountain";
				}
				else if (selectedObject.tag.Contains("DesertPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageHordePlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageHordePlain";
				} 
				else if (selectedObject.tag.Contains("DesertDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageHordeForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageHordeForest";
				} 
				else if (selectedObject.tag.Contains("DesertMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageHordeMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageHordeMountain";
				}
				else if (selectedObject.tag.Contains("TropicPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAfricanPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAfricanPlain";
				}
				else if (selectedObject.tag.Contains("TropicDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAfricanForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAfricanForest";
				} 
				else if (selectedObject.tag.Contains("TropicHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAfricanHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAfricanHill";
				} 
				else if (selectedObject.tag.Contains("TropicMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(VillageAfricanMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "VillageAfricanMountain";
				}
			}

			if (dropdownTileEditor.captionText.text == "Castle") {

				if (selectedObject.tag.Contains("Water")) {
					Debug.Log ("You can't build Castles on water!");
				} else if (selectedObject.tag.Contains("ColdBarren"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleNordicBarrenPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleNordicBarren";
				}
				else if (selectedObject.tag.Contains("ColdPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleNordicPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleNordicPlain";
				} else if (selectedObject.tag.Contains("ColdConiferous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleNordicForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleNordicForest";
				} else if (selectedObject.tag.Contains("ColdHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleNordicHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleNordicHill";
				} 
				else if (selectedObject.tag.Contains("ColdMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleNordicMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleNordicMountain";
				} else if (selectedObject.tag.Contains("WarmBarren"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleMedievalBarrenPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleMedievalBarren";
				}
				else if (selectedObject.tag.Contains("WarmPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleMedievalPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleMedievalPlain";
				} 
				else if (selectedObject.tag.Contains("WarmDeciduous") | selectedObject.tag.Contains("WarmConiferous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleMedievalForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleMedievalForest";
				} 
				else if (selectedObject.tag.Contains("WarmHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleMedievalHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleMedievalHill";
				} 
				else if (selectedObject.tag.Contains("WarmMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleMedievalMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleMedievalMountain";
				} else if (selectedObject.tag.Contains("MediterraneanBarren"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAncientBarrenPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAncientBarren";
				}
				else if (selectedObject.tag.Contains("MediterraneanPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAncientPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAncientPlain";
				} 
				else if (selectedObject.tag.Contains("MediterraneanDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAncientForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAncientForest";
				} 
				else if (selectedObject.tag.Contains("MediterraneanHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAncientHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAncientHill";
				} 
				else if (selectedObject.tag.Contains("MediterraneanMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAncientMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAncientMountain";
				} 
				else if (selectedObject.tag.Contains("DesertSand") | selectedObject.tag.Contains("DesertHammada"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleHordeBarrenPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleHordeBarren";
				}
				else if (selectedObject.tag.Contains("DesertHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleHordeHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleHordeHill";
				}
				else if (selectedObject.tag.Contains("DesertPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleHordePlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleHordePlain";
				} 
				else if (selectedObject.tag.Contains("DesertDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleHordeForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleHordeForest";
				} 
				else if (selectedObject.tag.Contains("DesertMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleHordeMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleHordeMountain";
				} 
				else if (selectedObject.tag.Contains("TropicBarren"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAfricanBarrenPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAfricanBarren";
				}
				else if (selectedObject.tag.Contains("TropicPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAfricanPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAfricanPlain";
				}
				else if (selectedObject.tag.Contains("TropicDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAfricanForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAfricanForest";
				} 
				else if (selectedObject.tag.Contains("TropicHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAfricanHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAfricanHill";
				} 
				else if (selectedObject.tag.Contains("TropicMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CastleAfricanMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CastleAfricanMountain";
				}
			}
			if (dropdownTileEditor.captionText.text == "City") {

				if (selectedObject.tag.Contains("Water")) {
					Debug.Log ("You can't build Cities on water!");
				} else if (selectedObject.tag.Contains("Barren")) {
					Debug.Log ("You can't build Cities on barren ground!");
				} else if (selectedObject.tag.Contains("Hammada")) {
					Debug.Log ("You can't build Cities on stonedesert!");
				} else if (selectedObject.tag.Contains("Sand")) {
					Debug.Log ("You can't build Cities on sanddesert!");
				} else if (selectedObject.tag.Contains("DesertHill")) {
					Debug.Log ("You can't build Cities on sanddunes!");
				} else if (selectedObject.tag.Contains("ColdPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityNordicPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityNordicPlain";
				} else if (selectedObject.tag.Contains("ColdConiferous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityNordicForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityNordicForest";
				} else if (selectedObject.tag.Contains("ColdHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityNordicHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityNordicHill";
				} 
				else if (selectedObject.tag.Contains("ColdMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityNordicMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityNordicMountain";
				}
				else if (selectedObject.tag.Contains("WarmPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityMedievalPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityMedievalPlain";
				} 
				else if (selectedObject.tag.Contains("WarmDeciduous") | selectedObject.tag.Contains("WarmConiferous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityMedievalForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityMedievalForest";
				} 
				else if (selectedObject.tag.Contains("WarmHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityMedievalHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityMedievalHill";
				} 
				else if (selectedObject.tag.Contains("WarmMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityMedievalMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityMedievalMountain";
				}
				else if (selectedObject.tag.Contains("MediterraneanPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAncientPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAncientPlain";
				} 
				else if (selectedObject.tag.Contains("MediterraneanDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAncientForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAncientForest";
				} 
				else if (selectedObject.tag.Contains("MediterraneanHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAncientHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAncientHill";
				} 
				else if (selectedObject.tag.Contains("MediterraneanMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAncientMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAncientMountain";
				}
				else if (selectedObject.tag.Contains("DesertPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityHordePlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityHordePlain";
				} 
				else if (selectedObject.tag.Contains("DesertDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityHordeForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityHordeForest";
				} 
				else if (selectedObject.tag.Contains("DesertMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityHordeMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityHordeMountain";
				}
				else if (selectedObject.tag.Contains("TropicPlain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAfricanPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAfricanPlain";
				}
				else if (selectedObject.tag.Contains("TropicDeciduous"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAfricanForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAfricanForest";
				} 
				else if (selectedObject.tag.Contains("TropicHill"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAfricanHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAfricanHill";
				} 
				else if (selectedObject.tag.Contains("TropicMountain"))
				{
					GameObject settlementGameObject = (GameObject)Instantiate(CityAfricanMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					settlementGameObject.tag = "CityAfricanMountain";
				}
			
			}

			if (dropdownTileEditor.captionText.text == "Medieval Village") {
				if (selectedObject.tag.Contains("Water")) {
					Debug.Log ("You can't build villages on water!");
				} else if (selectedObject.tag.Contains("Barren")) {
					Debug.Log ("You can't build villages on barren ground!");
				} else if (selectedObject.tag.Contains("Plain"))
				{
					Debug.Log ("Now there would be placed a medieval village with farmers - in every climate!");
					//GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalPlainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					//settlementGameObject.tag = "VillageNordicPlain";
				} else if (selectedObject.tag.Contains("ColdConiferous"))
				{
					Debug.Log ("Now there would be placed a medieval village with loggers - in every climate!");
					//GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalForestPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					//settlementGameObject.tag = "VillageNordicConiferous";
				} else if (selectedObject.tag.Contains("ColdHill"))
				{
					Debug.Log ("Now there would be placed a medieval village with cattle-farmers - in every climate!");
					//GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalHillPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					//settlementGameObject.tag = "VillageNordicHill";
				} 
				else if (selectedObject.tag.Contains("ColdMountain"))
				{
					Debug.Log ("Now there would be placed a medieval village with stone masons - in every climate!");
					//GameObject settlementGameObject = (GameObject)Instantiate(VillageMedievalMountainPrefab, selectedObject.transform.position, Quaternion.identity, selectedObject.transform);
					//settlementGameObject.tag = "VillageNordicMountain";
				}
			}

		}
		//if(selectedObject != null) {
		//	if(obj == selectedObject)
		//		return;
		//ClearSelection();
		//}

		//selectedObject = obj;

		//Renderer hexMaterial = selectedObject.GetComponentInChildren<Renderer>();
		//hexMaterial.material = MatMountains;

		//Renderer rs = selectedObject.GetComponentInChildren<Renderer>();
		//rs.material = MatMountains;
		//rs.material = MatMountains;
		//Material[] mats = rs.materials; 
		//foreach(Material mat in mats) { 
		//	mat.material = MatMountains; 
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