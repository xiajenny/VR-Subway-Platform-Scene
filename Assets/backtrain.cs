using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class backtrain : MonoBehaviour
{
	public AudioClip slowsubway;
	AudioSource audio;
	public AudioClip chime;
	AudioSource audiochime;
	bool play = false;
	bool playChime = false;

	Vector3 position1 = new Vector3(-140f, 0f, -4.9f);
	Vector3 position2 = new Vector3(0.0f, 0.0f, -4.9f);
	Vector3 position3 = new Vector3(200f, 0.0f, -4.9f);
	float timer = 0.0f;


	// Use this for initialization
	void Start()
	{
		audio = GetComponent<AudioSource>();
		audiochime = GetComponent<AudioSource>();
		audio.PlayOneShot(slowsubway, 0.9f);

		Debug.Log ("Finished movement initialization");

	}

	// Update is called once per frame
	void Update()
	{
		//start condition
		if (timer == 0f)
		{
			transform.position = Vector3.MoveTowards(transform.position, position2, 4 * Time.deltaTime);
			Debug.Log ("Start moving");
		}

		//train at platform position, counting
		if (transform.position.x == 0f)
		{
			Debug.Log("Centre platform");

			timer += Time.deltaTime;
			//Debug.Log(timer);
		}

		//train stop completion, chime
		if (timer > 5.0f && playChime == false)
		{
			audio.PlayOneShot(chime, 0.6f);
			playChime = true;
		}

		//start moving train to end of track, play train sound if play is false, disable door open script
		if (timer > 8.0f && play == false)
		{
			audio.PlayOneShot(slowsubway, 0.9f);
			play = true;
			Debug.Log("play audio");
			transform.position = Vector3.MoveTowards(transform.position, position3, 4 * Time.deltaTime);
			Debug.Log("Moving to end of track1");
		}

		//moving train to end of track
		if (timer > 8.0f)
		{
			transform.position = Vector3.MoveTowards(transform.position, position3, 4 * Time.deltaTime);
			Debug.Log("Moving to end of track2");
		}

		//if count is not 0 and train is at end of track, reset count to 0, play train sound 
		if (transform.position.x == 200f && timer != 0)
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
