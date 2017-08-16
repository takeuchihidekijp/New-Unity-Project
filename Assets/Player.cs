using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private List<GameObject> fellows = new List<GameObject>();

    // プレイヤーの座標ログを初期化
    private List<Vector3> PlayerPositionLog = new List<Vector3>();


    //Prefabを入れる
    public GameObject FellowPrefab;

	// Use this for initialization
	void Start () {

        PlayerPositionLog.Add(this.transform.position);

    }
	
	// Update is called once per frame
	void Update () {

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

            if (index >= 0)
            {
                fellow.transform.position = PlayerPositionLog[index];
            }



        }

    }


	// 味方のオブジェクトを追加
	public void AddFellow(){
		var ins = Instantiate (FellowPrefab);

		fellows.Add (ins);
	}
}
