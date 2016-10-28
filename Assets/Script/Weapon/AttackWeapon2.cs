using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttackWeapon2 : MonoBehaviour {
	private float mouseX;
	private float mouseY;
	private bool attackBt;
	public GameObject forwardSord;
	public GameObject RtoL;
	private float howRotation,nowRotation;

	private float screenW;
	private float screenH;
	private float[] screenHarf;
    private float[,] xy;//攻撃したい箇所
    private int cnt,cnt2;
	private float timerF;//ドラッグ可能時間
	private float finalTime;
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
			if(dragIs){
	            dragIs = false;
				attackNow = true;
				attackCheck ();//どんな攻撃か
				changeRotationHowAt ();//オブジェクト回転
			}
        }

        if (dragIs)	//ドラッグ中なら
        {   //配列300回　マウスの座標取得
			finalTime = Time.time - timerF;
			if (finalTime >= 0.3f) {//秒たったなら
				img.GetComponent<RectTransform>().sizeDelta = new Vector3(0,0);	//ゲージ0
				dragIs = false;
				attackNow = true;
				attackCheck ();
				changeRotationHowAt ();
			} else {
				img.GetComponent<RectTransform>().sizeDelta = new Vector3((1 - finalTime/0.3f) * imageLong[0], imageLong[1]);	//ゲージ減少
				if (cnt < 300)
				{
					xy[0, cnt] = Input.mousePosition.x;
					xy[1, cnt] = Input.mousePosition.y;
					cnt++;

				}
			}

        }
		if (attackNow) {//攻撃中
			if (howRotation >= nowRotation) {

				if (howAtNow == (int)howAt.LEFT_Right) {//左右
					float speed = 300f;
					nowRotation += speed * Time.deltaTime;
					transform.Rotate (new Vector3 (0f, 0, speed * Time.deltaTime));//速度
				} else if (howAtNow == (int)howAt.UP_Down) {
					float speed = 200f;
					nowRotation += speed * Time.deltaTime;
					transform.Rotate (new Vector3 (0f, 0, speed * Time.deltaTime));//速度
				}
			} else {
				attackNow = false;
				transform.LookAt (forwardSord.transform);
				//transform.eulerAngles =  new Vector3 (0f, 90f, 0f);
			}
		}
	}

	void attackCheck(){//攻撃の向きを解析
		cnt2 = 0;//初期化
		float tmpX = xy[0,cnt-1] - xy[0,0];//+なら左から右
		float tmpY = xy [1,cnt-1] - xy [1,0];//+なら下から上
		tmpX = Mathf.Abs(tmpX);
		tmpY = Mathf.Abs (tmpY);

		if (tmpX > tmpY && screenH / 4 > tmpY) {//横切り
			howAtNow = (int)howAt.LEFT_Right;
		} else if (tmpY > tmpX && screenW / 4 > tmpX) {//縦
			howAtNow = (int)howAt.UP_Down;
		}//以降一時対策
		else if (tmpX > tmpY) {
			howAtNow = (int)howAt.LEFT_Right;
		} else {
			howAtNow = (int)howAt.UP_Down;
		}


	}
	void changeRotationHowAt(){
		nowRotation = 0f;
		Debug.Log ("ch:" + howAtNow);
		if ((int)howAt.UP_Down == howAtNow) {//縦なら
			howRotation = finalTime/0.3f * 57f;

		}
		if ((int)howAt.LEFT_Right == howAtNow) {//横なら
			//transform.LookAt(RtoL.transform);
			transform.eulerAngles +=  new Vector3 (90f, 0f, -40f);
			howRotation = finalTime/0.3f * 140f;
			//どれくらいまわえうか、残り時間がすくないほうが多く回る
		}
	}

	enum howAt{
		UP_Down, LEFT_Right, rUP_lDOWN, lUP_rDOWN
	}
}
