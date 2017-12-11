using System.Collections;
using System.Collections.Generic;

public class DataController {
	
	public static DataController instance;

	private WorldData world;

	void Awake(){
		instance = this;
	}

	public void createWorld(string name, string endtime, int xsize, int ysize, float coldC, float warmC, float medC, float desertC, float tropicC){
		world = new WorldData ();
		world.name = name;
		//Call Random World Creation...

	}
}
