using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour {

	public GameObject colliderN; //北
	public GameObject colliderS; //南
	public GameObject colliderE; //東
	public GameObject colliderW; //西

	// Use this for initialization
	void Start () {

		//縦の進行を青に
		colliderN.SetActive(false);
		colliderS.SetActive(false);
		colliderW.SetActive(true);
		colliderE.SetActive(true);

		StartCoroutine (UpdateSignal());
	}
	

	IEnumerator UpdateSignal() {

		while (true) {

			yield return new WaitForSeconds (5.0f);

			//縦の信号を黄色に
			colliderN.SetActive(true);
			colliderS.SetActive(true);
			colliderW.SetActive(true);
			colliderE.SetActive(true);


			yield return new WaitForSeconds (1.0f);

			//縦の信号を赤に、横の信号を青に
			colliderN.SetActive(true);
			colliderS.SetActive(true);
			colliderW.SetActive(false);
			colliderE.SetActive(false);

			yield return new WaitForSeconds (5.0f);

            //横の信号を黄色に
            colliderN.SetActive(true);
            colliderS.SetActive(true);
            colliderW.SetActive(true);
            colliderE.SetActive(true);

            yield return new WaitForSeconds (1.0f);

            //横の信号を赤に、縦の信号を青に
            colliderN.SetActive(false);
            colliderS.SetActive(false);
            colliderW.SetActive(true);
            colliderE.SetActive(true);

        }

		yield return null;
	}

}
