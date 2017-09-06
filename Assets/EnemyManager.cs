using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    //Prefabを入れる
    public GameObject EnemyPrefab;

    //Playerのオブジェクト
    private GameObject Player;

    private int oldPosZ = -10;

    //Enemyを出すx方向の範囲
    private float posRange = 3.4f;

    private int enemysNumber = 0;

    // Use this for initialization
    void Start () {
        this.Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {



    }
}
