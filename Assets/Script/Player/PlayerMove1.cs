using UnityEngine;
using System.Collections;

public class PlayerMove1 : MonoBehaviour {
	private float speed = 10f;//歩行速度
	public float jHigh = 5.0f;//JUMP力
	public float GravityPower = 9.8f;//重力
	bool flag = true;
	bool jumpNow = false;

	private float rotation = 100f;
	private string[] key1;
	private CharacterController cc;
	private Vector3 v3 = Vector3.zero;
	private Vector3 snapGround = Vector3.down;
	private string jump;
	// Use this for initialization
	void Start () {
		key1 = new string[4];
		key1[0] = "w";
		key1[1] = "s";
		key1[2] = "a";
		key1[3] = "d";
		jump = "space";
		cc = gameObject.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		v3 = Vector3.zero;
		if (Input.GetKey(key1[0])) {	//前進
			v3 += transform.forward;
		}
		if (Input.GetKey (key1 [1])) {
			v3 -= transform.forward;
		}

		//回転
		if (Input.GetKey (key1 [2])) {
			//transform.Rotate (new Vector3 (0f, rotation * -1, 0f));
			transform.eulerAngles += new Vector3 (0f, rotation*Time.deltaTime*-1, 0f);
		}
		if (Input.GetKey (key1 [3])) {
			//transform.Rotate (new Vector3 (0f, rotation, 0f));
			transform.eulerAngles += new Vector3 (0f, rotation * Time.deltaTime, 0f);
		}
		//重力
		if (!cc.isGrounded) {
			snapGround += Vector3.down;
			cc.Move (snapGround * Time.deltaTime);
		}
		cc.Move (v3 * speed * Time.deltaTime);
	}
}
