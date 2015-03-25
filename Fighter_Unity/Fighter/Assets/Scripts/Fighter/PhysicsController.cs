using UnityEngine;
using System.Collections;

public class PhysicsController : MonoBehaviour {
	
	public float colliderWidth = 0.06f;
	public float colliderLength = 0.80f;
	
	
	protected CollisionFlag frontFlag;
	protected CollisionFlag backFlag;
	protected CollisionFlag groundFlag;
	
	protected FighterController controller;
	protected Rigidbody2D mainBody;
	protected CircleCollider2D mainCircle;
	
	public bool GroundFlag{
		get{
			return this.groundFlag.Flag;
		}
	}
	public bool FrontFlag{
		get{
			return this.frontFlag.Flag;
		}
	}	
	public bool BackFlag{
		get{
			return this.backFlag.Flag;
		}
	}
	void Awake () {
		this.frontFlag = this.transform.Find("FrontFlag").GetComponent<CollisionFlag>();
		this.backFlag = this.transform.Find("BackFlag").GetComponent<CollisionFlag>();
		this.groundFlag = this.transform.Find("GroundFlag").GetComponent<CollisionFlag>();
		
		this.controller = this.GetComponent<FighterController>();
		this.mainBody = this.GetComponent<Rigidbody2D>();
		this.mainCircle = this.GetComponent<CircleCollider2D>();
		
		
	}
	
	
	void Start () {
		BoxCollider2D front = this.frontFlag.gameObject.GetComponent<BoxCollider2D>();
		BoxCollider2D back = this.backFlag.gameObject.GetComponent<BoxCollider2D>();
		BoxCollider2D bottom = this.groundFlag.gameObject.GetComponent<BoxCollider2D>();
		
		front.size = new Vector2( this.colliderWidth, this.mainCircle.radius * colliderLength);
		front.offset = new Vector2(this.mainCircle.offset.x + this.mainCircle.radius, this.mainCircle.offset.y);
		
		back.size = new Vector2( this.colliderWidth, this.mainCircle.radius * colliderLength);
		back.offset = new Vector2(this.mainCircle.offset.x - this.mainCircle.radius, this.mainCircle.offset.y);
		
		bottom.size = new Vector2(this.mainCircle.radius * colliderLength, this.colliderWidth);
		bottom.offset = new Vector2(this.mainCircle.offset.x, this.mainCircle.offset.y - this.mainCircle.radius);
		
	}
	
	void FixedUpdate() {
		if(this.controller.walkState == WalkState.Right){
			if(this.controller.FacingRight){
				this.mainBody.velocity = new Vector2(this.controller.walkForwardSpeed, this.mainBody.velocity.y);
			}else{
				this.mainBody.velocity = new Vector2(this.controller.walkBackwardSpeed, this.mainBody.velocity.y);
				
			}
		}
		if(this.controller.walkState == WalkState.Left){
			if(!this.controller.FacingRight){
				this.mainBody.velocity = new Vector2(-this.controller.walkForwardSpeed, this.mainBody.velocity.y);

			}else{
				this.mainBody.velocity = new Vector2(-this.controller.walkBackwardSpeed, this.mainBody.velocity.y);

			}
		}

	}


//	public void Impulse(){
//		if(onRight){
//			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(wrapper.HitPacket.PushBack , 0), ForceMode2D.Impulse);
//		}else{
//			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-wrapper.HitPacket.PushBack , 0), ForceMode2D.Impulse);
//			
//		}
//	}
}
