using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Basico : MonoBehaviour
{
    //Helpful commands:
    //CTRL + F to search a word
    //CTRL + H to search and substitute a word

    //Some variables:
    int a = 1;
    double b = 2;
    float c = 3f;
    bool d = true;

    //Arrays:
    int[] e = new int[5];
    
    int[] f = { 1, 2, 5, 7, 9 };

    void basics()
    {
        // For loops
        for (int i = 0; i < f.Length; i++)
        {
            //Debug.log the a printing function that shows the result on unity's console
            Debug.Log(f[i]);
        }

        // While loops
        while (true)
        {
            Debug.Log("Basico");
        }

        // Do while loops
        do
        {
            Debug.Log("Basico");
            a += 1;
        } while (a != b);

        //Switches
        int day = 4;
        switch (day)
        {
            case 1:
                Debug.Log("Monday");
                break;
            case 2:
                Debug.Log("Tuesday");
                break;
            case 3:
                Debug.Log("Wednesday");
                break;
            case 4:
                Debug.Log("Thursday");
                break;
            case 5:
                Debug.Log("Friday");
                break;
            case 6:
                Debug.Log("Saturday");
                break;
            case 7:
                Debug.Log("Sunday");
                break;
        }
    }
}
