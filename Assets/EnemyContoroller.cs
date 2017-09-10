using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoroller : MonoBehaviour {


    Vector3 movement;                   // The vector to store the direction of the Enemy's movement.
    Rigidbody enemyRigidbody;          // Reference to the enemy's rigidbody.

    UnityEngine.AI.NavMeshAgent nav;               // 試しに実装.

    //Playerのオブジェクト
    private GameObject Player;

    //Storeのオブジェクト(敵の移動ポイントをStoreとする)
    private GameObject Store;

    private GameObject Store2;

    private GameObject Store3;

    //ランダムで選択目的地へ数秒間移動し続けるタイマー
    float enemyMoveTime = 0.0f;

    //直前まで敵が向かっていた移動ポイント
    int enemyDestination_Store = 1;
    int enemyDestination_Store2 = 2;
    int enemyDestination_Store3 = 3;

    // Use this for initialization
    void Start() {

        this.Player = GameObject.Find("Player");

        this.Store = GameObject.Find("Store");
        this.Store2 = GameObject.Find("Store2");
        this.Store3 = GameObject.Find("Store3");


        enemyRigidbody = GetComponent<Rigidbody>();

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        //プレイヤーからの直線距離
        Vector3 diff = Player.transform.position - this.transform.position;

        if (diff.magnitude > 100)
        {
            // プレイヤーからの直線距離が 100 以上のときPlayerに向かって移動
            nav.SetDestination(Player.transform.position);
        }
        else
        {

            enemyMoveTime -= Time.deltaTime;

            if (enemyMoveTime < 0.0f)
            {
                EnemyMoveMent();

                enemyMoveTime = 1.0f;
            }


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

    private void EnemyMoveMent()
    {
        //Storeとの直線距離
        Vector3 diff_Store = Store.transform.position - this.transform.position;
        //Store2との直線距離
        Vector3 diff_Store2 = Store2.transform.position - this.transform.position;
        //Store3との直線距離
        Vector3 diff_Store3 = Store3.transform.position - this.transform.position;

        Mathf.Max(diff_Store.magnitude, diff_Store2.magnitude, diff_Store3.magnitude);

        int num = Random.Range(0, 10);

        if(num <= 5)
        {
            // Storeに向かって移動(逃げるということ)
            nav.SetDestination(Store.transform.position);
        }
        else
        {
            nav.SetDestination(Store3.transform.position);
        }


    }

}
