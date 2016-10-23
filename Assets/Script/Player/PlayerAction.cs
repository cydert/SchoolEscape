using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	private bool onActionTx = false;//何か表示イベントがあるなら
	private string viewTx;
	private string actionKey = "e";
	private float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (onActionTx && Input.GetKey(actionKey)) {
			
		}
		
	}
	//void OnCollisionStay(Collision col){
	//void OnControllerColliderHit(ControllerColliderHit col){	
	void OnTriggerStay(Collider col){
		if (col.gameObject.CompareTag ("move")) {	//動かせるものと触れたら
			if (col.gameObject.name.Contains ("ドア")) {
				viewTx = "Eキー";
				onActionTx = true;
				if (Input.GetKey (actionKey)) {
					Door dr = col.gameObject.GetComponent<Door> ();
					dr.Open();
				}

			}
		} else {
			onActionTx = false;
		}
	}

	void OnGUI(){
		if(onActionTx)
			GUI.Label (new Rect (0, 0, 100, 30), viewTx);
	}
}
