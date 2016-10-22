using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool move = true;
	public bool isOpen = false;
	private float oldPos = 0;

	// Use this for initialization
	void Start () {
		Open ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool Open(){
		if (move) {
			isOpen = true;
			oldPos = transform.position.x;
			while (transform.position.x - oldPos <= 1.65f) {
				transform.position += new Vector3 (0.001f, 0f, 0f) * Time.deltaTime;
			}
			return true;
		} else {
			return false;
		}
	}

	bool Close(){
		if (move) {
			isOpen = true;
			oldPos = transform.position.x;
			while (oldPos - transform.position.x <= 50f) {
				transform.position -= new Vector3 (2f, 0f, 0f) * Time.deltaTime;
			}
			return true;
		} else {
			return false;
		}
	}

}
