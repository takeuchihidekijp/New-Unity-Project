using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    //スコアを表示するテキスト
    private GameObject scoreText;

    // Use this for initialization
    void Start () {

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("Score");

        float bestScore = PlayerPrefs.GetFloat(GameData.SCORE_KEY, GameData.TotalScoreTime);

        //ScoreText獲得した点数を表示
        this.scoreText.GetComponent<Text>().text = "BestTimeは " + bestScore + " s。頑張って";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
