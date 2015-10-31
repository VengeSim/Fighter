using UnityEngine;
using System.Collections;

public class GameControllerBaseScript : MonoBehaviour 
{

	protected GameController GameController;
	
	protected virtual void Intitalization()
	{
		this.GameController = GetComponent<GameController>();
	}

}
