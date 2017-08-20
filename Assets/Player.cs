﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private List<GameObject> fellows = new List<GameObject>();

    // プレイヤーの座標ログを初期化
    private List<Vector3> PlayerPositionLog = new List<Vector3>();


    //Prefabを入れる
    public GameObject FellowPrefab;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;
    //スコアを表示するテキスト（追加）
    private GameObject scoreText;

    //得点
    private int score = 0;

    //ゲーム終了の判定
    private bool isEnd = false;

    // Use this for initialization
    void Start () {

        PlayerPositionLog.Add(this.transform.position);

        // Playerの位置を最初に設定しておくことで最初や２番目に捕まえた敵の位置が固定で動かなくなる事象を回避
        for (int i = 1; i < 100; ++i)
        {
            Vector3 p = this.transform.position;
            p.z -= (float)i * 0.5f;
            PlayerPositionLog.Insert(0, p);

        }

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");



    }
	
	// Update is called once per frame
	void Update () {

        //ゲーム終了なら
        if (this.isEnd)
        {

        }

        // 最新の座標のインデックス
        int lastIndex = PlayerPositionLog.Count - 1;

        // 停止している場合は座標を追加しないようにするなら
        // 最新の座標から一定数値以上動かなければ追加しないようにする
        float dist = Vector3.Distance(PlayerPositionLog[lastIndex], this.transform.position);

        if(dist > 0.1f)
        {
            PlayerPositionLog.Add(this.transform.position);
        }



        for (int i = 0; i < fellows.Count; ++i)
        {
            var fellow = fellows[i]; // 配列をインデックスでアクセス

            int index = lastIndex - (i + 1) * 100;

            // インデックスが０未満の場合は捕まえた敵の位置をPlayerと合わせることはしない
            if (index >= 0)
            {
                fellow.transform.position = PlayerPositionLog[index];
            }



        }

        // ログの定期的な削除。１０００を超えたらその時点の０番目の値を削除する。あくまでその時点の０番目

        if (PlayerPositionLog.Count > 1000)
        {
            PlayerPositionLog.RemoveAt(0);
        }

    }


	// 味方のオブジェクトを追加とスコアも追加
	public void AddFellow(){
		var ins = Instantiate (FellowPrefab);

		fellows.Add (ins);

        // スコアを加算
        this.score += 10;

        //ScoreText獲得した点数を表示
        this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
    }

    // Playerが他のオブジェクトと接触した場合の処理
    private void OnCollisionEnter(Collision collision)
    {

        //障害物に衝突した場合(未実装　車などを想定)

        //ゴール地点に到達した場合
        if (collision.gameObject.tag == "Goal")
        {
            this.isEnd = true;
            //stateTextにGAME CLEARを表示（追加）
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }


    }
}
