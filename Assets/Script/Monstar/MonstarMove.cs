using UnityEngine;
using System.Collections;

public class MonstarMove : MonoBehaviour {
	public Transform player;
	public float speed = 4f;
	private bool rockOn;
	public bool save = true;//生存してるか
	// Use this for initialization
	void Start () {
		player  = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (rockOn && save) {
			Vector3 direc = player.position - transform.position;
			direc = direc.normalized;
			transform.position += direc * speed * Time.deltaTime;
			transform.LookAt (player);
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			rockOn = true;
		} else if (col.tag == "weapon") {
			Destroy (gameObject);
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Player") {
			rockOn = false;
		}
	}
}
