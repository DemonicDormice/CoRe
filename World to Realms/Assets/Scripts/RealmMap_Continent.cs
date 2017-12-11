using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmMap_Continent : RealmMap {

	override public void GenerateRealm() 
	{
		base.GenerateRealm ();

		int numberRaisedArea = 2;
		int continentSpacing = numberColumns / numberRaisedArea;

		//Uncomment this to generate the same "random" terrain every time.
		Random.InitState(1);

		for (int cont = 0; cont < numberRaisedArea; cont++)
		{
			// Make some kind of raised area. With numberContinents you choose how many
			int numSplats = Random.Range(4, 8);
			for (int i = 0; i < numSplats; i++)
			{
				int range = Random.Range(5, 8);
				int y = Random.Range(range, numberRows - range);
				int x = Random.Range (0, 10) - y / 2 + (cont * continentSpacing);

				RandomArea (x, y, range);
			}
		}

		//Now we add some perline noise
		float noiseResolution = 0.15f; //lets you tune the resolution
		Vector2 noiseOffset = new Vector2 ( Random.Range (0f, 1f), Random.Range (0f, 1f) ); //thats to randomize the PerlinNoise because its not random per se
		float noiseScale = 1f; //PerlinNoise gives back a value vom 0 to +1 (larger values makes bigger "area" over "normal")
		for (int column = 0; column < numberColumns; column++) 
		{
			for (int row = 0; row < numberRows; row++) 
			{
				Hex h = GetHexAt (column, row);
				float n = Mathf.PerlinNoise ( ((float)column/Mathf.Max(numberColumns, numberRows) / noiseResolution) + noiseOffset.x, ((float)row/Mathf.Max(numberColumns, numberRows) / noiseResolution) + noiseOffset.y); //The division by noiseResolution lets you tune the resolution. x and y are not necessarily linked to columns and rows. PerlinNoise doesn't have to be linked to the realm coordinates 
				h.HexTerrainValue += n * noiseScale;
			}
		}

		UpdateHexVisuals ();
	}

	void RandomArea (int c, int r, int range, float centerHeight = 0.5f)
	{
		Hex centerHex = GetHexAt(c, r);

		Hex[] areaHexes = GetHexesWithinRangeOf(centerHex, range);

		foreach(Hex h in areaHexes)
		{
			//if (h.HexTerrainValue < 0)
			//h.HexTerrainValue = 0; 

			h.HexTerrainValue = centerHeight * Mathf.Lerp ( 1f, 0.25f, Mathf.Pow(Hex.Distance (centerHex, h) / range, 2f)); //Its lerping depending on the distance between the centerHex and the current Hex h

			//h.Elevation = centerHeight * Mathf.Lerp( 1f, 0.25f, Mathf.Pow(Hex.Distance(centerHex, h) / range,2f) );
		}
	}
}
