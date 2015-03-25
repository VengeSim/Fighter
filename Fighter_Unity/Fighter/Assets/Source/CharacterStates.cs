/*
	Blood Ring
	Copyright © 2014 jgumbo@live.com
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;



public enum State{
	Neutral,
	Crouch
}

public enum BlockState{
	False,
	True
}
public enum StunState{
	False,
	True,
	Block
}
public enum WalkState{
	False,
	Right,
	Left
}

public enum JumpState{
	False,
	True,
	InAir
}
public enum HitState{
	False,
	High,
	Low
}

public enum AttackState{
	Ready,
	StartUp,
	Active,
	Recovery
}



