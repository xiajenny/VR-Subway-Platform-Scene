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

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audiochime = GetComponent<AudioSource>();
        audio.PlayOneShot(slowsubway, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);
        }

        if (count == 500)
         {
            audio.PlayOneShot(chime, 1.0f);
            count = count + 1;
            Debug.Log("Count" + count);
         }

        if (transform.position.x == 20f)
        {
            count = count + 1;
            Debug.Log("Count" + count);
        }

        if (count >= 700 && play == false)
        {
            audio.PlayOneShot(slowsubway, 1.0f);
            play = true;
            Debug.Log("play audio");
            transform.position = Vector3.MoveTowards(transform.position, position3, 5 * Time.deltaTime);
        }

        if (count >= 700)
        {
            transform.position = Vector3.MoveTowards(transform.position, position3, 5 * Time.deltaTime);
        }

        if (transform.position.x == -140f && count != 0)
        {
            count = 0;
            transform.position = position1;
            audio.PlayOneShot(slowsubway, 1.0f);
            play = false;
            Debug.Log("play audio");
        }

    }

}
