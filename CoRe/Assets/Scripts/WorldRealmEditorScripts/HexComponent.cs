using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour {

	public HexPosition Hex;
	public RealmMap RealmMap;

	/* public void UpdatePosition()
	{
		this.transform.position = Hex.PositionFromCamera(
			Camera.main.transform.position,
			RealmMap.numberColumns,
			RealmMap.numberRows
		);
	} */
}
