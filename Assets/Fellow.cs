using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //PlayerクラスにScenManaagementって。。後で検討

public class Fellow : MonoBehaviour {

    //Prefabを入れる
    public GameObject FellowPrefab;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;
    //スコアを表示するテキスト（追加）
    private GameObject scoreText;

    //Playerのオブジェクト
    private GameObject Player;

    //得点(cameraに使うためPublicに変更)
    public int score = 0;

    //ゲーム終了の判定
    private bool isEnd = false;

    // Use this for initialization
    void Start () {

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

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

        //    Debug.Log(this.Player);

            //車に当たったら残機を減らす。
            GameData.ILeft -= 1;

            //メッセージを設定
            GameData.MessageText = "車にあたっちゃった！";

            //stateTextメッセージを表示
            this.stateText.GetComponent<Text>().text = "車にあたっちゃった！";

            if (GameData.ILeft == 0)
            {

                //ロジック上、ローディングされないのでここに来ることはないはずだが、タイミングによって呼ばれる可能性があるのでここで設定
                GameData.MessageText = "車にあたっちゃって残念！GameOver！";

                //ゲームオーバなので初期値に戻す。
                GameData.ILeft = 3;

                this.isEnd = true;

                //stateTextにGAME OVERを表示
                this.stateText.GetComponent<Text>().text = "車にあたっちゃって残念！GameOver！";


                //仮実装。車と衝突したときにゲームオーバ画面へ遷移させる。
                SceneManager.LoadScene("GameOver");

            }
            else
            {
                // ローディング中のフラグを立てる
                GameData.IsLoading = true;

                SceneManager.LoadScene("Loading");

            }
        }


    }
}
