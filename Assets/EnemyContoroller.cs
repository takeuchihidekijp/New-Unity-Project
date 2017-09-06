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

        diff *= speed;


        if (Mathf.Abs(diff.x) < Mathf.Abs(diff.z))
        {
            if (diff.z > 0)
            {
                // 下に逃げる
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(0, 0, -1));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));

            }
            else
            {
                // 上に逃げる
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(0, 0, 1));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));

                if (this.transform.position.z > 130)
                {
                    nav.SetDestination(Store.transform.position);
                }
            }
        }
        else
        {
            // X軸の距離がZ軸の距離より大きい
            if (diff.x > 0)
            {
                // 左に逃げる
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(-1, 0, 0));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));

            }
            else
            {
                // 右に逃げる
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(1, 0, 0));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));

            }
        }

        Vector3 diff_after = Player.transform.position - this.transform.position;

        if (diff_after.z > 20)
        {
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
