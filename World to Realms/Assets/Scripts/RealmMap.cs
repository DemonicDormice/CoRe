using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GenerateRealm();
	}

	public GameObject HexPrefab;

	//Different meshes and materials per climate
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

	public Mesh MeshSettlement;
	public Material MatSettlements;


	//Tiles with HexTerrainValue of blabla are bla
	//Cold climate - tactically bad for cavalry because of hills and forests and mountains
	public float ValueColdPlain = 0.0f; //ColdBarren will get randomized with ColdPlain
	public float ValueColdConiferous = 0.25f;
	public float ValueColdHill = 0.5f; //Cold climate has much more hills with trees
	public float ValueColdMountain = 0.75f;

	//Warm climate
	public float ValueWarmPlain = 0.0f; //WarmBarren will get randomized with WarmPlain
	public float ValueWarmDeciduous = 0.45f;
	public float ValueWarmConiferous = 0.65f;
	public float ValueWarmHill = 0.75f;
	public float ValueWarmMountain = 0.80f;

	//Mediterranean climate - gets more plains and is better for cavalry
	public float ValueMediterraneanPlain = 0.0f; //MediterraneanBarren will get randomized with MediterraneanPlain
	public float ValueMediterraneanDeciduous = 0.4f;
	public float ValueMediterraneanHill = 0.65f; //Hill gets coniferous trees
	public float ValueMediterraneanMountain = 0.9f;

	//Desert climate - gets more desert and hammada is better for cavalry
	public float ValueDesertPlain = 0.0f;
	public float ValueDesertDeciduous = 0.15f;
	public float ValueDesertHammada = 0.25f; //DesertHammada is the stone desert and will be the normal together with hill (dunes) and sand deser
	public float ValueDesertSand = 0.50f;
	public float ValueDesertHill = 0.75f; //Hill gets dunes, its not like the hill in other climates predominant near mountains
	public float ValueDesertMountain = 0.80f;

	//Tropic climate - gets way more forest than the others and is bad for cavalry and ranged, except on barren
	public float ValueTropicPlain = 0.0f; //TropicBarren will get randomized with TropicPlain
	public float ValueTropicDeciduous = 0.4f;
	public float ValueTropicHill = 0.65f; //Hill gets coniferous trees
	public float ValueTropicMountain = 0.9f;


	//All for the climate zone 
	int climateWholeNumber;
	float climateColdPercent;
	float climateWarmPercent;
	float climateMediterraneanPercent;
	float climateDesertPercent;
	float climateTropicPercent;
	float climateTropicHalfzone;
	float climateDesertHalfzone;
	float climateMediterraneanHalfzone;
	float climateWarmHalfzone;
	float climateColdHalfzone;


	//Size of the world in realms*realms
	// TODO: Adminpanel to manipulate the world-size
	// or world-size in dependend on active user numbers
	static public readonly int numberColumns = 50; // columns are X
	static public readonly int numberRows = 50; // rows are Y

	int RealmX = 0; //Later from editor or database
	int RealmY = 1; //Later from editor or database
	int rowWorld; //thats the row inside a realm in relation to the whole world
	int numberRowsWorld = WorldMap.numberRows * numberRows; //thats the whole of all rows inside the world
	int middleRowWorld = (WorldMap.numberRows * numberRows) / 2; //whats the middle-row of the world (which we need to place climate zones)

	float randomRange = 0.9f; //this is needed outside the for-loop for the UpdateHexVisuals to do the transition between climate zones. The higher randomRange is, the higher the concentration/denseness of random climate


	private Hex[,] hexes;
	private Dictionary<Hex, GameObject> hexToGameObjectRealm; //Which GameObject belongs to which hex

	public Hex GetHexAt (int x, int y)
	{
		if(hexes == null)
		{
			Debug.LogError("Warning! Hexes are not yet instantiated!");
			return null;
		}

		//Negatives need to be fixed
		if (x < 0) {
			x += numberColumns;
		}
		if (y < 0) {
			y += numberRows;
		}

		//If x or y are higher than the size of the realm you need to fix "positives", too.
		if (x > numberColumns - 1) {
			x -= numberColumns;
		}
		if (y > numberRows - 1) {
			y -= numberRows;
		}

		try{
			return hexes [x, y];
		}
		catch{
			Debug.LogError("GetHexAt: " + x + "," + y);
			return null;
		}
	}

	virtual public void GenerateRealm() 
	{
		hexes = new Hex[numberColumns, numberRows];
		hexToGameObjectRealm = new Dictionary<Hex, GameObject> (); 


		//Generate a map filled with Grassland
		for (int column = 0; column < numberColumns; column++) 
		{
			for (int row = 0; row < numberRows; row++) 
			{
				// Instantiate a hex
				Hex h = new Hex ( column, row );
				h.HexTerrainValue = -0.2f; //whats the standard/start value of the hexes? Under 0 is water. The lower under 0 the more water on the map

				hexes [column, row] = h;


				//TODO: Camerazentrierung noch einbauen
				/* Vector3 pos = h.PositionFromCamera (
					Camera.main.transform.position,
					numberRows,
					numberColumns
				); */

				GameObject hexGameObject = (GameObject)Instantiate(	
					HexPrefab,
					h.Position(),
					Quaternion.identity,
					this.transform 
				);

				hexToGameObjectRealm [h] = hexGameObject;

				//Give the GO some sensible name
				//hexGameObject.name = "Hex " + column + "/" + row + " Value: " + h.HexTerrainValue;

				//For making sure the hex knows its position on the map
				hexGameObject.GetComponent<TileData> ().x = column;
				hexGameObject.GetComponent<TileData> ().y = row;

				//For a cleaner hierarchy, child this hex to RealmMap
				hexGameObject.transform.SetParent (this.transform);

				//For optimization
				hexGameObject.isStatic = true;

				//hexGameObject.GetComponent<HexComponent> ().Hex = h;
				//hexGameObject.GetComponent<HexComponent> ().RealmMap = this;

				hexGameObject.GetComponentInChildren<TextMesh> ().text = string.Format ("{0},{1}", column, row);


				//NOW FOR THE CLIMATE, what will finally be "paintet" in the realm only
				//whats the whole summ of all climate numbers?
				climateWholeNumber = WorldMap.numberCold + WorldMap.numberWarm + WorldMap.numberMediterranean + WorldMap.numberDesert + WorldMap.numberTropic;
				//whats the percentage of the world of the single climate zones?
				climateColdPercent = WorldMap.numberCold / (climateWholeNumber / 100f);
				climateWarmPercent = WorldMap.numberWarm / (climateWholeNumber / 100f);
				climateMediterraneanPercent = WorldMap.numberMediterranean / (climateWholeNumber / 100f);
				climateDesertPercent = WorldMap.numberDesert / (climateWholeNumber / 100f);
				climateTropicPercent = WorldMap.numberTropic / (climateWholeNumber / 100f);
				//TODO: calculate this somewhere else one time, not every loop...

				Debug.Log("numberRowsWorld " + numberRowsWorld);
				Debug.Log("climateWholeNumber " + climateWholeNumber);
				Debug.Log("climateTropicPercent " + climateTropicPercent);

				//Now we calculate the "zone" for every climate so that you can later ask: "is the hex on a row inside the world (rowWorld) which has a Y <=
				//the middle of the world (numberRowsWorld / 2) PLUS half of the climate zone (numberRowsWorld * ((climateTropicPercent / 100) / 2)) and has 
				//a row a Y that is bigger than the middle of the world MINUS half of the climate zone. That will enable us to place the climate zone on the world
				//while beeing able to change its size, drop climate zones or add new ones. To make the UpdateHexVisuals() easyer we pre-calculate the halfs of the
				//climate zones. We also need these halfs to make a nice transition between different climate zones.
				climateTropicHalfzone = numberRowsWorld * ((climateTropicPercent / 100) / 2);
				climateDesertHalfzone = climateTropicHalfzone + (numberRowsWorld * ((climateDesertPercent / 100) / 2));
				climateMediterraneanHalfzone = climateDesertHalfzone + (numberRowsWorld * ((climateMediterraneanPercent / 100) / 2));
				climateWarmHalfzone = climateMediterraneanHalfzone + (numberRowsWorld * ((climateWarmPercent / 100) / 2));
				climateColdHalfzone = climateWarmHalfzone + (numberRowsWorld * ((climateColdPercent / 100) / 2));

			}
		}

		UpdateHexVisuals ();
	}

	public void UpdateHexVisuals() //loop trought all the hexes and set their type based on HexTerrainValue
	{

		//float transitionRange = 0.9f; //the higher the transitionRange, the bigger the area of intermixture is. transitionRange is the percentage calculated from the starting area
		//randomRange = randomRange - 0.01f; //the higher randomRange is, the higher the concentration/denseness of random climate 
		//TODO: the randomRange has to be tied to the worldsize / numberRowsWorld and has to gradually decrease depending on Y position north and south from the middle.

		for (int column = 0; column < numberColumns; column++) 
		{



			for (int row = 0; row < numberRows; row++) 
			{

				Hex h = hexes [column, row];
				GameObject hexGameObject = hexToGameObjectRealm[h];

				rowWorld = row + (numberRows * RealmY);
				MeshRenderer mr = hexGameObject.GetComponentInChildren<MeshRenderer> ();
				MeshFilter mf = hexGameObject.GetComponentInChildren<MeshFilter> ();

				//Now that we have the numbers, we have to divide the world y-axis along this lines
				//like "if column < y than mr.material = blabla"
				if (WorldMap.numberTropic != 0 & rowWorld <= middleRowWorld + climateTropicHalfzone & rowWorld >= middleRowWorld - climateTropicHalfzone) 
				{
					//Tropic climate renderer
					if(h.HexTerrainValue >= ValueTropicMountain)
					{
						mr.material = MatTropicMountain;
					}
					else if(h.HexTerrainValue >= ValueTropicHill)
					{
						mr.material = MatTropicHill;
					} 
					else if(h.HexTerrainValue >= ValueTropicDeciduous)
					{
						mr.material = MatTropicDeciduous;
					} else if(h.HexTerrainValue >= ValueTropicPlain)
					{
						//Some tiles in the "plain-spectrum" will randomly get barren
						if (Random.Range (0f, 1f) > 0.8f) {
							mr.material = MatTropicBarren;
						} else 
						{
							mr.material = MatTropicPlain;
						}
					} else
					{
						mr.material = MatWater;
					}
				} 
				else if (WorldMap.numberDesert != 0 & rowWorld <= middleRowWorld + climateDesertHalfzone & rowWorld >= middleRowWorld - climateDesertHalfzone) 
				{				
					//Desert climate renderer
					if(h.HexTerrainValue >= ValueDesertMountain)
					{
						mr.material = MatDesertMountain;
					}
					else if(h.HexTerrainValue >= ValueDesertHill)
					{
						mr.material = MatDesertHill;
					} 
					else if(h.HexTerrainValue >= ValueDesertSand)
					{
						mr.material = MatDesertSand;
					} 
					else if(h.HexTerrainValue >= ValueDesertHammada)
					{
						mr.material = MatDesertHammada;
					} 
					else if(h.HexTerrainValue >= ValueDesertDeciduous)
					{
						mr.material = MatDesertDeciduous;
					} 
					else if(h.HexTerrainValue >= ValueDesertPlain)
					{
						mr.material = MatDesertPlain;
					} 
					else
					{
						mr.material = MatWater;
					}
				} 
				else if (WorldMap.numberMediterranean != 0 & rowWorld <= middleRowWorld + climateMediterraneanHalfzone & rowWorld >= middleRowWorld - climateMediterraneanHalfzone) 
				{
					//Mediterranean climate renderer
					if(h.HexTerrainValue >= ValueMediterraneanMountain)
					{
						mr.material = MatMediterraneanMountain;
					}
					else if(h.HexTerrainValue >= ValueMediterraneanHill)
					{
						mr.material = MatMediterraneanHill;
					} 
					else if(h.HexTerrainValue >= ValueMediterraneanDeciduous)
					{
						mr.material = MatMediterraneanDeciduous;
					} else if(h.HexTerrainValue >= ValueMediterraneanPlain)
					{
						//Some tiles in the "plain-spectrum" will randomly get barren
						if (Random.Range (0f, 1f) > 0.9f) {
							mr.material = MatMediterraneanBarren;
						} else 
						{
							mr.material = MatMediterraneanPlain;
						}
					} else
					{
						mr.material = MatWater;
					}				
				} 
				else if (WorldMap.numberWarm != 0 & rowWorld <= middleRowWorld + climateWarmHalfzone & rowWorld >= middleRowWorld - climateWarmHalfzone) 
				{
					//Warm climate renderer
					if(h.HexTerrainValue >= ValueWarmMountain)
					{
						mr.material = MatWarmMountain;
						mf.mesh = MeshWarmMountain;
					}
					else if(h.HexTerrainValue >= ValueWarmHill)
					{
						mr.material = MatWarmHill;
						mf.mesh = MeshWarmHill;
					} 
					else if(h.HexTerrainValue >= ValueWarmConiferous)
					{
						mr.material = MatWarmConiferous;
						mf.mesh = MeshWarmConiferous;
					} 
					else if(h.HexTerrainValue >= ValueWarmDeciduous)
					{
						mr.material = MatWarmDeciduous;
						mf.mesh = MeshWarmDeciduous;
					} else if(h.HexTerrainValue >= ValueWarmPlain)
					{
						//Some tiles in the "plain-spectrum" will randomly get barren
						if (Random.Range (0f, 1f) > 0.9f) {
							mr.material = MatWarmBarren;
							mf.mesh = MeshWarmBarren;
						} else 
						{
							mr.material = MatWarmPlain;
							mf.mesh = MeshWarmPlain;
						}
					} else
					{
						mr.material = MatWater;
					}				
				} 
				else if (WorldMap.numberCold != 0 & rowWorld <= middleRowWorld + climateColdHalfzone & rowWorld >= middleRowWorld - climateColdHalfzone) 
				{
					//Cold climate renderer
					if(h.HexTerrainValue >= ValueColdMountain)
					{
						mr.material = MatColdMountain;
					}
					else if(h.HexTerrainValue >= ValueColdHill)
					{
						mr.material = MatColdHill;
					} 
					else if(h.HexTerrainValue >= ValueColdConiferous)
					{
						mr.material = MatColdConiferous;
					} else if(h.HexTerrainValue >= ValueColdPlain)
					{
						//Some tiles in the "plain-spectrum" will randomly get barren
						//In cold climate many plains are barren and only a portion is good for agriculture
						if (Random.Range (0f, 1f) > 0.5f) {
							mr.material = MatColdBarren;
						} else 
						{
							mr.material = MatColdPlain;
						}
					} else
					{
						mr.material = MatWater;
					}				
				} 
				else if (WorldMap.numberCold == 0 & WorldMap.numberWarm != 0)
				{
					mr.material = MatWarmPlain;
				} 
				else if (WorldMap.numberWarm == 0 & WorldMap.numberMediterranean != 0)
				{
					mr.material = MatMediterraneanPlain;
				}
				else if (WorldMap.numberMediterranean == 0 & WorldMap.numberDesert != 0)
				{
					mr.material = MatDesertHammada;
				}
				else if (WorldMap.numberDesert == 0 & WorldMap.numberTropic != 0)
				{
					mr.material = MatTropicPlain;
				} 
				else
				{
					mr.material = MatWarmPlain;
				}

				//Now for the seamless climate change
				//We want some seamless as possible transitions between clima zones.
				//For that we take maybe the last and first five or three percent (transitionRange) of the
				//whole clima zone and mix it up a little (randomRange) with the following zone.
				//TODO: we have to "catch" the possibility, that some clima zones are
				//deactivated, so that desert doesn't follow tropic and tropic could
				//transition directly for example into cold
				/*
				if (WorldMap.numberTropic != 0 & rowWorld >= middleRowWorld + climateTropicHalfzone & rowWorld <= middleRowWorld + climateTropicHalfzone + (climateTropicHalfzone * transitionRange) | rowWorld <= middleRowWorld - climateTropicHalfzone & rowWorld >= middleRowWorld - (climateTropicHalfzone + (climateTropicHalfzone * transitionRange)))
				{
					if (Random.Range (0f, 1f) < randomRange) 
					{
						//Tropic climate renderer

						mr.material = MatWater;

						/*if (h.HexTerrainValue >= ValueTropicMountain) { 
							mr.material = MatTropicMountain;
						} else if (h.HexTerrainValue >= ValueTropicHill) {
							mr.material = MatTropicHill;
						} else if (h.HexTerrainValue >= ValueTropicDeciduous) {
							mr.material = MatTropicDeciduous;
						} else if (h.HexTerrainValue >= ValueTropicPlain) {
							//Some tiles in the "plain-spectrum" will randomly get barren
							if (Random.Range (0f, 1f) > 0.8f) {
								mr.material = MatTropicBarren;
							} else {
								mr.material = MatTropicPlain;
							}
						}
					}
				}
				else if (WorldMap.numberDesert != 0 & rowWorld >= middleRowWorld + climateDesertHalfzone & rowWorld <= middleRowWorld + climateDesertHalfzone + (climateDesertHalfzone * transitionRange) | rowWorld <= middleRowWorld - climateDesertHalfzone & rowWorld >= middleRowWorld - (climateDesertHalfzone + (climateDesertHalfzone * transitionRange)))		
				{	
				if (Random.Range (0f, 1f) < randomRange) {
						mr.material = MatWarmMountain;
						//Desert climate renderer
						/* if (h.HexTerrainValue >= ValueDesertMountain) {
							mr.material = MatDesertMountain;
						} else if (h.HexTerrainValue >= ValueDesertHill) {
							mr.material = MatDesertHill;
						} else if (h.HexTerrainValue >= ValueDesertSand) {
							mr.material = MatDesertSand;
						} else if (h.HexTerrainValue >= ValueDesertHammada) {
							mr.material = MatDesertHammada;
						} else if (h.HexTerrainValue >= ValueDesertDeciduous) {
							mr.material = MatDesertDeciduous;
						} else if (h.HexTerrainValue >= ValueDesertPlain) {
							mr.material = MatDesertPlain;
						}
					} 
				}
				else if (WorldMap.numberMediterranean != 0 & rowWorld <= (numberRowsWorld / 2) + (numberRowsWorld * ((climateTropicPercent / 100) / 2)) + (numberRowsWorld * ((climateDesertPercent / 100) / 2)) + (numberRowsWorld * ((climateMediterraneanPercent / 100) / 2 + transitionRange)) & rowWorld >= (numberRowsWorld / 2) - (numberRowsWorld * ((climateTropicPercent / 100) / 2)) - (numberRowsWorld * ((climateDesertPercent / 100) / 2)) - (numberRowsWorld * ((climateMediterraneanPercent / 100) / 2 + transitionRange))) 
				{
					if (Random.Range (0f, 1f) < randomRange) {
						//Mediterranean climate renderer
						if (h.HexTerrainValue >= ValueMediterraneanMountain) {
							mr.material = MatMediterraneanMountain;
						} else if (h.HexTerrainValue >= ValueMediterraneanHill) {
							mr.material = MatMediterraneanHill;
						} else if (h.HexTerrainValue >= ValueMediterraneanDeciduous) {
							mr.material = MatMediterraneanDeciduous;
						} else if (h.HexTerrainValue >= ValueMediterraneanPlain) {
							//Some tiles in the "plain-spectrum" will randomly get barren
							if (Random.Range (0f, 1f) > 0.9f) {
								mr.material = MatMediterraneanBarren;
							} else {
								mr.material = MatMediterraneanPlain;
							}
						} 
					}
				} 
				else if (WorldMap.numberWarm != 0 & rowWorld <= (numberRowsWorld / 2) + (numberRowsWorld * ((climateTropicPercent / 100) / 2)) + (numberRowsWorld * ((climateDesertPercent / 100) / 2)) + (numberRowsWorld * ((climateMediterraneanPercent / 100) / 2)) + (numberRowsWorld * ((climateWarmPercent / 100) / 2 + transitionRange)) & rowWorld >= (numberRowsWorld / 2) - (numberRowsWorld * ((climateTropicPercent / 100) / 2)) - (numberRowsWorld * ((climateDesertPercent / 100) / 2)) - (numberRowsWorld * ((climateMediterraneanPercent / 100) / 2)) - (numberRowsWorld * ((climateWarmPercent / 100) / 2 + transitionRange))) 
				{
					if (Random.Range (0f, 1f) < randomRange) {
						//Warm climate renderer
						if (h.HexTerrainValue >= ValueWarmMountain) {
							mr.material = MatWarmMountain;
						} else if (h.HexTerrainValue >= ValueWarmHill) {
							mr.material = MatWarmHill;
						} else if (h.HexTerrainValue >= ValueWarmConiferous) {
							mr.material = MatWarmConiferous;
						} else if (h.HexTerrainValue >= ValueWarmDeciduous) {
							mr.material = MatWarmDeciduous;
						} else if (h.HexTerrainValue >= ValueWarmPlain) {
							//Some tiles in the "plain-spectrum" will randomly get barren
							if (Random.Range (0f, 1f) > 0.9f) {
								mr.material = MatWarmBarren;
							} else {
								mr.material = MatWarmPlain;
							}
						
						}
					}
				} 
				else if (WorldMap.numberCold != 0 & rowWorld <= (numberRowsWorld / 2) + (numberRowsWorld * ((climateTropicPercent / 100) / 2)) + (numberRowsWorld * ((climateDesertPercent / 100) / 2)) + (numberRowsWorld * ((climateMediterraneanPercent / 100) / 2)) + (numberRowsWorld * ((climateWarmPercent / 100) / 2)) + (numberRowsWorld * ((climateColdPercent / 100) / 2 + transitionRange)) & rowWorld >= (numberRowsWorld / 2) - (numberRowsWorld * ((climateTropicPercent / 100) / 2)) - (numberRowsWorld * ((climateDesertPercent / 100) / 2)) - (numberRowsWorld * ((climateMediterraneanPercent / 100) / 2)) - (numberRowsWorld * ((climateWarmPercent / 100) / 2)) - (numberRowsWorld * ((climateColdPercent / 100) / 2 + transitionRange))) 
				{
					if (Random.Range (0f, 1f) < randomRange) {
						//Cold climate renderer
						if (h.HexTerrainValue >= ValueColdMountain) {
							mr.material = MatColdMountain;
						} else if (h.HexTerrainValue >= ValueColdHill) {
							mr.material = MatColdHill;
						} else if (h.HexTerrainValue >= ValueColdConiferous) {
							mr.material = MatColdConiferous;
						} else if (h.HexTerrainValue >= ValueColdPlain) {
							//Some tiles in the "plain-spectrum" will randomly get barren
							//In cold climate many plains are barren and only a portion is good for agriculture
							if (Random.Range (0f, 1f) < 0.5f) {
								mr.material = MatColdBarren;
							} else {
								mr.material = MatColdPlain;
							}
						}
					}

				} */
				//Later this material stuff is only part of the realm szene, editor etc.
				//and here you will get a screenshot or something of the realm and
				//Gameobjects for the settlements, maybe for armies, too.

				//Give the GO some sensible name
				hexGameObject.name = "Hex " + column + "/" + row + " Value: " + h.HexTerrainValue;
				hexGameObject.tag = "Hex_" + mr.material.name.Replace (" (Instance)", ""); //this gives every tile the generic tag "Hex_XXX" where X is the same as the material, which defines the tile perfectly. Later it is possible to ask tag.Contains() for example tag.Contains("Warm"), which gets you all tiles of this tag type

			}
		}
	}

	// Pick hexes around a center one within a given range.
	// If range = 0 returns only the centerHex.
	// "centerHex" = The center hex
	// "range" = The maximum distance between a selected hex and the centerHex
	// returns an unordered array of hexes containing all the selected ones
	public Hex[] GetHexesWithinRangeOf (Hex centerHex, int range)
	{
		if(centerHex == null || range < 0)
		{
			Debug.LogError("RealmMap::GetHexesWithinRangeOf cannot be called with centerHex = " + centerHex + " and range = " + range);
			return new Hex[] { };
		}

		List<Hex> results = new List<Hex>();

		for (int dx = -range; dx <= range; dx++)
		{
			for (int dy = Mathf.Max(-range, -dx-range); dy <= Mathf.Min(range, -dx+range); dy++)
			{
				results.Add( GetHexAt(centerHex.C + dx, centerHex.R + dy) );
			}
		}

		return results.ToArray ();
	}
}