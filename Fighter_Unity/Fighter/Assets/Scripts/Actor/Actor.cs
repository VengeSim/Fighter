using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour {

	public GameController GameController;

	void Awake () {
		this.GameController = GameObject.Find ("GameController").GetComponent<GameController>();
		this.GameController.TurnList.AddActor (this);



	}

	void Start(){

		this.transform.position = this.GameController.ArenaTerrain.GetSpawnPoint ();
	}
	
	void Update () {
		
	}

	public virtual void PreTick(){


	}

	public virtual void Tick(){

		if (Input.GetKey (KeyCode.A)) {
			Log("Pressed A!");

		}

	}

	public virtual void PostTick(){


	}

	void Log(string str){
		GameController.TurnList.Log (str);
	}

	public void MoveX(float x){
		transform.position = new Vector2 (transform.position.x + x, transform.position.y);

	}
	public void MoveY(float y){
		transform.position = new Vector2 (transform.position.x, transform.position.y + y);
	}

	public void Move(float x, float y){
		transform.position = new Vector2 (transform.position.x, transform.position.y + y);
	}
	public void Move(Vector2 vector){
		transform.position += (Vector3)vector;
	}
}




