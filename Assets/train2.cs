using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train2 : MonoBehaviour
{

    Vector3 position1 = new Vector3(1.5f, 0f, 0f);
    Vector3 position2 = new Vector3(-1f, 0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);

        if (transform.position.x == -1.0f)
        {

            transform.position = position1;

            transform.position = Vector3.MoveTowards(transform.position, position2, 5 * Time.deltaTime);
        }
    }

}
