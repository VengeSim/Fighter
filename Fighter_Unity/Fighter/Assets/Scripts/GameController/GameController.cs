using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public FrameLoop FrameLoop;
	public TurnList TurnList;
	public Variables Variables;


	public GameObject Arena;
	public ArenaTerrain ArenaTerrain;
	void Awake () 
	{
		this.FrameLoop = GetComponent<FrameLoop>();
		this.TurnList = GetComponent<TurnList>();
		this.Variables = GetComponent<Variables>();


		this.Arena = GameObject.Find ("Arena");
		this.ArenaTerrain = this.Arena.GetComponent<ArenaTerrain>();
	}
	
	void Update () 
	{
	
	}
}
