﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Titleクラスで初期化処理実行
        GameData.NUMBER_OF_STAGES = 1;
        GameData.IsLoading = false;

        GameData.ILeft = 3;

        GameData.TotalScoreTime = 0.0f;
        GameData.TotalTime = 2 * 60;

        GameData.BestTime = PlayerPrefs.GetFloat(GameData.SCORE_KEY, GameData.TotalScoreTime);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}