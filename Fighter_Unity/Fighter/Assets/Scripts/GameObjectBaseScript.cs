using UnityEngine;
using System.Collections;

public class GameObjectBaseScript : MonoBehaviour 
{

	protected GameController GameController;

	protected virtual void Intitalization()
	{
		GameController = GameObject.Find ("GameController").GetComponent<GameController>();
	}

}
