using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // This class has the code for a simple vertical parallax
    float length;
    Vector3 startPos;
    [SerializeField] float paralaxSpeed;
    [SerializeField] GameObject secondBG;

    void Start()
    {
        // Get the initial position of the second background, that is nested on the background that has this script
        startPos = secondBG.transform.position;
        // Get the y length of the sprite of the background
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Move both backgrounds 
        transform.Translate(Vector3.up * paralaxSpeed * Time.deltaTime);
        secondBG.transform.Translate(Vector3.up * paralaxSpeed * Time.deltaTime);

        // Return background to initial position if out of bounds
        if(transform.position.y> length)
        {
            transform.position = startPos;

        }
        if(secondBG.transform.position.y > length)
        {
            secondBG.transform.position = startPos;
        }
    }
}
