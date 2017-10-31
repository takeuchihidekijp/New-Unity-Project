using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    //carPrefabを入れる
    public GameObject carPrefab;

    //Carを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //Carを前進するための力
    private float forwardForce = 50.0f;

    // Use this for initialization
    void Start () {
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        //carに前方向の力を加える（追加）
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //障害物を検知したら止まる
        RaycastHit hit;

        if(Physics.Raycast(this.transform.position,Vector3.forward, out hit, 5f) == true)
        {
            if(hit.collider.name == "Enemy")
            {
                this.myRigidbody.velocity = Vector3.zero;
            }
        }


        if(this.transform.position.z < -140)
        {
            Destroy(this.gameObject);
        }

    }
}
