using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jenny Xia April 18th 2018
//This script controls the movements of the northbound train.
//The timing is based on the train-stclair-loud.mp3 recording,
//replacing train2.cs, which previously triggered individual sound
//effects. The event timing is available in sound-timing.txt.

public class northboundtrain : MonoBehaviour 
{
    //The northbound train is the train closest to the platform the
    //cameras are set towards. North is to the right, south is to the left.
    Vector3 southPosition = new Vector3(250f, 0f, 0f);
    Vector3 platformPosition = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 northPosition = new Vector3(-230f, 0.0f, 0.0f);

    //Movement events are mainly controlled by the following timer and bools:
    float timer = 0.0f;
    bool atPlatform = false;
    bool doorsOpened = false;

    private openDoors doorController;
    
    void Start ()
    {
        doorController = GetComponent<openDoors>();
        Debug.Log("Finished initialization");
    }
	
	void Update ()
    {
        //timer counting seconds passed
        timer += Time.deltaTime;
        Debug.Log(timer + "s");

		//Move towards platform and stop
        if (timer >= 75f && atPlatform == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, platformPosition, 5 * Time.deltaTime);
            Debug.Log("Start moving");
            if (transform.position.x == 0f)
            {
                atPlatform = true;
                Debug.Log("Centre platform");
            } 
        }

        //Enable open doors script
        if (timer >= 126f && doorsOpened == false)
        {
            doorController.enabled = true;
            doorsOpened = true;
            Debug.Log("doorController" + doorController.enabled);
        }

        //After door movement is complete, disable script
        if (timer >= 141f && doorsOpened == true)
        {
            doorController.enabled = false;
            Debug.Log("doorController" + doorController.enabled);
        }

        //Continue train movement northbound to leave platform
        if (timer >= 142f && atPlatform == true)
        {
            if (timer < 143)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 1 * Time.deltaTime);
            else if (timer < 144)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 2 * Time.deltaTime);
            else if (timer < 145)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 3 * Time.deltaTime);
            else if (timer < 146)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 4 * Time.deltaTime);
            else if (timer < 147)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 6 * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 9 * Time.deltaTime);
        }


    }
}
