using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session1Homework : MonoBehaviour
{
   // Declare a int variable and set a value
    public int myVariable = 1;

    // Declare a float variable and set a value
    public float myFloat = 2.0f;

    //Declare a string variable and set a value
    private string myString = "my homework string is here.";

    //Declare and initialize an array
    private string[] myStringsArray = {"one", "2","three"};
    private int[,] my2DIntArray = new int[3,3];

    //  Declare a list
    private List<string> myStringList = new List<string>();

    //Create a Dictionary
    private Dictionary<int, int> myDictionary = new Dictionary <int,int>();
    private int i = 0;




    void Start ()
	{
	    //Create a function that prints the declared variables
        Debug.Log(myVariable.ToString());

	    //initialize a list
	    myStringList.Add("bubble");
	    myStringList.Add("wine");
	    myStringList.Add("is");
	    myStringList.Add("the");
	    myStringList.Add("best");

	    Debug.Log(myStringList);

        //initialize a Dictionary
        myDictionary.Add(1, 9);
        myDictionary .Add(2,8);
        myDictionary.Add(3,7);


	}
	

	void Update () {
	    if (myDictionary.ContainsKey(i))
	    {

	        Debug.Log("the number" + i + "is" + myDictionary.Values);
	        i++;
	    }
    }
}
