//Refrences 
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//Where code lives 
public class Session1 : MonoBehaviour {

    // 1.Variables


    // Numbers
    public int myFirstIntegerNumber = 101; //make sure you end with ;
                                           //Public Private: related to the scope {}

    //numbers
    private int myInteger = 145;

    private int largeStinteger = int.MaxValue;

    private int smalleStinteger = int.MinValue;

    private double muDouble = 16.3;
    float myFirstFloatNumber = 1.75f;
    //Double 小数 restricted to length(16)
    // Float 小数 length(64) remember put f behind
    // So it dipends for need
    //For eg.Force, culculation variable : need more precise

    private int[ ] myIntArray= new int[5];

    // Text
    public string myFirstString = "My text is somewhere.";



    // Logical variable
    bool myFirstBoolean = true;



    // Data structures
    // Scope -- Type -- Values



    // 3.a.Arrays
    public int[] myIntegrerArray = { 1, 2, 3, 4, 5 };//bracket[] is to tell computer it's a array
    private int[] twebrtElementsArray = new int[20]; //this is the form howmany numbers that in a array
    //remember the array number is count from 0 rather than 1


    int[,] xyArray = new int[4,5];    // 2d array form

    private double[] dounleArray = {10.4, 11.23, 45, 72.9}; // we can see that integer and float and double can be input with recognization

    public float[] myFloatArray = new float[5];






    // 3.b.Lists
    // list is more flexible than array to add number on list,when array is fixed when named
    public List<int> myIntegerList = new List<int>();
    //   make a list  /name                  

    public List<int> myList = new List<int>();


    //dictionary- creat rule in order to search sth
    private Dictionary<string, string> movingAnimals = new Dictionary<string, string>();









    // 2.Functions
    // Scope -- Type -- Variables -- Body (Instructions)

    // Use this for initialization
    void Start()
    {
        Debug.Log("Addition of 5 and 3 is: " + AddtionOfNumbers(5, 3));
        myFloatArray[2] = 3.2f;
        myFloatArray[3] = 5.6f;
        myFloatArray[4] = 9.2f;

        myIntegerList.Add(1);
        myIntegerList.Add(2);
        myIntegerList.Add(3);

        //how to add value to array
        myIntArray[2] = 300;

        //array retrIve value FORM
        Debug.Log(myIntegrerArray[1].ToString());



        //list adding value
        myList.Add(4321);
        myList.Add(41);
        myList.Add(2);
        //list retrive values
        Debug.Log(myList[2].ToString( ));
        Debug.Log(myList[myList.Count-1].ToString());//myList.Count-1 is because the computer is counting from 0


        movingAnimals.Add("flying", "eagle");
        movingAnimals.Add("flying", "parrot");
        movingAnimals.Add("walking", "human");
        movingAnimals.Add("walking", "dog");

        if (movingAnimals.ContainsKey("flying"))
        {
            Debug.Log("A flying animal is:"+ movingAnimals.Values );
        }
  
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Hello world!");
	}


    //number addition function
    //scope-type-variables-body(instructions)
    float NumberAddition(float a, float b)
    {
        return a + b; // the return type can only be float which is defined

    }

    void PrintSomeNumbers()
    {
      //  Debug.Log(myList[0]);
      // Debug.Log();
        //this is homework
    }
    int AddtionOfNumbers(int number1, int number2)
    {
        int addtionResult = number1 + number2;
        return addtionResult;
    }
}
