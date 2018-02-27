using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetrain : MonoBehaviour {
	
	Vector3 position1 = new Vector3(-158.4f, 1.373373e-17f, -29.24922f);
	Vector3 position2 = new Vector3(200f, 1.373373e-17f, -29.24922f);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards (transform.position, position2, 15 * Time.deltaTime);

		if (transform.position.x == 200f) {

			transform.position = position1;

			transform.position = Vector3.MoveTowards (transform.position, position2, 23 * Time.deltaTime);
	}
}

}
