using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    private int point = 0;
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    //ポイント表示テキスト
    private GameObject pointText;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    
	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //ポイント表示オブジェクトの取得
        this.pointText = GameObject.Find("PointText");
	}
	
	// Update is called once per frame
	void Update () {

        //ポイント表示
        this.pointText.GetComponent<Text>().text = "point:" + point;

        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;

        }
            

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SmallStarTag")
        {
            point += 50;
        }
        if (collision.gameObject.tag == "LargeStarTag")
        {
            point += 100;
        }
        if (collision.gameObject.tag == "SmallCloudTag")
        {
            point += 500;
        }
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            point += 5000;
            
        }

        this.pointText.GetComponent<Text>().text = "point:" + point;
    }
}
