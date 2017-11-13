using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    //Prefabを入れる
    public GameObject EnemyPrefab;

    //Playerのオブジェクト
    private GameObject Player;

    float carCreateTime = 0.0f;

    //carPrefabを入れる
    public GameObject carPrefab;

    //お菓子を入れる
    public GameObject Cake;

    //アイテムを出すスタート地点(Z)
    private int startPosZ = -120;
    //アイテムを出すゴール地点(Z)
    private int goalPosZ = 80;

    //アイテムを出すスタート地点(X)
    private int startPosX = -50;
    //アイテムを出すゴール地点(X)
    private int goalPosX = 80;

    //アイテムを出すx方向の幅
    private float posRange = 10;

    //Raycast実装
    List<Vector3> spawnPositions = new List<Vector3>();



    // Use this for initialization
    void Start () {

        //敵の出現数をGameDataに合わせる
        //   for(int i = 0; i < GameData.NUMBER_OF_ENEMYS; i++)
        // {
        //
        // int num_x = Random.Range(startPosX, goalPosX);
        // int num_z = Random.Range(startPosZ, goalPosZ);
        //
        // GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
        //
        // enemy.transform.position = new Vector3(num_x, enemy.transform.position.y, num_z);
        //
        //試しにお菓子を実装
        //GameObject cake = Instantiate(Cake) as GameObject;
        //cake.transform.position = new Vector3(num_x, enemy.transform.position.y, num_z);
        // }

        InitSpawnPos();

        CreateEnemys();

        CreateItems();

    }

    // Update is called once per frame
    void Update () {

        //車の出現はここではなくGarGeneratorクラスで統一。
  //      carCreateTime -= Time.deltaTime;

    //    if (carCreateTime < 0.0f)
    //    {
            // 新しくクルマを作る
      //      GameObject car = Instantiate(carPrefab) as GameObject;
      //      car.transform.position = new Vector3(-81, 3, 55);


            //発生間隔をランダムにする(数値は仮)
    //        carCreateTime = 2.0f;
    //    }

    }

    // 生成するオブジェクトが重ならないように位置情報を設定
    void InitSpawnPos()
    {
        spawnPositions.Clear();

        //xとz の四角形を作る。Unityの位置情報なのでX軸とZ軸(仮で10．もっと大きくするもしくは位置を0からではなくすることも検討)
        for(int x = startPosX; x < goalPosX; x += 3)
        {
            for(int z = startPosZ; z < goalPosZ; z += 3)
            {
                //Positionsを埋めていくので*3は範囲を余裕を持たせている
                Vector3 Pos = new Vector3(x, 1.5f, z);
                Vector3 PosTop = Pos + new Vector3(0, 30, 0);

                RaycastHit hit;

                //四角形の範囲で上からRaycastを投げてFloor（何もない）だったところにPositionsを埋めていく。
                if (Physics.Raycast(PosTop, Vector3.down, out hit, 50f) == true)
                {
                //    if(hit.collider.name == "Floor")
                //マップをTerianにしたため以下の条件に変更
                    if (hit.collider.name == "Floor" || hit.collider.name == "Terrain")
                    {
                        spawnPositions.Add(Pos);
                    }
                }

            }
        }

    }

    Vector3 GetSpawnPos()
    {
        //spawnPositionsの数だけランダムに
        int r = Random.Range(0, spawnPositions.Count);
        Vector3 pos = spawnPositions[r];
        //取得したところから消していく。
        spawnPositions.RemoveAt(r);

        return pos;
    }

    void CreateEnemys()
    {
        //敵をループの数だけ出現させる。
        for(int i = 0; i < GameData.NUMBER_OF_ENEMYS; i++)
        {
            Vector3 pos = GetSpawnPos();

            GameObject enemy = Instantiate(EnemyPrefab, pos, Quaternion.identity);
        }
    }

    void CreateItems()
    {
        //アイテムをループの数だけ出現させる。
        for(int i =0; i < 10; i++)
        {
            Vector3 pos = GetSpawnPos();

            GameObject cake = Instantiate(Cake, pos, Quaternion.identity);
        }

    }

}
