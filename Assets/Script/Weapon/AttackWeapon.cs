using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackWeapon : MonoBehaviour {
	private float mouseX;
	private float mouseY;
	private bool attackBt;

	private float screenW;
	private float screenH;
	private float[] screenHarf;
    private float[,] xy;//攻撃したい箇所
    private int cnt,cnt2;
	private float timerF;//ドラッグ可能時間
	public Image img;//バーの画像(サイズを変更する)
	private float[] imageLong = new float[2];//初期の画像サイズx,y
    private bool dragIs;//ドラッグ中か
	private bool attackNow;//攻撃中か
	private int howAtNow;//現在の攻撃方法
    // Use this for initialization
    void Start () {
		screenW = Screen.width;
		screenH = Screen.height;

		screenHarf = new float[2];
		screenHarf [0] = screenW / 2;
		screenHarf [1] = screenH / 2;
        xy = new float[2,300];

		imageLong[0] = img.GetComponent<RectTransform> ().sizeDelta.x;
		imageLong[1] = img.GetComponent<RectTransform> ().sizeDelta.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))//左クリックしたら
        {
            cnt = 0;
            dragIs = true;
			timerF = Time.time;
        }

        if (Input.GetMouseButtonUp(0))//左クリック終了
        {
            dragIs = false;
			attackNow = true;
			attackCheck ();//どんな攻撃か
			changeRotationHowAt ();//オブジェクト回転
        }

        if (dragIs)	//ドラッグ中なら
        {   //配列300回　マウスの座標取得
			float tmpTime = Time.time - timerF;
			if (tmpTime >= 0.4f) {//秒たったなら
				img.GetComponent<RectTransform>().sizeDelta = new Vector3(0,0);	//ゲージ0
				dragIs = false;
				attackNow = true;
				attackCheck ();
				changeRotationHowAt ();
			} else {
				img.GetComponent<RectTransform>().sizeDelta = new Vector3((1 - tmpTime/0.4f) * imageLong[0], imageLong[1]);	//ゲージ減少
				if (cnt < 300)
				{
					xy[0, cnt] = Input.mousePosition.x;
					xy[1, cnt] = Input.mousePosition.y;
					cnt++;

				}
			}

        }
		if (attackNow) {//攻撃中
			if (cnt > cnt2) {
				cnt2++;
			} else {
				attackNow = false;
				transform.eulerAngles =  new Vector3 (0f, 0f, 0f);
			}
		}


        /*
		if (Input.GetMouseButton (0)) {
			attackBt = true;
			float tmp;
			float toX;//中心からどれだけ
			float toY;
 
			mouseX = Input.mousePosition.x;
			mouseY = Input.mousePosition.y;

			//x軸 角度
			tmp = screenHarf[0] - mouseX;
			if (tmp == 0) {
				toX = 0f;
			}else if (tmp < 0) {//左側
				tmp *= -1;
				toX = screenHarf[0] - tmp;
			} else {
				toX = screenW - mouseX;
			}
			toX = 180f * toX / screenHarf [0];
			//y軸　縦

			tmp = screenHarf [1] - mouseY;

		} else {

		}
        */
	}
	/*
	void OnMouseDrag(){
		float tmp;
		float toX;//中心からどれだけ
		float toY;
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;

		tmp = screenHarf[0] - mouseX;
		if (tmp == 0) {
			toX = 0f;
		}else if (tmp < 0) {//左側
			tmp *= -1;
			toX = screenHarf[0] - tmp;
		} else {
			toX = screenW - mouseX;
		}
		Debug.Log ("" + toX);
		toX = 180f * toX / screenHarf [0];

		tmp = screenHarf [1] - mouseY;


	}*/
	void attackCheck(){//攻撃の向きを解析
		cnt2 = 0;//初期化
		float tmpX = xy[0,cnt] - xy[0,0];//+なら左から右
		tmpX = Mathf.Abs(tmpX);
		Debug.Log("x:"+xy[0,cnt] +"-"+ xy[0,0]);
		float tmpY = xy [1,cnt] - xy [1,0];//+なら下から上
		tmpY = Mathf.Abs(tmpY);
		Debug.Log("y:"+xy [1,cnt] +"-"+ xy [1,0]);
		if (screenH / 5 >= tmpY) {//ほぼ横に切ったら
			howAtNow = (int)howAt.LEFT_Right;
			return;
		} else if (screenW / 5 >= tmpX) {//ほぼ縦
			howAtNow = (int)howAt.UP_Down;
			return;
		} else {
			if (xy [0, 0] >= screenW / 2 && xy [1, 0] >= screenH / 2)
				howAtNow = (int)howAt.rUP_lDOWN;
			else
				howAtNow = (int)howAt.lUP_rDOWN;
		}
	}
	void changeRotationHowAt(){
		Debug.Log ("ch:" + howAtNow);
		switch (howAtNow) {
		case (int)howAt.LEFT_Right:
			transform.Rotate (new Vector3 (90f, 0f, 0f));
			Debug.Log ("左右");
			break;
		case (int)howAt.rUP_lDOWN:
			transform.Rotate (new Vector3 (0f, 153f, 0f));
			Debug.Log ("右上左下");
			break;
		case (int)howAt.lUP_rDOWN:
			transform.Rotate (new Vector3 (0f, -153f, 0f));
			Debug.Log ("左上右下");
			break;
		}
	}

	enum howAt{
		UP_Down, LEFT_Right, rUP_lDOWN, lUP_rDOWN
	}
}
