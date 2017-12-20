using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour {

    //スコアを表示するテキスト
    private GameObject scoreText;

    private GameObject bestScoreText;

    // Use this for initialization
    void Start () {

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("Score");

        this.bestScoreText = GameObject.Find("BestScore");

        //Debug 
        Debug.Log("GameClear" + GameData.TotalScoreTime);

        //ScoreText獲得した点数を表示
        this.scoreText.GetComponent<Text>().text = "Timeは " + GameData.TotalScoreTime + " s。";

        float bestScore = PlayerPrefs.GetFloat(GameData.SCORE_KEY, GameData.TotalScoreTime);

        if (bestScore > GameData.TotalScoreTime)
        {
            //スコア保存
            PlayerPrefs.SetFloat(GameData.SCORE_KEY, GameData.TotalScoreTime);
            PlayerPrefs.Save();

            bestScore = GameData.TotalScoreTime;
        }

        //ScoreText獲得した点数を表示
        this.bestScoreText.GetComponent<Text>().text = "BestTimeは " + bestScore + " s。頑張って";

        //GameClearクラスで初期化処理実行
        //2回？呼ばれる可能性があるのでTitleクラスで初期化するように変更
        //GameData.NUMBER_OF_STAGES = 1;
        //GameData.IsLoading = false;

        //GameData.ILeft = 3;

        //   GameData.TotalScoreTime = 0.0f;
        //GameData.TotalTime = 2 * 60;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
