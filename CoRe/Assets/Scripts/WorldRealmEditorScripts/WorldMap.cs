using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GenerateWorld();
	}

	public GameObject WorldPrefab;

	public Material MatRealm;
	public Material MatClimateCold;
	public Material MatClimateWarm;
	public Material MatClimateMediterranean;
	public Material MatClimateDesert;
	public Material MatClimateTropic;

	//Size of the world in realms*realms
	//We also need the numberColumns and numberRows from RealmMap.cs to measure the 
	//the needed size of the realm-tiles
	//Hardcoded unit with which the size of realm-tiles etc. will be determined
	// TODO: Adminpanel to manipulate the world-size
	// or world-size in dependend on active user numbers
	static public readonly int numberColumns = DataControllerEditor.worldSizeX; // columns are X
	static public readonly int numberRows = DataControllerEditor.worldSizeY; // rows are Y

	//Now we set the climate zones of the world/realms and how they are distributed
	//in percent. In follows: cold, warm, mediterranean, desert, tropic, desert,
	//mediterranean, warm, cold. They get numbers depending on the size they take 
	//in the world. The numbers can be choosen freely. The addition of the whole
	//makes up for the 100 percent. 0 deactivades a climate zone.
	static public readonly int numberCold = DataControllerEditor.portionColdClimate;
	static public readonly int numberWarm = DataControllerEditor.portionWarmClimate;
	static public readonly int numberMediterranean = DataControllerEditor.portionMediterraneanClimate;
	static public readonly int numberDesert = DataControllerEditor.portionDesertClimate;
	static public readonly int numberTropic = DataControllerEditor.portionTropicClimate;
	//In the finale program you don't need the calculation of the clima zones in the
	//WorldMap.cs script. In the WorldEditor you choose the distribution, the "painting"
	//of the realm is done in the realm szene...
	int climateWholeNumber;
	float climateColdPercent;
	float climateWarmPercent;
	float climateMediterraneanPercent;
	float climateDesertPercent;
	float climateTropicPercent;
	//So this WholeNumber and Percent will go in the realm only 


	//More about the following in script Settlement.cs
	static public readonly float WIDTH_MULTIPLIER = Mathf.Sqrt (3) / 2;
	static public readonly float radius = 1f;
	static public readonly float Hb = radius * 2; //Hb is the height of a hex.
	static public readonly float Ha = WIDTH_MULTIPLIER * Hb; //Ha is the width of a hex.
	static public readonly float Ra_width = Ha * RealmMap.numberColumns; //Ra_width is the width of a realm. 
	static public readonly float Rb_height = Hb * RealmMap.numberRows; //Rb_Height is the height of a realm.
	//float Ra_percentage = (Ra_width / (Ra_width + Rb_height)); //Gives back the percentage to resize the tile on Ra
	//float Rb_percentage = (Rb_height / (Ra_width + Rb_height)); //Gives back the percentage to resize the tile on Rb

	public void GenerateWorld() 
	{
		for (int column = 0; column < numberColumns; column++) 
		{
			for (int row = 0; row < numberRows; row++) 
			{
				// Instantiate a realm
				RealmPosition r = new RealmPosition( column, row ); 

				GameObject RealmGameObject = (GameObject)Instantiate(	
					WorldPrefab,
					r.Position(),
					Quaternion.identity,
					this.transform
				);

				RealmGameObject.name = "Realm_Coord_" + column + "_" + row;

				Vector3 realmChanger = RealmGameObject.transform.localScale;
				realmChanger.x = (RealmGameObject.transform.localScale.x * Ra_width) / 10; //* Ra_percentage);
				realmChanger.y = (RealmGameObject.transform.localScale.y);
				realmChanger.z = (RealmGameObject.transform.localScale.z * Rb_height) / 10; //* Rb_percentage);
				RealmGameObject.transform.localScale = realmChanger;

				RealmGameObject.transform.localPosition += new Vector3 (0, 0, (row * -(Hb)) + (row * (realmChanger.z)));
				RealmGameObject.transform.localPosition += new Vector3 ((column * -(Hb)) + (column * (realmChanger.x)), 0, 0);


				RealmGameObject.transform.SetParent (this.transform);

				RealmGameObject.isStatic = true;

				Debug.Log ("Ha ist " + Ha);
				Debug.Log ("Hb ist " + Hb);
				Debug.Log ("Ra_width ist " + Ra_width);
				Debug.Log ("Rb_Height ist " + Rb_height);

				//RealmGameObject.GetComponent<RealmComponent> ().Realm = r;
				//RealmGameObject.GetComponent<RealmComponent> ().WorldMap = this;

				RealmGameObject.GetComponentInChildren<TextMesh> ().text = string.Format ("{0},{1}", column, row);

				//NOW FOR THE CLIMATE, what will finally be "paintet" in the realm only
				//whats the whole summ of all climate numbers?
				climateWholeNumber = numberCold + numberWarm + numberMediterranean + numberDesert + numberTropic;
				//whats the percentage of the world of the single climate zones?
				climateColdPercent = numberCold / (climateWholeNumber / 100f);
				climateWarmPercent = numberWarm / (climateWholeNumber / 100f);
				climateMediterraneanPercent = numberMediterranean / (climateWholeNumber / 100f);
				climateDesertPercent = numberDesert / (climateWholeNumber / 100f);
				climateTropicPercent = numberTropic / (climateWholeNumber / 100f);
				//TODO: calculate this somewhere else one time, not every loop...

				//Now that we have the numbers, we have to divide the world y-axis along this lines
				//like "if column < y than mr.material = blabla"
				if (numberTropic != 0 & row <= (numberRows / 2) + (numberRows * ((climateTropicPercent / 100) / 2)) & row >= (numberRows / 2) - (numberRows * ((climateTropicPercent / 100) / 2))) 
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateTropic;
				} 
				else if (numberDesert != 0 & row <= (numberRows / 2) + (numberRows * ((climateTropicPercent / 100) / 2)) + (numberRows * ((climateDesertPercent / 100) / 2)) & row >= (numberRows / 2) - (numberRows * ((climateTropicPercent / 100) / 2)) - (numberRows * ((climateDesertPercent / 100) / 2))) 
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateDesert;
				} 
				else if (numberMediterranean != 0 & row <= (numberRows / 2) + (numberRows * ((climateTropicPercent / 100) / 2)) + (numberRows * ((climateDesertPercent / 100) / 2)) + (numberRows * ((climateMediterraneanPercent / 100) / 2)) & row >= (numberRows / 2) - (numberRows * ((climateTropicPercent / 100) / 2)) - (numberRows * ((climateDesertPercent / 100) / 2)) - (numberRows * ((climateMediterraneanPercent / 100) / 2))) 
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateMediterranean;
				} 
				else if (numberWarm != 0 & row <= (numberRows / 2) + (numberRows * ((climateTropicPercent / 100) / 2)) + (numberRows * ((climateDesertPercent / 100) / 2)) + (numberRows * ((climateMediterraneanPercent / 100) / 2)) + (numberRows * ((climateWarmPercent / 100) / 2)) & row >= (numberRows / 2) - (numberRows * ((climateTropicPercent / 100) / 2)) - (numberRows * ((climateDesertPercent / 100) / 2)) - (numberRows * ((climateMediterraneanPercent / 100) / 2)) - (numberRows * ((climateWarmPercent / 100) / 2))) 
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateWarm;
				} 
				else if (numberCold != 0 & row <= (numberRows / 2) + (numberRows * ((climateTropicPercent / 100) / 2)) + (numberRows * ((climateDesertPercent / 100) / 2)) + (numberRows * ((climateMediterraneanPercent / 100) / 2)) + (numberRows * ((climateWarmPercent / 100) / 2)) + (numberRows * ((climateColdPercent / 100) / 2)) & row >= (numberRows / 2) - (numberRows * ((climateTropicPercent / 100) / 2)) - (numberRows * ((climateDesertPercent / 100) / 2)) - (numberRows * ((climateMediterraneanPercent / 100) / 2)) - (numberRows * ((climateWarmPercent / 100) / 2)) - (numberRows * ((climateColdPercent / 100) / 2))) 
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateCold;
				} 
				else if (numberCold == 0 & numberWarm != 0)
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateWarm;
				} 
				else if (numberWarm == 0 & numberMediterranean != 0)
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateMediterranean;
				}
				else if (numberMediterranean == 0 & numberDesert != 0)
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateDesert;
				}
				else if (numberDesert == 0 & numberTropic != 0)
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateTropic;
				} 
				else
				{
					MeshRenderer mr = RealmGameObject.GetComponentInChildren<MeshRenderer> ();
					mr.material = MatClimateWarm;
				} 
				//Later this material stuff is only part of the realm szene, editor etc.
				//and here you will get a screenshot or something of the realm and
				//Gameobjects for the settlements, maybe for armies, too.
			}
		}

	}
}
