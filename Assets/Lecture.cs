using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lecture : MonoBehaviour {

    public GameObject canvas;

    // Use this for initialization
    void Start()
    {

        Time.timeScale = 0.0f;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPressClose()
    {
        Time.timeScale = 1.0f;

        Debug.Log(this.gameObject.name);

        this.gameObject.SetActive(false);

    }

    void OnEnable()
    {
        Debug.Log("OnEnableだよ");
    }
}
