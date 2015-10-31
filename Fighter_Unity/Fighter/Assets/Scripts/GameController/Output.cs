using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Output : GameControllerBaseScript 
{
	void Awake()
	{
		base.Intitalization ();
	}

	public void Log(string str)
	{
		print(String.Format("{0} - {1}", GameController.TurnLoop.TurnID, str));
	}
}
