using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //write a dog class and initialize an instance of the class
    public class dog
    {
        int age;
        float weight;
        float length;
       
        string  Name;
        bool sleep= false;

        public dog(int _age, float _weight, float _length, bool _sleep, string _nickName)
        {
            age = _age;
            weight = _weight;
            length = _length;
            sleep = _sleep;
            Name = _nickName;

        }

        public void AgeRange( )
        {
            if(age<3)
            Debug.Log("it's a puppy");
            else
            {
            Debug.Log("it's a mature dog");
            }
        }
        public void Action()
        {
            if (sleep = true)
                Debug.Log("my pet is sleeping");

        }

    }
