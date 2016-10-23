using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
	public float Speed = 9.0f;//歩行速度
	public float jHigh = 5.0f;//JUMP力
	public float GravityPower = 10.0f;//重力
	public GameObject obj1;
	Vector3 velocity = Vector3.zero;
	CharacterController characterController;
	bool flag = true;
	bool ctrlIn = false;
	bool highJpN = false;
	bool jumpNow = false;
	Animation anime;
	private Vector3 snapGround = Vector3.down;

	private Vector3 deb;
	/*  --------	入力設定			---------------*/
	string jump = "space";	string jumpHigh = "left ctrl";
	string dash = "left shift";
//	string up = "up";	string down = "down";	string left = "left";	string right = "right";
	string up = "w";	string down = "s";	string left = "a";	string right = "d";
	/* --------------------------------------------------------------------------------------------*/
	// Use this for initialization
	void Start () {
		characterController = GetComponent <CharacterController> ();
		anime = GetComponent (typeof(Animation))as Animation;
	}
	
	// Update is called once per frame
	void Update () {
		float j;
		float walkSpeed = Speed;
		bool running = false;
		if (Input.GetKey (jumpHigh)) {//ctrl押していたら
			j = jHigh * 1.5f;
			ctrlIn = true;
		} else {
			j = jHigh;
			ctrlIn = false;
		}
		//velocity = Vector3.down * GravityPower;
		//接地していたら地面押しつけ
		snapGround += Vector3.down;
		if (characterController.isGrounded) {
			velocity = Vector3.zero;
			snapGround = Vector3.down;
			if (Input.GetKey (jump) && flag) {

				flag = false;
				velocity = Vector3.down * GravityPower * -1 * Time.deltaTime;
				characterController.Move (new Vector3 (0.0f, j, 0.0f));
				jumpNow = true;
			/*	if(ctrlIn){
					highJpN = true;
				}*/
			}else{
				jumpNow = false;
				highJpN = false;
			}
			if (Input.GetKey (dash)) {
				walkSpeed = Speed * 2.0f;
				running = true;
			}
		}
		if(jumpNow){
			velocity = Vector3.down*Time.deltaTime;
			if(highJpN){
				//ジャンプ時の重力
				velocity = Vector3.down*500.5f*Time.deltaTime;
			}
		}
		characterController.Move(velocity*Time.deltaTime+ snapGround*Time.deltaTime);
		//characterController.Move(snapGround*Time.deltaTime);
		//Debug.Log (velocity + ".." + snapGround);
		//Debug.Log (Vector3.down * Time.deltaTime);
		/* ---ここまで重力関係 ------   */
		if (Input.GetKeyDown (jump))
			flag = true;
		Vector3 move = Vector3.zero;
		
		if( Input.GetKey(KeyCode.W))
		{
			move += transform.forward;
		}
		if (Input.GetKey(KeyCode.A))
		{
			move -= transform.right;
		}
		if(Input.GetKey(KeyCode.S))
		{
			move -= transform.forward;
		}
		if(Input.GetKey(KeyCode.D))
		{
			move += transform.right;
		}
		
		characterController.Move(move.normalized*(walkSpeed*1.5f/Mathf.Sqrt(2.0f)*Time.deltaTime));




		/*
		if (Input.GetKey (up) && Input.GetKey (right)) {	///斜め移動
			//characterController.Move(transform.forward*(1/Mathf.Sqrt(2.0f)*walkSpeed*Time.deltaTime));
			//characterController.Move(transform.right*(1/Mathf.Sqrt(2.0f)*walkSpeed*Time.deltaTime));

			obj1.SendMessage("walk",running);
			characterController.Move(transform.forward*(walkSpeed/Mathf.Sqrt(2.0f)*Time.deltaTime));
			characterController.Move(transform.right*(walkSpeed/Mathf.Sqrt(2.0f)*Time.deltaTime));
		} else if (Input.GetKey (up) && Input.GetKey (left)) {
			obj1.SendMessage("walk",running);
			characterController.Move(transform.forward*(1/Mathf.Sqrt(2)*walkSpeed*Time.deltaTime));
			characterController.Move(transform.right*(1/Mathf.Sqrt(2)*walkSpeed*Time.deltaTime*-1));

		} else if (Input.GetKey (down) && Input.GetKey (right)) {
			obj1.SendMessage("walk",running);
			characterController.Move(transform.forward*(1/Mathf.Sqrt(2)*walkSpeed*Time.deltaTime*-1));
			characterController.Move(transform.right*(1/Mathf.Sqrt(2)*walkSpeed*Time.deltaTime));
		} else if (Input.GetKey (down) && Input.GetKey (left)) {
			obj1.SendMessage("walk",running);
			characterController.Move(transform.forward*(1/Mathf.Sqrt(2)*walkSpeed*Time.deltaTime*-1));
			characterController.Move(transform.right*(1/Mathf.Sqrt(2)*walkSpeed*Time.deltaTime*-1));
		} else if (Input.GetKey (up) && !Input.GetKey (down)) {	//前後方
			obj1.SendMessage("walk",running);
			//characterController.Move(new Vector3(walkSpeed,0.0f,0.0f)*Time.deltaTime);
			characterController.Move(transform.forward*(walkSpeed*Time.deltaTime));
		} else if (Input.GetKey (down) && !Input.GetKey (up)) {
			obj1.SendMessage("walk",running);
			characterController.Move(transform.forward*walkSpeed*Time.deltaTime*-1);
		} else if (Input.GetKey (right) && !Input.GetKey (left)) {//左右
			obj1.SendMessage("walk",running);
			characterController.Move(transform.right*walkSpeed*Time.deltaTime);
		} else if (Input.GetKey (left) && !Input.GetKey(right)) {
			obj1.SendMessage("walk",running);
			characterController.Move(transform.right*walkSpeed*Time.deltaTime*-1);
		}
		*/
	}
}
