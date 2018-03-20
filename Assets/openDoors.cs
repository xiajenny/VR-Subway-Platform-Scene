using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class openDoors : MonoBehaviour {


	// Use this for initialization
	void Start () {
		transform.Find("left_door12");
		transform.Find("right_door12");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
