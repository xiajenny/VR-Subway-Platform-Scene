using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class southboundtrain : MonoBehaviour
{
    //The southbound train is the train farthest from the platform the
    //cameras are set towards. North is to the right, south is to the left.
    Vector3 southPosition = new Vector3(250f, 0f, -4.9f);
    Vector3 platformPosition = new Vector3(0.0f, 0.0f, -4.9f);
    Vector3 northPosition = new Vector3(-250f, 0.0f, -4.9f);

    //Movement events are mainly controlled by the following timer and bools:
    float timer = 0.0f;
    bool atPlatform = false;

    void Start()
    {

    }

    void Update()
    {
        //timer counting seconds passed
        timer += Time.deltaTime;
        Debug.Log(timer + "s (S)");

        //Move towards platform and stop
        if (timer >= 53f && atPlatform == false && timer < 180f)
        {
            if (timer < 102)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 5 * Time.deltaTime);
            else if (timer < 103)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 4 * Time.deltaTime);
            else if (timer < 104)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 3 * Time.deltaTime);
            else if (timer < 105)
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


        //Accelerate train movement northbound to leave platform
        if (timer >= 118f && atPlatform == true && timer < 180f)
        {
            if (timer < 120)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 1 * Time.deltaTime);
            else if (timer < 121)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 2 * Time.deltaTime);
            else if (timer < 122)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 3 * Time.deltaTime);
            else if (timer < 123)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 4 * Time.deltaTime);
            else if (timer < 124)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 6 * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 9 * Time.deltaTime);
        }

        //Reset for second run
        if (timer >= 180 && transform.position.x == 250f && timer < 294f)
        {
            transform.position = northPosition;
            atPlatform = false;
        }

        if (timer >= 237f && atPlatform == false && timer < 294f)
        {
            if (timer < 267)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 8 * Time.deltaTime);
            else if (timer < 268)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 6 * Time.deltaTime);
            else if (timer < 269)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 4 * Time.deltaTime);
            else if (timer < 270)
                transform.position = Vector3.MoveTowards(transform.position, platformPosition, 3 * Time.deltaTime);
            else if (timer < 271)
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

        //Accelerate train movement northbound to leave platform
        if (timer >= 294f && atPlatform == true)
        {
            if (timer < 296)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 1 * Time.deltaTime);
            else if (timer < 297)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 2 * Time.deltaTime);
            else if (timer < 298)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 3 * Time.deltaTime);
            else if (timer < 299)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 4 * Time.deltaTime);
            else if (timer < 300)
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 6 * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, southPosition, 9 * Time.deltaTime);
        }

        //Reset 
        if (timer >= 595.5)
        {
            transform.position = northPosition;
            atPlatform = false;
            timer = 0;

        }
    }
}

