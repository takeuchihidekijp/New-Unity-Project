using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fellow : MonoBehaviour {

    //Prefabを入れる
    public GameObject FellowPrefab;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;
    //スコアを表示するテキスト（追加）
    private GameObject scoreText;

    //得点(cameraに使うためPublicに変更)
    public int score = 0;

    //ゲーム終了の判定
    private bool isEnd = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Playerが他のオブジェクトと接触した場合の処理
    private void OnCollisionEnter(Collision collision)
    {

        //障害物に衝突した場合(未実装　車などを想定)
        if (collision.gameObject.tag == "Car")
        {
            this.isEnd = true;
            //stateTextにGAME OVERを表示
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //ゴール地点に到達した場合
        if (collision.gameObject.tag == "Goal")
        {
            this.isEnd = true;
            //stateTextにGAME CLEARを表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }


    }
}
