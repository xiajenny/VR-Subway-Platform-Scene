using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jenny Xia April 18th 2018
//This script controls the movements of the northbound train.
//The timing is based on the train-stclair-loud.mp3 recording,
//replacing train2.cs, which previously triggered individual sound
//effects. The event timing is available in sound-timing.txt.

[RequireComponent(typeof(AudioSource))]
public class northboundtrain : MonoBehaviour 
{
    //The northbound train is the train closest to the platform the
    //cameras are set towards. North is to the right, south is to the left.
    Vector3 southPosition = new Vector3(250f, 0f, 0f);
    Vector3 platformPosition = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 northPosition = new Vector3(-250f, 0.0f, 0.0f);

    //Movement events are mainly controlled by the following timer and bools:
    float timer = 0.0f;
    bool atPlatform = false;
    bool doorsOpened = false;

    private openDoors doorController;
    private openDoors2 doorController2;

    void Start ()
    {
        AudioSource soundtrack = GetComponent<AudioSource>();
        soundtrack.Play();

        doorController = GetComponent<openDoors>();
        doorController2 = GetComponent<openDoors2>();
        Debug.Log("Finished initialization");
    }
	
	void Update ()
    {
        //timer counting seconds passed
        timer += Time.deltaTime;
        Debug.Log(timer + "s");

		//Move towards platform and stop
        if (timer >= 73f && atPlatform == false && timer < 400f)
        {
            if (timer < 121)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 5 * Time.deltaTime);
            else if (timer < 122)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 4 * Time.deltaTime);
            else if (timer < 123)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 3 * Time.deltaTime);
            else if (timer < 124)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 2 * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 1 * Time.deltaTime);

           // transform.position = Vector3.MoveTowards(transform.position, platformPosition, 5 * Time.deltaTime);
            Debug.Log("Start moving");
            if (transform.position.x == 0f)
            {
                atPlatform = true;
                Debug.Log("Centre platform");
            } 
        }

        //Enable open doors script
        if (timer >= 126f && doorsOpened == false && timer < 400f)
        {
            doorController.enabled = true;
            doorsOpened = true;
            Debug.Log("doorController" + doorController.enabled);
        }

        //After door movement is complete, disable script
        if (timer >= 141f && doorsOpened == true && timer < 400f)
        {
            doorController.enabled = false;
            Debug.Log("doorController" + doorController.enabled);
        }

        //Accelerate train movement northbound to leave platform
        if (timer >= 142f && atPlatform == true && timer < 400f)
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

        //Reset for second run
        if (timer >= 400 && transform.position.x == -250f && timer < 530f)
        {
            transform.position = southPosition;
            atPlatform = false;
            doorsOpened = false;
        }

        if (timer >= 422f && atPlatform == false)
        {
            if (timer < 452)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 8 * Time.deltaTime);
            else if (timer < 453)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 6 * Time.deltaTime);
            else if (timer < 454)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 4 * Time.deltaTime);
            else if (timer < 455)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 3 * Time.deltaTime);
            else if (timer < 456)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 2 * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 1 * Time.deltaTime);

           // transform.position = Vector3.MoveTowards(transform.position, platformPosition, 5 * Time.deltaTime);
            Debug.Log("Start moving");

            if (transform.position.x == 0f)
            {
                atPlatform = true;
                Debug.Log("Centre platform");
            }
        }

        //Enable open doors script
        if (timer >= 462f && doorsOpened == false)
        {
            doorController2.enabled = true;
            doorsOpened = true;
            Debug.Log("doorController2" + doorController2.enabled);
        }

        //After door movement is complete, disable script
        if (timer >= 500f && doorsOpened == true)
        {
            doorController2.enabled = false;
            Debug.Log("doorController" + doorController2.enabled);
        }

        //Accelerate train movement northbound to leave platform
        if (timer >= 501f && atPlatform == true)
        {
            if (timer < 502)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 1 * Time.deltaTime);
            else if (timer < 503)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 2 * Time.deltaTime);
            else if (timer < 504)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 3 * Time.deltaTime);
            else if (timer < 505)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 4 * Time.deltaTime);
            else if (timer < 506)
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 6 * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, northPosition, 9 * Time.deltaTime);
        }

        //Reset 
        if (timer >= 595.5)
        {
            transform.position = southPosition;
            atPlatform = false;
            doorsOpened = false;
            timer = 0;
            AudioSource soundtrack = GetComponent<AudioSource>();
            soundtrack.Play();
        }
    }
}
