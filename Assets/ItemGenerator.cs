using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    float carCreateTime = 0.0f;

    //carPrefabを入れる
    public GameObject carPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        carCreateTime -= Time.deltaTime;

        if(carCreateTime < 0.0f)
        {
            // 新しくクルマを作る
            GameObject car = Instantiate(carPrefab) as GameObject;
            car.transform.position = new Vector3(-81,3,55);


            //発生間隔をランダムにする(数値は仮)
            carCreateTime = 2.0f;
        }


    }
}
