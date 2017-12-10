using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviourはClassの特性上、取る
public class GameData {

    //ステージ数。いったん5
    public static int NUMBER_OF_LEVELS = 5;

    //現在のステージ。クリアしたら＋１
    public static int NUMBER_OF_STAGES = 1;

    //ローディング中のフラグ
    public static bool IsLoading = false;

    //現在の残機。マイナスになるとゲームオーバー。
    public static int ILeft = 3;

    // start updateも取る。MonoBehaviourの機能なので

    //敵の数の上限
    public static int NUMBER_OF_ENEMYS = 15;

    //タイムリミット
    public static float TotalTime = 2 * 60;

    //ステージのタイム合計
    public static float TotalScoreTime = 0.0f;

    //スコア保存用
    public static string SCORE_KEY = "Score";

    //ベストスコア保存用
    public static string HIGH_SCORE_KEY_BEST = "highScore";

    //車に当たった際のメッセージ
    public static string Message_Of_CarClash = "車にあたっちゃった！";

    //車に当たった際のメッセージでゲームオーバの場合
    public static string Message_Of_CarClash_End = "車にあたっちゃって残念！GameOver！";

    //全員捕まえてない状態でゴールに行った際のメッセージ
    public static string Message_Of_Goal_Not_Clear = "全員捕まえてないよ！";

    //全員捕まえてゴールに行った際のメッセージ
    public static string Message_Of_Goal_Clear = "学校についた!!";


    //タイムリミット(TotalTimeから減らしていく)
    //deltaTimeはUpdate内での実装が必要なため取る。（今までは動作していたのだが。。）
    //  public static float TimeLimit = Time.deltaTime;

}
