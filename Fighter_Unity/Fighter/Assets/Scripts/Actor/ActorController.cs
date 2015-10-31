using UnityEngine;
using System.Collections;

public class ActorController : GameObjectBaseScript {

	public Movement Movement;
	public Vector3 Goal;
	GameObject tempObject;
	void Awake () 
	{
		Intitalization ();

		this.Movement = GetComponent<Movement> ();
	}
	
	void Start()
	{
		GameController.ActorList.AddActor (this);
		Goal = new Vector3 (0f, 0f, 0f);
	}
	
	void Update () 
	{
		if (Input.GetMouseButton(1)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{

				//print ("MouseClicked!");

				Goal = hit.point;
				//Direction.y = 0f;
				tempObject = GameObject.CreatePrimitive (PrimitiveType.Sphere);
				tempObject.name = "Goal Position";
				tempObject.GetComponent<SphereCollider> ().enabled = false;
				tempObject.transform.position = hit.point;
				tempObject.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
			}
		}
	}
	
	public virtual void PreTick()
	{
		
		
	}
	
	public virtual void Tick()
	{
		if(Goal != Vector3.zero)
		Movement.StepToPoint (Goal, 0.1f);
	}
	
	public virtual void PostTick()
	{
		
		
	}
}
