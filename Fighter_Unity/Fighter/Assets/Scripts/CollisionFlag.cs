using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CollisionFlag : MonoBehaviour {
	
	protected GameObjectController controller;
	protected BoxCollider2D boxCollider;
	public bool flag = false;
	
	public GameObjectController GameObjectController {get {return controller;}}
	public BoxCollider2D BoxCollider2D {get {return boxCollider;}}
	public bool Flag {get {return flag;}}
	
	void OnTriggerEnter2D(Collider2D other) {
		this.flag = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		this.flag = false;
	}
	
	void OnTriggerStay2D(Collider2D other) {
		this.flag = true;
	}
	
	void Awake () {
		
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.controller = this.gameObject.transform.root.GetComponent<GameObjectController>();
		
	}
	
	void Update () {

	}
	

}






