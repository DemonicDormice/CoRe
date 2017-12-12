using System.Collections;
using System.Collections.Generic;

public class DataControllerEditor {
	
	public static DataControllerEditor instance;

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
