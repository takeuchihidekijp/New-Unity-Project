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

        //GameOverクラスで初期化を実装するように変更
        //ゲーム時間を戻す
        GameData.TotalTime = 2 * 60;

        //ステージを初期化
        GameData.NUMBER_OF_STAGES = 1;
        GameData.IsLoading = false;

        GameData.ILeft = 3;

        //時間の初期化（要確認）
        GameData.TotalScoreTime = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
