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
	bool play = false;
    bool playChime = false;

    Vector3 position1 = new Vector3(140f, 0f, 0f);
    Vector3 position2 = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 position3 = new Vector3(-120f, 0.0f, 0.0f);
	float timer = 0.0f;

	private openDoors doorController;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audiochime = GetComponent<AudioSource>();
        audio.PlayOneShot(slowsubway, 1.0f);

		doorController = GetComponent<openDoors> ();
		Debug.Log ("Finished movement initialization");

    }

    // Update is called once per frame
    void Update()
    {
        //start condition
        if (timer == 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);
			Debug.Log ("Start moving");
		}

        //train at platform position, doors open, counting
        if (transform.position.x == 0f)
        {
            Debug.Log("Centre platform");

            doorController.enabled = true;
            Debug.Log("doorController" + doorController.enabled);

            timer += Time.deltaTime;
            //Debug.Log(timer);
        }

        //train stop completion, chime
        if (timer > 10.0f && playChime == false)
         {
            audio.PlayOneShot(chime, 1.0f);
            playChime = true;
        }

        //start moving train to end of track, play train sound if play is false, disable door open script
        if (timer > 15.0f && play == false)
        {
            doorController.enabled = false;
            Debug.Log("doorController" + doorController.enabled);

            audio.PlayOneShot(slowsubway, 1.0f);
            play = true;
            Debug.Log("play audio");
            transform.position = Vector3.MoveTowards(transform.position, position3, 5 * Time.deltaTime);
            Debug.Log("Moving to end of track1");
        }

        //moving train to end of track
        if (timer > 15.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, position3, 5 * Time.deltaTime);
            Debug.Log("Moving to end of track2");
        }

        //if count is not 0 and train is at end of track, reset count to 0, play train sound 
        if (transform.position.x == -120f && timer != 0)
        {
            timer = 0.0f;
            transform.position = position1;
            audio.PlayOneShot(slowsubway, 1.0f);
            play = false;
            playChime = false;
            Debug.Log("play audio");
            Debug.Log("reset all");
            Debug.Log(timer);
        }

    }
		
}
