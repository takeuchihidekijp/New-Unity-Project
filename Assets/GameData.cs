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

    //タイムリミット(TotalTimeから減らしていく)
    //deltaTimeはUpdate内での実装が必要なため取る。（今までは動作していたのだが。。）
    //  public static float TimeLimit = Time.deltaTime;

}
