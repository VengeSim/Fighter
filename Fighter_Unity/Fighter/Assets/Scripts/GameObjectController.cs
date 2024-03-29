using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameObjectController : MonoBehaviour {

	protected bool facingRight;

	public bool FacingRight {get {return this.facingRight;}}

	// Use this for initialization
	void Awake () {
		this.facingRight = true;
	}
	
	void Update () {
	
	}
	
	public void Turn(){
		if(this.facingRight){
			this.FaceLeft();
		}else{
			this.FaceRight();
		}
	}
	
	public bool IsOnRightSide(Vector2 vector2){
		//Returns true if this object is on the right side of var vector2
		if(this.transform.position.x > vector2.x){
			return true;
		}
		
		return false;
	}
	
	public void FaceRight(){
		if( transform.localScale.x < 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			this.facingRight = true;
		}
	}
	public void FaceLeft(){
		if( transform.localScale.x > 0f ){
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			this.facingRight = false;
			
		}
	}
}