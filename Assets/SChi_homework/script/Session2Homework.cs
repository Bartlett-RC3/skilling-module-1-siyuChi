using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Session2Homework : MonoBehaviour {

  

    //Write a function that uses a condition
    private int MarryHeight = 160;

    private int BobHeight = 167;

    private int LucaHeight = 170;

    dog myDog = new dog(2,1,2,true,"wow");

    void Start () {
        if ((MarryHeight < BobHeight)&&(LucaHeight>BobHeight))
        {
            Debug.Log("marry is taller than bob but luca is highest");
        }
        else if(MarryHeight<BobHeight && BobHeight >LucaHeight )
        {
            Debug.Log("bob is tallest");
        }
        else
        {
            Debug.Log("marry is highest");
        }


        //only compare two object
        Debug.Log((MarryHeight < BobHeight) ? "bob is taller" : "marry is taller");


        int count = 10;
        Vector3 myVector;
        float m = 10f;

        //Write a for loop
        for (int a = 0 ; a < count; a++)
        {
            float x = m * a;
            float y = a / m;
            float z = m / (0.25f * a);
            myVector = new Vector3(x, y, z);
        }
        

        //dog information collect
        myDog.AgeRange();
        myDog.Action();





    }

    // Update is called once per frame
    void Update () {

    }
}
