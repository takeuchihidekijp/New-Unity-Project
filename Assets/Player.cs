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

    //残基数を表示するテキスト
    private GameObject lifeText;

    //得点(cameraに使うためPublicに変更)
    public int score = 0;


    //タイマーを表示するテキスト（追加）
    private GameObject timerText;

    //タイマー
    public float timer = 0.0f;

    //ゲームオーバーの判定（ゲームクリアとは別）
    private bool isEnd = false;

    //バウンディングボックス設定用
    private Vector3 cameraFocusPoint;

    //死んだ際のプレイヤーの戻り位置
    private Vector3 startPosition;

    //ベストスコア保存用
    const string HIGH_SCORE_KEY_BEST = "highScore";

    //スコア保存用
    const string SCORE_KEY = "Score";

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

        //シーン中のtimerTextオブジェクトを取得
        this.timerText = GameObject.Find("TimerText");

        //シーン中のLifeTextオブジェクトを取得
        this.lifeText = GameObject.Find("LifeText");
        
        //LifeText初期表示
        this.lifeText.GetComponent<Text>().text = "残り" + GameData.ILeft + " / 3";
    }

    // Update is called once per frame
    void Update () {

        //Timer を減らす。
        //GameData.TotalTime -= GameData.TimeLimit;
        GameData.TotalTime -= Time.deltaTime;

        //ScoreText獲得した点数を表示
        this.timerText.GetComponent<Text>().text = "Time " + GameData.TotalTime + " s";

        //LifeTextの表示
        this.lifeText.GetComponent<Text>().text = "残り" + GameData.ILeft + " / 3";

        if (GameData.TotalTime < 0.0f)
        {
            //制限時間超えたらゲームオーバ―
            this.isEnd = true;

            //stateTextにGAME OVERを表示
            this.stateText.GetComponent<Text>().text = "時間切れ！";
        }


        //ゲームオーバーなら
        if (this.isEnd)
        {
            //GameOverクラスで初期化を実装するように変更

            //ゲーム時間を戻す
            //  GameData.TotalTime = 2 * 60;

            //ステージを初期化
            //  GameData.NUMBER_OF_STAGES = 1;
            // GameData.IsLoading = false;

            //  GameData.ILeft = 3;

            //時間の初期化（要確認）
            // GameData.TotalScoreTime = 0.0f;

            //仮実装。ゲームオーバ画面へ遷移させる。
            //TODO ゲームオーバ時にfellow.conutをクリアしなくてよいか確認

            //GameOverクラスで初期化を実装するように変更


            SceneManager.LoadScene("GameOver");
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
            //数値は、仮。過去の履歴の何番目ということになる。なので数を減らすほどキャラの感覚が小さくなる。2にするとスネークゲームっぽくなる。
            int index = lastIndex - (i + 1) * 2;

            // インデックスが０未満の場合は捕まえた敵の位置をPlayerと合わせることはしない
            if (index >= 0)
            {
                fellow.transform.position = PlayerPositionLog[index];
                //追加
                fellow.transform.LookAt(PlayerPositionLog[index + 1]);  // 追加
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
        //+10から1に変更。捕まえた人がわかるような表示とする。
        //this.score += 10;
        this.score += 1;

        //ScoreText獲得した点数を表示
        //捕まえた人がわかるような表示とする。
        //this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
        this.scoreText.GetComponent<Text>().text = "あと " + this.score + "/ 15 人";
    }

    //Playerが死んだときの位置を定める
    public void ReturnPoint()
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

            //メッセージを設定
            GameData.MessageText = "車にあたっちゃった！";

            //stateTextメッセージを表示
            this.stateText.GetComponent<Text>().text = "車にあたっちゃった！";

            if (GameData.ILeft == 0)
            {

                this.isEnd = true;
                //stateTextにGAME OVERを表示
                this.stateText.GetComponent<Text>().text = "車にあたっちゃって残念！GameOver！";

            }
            else
            {
                // ローディング中のフラグを立てる
                GameData.IsLoading = true;

                SceneManager.LoadScene("Loading");
            }

        }

        //ゴール地点に到達した場合
        if (collision.gameObject.tag == "Goal" && GameData.IsLoading == false)
        {
            Debug.Log(fellows.Count);

            //ゴールした時にすべての敵を捕まえてない、かつ、残機ゼロだとゲームオーバ
            if (GameData.NUMBER_OF_ENEMYS > fellows.Count)
            {
                //残機を減らす。
                GameData.ILeft -= 1;

                //メッセージを設定
                GameData.MessageText = "全員捕まえてないよ！";

                //stateTextメッセージを表示
                this.stateText.GetComponent<Text>().text = "全員捕まえてないよ！";

                if (GameData.ILeft == 0)
                {

                    this.isEnd = true;
                }

                // ローディング中のフラグを立てる
                GameData.IsLoading = true;

                SceneManager.LoadScene("Loading");
            }
            else
            {
                //ゴールした時にすべての敵を捕まえている場合はクリア

                //メッセージを設定
                GameData.MessageText = "学校についた!!";

                //stateTextにGAME CLEARを表示
                this.stateText.GetComponent<Text>().text = "学校についた!!";

                //総合時間にクリア時間を加える
                GameData.TotalScoreTime += GameData.TotalTime;


                //GameData.NUMBER_OF_STAGESの数を加算する
                GameData.NUMBER_OF_STAGES += 1;

                // ローディング中のフラグを立てる
                GameData.IsLoading = true;

                Debug.Log(GameData.NUMBER_OF_STAGES);

                if (GameData.NUMBER_OF_STAGES > GameData.NUMBER_OF_LEVELS)
                {
                    //スコア保存
                    PlayerPrefs.SetFloat(GameData.SCORE_KEY, GameData.TotalScoreTime);
                    PlayerPrefs.Save();

                    //GameClearクラスで初期化処理実行
                    //クリアしたらステージを初期化
                //    GameData.NUMBER_OF_STAGES = 1;
                //    GameData.IsLoading = false;

                //    GameData.ILeft = 3;

                    //時間の初期化（要確認）
                    //ここで初期化するとゲームクリア時に０になる。。
                 //   GameData.TotalScoreTime = 0.0f;
                //    GameData.TotalTime = 2 * 60;


                    Debug.Log(GameData.NUMBER_OF_STAGES);


                    SceneManager.LoadScene("GameClear");
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
}
