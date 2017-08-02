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


    // Use this for initialization
    void Start() {

        this.Player = GameObject.Find("Player");
        enemyRigidbody = GetComponent<Rigidbody>();

     //   nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update() {

     //   nav.SetDestination(Player.transform.position);

        Vector3 diff = Player.transform.position - this.transform.position;

        //    diff *= speed;

        if (Mathf.Abs(diff.x) < Mathf.Abs(diff.z))
        {
            if (diff.z > 0)
            {
                //下方向
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(0, 0, -1));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));
            }
            else
            {
                // 上方向
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(0, 0, 1));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));
            }


        }
        else
        {
            // X軸の距離がZ軸の距離より大きい
            if (diff.x > 0)
            {
                //右方向
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(1, 0, 0));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));

            }
            else
            {
                //左方向
                enemyRigidbody.MovePosition(this.transform.position + new Vector3(-1, 0, 0));
                enemyRigidbody.MoveRotation(Quaternion.Euler(0, 0, 0));

            }
        }



    }

}
