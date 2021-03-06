﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoors : MonoBehaviour {

	private GameObject[] leftdoors;
	private GameObject[] rightdoors;
	private Vector3[] leftPosV;
	private Vector3[] rightPosV;
	private Vector3 startPos = new Vector3 (0f, 0f, 0f);
	private bool doorOpen = false;
	private float counter = 12.5f;


	void OnEnable () {

		leftdoors = GameObject.FindGameObjectsWithTag ("leftdoor");
		rightdoors = GameObject.FindGameObjectsWithTag ("rightdoor");

		Debug.Log ("There are " + leftdoors.Length + " left doors");
		Debug.Log ("There are " + rightdoors.Length + " right doors");

		leftPosV = new Vector3[leftdoors.Length];
		Debug.Log ("There are " + leftPosV.Length + " left door array spots");
		rightPosV = new Vector3[rightdoors.Length];
		Debug.Log ("There are " + rightPosV.Length + " right door array spots");

		Debug.Log ("Initialized doors");

		for (int i = 0; i < leftdoors.Length; i++) 
		{
			leftPosV[i] = leftdoors[i].transform.localPosition + new Vector3 (0.85f, 0f, 0f);
			Debug.Log (i + " leftPos =" + leftPosV[i] + "leftdoors transPos =" + leftdoors[i].transform.localPosition);
		}

		for (int i = 0; i < rightdoors.Length; i++) 
		{
			rightPosV[i] = rightdoors[i].transform.localPosition + new Vector3 (-0.85f, 0f, 0f);
			Debug.Log (i + " rightPos =" + rightPosV[i] + "rightdoors transPos =" + rightdoors[i].transform.localPosition);
		}

        counter = 12.5f;
        doorOpen = false;
        Debug.Log("doorOpen" + doorOpen);
    }
	
	// Update is called once per frame
	void Update () {

		if (!doorOpen && counter > 0) {
			
			for (int i = 0; i < leftdoors.Length; i++) {
				leftdoors [i].transform.position = Vector3.MoveTowards (leftdoors [i].transform.position, leftPosV [i], 0.7f * Time.deltaTime);
				//Debug.Log (leftdoors [i].transform.position);
			}
				
			for (int i = 0; i < rightdoors.Length; i++) {
				rightdoors [i].transform.position = Vector3.MoveTowards (rightdoors [i].transform.position, rightPosV [i], 0.7f * Time.deltaTime);
				//Debug.Log (leftdoors [i].transform.position);
			}

			counter -= Time.deltaTime;
			Debug.Log (counter);
		}

		if (counter < 0.0f) {

			doorOpen = true;
            Debug.Log("doorOpen" + doorOpen);
        }

		if (doorOpen) {

			for (int i = 0; i < leftdoors.Length; i++) {
				leftdoors [i].transform.position = Vector3.MoveTowards (leftdoors [i].transform.position, startPos, 0.5f * Time.deltaTime);
				//Debug.Log (leftdoors [i].transform.position);
			}

			for (int i = 0; i < rightdoors.Length; i++) {
				rightdoors [i].transform.position = Vector3.MoveTowards (rightdoors [i].transform.position, startPos, 0.5f * Time.deltaTime);
				//Debug.Log (leftdoors [i].transform.position);
			}

            counter -= Time.deltaTime;
            Debug.Log(counter);

            if (rightdoors[0].transform.position.x == 0)
                doorOpen = false;
        }

        //if (leftdoors[0].transform.position == startPos && counter < -5f )
        //{
        //    counter = 9.0f;
        //    doorOpen = false;
        //}

    }
}
