using UnityEngine;
using System.Collections;

public class ActorBaseScript : GameObjectBaseScript 
{

	protected ActorController ActorController;

	protected override void Intitalization()
	{
		base.Intitalization ();
		this.ActorController = GetComponent<ActorController>();
	}
}
