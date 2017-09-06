using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoroller : MonoBehaviour {

    public float speed = 6f;            // The speed that the player will move at.


    Vector3 movement;                   // The vector to store the direction of the Enemy's movement.
    Rigidbody enemyRigidbody;          // Reference to the enemy's rigidbody.

    UnityEngine.AI.NavMeshAgent nav;               // 試しに実装.

    //Playerのオブジェクト
    private GameObject Player;

    //Storeのオブジェクト
    private GameObject Store;

    // Use this for initialization
    void Start() {

        this.Player = GameObject.Find("Player");
        this.Store = GameObject.Find("Store");

        enemyRigidbody = GetComponent<Rigidbody>();

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 diff = Player.transform.position - this.transform.position;

        if(diff.magnitude > 100)
        {
            // プレイヤーからの直線距離が 20 以上のときPlayerに向かって移動
            nav.SetDestination(Player.transform.position);
        }
        else
        {
            // プレイヤーからの直線距離が 20 未満のときStoreに向かって移動(逃げるということ)
            nav.SetDestination(Store.transform.position);
        }

        // nav.SetDestination(Player.transform.position);

        //  Vector3 diff = Player.transform.position - this.transform.position;

        //    diff *= speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            // Playerクラスの参照を取得して味方の数を増やす
            Player player = this.Player.gameObject.GetComponent<Player>();
            player.AddFellow();

            Destroy(this.gameObject);

        }
    }

}
