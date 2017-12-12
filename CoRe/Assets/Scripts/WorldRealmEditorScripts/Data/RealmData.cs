using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class RealmData : MonoBehaviour {

	//This should be a simple script (because all hexes get this). 
	//it should only contain things a realm should know about
	//itself like its coordinates in the WorldMap
	public int x;
	public int y;
	public List<TileData> tiles;
	public int worldid;
	public int realmid;
}
