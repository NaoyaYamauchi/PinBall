using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //座標取得
    private Vector2 position;

    //画面の大きさ取得
    int width =0;
    int height =0;
    //x軸中央
    int center = 0;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        //画面の大きさ取得
        width = Screen.width;
        height = Screen.height;
        center = width / 2;
        print(width+":"+height+":"+center);
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
        //左矢印キーを押した時左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow)&&tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.RightArrow)&& tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //矢印キー離された時フリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow)&& tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)&& tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);

        }

        //ここからタッチ操作の内容
        position = Input.mousePosition;
        print(position.x+":" + Input.touchCount);
        
            //画面左半分をタップしたときに左フリッパーが動く
            if (position.x<= 300&& tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //画面右半分をタップしたときに右フリッパーが動く
            if (position.x >= 300  && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //念のため
            if (Input.touchCount == 2 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            if (Input.touchCount == 2 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //指が離れたらフリッパーがもどる
            if (Input.touchCount == 0 && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.touchCount == 1 && position.x >= 300 && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.touchCount == 0 && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.touchCount == 1 && position.x <= 300 && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
    }
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
