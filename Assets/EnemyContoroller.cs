using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoroller : MonoBehaviour {

    //Playerのオブジェクト
    private GameObject Player;


    // Use this for initialization
    void Start () {

        this.Player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 diff = Player.transform.position - this.transform.position;

    }
}
