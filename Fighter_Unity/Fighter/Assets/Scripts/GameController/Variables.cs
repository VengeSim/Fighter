using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Variables : MonoBehaviour 
{
	void Awake()
	{
		Random.seed = 420;

	}

	public static string ArrayToStringGeneric<T>(IList<T> array, string delimeter)
	{
		string outputString = "";
		
		for (int i = 0; i < array.Count; i++)
		{
			if (array[i] is IList<T>)
			{
				//Recursively convert nested arrays to string
				outputString += ArrayToStringGeneric<T>((IList<T>)array[i], delimeter);
			}
			else
			{
				outputString += array[i];
			}
			
			if (i != array.Count - 1)
				outputString += delimeter;
		}
		
		return outputString;
	}
}
