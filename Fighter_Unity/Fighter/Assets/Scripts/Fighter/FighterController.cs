using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;


public class FighterController : GameObjectController{



	public PhysicsController physicsController;
	public SpriteRenderer spriteRenderer;
	public Animator animator;
	public Rigidbody2D mainBody;
	
	[Space(10)]

	public float walkForwardSpeed = 3;
	public float walkBackwardSpeed = 2;
	public float jumpHeight = 1;
	public int jumpGroundCoolDown = 20;
	public int health = 1000;
	
	[Space(10)]

	public int inAirFrameCount;
	public int onGroundFrameCount;

	[Space(10)]

	public State state;
	public BlockState blockState;
	public WalkState walkState;
	public JumpState jumpState;
	public HitState hitState;
	public StunState stunState;
	public AttackState attackState;
			
	#region Properties


	public bool GroundFlag{
		get{
			return this.physicsController.GroundFlag;
		}
	}
	public bool FrontFlag{
		get{
			return this.physicsController.FrontFlag;
		}
	}
	public bool BackFlag{
		get{
			return this.physicsController.BackFlag;
		}
	}


	#endregion
	
	void Awake () {

		this.physicsController = this.GetComponent<PhysicsController>();
		this.spriteRenderer = this.transform.Find("Sprite").GetComponent<SpriteRenderer>();
		this.animator = this.transform.Find("Sprite").GetComponent<Animator>();
		this.mainBody = this.GetComponent<Rigidbody2D>();

		this.facingRight = true;

		Mesh mesh = new Mesh ();

		Vector3[] vertices = new Vector3[this.spriteRenderer.sprite.vertices.GetLength(0)];

		for (int i = 0; i < this.spriteRenderer.sprite.vertices.GetLength(0); i++) {
			vertices[i] = this.spriteRenderer.sprite.vertices[i];
		}

		mesh.vertices = vertices;

		int[] triangles = new int[this.spriteRenderer.sprite.triangles.GetLength(0)];

		for (int i = 0; i < this.spriteRenderer.sprite.triangles.GetLength(0); i++) {
			triangles[i] = this.spriteRenderer.sprite.triangles[i];
		}

		mesh.triangles = triangles;

		this.GetComponent<MeshFilter> ().mesh = mesh;

	}
	
	void Update () {


		if (this.jumpState == JumpState.True && this.GroundFlag) {
		} else {

			//Checks if in Air
			if (this.GroundFlag) {
				this.onGroundFrameCount++;
				this.inAirFrameCount = 0;
				this.jumpState = JumpState.False;	
			} else {
				this.onGroundFrameCount = 0;
				this.inAirFrameCount++;
				this.jumpState = JumpState.InAir;	
				
			}

		}

		
		if(this.health <= 0){this.animator.SetBool("KnockDown", true);}


		// Must set animator parameters last
		this.animator.SetInteger("State",(int)this.state);
		this.animator.SetInteger("BlockState",(int)this.blockState);
		this.animator.SetInteger("WalkState",(int)this.walkState);
		this.animator.SetInteger("JumpState",(int)this.jumpState);
		this.animator.SetFloat("Velocity_Y", this.GetComponent<Rigidbody2D>().velocity.y);
		this.animator.SetInteger("HitState",(int)this.hitState);
		this.animator.SetInteger("StunState",(int)this.stunState);


		//Resets at the end of every frame after animator is set

	}
	
	public bool CanMoveLeft(){
		if(this.FacingRight){
			if(this.BackFlag){
				return false;
			}
		}else{
			if(this.FrontFlag){
				return false;
			}
		}
		return true;
	}

	public bool CanMoveRight(){
		if(this.FacingRight){
			if(this.FrontFlag){
				return false;
			}
		}else{
			if(this.BackFlag){
				return false;
			}
		}
		return true;
	}



	public bool Neutral(){
		
		if(this.jumpState == JumpState.False){
			this.state = State.Neutral;
			this.blockState = BlockState.False;
			this.walkState = WalkState.False;

			return true;
		}
		return false;
		
	}

	public bool Crouch(){
		
		if(this.jumpState == JumpState.False){
			this.state = State.Crouch;
			this.walkState = WalkState.False;
			return true;
		}
		return false;
		
	}
	
	public bool Jump(){

		if(this.jumpState == JumpState.False && this.onGroundFrameCount > this.jumpGroundCoolDown && this.blockState == BlockState.False){
			this.jumpState = JumpState.True;
			this.mainBody.velocity = new Vector2(this.mainBody.velocity.x , 0);
			this.mainBody.AddForce(new Vector2(0 , this.jumpHeight), ForceMode2D.Impulse);
			return true;
		}
		return false;

	}

	public bool WalkRight(){
		
		if(this.state == State.Neutral && this.jumpState == JumpState.False && this.blockState == BlockState.False){
			if(this.CanMoveRight()){
				this.walkState = WalkState.Right;

			}
			return true;
		}
		return false;
		
	}

	public bool WalkLeft(){
		
		if(this.state == State.Neutral && this.jumpState == JumpState.False && this.blockState == BlockState.False){
			if(this.CanMoveLeft()){
				this.walkState = WalkState.Left;
				
			}

			return true;
		}
		return false;
		
	}
	public void StopWalk(){

		this.walkState = WalkState.False;

	}
	public void Stand(){
		
		this.state = State.Neutral;
		
	}
	public void Block(){
		
		this.blockState = BlockState.True;
		this.walkState = WalkState.False;
		
	}
	public void StopBlock(){
		
		this.blockState = BlockState.False;
		
	}
}






