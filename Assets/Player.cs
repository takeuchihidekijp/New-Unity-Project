using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private List<GameObject> fellows = new List<GameObject>();

	//Prefabを入れる
	public GameObject FellowPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var fellow in fellows) {
		//	fellow.transform.position = test; //←味方の位置を調整
		}
		
	}


	// 味方のオブジェクトを追加
	public void AddFellow(){
		var ins = Instantiate (FellowPrefab);

		fellows.Add (ins);
	}
}
