using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Box : MonoBehaviour {


	public List<Collider2D> Others;

	public bool CheckCollide{
		get{
			if(Others.Count > 0){
				return true;
			}
			return false;
		}
	}
	void Awake () {
		
		
	}
	
	void Update () {

		//for (int i = 0; i < Others.Count; i++) {
			
		//}
	}


	void OnTriggerEnter2D(Collider2D other) {

		Others.Add (other);

	}
	
	void OnTriggerExit2D(Collider2D other) {

		Others.Remove(other);

	}
	
	void OnTriggerStay2D(Collider2D other) {

	}
	

	
	
}





//public enum HitBoxType{
//	High,
//	Low
//}
//
//
//public class HitBox : CollisionFlag {
//	
//	public HitBoxType type;
//	
//	public HitBoxType Type {get {return type;}}
//	public List<HurtBox> others;
//	public List<HurtBox> HurtBoxes {get {return others;}}
//	
//	
//	void Start () {
//		
//	}
//	
//	void Update () {
//		for (int i = 0; i < others.Count; i++) {
//			if(others[i].HitPacket.IsReset){
//				this.others.Remove(others[i]);
//			}
//		}
//		
//		
//	}
//	
//	void OnTriggerEnter2D(Collider2D other) {
//		HurtBox hBox = other.GetComponent<HurtBox>();
//		if(!hBox.HitPacket.IsReset){
//			this.others.Add(hBox);
//		}
//	}
//	
//	void OnTriggerExit2D(Collider2D other) {
//		
//		this.others.Remove(other.GetComponent<HurtBox>());
//	}
//	
//	void OnTriggerStay2D(Collider2D other) {
//		
//		this.others.Remove(other.GetComponent<HurtBox>());
//	}
//	
//}