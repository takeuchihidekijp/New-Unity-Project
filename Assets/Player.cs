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
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < fellows.Count; ++i)
        {
            var fellow = fellows[i]; // 配列をインデックスでアクセス

            fellow.transform.position = PlayerPositionLog[i]; 
        }

    }


	// 味方のオブジェクトを追加
	public void AddFellow(){
		var ins = Instantiate (FellowPrefab);

		fellows.Add (ins);
	}
}
