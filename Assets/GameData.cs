using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviourはClassの特性上、取る
public class GameData {

    //ステージ数。いったん5(ステージの数が５の場合、一つ足して６)
    public static int NUMBER_OF_LEVELS = 5;

    //現在のステージ。クリアしたら＋１
    public static int NUMBER_OF_STAGES = 1;

    //ローディング中のフラグ（）
    public static bool IsLoading = false;

    // start updateも取る。MonoBehaviourの機能なので

    //敵の数の上限
    public static int NUMBER_OF_ENEMYS = 15;

}
