using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //PlayerクラスにScenManaagementって。。後で検討

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

    //得点(cameraに使うためPublicに変更)
    public int score = 0;

    //ゲーム終了の判定
    private bool isEnd = false;

    //バウンディングボックス設定用
    private Vector3 cameraFocusPoint;

    //死んだ際のプレイヤーの戻り位置
    private Vector3 startPosition;

    // Use this for initialization
    void Start () {
        //FrameRateがandroidとiPhoneで異なることがあるのでここで合わせておく
        //FrameRateがandroid 60のことが多い。端末の問題。iPhoneは３０のことが多い。60 はオーバースペック
        Application.targetFrameRate = 30;

        //最初に死んだ際の位置を取得しておく。
        startPosition = this.transform.position;

        //Playerの位置の座標を設定
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
            //100は、仮。過去の履歴の１００番目ということになる。なので10にしておく。10にするとスネークゲームっぽくなる。
            int index = lastIndex - (i + 1) * 10;

            // インデックスが０未満の場合は捕まえた敵の位置をPlayerと合わせることはしない
            if (index >= 0)
            {
                fellow.transform.position = PlayerPositionLog[index];
            }





        }

        // 味方のバウンディングボックスからカメラの注視点を求める
        Vector3 min = this.transform.position;
        Vector3 max = this.transform.position;

        for (int i = 0; i < fellows.Count; ++i)
        {

            var fellow = fellows[i];

            if (min.x > fellow.transform.position.x)
            {
                min.x = fellow.transform.position.x;
            }
            if (min.z > fellow.transform.position.z)
            {
                min.z = fellow.transform.position.z;
            }
            if (max.x < fellow.transform.position.x)
            {
                max.x = fellow.transform.position.x;
            }
            if (max.z < fellow.transform.position.z)
            {
                max.z = fellow.transform.position.z;
            }
        }

        cameraFocusPoint = (min + max) / 2;

        // 注視点とプレイヤーの間を取る
        cameraFocusPoint = (cameraFocusPoint + this.transform.position) / 2;

        // ログの定期的な削除。１０００を超えたらその時点の０番目の値を削除する。あくまでその時点の０番目

        if (PlayerPositionLog.Count > 1000)
        {
            PlayerPositionLog.RemoveAt(0);
        }

    }

    public Vector3 GetCameraPos()
    {
        return cameraFocusPoint;
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

    //Playerが死んだときの位置を定める
    private void ReturnPoint()
    {
      //  this.transform.localPosition = startPosition;
        this.transform.position = startPosition;

    }

    // Playerが他のオブジェクトと接触した場合の処理
    private void OnCollisionEnter(Collision collision)
    {

        //障害物に衝突した場合(未実装　車などを想定)
        if (collision.gameObject.tag == "Car")
        {

            //車に当たったら残機を減らす。
            GameData.ILeft -= 1;

            if(GameData.ILeft == 0)
            {
                //ゲームオーバなので初期値に戻す。
                GameData.ILeft = 3;

                this.isEnd = true;
                //stateTextにGAME OVERを表示
                this.stateText.GetComponent<Text>().text = "GAME OVER";

                //仮実装。車と衝突したときにゲームオーバ画面へ遷移させる。
                SceneManager.LoadScene("GameOver");

            }
            else
            {
                this.ReturnPoint();
            }

        }

        //ゴール地点に到達した場合
        if (collision.gameObject.tag == "Goal" && GameData.IsLoading == false)
        {
            this.isEnd = true;
            //stateTextにGAME CLEARを表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";

            //GameData.NUMBER_OF_STAGESの数が一定しないバグ
            GameData.NUMBER_OF_STAGES += 1;

            // ローディング中のフラグを立てる
            GameData.IsLoading = true;

            Debug.Log(GameData.NUMBER_OF_STAGES);

            if (GameData.NUMBER_OF_STAGES > GameData.NUMBER_OF_LEVELS)
            {
                //クリアしたらステージを初期化
                GameData.NUMBER_OF_STAGES = 1;
                GameData.IsLoading = false;

                Debug.Log(GameData.NUMBER_OF_STAGES);

                SceneManager.LoadScene("GameClear");
            }
            else
            {
                SceneManager.LoadScene("Loading");
            }

            
        }


    }
}
