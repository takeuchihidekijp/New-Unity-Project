using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour {

    //Playerのオブジェクト
    private GameObject Player;

    // Use this for initialization
    void Start () {

        this.Player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //お菓子と接触したらリミット時間を増やす
        if (collision.gameObject.tag == "Player")
        {
            //Timer を増やす。時間は仮
            GameData.TotalTime += 5;

            Destroy(this.gameObject);

        }
    }
}
