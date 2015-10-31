using UnityEngine;
using System.Collections;

public class Movement : ActorBaseScript {
	
	GameObject 	movementGameObject;


	public GameObject GoalObject;
	public Ray ray;
	public RaycastHit hit;
	private float rayCastHeight = 200f;
	private float rayCastLength = 200f;

	void Awake () 
	{
		base.Intitalization ();

		movementGameObject = transform.FindChild ("MovementGameObject").gameObject;

//		GoalObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
//		GoalObject.transform.localRotation 	= Quaternion.identity;
//		GoalObject.transform.localPosition 	= Vector3.zero;
//		GoalObject.transform.localScale  	= new Vector3(0.05f, 5f, 0.05f);
//		GoalObject.transform.position 		= GameController.ArenaTerrain.GetSpawnPoint();
//		GoalObject.transform.position 		= new Vector3 (GoalObject.transform.position.x, 0f, GoalObject.transform.position.z);
	}
	
	void Start () 
	{
		this.transform.position = GameController.ArenaTerrain.GetSpawnPoint();
		//Set movementTransform orientation
		Ray ray = new Ray (transform.position, Vector3.down);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 5f))
		{
			movementGameObject.transform.position 	= hit.point;
			movementGameObject.transform.up 		= hit.normal.normalized;
		}


	}

	void Update () 
	{
	
		Debug.DrawRay (ray.origin, ray.direction.normalized * rayCastLength);

	}

	public bool StepToPoint(Vector3 goal, float distance)
	{
		GameObject trailObject = TrailObject ();

		Vector3 currentNormal = movementGameObject.transform.up;

		Vector3 pos = new Vector3(transform.position.x, 0f, transform.position.z);
		goal = new Vector3(goal.x, 0f, goal.z);

		float angle = Angle360XZ(pos, goal);

		Vector3 positionOnRadius = GetPositionOnRadiusXZ (angle, distance);
		positionOnRadius.y = rayCastHeight;

		ray = new Ray (positionOnRadius, Vector3.down);
		//TODO Distance isnt accurate when crossing to a different Normal
		if (Physics.Raycast (ray, out hit, rayCastLength)) 
		{

			Vector3 point = hit.point;
			Vector3 normal = hit.normal.normalized;
		
			if (normal == currentNormal.normalized) 
			{
				print ("Same");
				transform.position = Vector3.MoveTowards(transform.position, point, distance);
				return true;
			}
			AlignToMeshNormal(hit);
		}

		return true;
	}

	public void AlignToMeshNormal(RaycastHit hit)
	{
		transform.position = hit.point;
		movementGameObject.transform.up = hit.normal.normalized;

	}

	public GameObject TrailObject ()
	{
		GameObject tempObject = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		tempObject.name = GameController.TurnLoop.TurnID.ToString ();
		tempObject.GetComponent<SphereCollider> ().enabled = false;
		tempObject.transform.position = transform.position;
		tempObject.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		tempObject.transform.up = movementGameObject.transform.up;
		return tempObject;
	}

	public Vector3 GetPositionOnRadiusXZ(float angle, float radius)
	{
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		x = x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
		z = z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
		
		return new Vector3 (x, y, z);
	}

	public float Angle360XZ(Vector3 from, Vector3 to)
	{
		Vector3 p1 = from;
		Vector3 p2 = to;
		float rawAngle = Mathf.Atan2(p2.z-p1.z, p2.x-p1.x)*180 / Mathf.PI;
		if(rawAngle >= 0 && rawAngle < 180){return rawAngle;}
		return rawAngle + 360f;
	}

}





//public bool StepToPoint(Vector3 goalPos, float distance)
//{
//	GameObject trailObject = TrailObject ();
//	
//	Vector3 currentNormal = movementGameObject.transform.up;
//	Vector3 posMod = new Vector3(transform.position.x, 0f, transform.position.z);
//	goalPos = new Vector3(goalPos.x, 0f, goalPos.z);
//	float angle = Angle360XZ(posMod, goalPos);
//	print (angle);
//	
//	Vector3 positionOnRadius = GetPositionOnRadiusXZ (angle, distance);
//	positionOnRadius.y = 1f;
//	ray = new Ray (positionOnRadius, Vector3.down);
//	//check if is same normal
//	if (Physics.Raycast (ray, out hit, 1f)) 
//	{
//		
//		Vector3 point = hit.point;
//		Vector3 normal = hit.normal.normalized;
//		
//		if (normal == currentNormal.normalized) 
//		{
//			print ("Same");
//			transform.position = Vector3.MoveTowards(transform.position, point, distance);
//			
//		}else{
//			print ("Different");
//			for (int i = 0; i < distance; i = i + 0.01) 
//			{
//				ray = new Ray (Vector3.MoveTowards(transform.position, point, i), Vector3.down);
//				if (Physics.Raycast (ray, out hit, 1f)) 
//				{
//					if (normal == currentNormal.normalized) 
//					{
//						print ("Same");
//						
//						
//					}else{
//						print ("Different");
//						
//					}
//				}
//			}
//			
//			
//			
//		}
//	}
//	return true;
//}
