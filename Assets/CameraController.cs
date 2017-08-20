using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Playerのオブジェクト
    private GameObject Player;

    //Playerとカメラの距離(X軸)
    private float difference_x;

    //Playerとカメラの距離(Y軸)
    private float difference_y;

    //Playerとカメラの距離(Z軸)
    private float difference_z;

    // Use this for initialization
    void Start () {

        this.Player = GameObject.Find("Player");

        this.difference_x = Player.transform.position.x - this.transform.position.x;

        this.difference_y = Player.transform.position.y - this.transform.position.y;

        this.difference_z = Player.transform.position.z - this.transform.position.z;

    }
	
	// Update is called once per frame
	void LateUpdate() {

        //Playerの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.Player.transform.position.x - difference_x, this.Player.transform.position.y - difference_y, this.Player.transform.position.z - difference_z);

    }
}
