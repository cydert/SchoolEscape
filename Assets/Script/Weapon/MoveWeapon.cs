using UnityEngine;
using System.Collections;

public class MoveWeapon : MonoBehaviour {
	private float angle = 45f;
	private float locatonForward = 1f;
	private Timer tmr;//時間差スクリプト有効用
	private bool fin = false;//最終スクリプト処理をするか
	private GameObject oldObj;
	private bool getCan = false;//表示用
	private string viewTx;
	private string getKey = "q";
	private GameObject pObj;

	public float upY;//各武器誤差対処用 交換時
	// Use this for initialization
	void Start () {
		pObj = Player1.playerObj;
	}
	
	// Update is called once per frame
	void Update () {
		//終了処理
		if (fin && tmr.getEndIs()) {
			fin = false;
			oldObj.GetComponent<MoveWeapon> ().enabled = true;//置いたオブジェクトのスクリプト有効化
			this.GetComponent<MoveWeapon>().enabled = false;//このスクリプト無効
		}else if (getCan) {
			if (Input.GetKey (getKey)) {
				getCan = false;
				//武器入れ替え
				//所持武器を捨てる
				if (Player1.noActiveWeapon != null) {
					Player1.noActiveWeapon.transform.parent = null;//子解除
					Player1.noActiveWeapon.SetActive(true);//再表示

					fin = true;
					oldObj = Player1.noActiveWeapon;
				}
				//武器装備
				gameObject.transform.parent = pObj.transform;//子として登録
				Player1.noActiveWeapon = gameObject;
				gameObject.transform.position = Player1.playerObj.transform.position + new Vector3(0f,upY,0f);
				gameObject.SetActive(false);//非表示
				getCan = false;
				tmr = new Timer (0.2f);


			}
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
