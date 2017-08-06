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

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update() {

        nav.SetDestination(Player.transform.position);

      //  Vector3 diff = Player.transform.position - this.transform.position;

        //    diff *= speed;





    }

}
