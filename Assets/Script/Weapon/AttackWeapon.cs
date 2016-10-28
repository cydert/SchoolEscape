using UnityEngine;
using System.Collections;

public class AttackWeapon : MonoBehaviour {
	private float mouseX;
	private float mouseY;
	private bool attackBt;

	private float screenW;
	private float screenH;
	private float[] screenHarf;
    private float[,] xy;
    private int cnt;
    public Canvas cvs;
    private bool dragIs;
    // Use this for initialization
    void Start () {
		screenW = Screen.width;
		screenH = Screen.height;

		screenHarf = new float[2];
		screenHarf [0] = screenW / 2;
		screenHarf [1] = screenH / 2;
        xy = new float[2,500];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            cnt = 0;
            dragIs = true;
            Debug.Log("hi");

        }

        if (Input.GetMouseButtonUp(0))
        {
            dragIs = false;
        }

        if (dragIs)
        {   //配列500回　マウスの座標取得
            if (cnt < 500)
            {
                xy[0, cnt] = Input.mousePosition.x;
                xy[1, cnt] = Input.mousePosition.y;
                cnt++;
                Debug.Log("cnt: " + cnt);
            }
            else
            {
                Debug.LogWarning("配列越え");
                //ドラッグ強制終了
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


	}
}
