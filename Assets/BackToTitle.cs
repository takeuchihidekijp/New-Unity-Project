using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonClick()
    {
        switch (transform.name)
        {
            case "BackToTitle":

            //title画面へ遷移
            SceneManager.LoadScene("title");
            break;

            case "Continue":

            SceneManager.LoadScene(GameData.NUMBER_OF_STAGES); ;
            break;

        }

    }
}
