using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {

	public FighterController controller;

	void Awake () {
		this.controller = this.GetComponent<FighterController>();

	}
	
	void Update () {

		this.CheckHorizontalInputs();
		this.CheckVerticalInputs();
		this.CheckButtonInputs();


	}

	public bool CheckHorizontalInputs(){

		if(	Input.GetAxisRaw("Horizontal") > 0){

			this.controller.WalkRight();
			return true;

		}
		
		if(	Input.GetAxisRaw("Horizontal") < 0){

			this.controller.WalkLeft();
			return true;

		}
		this.controller.StopWalk();
		return false;


	}

	public bool CheckVerticalInputs(){
		
		if(	Input.GetAxisRaw("Vertical") > 0){

			this.controller.Jump();
			return true;
			
		}
		
		if(	Input.GetAxisRaw("Vertical") < 0){

			this.controller.Crouch();
			return true;
			
		}
		this.controller.Stand();
		return false;
		
		
	}

	public void CheckButtonInputs(){

		if(	Input.GetButtonDown("Attack1")){

		}
		
		if(	Input.GetButtonDown("Attack2")){
			
		}
		
		if(	Input.GetButtonDown("Turn")){
			this.controller.Turn();

		}
		
		if (Input.GetButton ("Block")) {
			this.controller.Block ();
		} else {
			this.controller.StopBlock();
		}
		
		if(	Input.GetButtonDown("Increase")){
			
		}
		
		if(	Input.GetButtonDown("Decrease")){
			
		}
		
		if(	Input.GetButtonDown("Start")){

		}
		if(	Input.GetButtonDown("Select")){

		}
	}

}
