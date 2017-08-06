using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;            // The speed that the player will move at.


    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.


    // ゴール
    [SerializeField] Transform target;

    // カーソル
    [SerializeField] Transform cursor;




    // Use this for initialization
    void Start () {

        playerRigidbody = GetComponent<Rigidbody>();

    }

	Vector3 beginPos;

    // Update is called once per frame
    void Update () {

		if( Input.GetMouseButtonDown(0) ) {
			beginPos = Input.mousePosition;
		}
		else if ( Input.GetMouseButton(0) ) {

			Vector3 diff = Input.mousePosition - beginPos;

			diff *= speed;

			Move( diff.x, diff.y );

			Vector3 dir = diff.normalized;

			float rag = Mathf.Atan2( dir.x, dir.y );
			float deg = rag * Mathf.Rad2Deg;

			playerRigidbody.MoveRotation(Quaternion.Euler(0,deg,0));
		}

        cursor.LookAt(target);



    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

}