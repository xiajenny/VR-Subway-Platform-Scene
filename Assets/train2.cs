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
	bool play;

    Vector3 position1 = new Vector3(140f, 0f, 0f);
    Vector3 position2 = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 position3 = new Vector3(-120f, 0.0f, 0.0f);
    int count = 0;
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
        if (count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);
			Debug.Log ("Start moving");
		}

        //train stop completion, chime, counting
        if (count == 500)
         {
            audio.PlayOneShot(chime, 1.0f);
            count = count + 1;
            Debug.Log("Count" + count);
         }

        //train at platform position, doors open, counting
        if (transform.position.x == 0f)
        {
			doorController.enabled = true;
			Debug.Log ("doorController" + doorController.enabled );

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
        if (transform.position.x == -120f && count != 0)
        {
            count = 0;
            transform.position = position1;
            audio.PlayOneShot(slowsubway, 1.0f);
            play = false;
            Debug.Log("play audio");
        }

    }
		
}
