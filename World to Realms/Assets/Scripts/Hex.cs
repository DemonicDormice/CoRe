using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hex class defines grid position, world space position of the hex, size, neighbours and does
// not interact with Unity directly

public class Hex {

	// C defines column, R defines row and S defines z-axis
	// C + R + S = 0
	// S = -(C + R) --> ergo: You don't need to ask for S directly
	// Because of this you don't have to think about S, just C and R
	public Hex(int c, int r)
	{
		this.C = c;
		this.R = r;
		this.S = -(c + r);
	}

	public readonly int C;
	public readonly int R;
	public readonly int S;

	//Data for map generation and maybe in-game effects
	public float HexTerrainValue; //the value a hex gets which determines with the randomgenerator which type the hex is

	//public readonly WorldMap WorldMap;

	float radius = 1f;

	static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt (3) / 2;

	// This will return the world space position of this realm
	/* public Vector3 Position()
	{
		float height = radius * 2;
		float width = WIDTH_MULTIPLIER * height;

		float vertical = height * 0.75f;
		float horizontal = width;
	
		return new Vector3(
			horizontal (this.C + this.R/2f),
			0,
			vertical * (this.R)
		);
	} */		

	public Vector3 Position()
	{		

		//to takkle the rhombus shape
		float xOffset = radius * 0.866025404f;
		float yOffset = radius * 0.75f;

	float xPos = C * xOffset;

	// Are we on an odd row?
	if (R % 2 == 1) {
		xPos += xOffset/2;
	}


		return new Vector3(
			xPos,
			0,
			R * yOffset
		);
	}


	/* new Vector3 (column, 0, row), 
	 
	  public float RealmHight()
	{
		return radius * 2;
	}

	public float RealmWidth()
	{
		return WIDTH_MULTIPLIER * RealmHight();
	}

	public float RealmVerticalSpacing()
	{
		return RealmHight() * 0.75f;
	}

	public float RealmHorizontalSpacing()
	{
		return RealmWidth();
	}

	public Vector3 PositionFromCamera( Vector3 cameraPosition, float numberColumns, float numberRows)
	{
		//float mapHeight = numberRows * RealmVerticalSpacing ();
		float mapWidth = numberColumns * RealmHorizontalSpacing ();

		Vector3 position = Position ();

		float howManyWidthsFromCamera = Mathf.Round((position.x - cameraPosition.x) / mapWidth);
			
			//howManyWidthsFromCamera should be between -0.5 and 0.5 to not be more than
			//half a map width away from the camera

		if (Mathf.Abs (howManyWidthsFromCamera) <= 0.5f) 
		{
			return position;
		}

			// When at 0.6, then we want to be at -0.4
			// When at 2.2, we want to be at 0.2
			// 2.6 would become -0.4
			if (howManyWidthsFromCamera > 0)
				howManyWidthsFromCamera += 0.5f;
			else
				howManyWidthsFromCamera -= 0.5f;
		
			int howManyWidthToFix = (int)howManyWidthsFromCamera;

			position.x -= howManyWidthToFix * mapWidth;

			//int howManyWidthToFix = (int)howManyWidthsFromCamera;

			//position.x -= howManyWidthToFix * mapWidth;

		return position;
		} */  

	public static float Distance (Hex a, Hex b) //this calculates the distance between hexes for RealmMap_Continent.RandomArea
	{
		// WARNING: this can give back Hex a and Hex b which is outside the realm 
		//for example 52/19 in a 50*50 realm.
		int dQ = Mathf.Abs(a.C - b.C);

		if(dQ > RealmMap.numberColumns / 2)
			dQ = RealmMap.numberColumns - dQ;

		int dR = Mathf.Abs(a.R - b.R);

		if(dR > RealmMap.numberRows / 2)
			dR = RealmMap.numberRows - dR;

		return 
			Mathf.Max( 
				dQ, //This gives back the max-amount of distance between those.
				dR, //The biggest one of these is the distance between
				Mathf.Abs(a.S - b.S) //two hexes
			);
	}
}