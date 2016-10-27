using UnityEngine;
using System.Collections;

public class MoveWeapon : MonoBehaviour {
	private float angle = 45f;
	private float locatonForward = 1f;
	private Timer tmr;//時間差スクリプト有効用
	private bool fin;//最終スクリプト処理をするか
	private GameObject oldObj;
	private bool getCan = false;//表示用
	private string viewTx;
	private string getKey = "q";
	public GameObject pObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (getCan) {
			if (Input.GetKey (getKey)) {
				getCan = false;
				//武器入れ替え
				//所持武器を捨てる
				if (Player1.weapon != null) {
					transform.Rotate(new Vector3(0f,0f,0f));
					Player1.weapon.transform.parent = null;//子解除
					fin = true;
					oldObj = Player1.weapon;
				}
				//武器装備
				Player1.weapon = gameObject;
				transform.parent = pObj.transform;//子として登録
				transform.position = pObj.transform.forward + pObj.transform.forward * locatonForward;//装備場所指定
				transform.Rotate(new Vector3(0f,0f,45f));

				getCan = false;
				tmr = new Timer (0.2f);
			}
		}

		//終了処理
		if (fin && tmr.getEndIs()) {
			fin = false;
			oldObj.GetComponent<MoveWeapon> ().enabled = true;//置いたオブジェクトのスクリプト有効化
			this.GetComponent<MoveWeapon>().enabled = false;//このスクリプト無効
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {	//Playerと触れたら
			getCan = true;
			viewTx = "Qキー";
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
