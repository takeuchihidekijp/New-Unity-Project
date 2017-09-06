using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Prefabを入れる
    public GameObject EnemyPrefab;

    //Playerのオブジェクト
    private GameObject Player;

    float carCreateTime = 0.0f;

    //carPrefabを入れる
    public GameObject carPrefab;

    //アイテムを出すスタート地点(Z)
    private int startPosZ = -120;
    //アイテムを出すゴール地点(Z)
    private int goalPosZ = 80;

    //アイテムを出すスタート地点(X)
    private int startPosX = -50;
    //アイテムを出すゴール地点(X)
    private int goalPosX = 80;

    //アイテムを出すx方向の幅
    private float posRange = 10;

    // Use this for initialization
    void Start () {

        //一定の距離ごとにアイテムを生成
        for(int i = startPosZ; i < goalPosZ; i += 15)
        {
            int num = Random.Range(0, 10);

            if(num <= 1)
            {
                for(int j =startPosX; j < goalPosX; j += 30)
                {
                    GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
                    enemy.transform.position = new Vector3(j, enemy.transform.position.y, i);
                }

            }
        }

    }

    // Update is called once per frame
    void Update () {

        carCreateTime -= Time.deltaTime;

        if (carCreateTime < 0.0f)
        {
            // 新しくクルマを作る
            GameObject car = Instantiate(carPrefab) as GameObject;
            car.transform.position = new Vector3(-81, 3, 55);


            //発生間隔をランダムにする(数値は仮)
            carCreateTime = 2.0f;
        }

    }
}
