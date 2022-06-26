using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TranslateMovement : MonoBehaviour
{
    //Translate is used when the object does not interact phisically with others and the collision detection occurs using triggers

    public float Speed = 5f;
    
    void Update()
    {
        Translate3();
    }

    void Translate1()
    {
        //First way to use translate, the code is simple, but there is a problem:
        //Moving along diagonals will be faster than moving in one direction at a time.

        //The Input.GetAxis() method inside the unity returns values with a certain acceleration, which
        //smooths the movement. To remove this acceleration it is necessary to normalize.

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * Speed * Time.deltaTime);
    }

    void Translate2()
    {
        //Second way to use translate, this time solving the problem of diagonal movement

        var movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal") * Speed;
        movement.y = Input.GetAxis("Vertical") * Speed;
        movement = Vector3.ClampMagnitude(movement, Speed);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    void Translate3()
    {
        //Third way to use translate, this time removing acceleration with normalization

        double velX = 0;
        double velY = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) velX += -1;
        if (Input.GetKey(KeyCode.RightArrow)) velX += 1;
        if (Input.GetKey(KeyCode.UpArrow)) velY += 1;
        if (Input.GetKey(KeyCode.DownArrow)) velY += -1;

        // Normalizing
        double length = Math.Sqrt((velX * velX) + (velY * velY));
        if (length != 0)
        {
            velX /= length;
            velY /= length;
        }

        velX *= Speed;
        velY *= Speed;

        transform.Translate(Vector3.right * (float) velX * Time.deltaTime);
        transform.Translate(Vector3.up * (float) velY * Time.deltaTime);
    }
}
