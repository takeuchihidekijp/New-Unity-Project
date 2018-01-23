using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureMsg : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPressClose()
    {
        Time.timeScale = 1.0f;
        Destroy(this.gameObject);

    }
}
