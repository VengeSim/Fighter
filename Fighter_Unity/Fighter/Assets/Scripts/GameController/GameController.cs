using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public TurnLoop TurnLoop;
	public ActorList ActorList;
	public Variables Variables;
	public Output Output;

	public GameObject Arena;
	public ArenaTerrain ArenaTerrain;

	void Awake () 
	{
		this.TurnLoop = GetComponent<TurnLoop> ();
		this.ActorList = GetComponent<ActorList> ();
		this.Variables = GetComponent<Variables> ();
		this.Output = GetComponent<Output> ();

		this.Arena = GameObject.Find ("Arena");
		this.ArenaTerrain = this.Arena.GetComponent<ArenaTerrain>();
	}

	void Start()
	{
		TurnLoop.StartLoop ();

	}
	void Update () 
	{
	
	}
}
