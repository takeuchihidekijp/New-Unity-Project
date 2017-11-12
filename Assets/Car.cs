using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    //carPrefabを入れる
    public GameObject carPrefab;

    //Carを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //Carを前進するための力
    private float forwardForce = 30.0f;

    float carCreateTime = 0.0f;


    // Use this for initialization
    void Start () {
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();

         carCreateTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        //carに前方向の力を加える（追加）
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //障害物を検知したら止まる
        RaycastHit hit;

        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 50, Color.red);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 50f) == true)
        {
            if(hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag == "Car")
            {
                this.myRigidbody.velocity = Vector3.zero;
            }
        }

        carCreateTime += Time.deltaTime;

        if (this.carCreateTime > 30)
        {
            Destroy(this.gameObject);
        }

    }
}
