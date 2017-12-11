using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Settlement class defines grid position, world space position of the Settlements, size, neighbours and does
// not interact with Unity directly
public class Settlement : MonoBehaviour {
	
	// Use this for initialization
	void Start ()
	{
		GenerateSettlements ();

	}

	public GameObject SettlementPrefab;

	public void GenerateSettlements()
	{
		//Whats important for the settlement from database:
		//The X/Y of their realm (Rx / Ry)
		//The X/Y of their hex inside the realm (Hx / Hy)
		//There has to be a sort of loop which builds all the 
		//settlements of the whole map
		//TODO: Later they should get colored depending on
		//fraction, npc or player.

		int Rx = 2; //Later from database
		int Ry = 2; //Later from database
		int Hx = 0; //Later from database
		int Hy = 0; //Later from database

		float Hb = WorldMap.Hb; //Hb is the height of a hex.
		float Ha = WorldMap.Ha; //Ha is the width of a hex.

		float Ra = WorldMap.Ra_width / 10; //Ra is the width of a realm. 
		float Rb = WorldMap.Rb_height / 10; //Ra is the height of a realm.	

		//To work with Rx and Ry in an changing world depending on the size of the realms
		//we need to implement the changed realmposition on the worldmap to change
		//the fixed points of the settlements accordingly


		//float Rx_changed = (Rx); // * -( Hb ));// + (Rx * ( Ra ));
		//float Ry_changed = (Ry); // * -( Hb ));// + (Ry * ( Rb ));


		//float columnSett = (Rx_changed); // - ( Ra / 2 )) + ( Hx * Ha ) + ( Ha / 2 ); 
		//float rowSett = (Ry_changed); // - ( Rb / 2 )) + ( Hy * Hb ) + ( Hb / 2 );
		float Rx_changed = (Rx); // * -( Hb ));// + (Rx * ( Ra ));
		float Ry_changed = (Ry); // * -( Hb ));// + (Ry * ( Rb ));


		float columnSett = (Rx_changed - (Ra / 2)) + (Hx * Ha) + (Ha / 2); 
		float rowSett = (Ry_changed - (Rb / 2)) + (Hy * Hb) + (Hb / 2);


		// Instantiate a settlement
		//Settlement r = new Settlement( columnSett, rowSett ); 

				GameObject SettlementGameObject = (GameObject)Instantiate(	
					SettlementPrefab,
					new Vector3 (columnSett, 0, rowSett),
					Quaternion.identity,
					this.transform 
				); 

	//	SettlementGameObject.name = "Settlement_Coord_" + columnSett + "_" + rowSett;

	//	SettlementGameObject.transform.SetParent (this.transform);

	//	SettlementGameObject.isStatic = true;

				//RealmGameObject.GetComponent<RealmComponent> ().Realm = r;
				//RealmGameObject.GetComponent<RealmComponent> ().WorldMap = this;

		//SettlementGameObject.GetComponentInChildren<TextMesh> ().text = string.Format ("{0},{1}", column, row);


				//	MeshRenderer mr = hexGO.GetComponentInChildren<MeshRenderer> ();
				//	mr.material = HexMaterials [Random.Range (0, HexMaterials.Length)];
	}
		
}