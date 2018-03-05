using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class train2 : MonoBehaviour
{
    public AudioClip slowsubway;
    AudioSource audio;
    Vector3 position1 = new Vector3(130f, 0f, 0f);
    Vector3 position2 = new Vector3(-20f, 0.0f, 0.0f);


    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);

            if (transform.position.x == -20f)
        {
            audio.PlayOneShot(slowsubway, 1.0f);
            audio.Play();
            Debug.Log("play audio");

            transform.position = position1;
            transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);
        }
    }

}
