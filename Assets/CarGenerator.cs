using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour {

    //carPrefabを入れる
    public GameObject carPrefab;

    float carCreateTime = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        carCreateTime -= Time.deltaTime;

        if (carCreateTime < 0.0f)
        {
            // 新しくクルマを作る
            GameObject car = Instantiate(carPrefab) as GameObject;

            // 座標
            car.transform.position = this.transform.position;

            // 回転
			car.transform.rotation = this.transform.rotation * Quaternion.Euler(0,180,0);

            //発生間隔をランダムにする(数値は仮)
            carCreateTime = 5.0f;
        }

    }
}
