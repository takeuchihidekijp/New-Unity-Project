using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoroller : MonoBehaviour {


    Vector3 movement;                   // The vector to store the direction of the Enemy's movement.
    Rigidbody enemyRigidbody;          // Reference to the enemy's rigidbody.

    UnityEngine.AI.NavMeshAgent nav;               // 試しに実装.

    //Playerのオブジェクト
    private GameObject Player;

    //Storeのオブジェクト用List(敵の移動ポイントをStoreとする)
    private int StoreCount = 10;
    private List<GameObject> storeList = new List<GameObject>();

    //ランダムで選択目的地へ数秒間移動し続けるタイマー
    float enemyMoveTime = 0.0f;

    private bool isDead = false; // 死亡判定フラグ(Destoyしても敵がタイミングによって生きていてFellowに追加されるバグ対応)

    // Use this for initialization
    void Start() {

        this.Player = GameObject.Find("Player");

     //   Debug.Log(this.Player);

        for (int i= 1; i <= StoreCount; ++i)
        {
            GameObject store = GameObject.Find("Store" + i.ToString());

            if(store != null)
            {
                storeList.Add(store);
            }
        }

        enemyRigidbody = GetComponent<Rigidbody>();

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        //プレイヤーからの直線距離
        Vector3 diff = Player.transform.position - this.transform.position;

        if (diff.magnitude > 300)
        {
            // プレイヤーからの直線距離が 300 以上のときPlayerに向かって移動
            nav.SetDestination(Player.transform.position);
        }
        else
        {
            //敵の移動方向（どのストアに向かうかということ）を制御するカウンタ
            enemyMoveTime -= Time.deltaTime;
            
            if (enemyMoveTime < 0.0f)
            {
               EnemyMoveMent();

               enemyMoveTime = 20.0f;
            }


        }

        // nav.SetDestination(Player.transform.position);

        //  Vector3 diff = Player.transform.position - this.transform.position;

        //    diff *= speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //isDeadはDestory()してもタイミングによって敵が残って居てFellowに追加されるバグ対応
        if (this.Player != null && collision.gameObject.tag == "Player"  && this.isDead == false)
        {

            // Playerクラスの参照を取得して味方の数を増やす

            //Player player = this.Player.gameObject.GetComponent<Player>(); がステージ切り替え後に不具合があり、一時的に変更
            //Player player = collision.gameObject.GetComponent<Player>(); これだと捕まえた敵が敵を捕まえられないので再度変更

            //      Player player = this.Player.GetComponent<Player>();
            //      player.AddFellow();

            //  Destroy(this.gameObject);
            //ここでフラグをオンにすることで条件分岐が正しく動くようにする。
            //  this.isDead = true;

        }
    }

    public void OnEnterShadow()
    {
        if(this.Player != null && this.isDead == false)
        {
        Debug.Log("OnEnterShadow");

        Player player = this.Player.GetComponent<Player>();
        player.AddFellow();

        Destroy(this.gameObject);
        //ここでフラグをオンにすることで条件分岐が正しく動くようにする。
        this.isDead = true;
        }
    }

    private void EnemyMoveMent()
    {

        int r = Random.Range(0, storeList.Count);

        nav.SetDestination(storeList[r].transform.position);


        //    int num = Random.Range(0, 10);

        //    if (num <= 5)
        //    {
        // Storeに向かって移動(逃げるということ)
        //    nav.SetDestination(Store.transform.position);
        //  }
        //   else
        //   {
        //   nav.SetDestination(Store3.transform.position);
        //  }


    }

}
