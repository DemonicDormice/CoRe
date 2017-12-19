using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class RealmData : MonoBehaviour {

	//This should be a simple script (because all hexes get this). 
	//it should only contain things a realm should know about
	//itself like its coordinates in the WorldMap
	public int realmX;
	public int realmY;
	public List<TileData> tiles;
	public int worldID;
}
