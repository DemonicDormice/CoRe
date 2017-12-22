using UnityEngine;
using System.Collections.Generic;

public class globalPrefabs : ScriptableObject
{
	public static Dictionary<int, Object> objectList = new Dictionary<int, Object>();
	private static Object emptyObj;

	public static Object getPrefab(string objName)
	{
		Object obj;

		if (objectList.TryGetValue(objName.GetHashCode(), out obj))
			return obj;
		else 
		{
			//Debug.Log ("Object not found: " + objName, 3);
			return (emptyObj);
		}
	}

	public static void LoadAll(string pPath) 
	{
		Object[] ObjectArray = Resources.LoadAll(pPath);

		foreach (Object o in ObjectArray) 
			objectList.Add (o.name.GetHashCode(), (Object)o);
	}
		
}