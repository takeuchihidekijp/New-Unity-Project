﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class 名をCameraControllerからGameCameraControllerに変更。アセットにCameraControllerクラスが含まれていたためこっちを変更。
public class GameCameraController : MonoBehaviour {

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

        //クラス名を「CameraController」から「」に変更したことにより影響範囲について確認するためログ出力
        Debug.Log(this.gameObject.name);

        //バウンディングボックスからデータを取得
        Player playerClass = this.Player.GetComponent<Player>();
        Vector3 cameraPos = playerClass.GetCameraPos();

        float dist = playerClass.score * 0.4f;

        //バウンディングボックスの位置に合わせてカメラの位置を移動(cameraPos.y + playerClass.scoreとすることで敵を捕まえたらカメラの位置を上に移動)
        //Lerpの値は調整中(Zだけ「dist * 2」をしているが下に移動する際にカメラが外れるため。まだ調整中。
        Vector3 target = new Vector3(cameraPos.x - difference_x, cameraPos.y + dist - difference_y, cameraPos.z - dist * 2 - difference_z);
        this.transform.position = Vector3.Lerp(this.transform.position, target, 1.5f * Time.deltaTime);
    }
}