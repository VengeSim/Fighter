using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TurnList : MonoBehaviour {

	private FrameLoop FrameLoop;

	public List<Actor> ActorList;

	void Awake () {

		FrameLoop = GetComponent<FrameLoop> ();
		ActorList = new List<Actor> ();

	}

	void Start () {
		FrameLoop.StartLoop ();
	}
	
	void Update () {
	
	}

	public void Log(string str){
		print(String.Format("{0} - {1}", FrameLoop.FrameID, str));
	}

	public void AddActor(Actor actor){

		if (!ActorList.Contains (actor)) {

			ActorList.Add (actor);
			FrameLoop.PreTick += actor.PreTick;
			FrameLoop.Tick += actor.Tick;
			FrameLoop.PostTick += actor.PostTick;


		} else {

			Log ("AddActor - Actor already in list");

		}
	}

	public void RemoveActor(Actor actor){

		if (ActorList.Contains (actor)) {

			ActorList.Remove (actor);
			FrameLoop.PreTick -= actor.PreTick;
			FrameLoop.Tick -= actor.Tick;
			FrameLoop.PostTick -= actor.PostTick;


		} else {

			Log ("RemoveActor - Actor not in list");
			
		}

	}
}
