using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Realm class defines grid position, world space position of the realms, size, neighbours and does
// not interact with Unity directly

public class Realm {

	// C defines column, R defines row and S defines z-axis
	// C + R + S = 0
	// S = -(C + R) --> ergo: You don't need to ask for S directly
	// Because of this you don't have to think about S, just C and R
	public Realm(int c, int r)
	{
		this.C = c;
		this.R = r;
		this.S = -(c + r);
	}

	public readonly int C;
	public readonly int R;
	public readonly int S;

	//public readonly WorldMap WorldMap;

	static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt (3) / 2;

	float radius = 1f;

	// This will return the world space position of this realm
	public Vector3 Position()
	{
		float height = radius * 2;
		float width = radius * 2; //WIDTH_MULTIPLIER * height;

		float vertical = height; // * 0.75f;
		float horizontal = width;

		return new Vector3(
			horizontal * this.C, //(this.C + this.R/2f),
			0,
			vertical * this.R
		);
	}

	/*
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
}