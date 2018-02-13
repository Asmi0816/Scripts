using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour {
	private GameObject playerPosition;

	private GameObject heart1, heart2, heart3, heart4, heart5;

	// Use this for initialization
	void Start () {
		playerPosition = GameObject.FindGameObjectWithTag ("Player");
		heart1 = GameObject.FindGameObjectWithTag ("Heart1");
		heart2 = GameObject.FindGameObjectWithTag ("Heart2");
		heart3 = GameObject.FindGameObjectWithTag ("Heart3");
		heart4 = GameObject.FindGameObjectWithTag ("Heart4");
		heart5 = GameObject.FindGameObjectWithTag ("Heart5");
	}

	// Update is called once per frame
	void LateUpdate () {

		float x = playerPosition.transform.position.x;

		heart1.transform.position = new Vector3 (x-320,165, gameObject.transform.position.z);
		heart2.transform.position = new Vector3 (x-300,165, gameObject.transform.position.z);
		heart3.transform.position = new Vector3 (x-280,165, gameObject.transform.position.z);
		heart4.transform.position = new Vector3 (x-260,165, gameObject.transform.position.z);
		heart5.transform.position = new Vector3 (x-240,165, gameObject.transform.position.z);

	}


}
