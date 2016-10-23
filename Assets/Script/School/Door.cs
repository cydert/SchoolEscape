using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool move = true;//動かせるか
	private bool moving = false;//動作中か
	private bool isOpen = false;//開いているか
	private float oldPos = 0;
	private float doorSpeed = 2f;//1.5

	private float time;	//アクション表示時間計測
	private bool onActionTx = false;//何か表示イベントがあるなら
	private string viewTx;
	private string actionKey = "e";
	private float checkTime = -1f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (checkTime != -1f) {
			if (Time.time - checkTime >= 0.5f) {
				checkTime = -1f;
				onActionTx = false;
			}
		}

		if (moving && move) {
			if (isOpen) {//開いているなら
				if (oldPos- transform.position.x <= 1.64f) {
					transform.position -= new Vector3 (doorSpeed, 0f, 0f) * Time.deltaTime;
				} else {//開 完了
					isOpen = false;
					moving = false;
				}
			} else {//閉じてれば
				if (transform.position.x - oldPos <= 1.64f) {
					transform.position += new Vector3 (doorSpeed, 0f, 0f) * Time.deltaTime;
				} else {//閉 完了
					isOpen = true;
					moving = false;
				}
			}
		}
	}

	public bool Open(){
		if (move) {
			if (!moving) {//動作中でなければ
				oldPos = transform.position.x;
				moving = true;
			}
			return true;
		}else{
			return false;
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.CompareTag ("Player")) {	//Playerと触れたら
				checkTime = Time.time;
				viewTx = "Eキー";
				onActionTx = true;
				if (Input.GetKey (actionKey)) {
					Open();
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
