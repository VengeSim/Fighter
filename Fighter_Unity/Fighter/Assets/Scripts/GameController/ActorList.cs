using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ActorList : GameControllerBaseScript {
	
	public List<ActorController> List;

	void Awake () 
	{
		Intitalization ();

		List = new List<ActorController> ();

	}

	void Update () 
	{
	
	}



	public void AddActor(ActorController actor){

		if (!List.Contains (actor)) {

			List.Add (actor);
			GameController.TurnLoop.PreTick += actor.PreTick;
			GameController.TurnLoop.Tick += actor.Tick;
			GameController.TurnLoop.PostTick += actor.PostTick;


		} else {

			GameController.Output.Log ("AddActor - Actor already in list");

		}
	}

	public void RemoveActor(ActorController actor){

		if (List.Contains (actor)) {

			List.Remove (actor);
			GameController.TurnLoop.PreTick -= actor.PreTick;
			GameController.TurnLoop.Tick -= actor.Tick;
			GameController.TurnLoop.PostTick -= actor.PostTick;


		} else {

			GameController.Output.Log ("RemoveActor - Actor not in list");
			
		}

	}
}
