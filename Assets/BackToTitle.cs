using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //title画面へ遷移
        SceneManager.LoadScene("title");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
