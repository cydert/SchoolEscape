using UnityEngine;
using System.Collections;

public class PlayerMove1 : MonoBehaviour {
	private float speed = 10f;
	private float rotation = 4f;
	private string[] key1;
	private const float GRAVITY = 9.8f;
	// Use this for initialization
	void Start () {
		key1 = new string[4];
		key1[0] = "w";
		key1[1] = "s";
		key1[2] = "a";
		key1[3] = "d";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(key1[0])) {	//前進
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey (key1 [1])) {
			transform.position += transform.forward * speed * Time.deltaTime * -1;
		}

		//回転
		if (Input.GetKey (key1 [2])) {
			transform.Rotate (new Vector3 (0f, rotation * -1, 0f));
			//transform.eulerAngles += new Vector3 (0f, rotation*-1, 0f);
		}
		if (Input.GetKey (key1 [3])) {
			transform.Rotate (new Vector3 (0f, rotation, 0f));
			//transform.eulerAngles += new Vector3 (0f, rotation, 0f);
		}

		//重力
		//transform.position -= new Vector3(0f, GRAVITY * Time.deltaTime, 0f);

	}
}
