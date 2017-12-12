using System.Collections;
using UnityEngine;
using System;

[Serializable]
public class TileData : MonoBehaviour{

	//This should be a simple script (because all hexes get this). 
	//it should only contain things a hex should know about
	//itself like its coordinates in the map
	public int x;
	public int y;
	public int realmid;
	public int tileid;
	public int type;
	public SettlementData settlement;
}
