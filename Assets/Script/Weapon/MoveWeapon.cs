using UnityEngine;
using System.Collections;

public class MoveWeapon : MonoBehaviour {
	private float angle = 45f;
	private float locatonForward = 1f;
	private Timer tmr;
	private bool getCan = false;
	private string viewTx;
	private string getKey = "q";
	public GameObject pObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {	//Playerと触れたら
			getCan = true;
			viewTx = "Qキー";
			if (Input.GetKey (getKey)) {
				getCan = false;
				//武器入れ替え
				//所持武器を捨てる
				if (Player1.weapon != null) {
					Player1.weapon.transform.parent = null;//子解除
					Player1.weapon.GetComponent<MoveWeapon>().enabled = true;
				}
				Player1.weapon = gameObject;
				pObj.transform.parent = transform;//子として登録
				this.GetComponent<MoveWeapon>().enabled = false;//スクリプト無効
			}
		}
	}
	void OnTriggerExit(Collider col){
		getCan = false;
	}

	void OnGUI(){
		if(getCan)
			GUI.Label (new Rect (0, 0, 100, 30), viewTx);
	}
}
