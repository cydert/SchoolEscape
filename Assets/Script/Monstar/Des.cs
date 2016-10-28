using UnityEngine;
using System.Collections;

public class Des : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.CompareTag("weapon")) {
			//Destroy(this.gameObject);
			GameObject.Destroy (gameObject);
		}
	}
	/*
	void OnTriggerEnter(Collider col){
		Debug.Log ("ss1");
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.CompareTag("weapon")) {
			Debug.Log ("s1");
			//Destroy(this.gameObject);
			GameObject.Destroy (gameObject);
		}
	}
	*/
}
