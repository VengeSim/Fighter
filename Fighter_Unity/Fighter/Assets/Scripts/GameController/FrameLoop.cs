﻿using UnityEngine;
using System;
using System.Collections;
using System.Diagnostics;



public enum LoopState{
	Stop, 
	Run,
	Pause



}



public class FrameLoop : MonoBehaviour {

	public float FrameSpeed;
	public int FrameID;
	public LoopState LoopState;
	[Space(10)]
	public Stopwatch GlobalStopWatch;

	public delegate void TickEvent();
	public event TickEvent PreTick;
	public event TickEvent Tick;
	public event TickEvent PostTick;





	void Awake () 
	{

		LoopState = LoopState.Stop;
		FrameID = 0;

		GlobalStopWatch = new Stopwatch();

	}
	
	void Update () 
	{

	}

	void OnGUI () 
	{
		GUILayout.Label (String.Format("Frame ID = {0}", FrameID));
	}

	IEnumerator Loop() 
	{
		for(;;) 
		{

			if(LoopState == LoopState.Run)
			{
				FrameID++;

				if(PreTick != null){PreTick.Invoke();}
				if(Tick != null){Tick.Invoke();}
				if(PostTick != null){PostTick.Invoke();}

				yield return new WaitForSeconds(FrameSpeed);

			}
			if(LoopState == LoopState.Pause)
			{
				yield return new WaitForSeconds(FrameSpeed);
			}
			if(LoopState == LoopState.Stop)
			{
				yield break;
			}

		}
	}

	public void StartLoop()
	{
		LoopState = LoopState.Run;
		StartCoroutine (Loop());
	}
	
	public void PauseLoop()
	{
		LoopState = LoopState.Pause;
	}
	
	public void StopLoop()
	{
		LoopState = LoopState.Stop;
	}



	/*
	 * Adding TickEvents
	 */
	public void AddPreTickEvent(TickEvent tickEvent)
	{
		PreTick += tickEvent;
	}

	public void AddTickEvent(TickEvent tickEvent)
	{
		Tick += tickEvent;
	}

	public void AddPostTickEvent(TickEvent tickEvent)
	{
		PostTick += tickEvent;
	}




	/*
	 * Removing TickEvents
	 */
	public void RemovePreTickEvent(TickEvent tickEvent)
	{
		PreTick -= tickEvent;
	}
	
	public void RemoveTickEvent(TickEvent tickEvent)
	{
		Tick -= tickEvent;
	}
	
	public void RemovePostTickEvent(TickEvent tickEvent)
	{
		PostTick -= tickEvent;
	}
}


















