using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour {


	Vector3 position1 = new Vector3(160f, 0f, 0f);
	Vector3 position2 = new Vector3(20f, 0.0f, 0.0f);
	Vector3 position3 = new Vector3(-140f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);

	}
}
