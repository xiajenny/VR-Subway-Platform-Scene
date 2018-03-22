using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class train2 : MonoBehaviour
{
    public AudioClip slowsubway;
    AudioSource audio;
    public AudioClip chime;
    AudioSource audiochime;
    Vector3 position1 = new Vector3(160f, 0f, 0f);
    Vector3 position2 = new Vector3(20f, 0.0f, 0.0f);
    Vector3 position3 = new Vector3(-140f, 0.0f, 0.0f);
    int count = 0;
    bool play;

    private GameObject[] leftdoors;
    private GameObject[] rightdoors;
    private Vector3[] leftPosV;
    private Vector3[] rightPosV;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audiochime = GetComponent<AudioSource>();
        audio.PlayOneShot(slowsubway, 1.0f);



        leftdoors = GameObject.FindGameObjectsWithTag("leftdoor");
        rightdoors = GameObject.FindGameObjectsWithTag("rightdoor");

        Debug.Log("There are " + leftdoors.Length + " left doors");
        Debug.Log("There are " + rightdoors.Length + " right doors");

        leftPosV = new Vector3[leftdoors.Length];
        Debug.Log("There are " + leftPosV.Length + " left door array spots");
        rightPosV = new Vector3[rightdoors.Length];
        Debug.Log("There are " + rightPosV.Length + " right door array spots");

        //Debug.Log (leftdoors [1].transform.position);

        for (int i = 0; i < leftdoors.Length; i++)
        {
            leftPosV[i] = leftdoors[i].transform.localPosition + new Vector3(0.0085f, 0f, 0f);
            Debug.Log(i + " leftPos =" + leftPosV[i] + "leftdoors transPos =" + leftdoors[i].transform.localPosition);
        }

        for (int i = 0; i < rightdoors.Length; i++)
        {
            rightPosV[i] = rightdoors[i].transform.localPosition + new Vector3(-0.0085f, 0f, 0f);
            Debug.Log(i + " rightPos =" + rightPosV[i] + "rightdoors transPos =" + rightdoors[i].transform.localPosition);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //start condition
        if (count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);
        }

        //train stop completion, chime, counting
        if (count == 500)
         {
            audio.PlayOneShot(chime, 1.0f);
            count = count + 1;
            Debug.Log("Count" + count);
         }

        //train at platform position, doors open, counting
        if (transform.position.x == 20f)
        {
            for (int i = 0; i < leftdoors.Length; i++)
            {
                leftdoors[i].transform.position = Vector3.MoveTowards(leftdoors[i].transform.position, leftPosV[i], 0.8f * Time.deltaTime);
                //Debug.Log (leftdoors [i].transform.position);
            }

            for (int i = 0; i < rightdoors.Length; i++)
            {
                rightdoors[i].transform.position = Vector3.MoveTowards(rightdoors[i].transform.position, rightPosV[i], 0.8f * Time.deltaTime);
                //Debug.Log (leftdoors [i].transform.position);
            }
            count = count + 1;
            Debug.Log("Count" + count);
        }

        //play train sound if play is false, and move to end of track
        if (count >= 700 && play == false)
        {
            audio.PlayOneShot(slowsubway, 1.0f);
            play = true;
            Debug.Log("play audio");
            transform.position = Vector3.MoveTowards(transform.position, position3, 5 * Time.deltaTime);
        }

        //start moving train
        if (count >= 700)
        {
            transform.position = Vector3.MoveTowards(transform.position, position3, 5 * Time.deltaTime);
        }

        //if count is not 0 and train is at end of track, reset count to 0, play train sound 
        if (transform.position.x == -140f && count != 0)
        {
            count = 0;
            transform.position = position1;
            audio.PlayOneShot(slowsubway, 1.0f);
            play = false;
            Debug.Log("play audio");
        }

    }

//	void OpenDoors(int doorNum)
//	{
//		
//		transform.localPosition = new Vector3 (0, 0, 0);
//	}
}
