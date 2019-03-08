// Session 2: Conditionals, Loops and Classes 
// UCL RC3 12Nov2017
using System.Collections;
using System.Collections.Generic;
using UnityEngine; //this is the library that this class can be recognized by unity script


//normally a class is like
public class human   //
                     //if we want input A property into B we can use public class B: A(SO THAT B now has all property of A
                     // if we only need part of the A we use the "interface"
                     //here we write how to use interface
                     /*
                      public interface IA(name the interface obj with Iobj){
                      //propertied
                      int age = {get; set;} (instead giving a value,we use get,set)(so we can chose where the source can be get
                      string name = {get;set;}
                      /behavior
                      viod sleeping();
                      viod walking();

                      */
                     //so the interface is more generic
                     // Variables
{
    //properties
    private string name = "me";
    private int age = 23;
    private float hieght = 167.0f;
    //behavior-more like functions
    void waliking()
    {

    }

    void sleeping()
    {

    }
}


public class Session2 : MonoBehaviour
{
    // we can change the name"session2" and file name by right click-refactor-remane
    //monobehavior is unity implementation inside class(so the obj can be easier control and multiple people working on same obj with different script controling different part

    public int myNumber = 2;
    public bool questionTime = true;
    int myVariableQuestionTime;



    List<int> evenNumbers = new List<int>();
    int[] evenNumbersSmart = new int[10];

    //List to store humans
    List<Human> rc3Tutors = new List<Human>();



    //on class
    private int number1 = 10;
    private int number2 = 20;
    private int number3 = 30;

    private bool someBool = false;
    private string someName = "name";
    private string[] tutorNames = {"Dave", "Tyson", "Jordi", "Octavian", "Panos"};


    // Use this for initialization
    void Start()
    {
        Debug.Log("A tutor is:" + tutorNames[0]); //dave come out
        Debug.Log("A tutor is:" + tutorNames[1]);
        Debug.Log("A tutor is:" + tutorNames[2]);
        //short above by below

        //navigate data
        //iterative for loop
        //for loop (variables that counts start, where it ends ,what is increments
        for (int i = 0; i <= tutorNames.Length - 1; i++) //length?
        {
            Debug.Log("A tutor is:" + tutorNames[i]);
        } //then all the tutor name come out

        //we write this by foreach loop
        foreach (string tutorName in tutorNames)
        {
            Debug.Log(tutorName);
        } //foreach is easier way to understand and more clear




        // Conditionals
        if (number1 < number2) //question
            //action if true
        {
            Debug.Log("number1 is smaller than number2.");
        }
        else
        {
            //action if false
            Debug.Log("number1 is bigger than number2.");
        }

        //questions we can ask
        //if sth is smaller or bigger
        //<,> are used

        //if somering is equal to sth else
        //== is used

        //asking multiple question
        if (number1 < number2 && someBool == true)
        {
            //action
            Debug.Log("Answer to both question is yes.");
        }

        //above is equal to write like below
        if (number1 < number2)
        {
            if (someBool == true)
            {
                Debug.Log("Answer to both question is yes.");
            }
            //this way althought long sentence, they are more readable


            // "or"
            if (number1 < number2 || someBool == true)
            {
                Debug.Log("Answer to one od the questions was true");
            }

            //complex question by concatenation and by emdedding sub questions
            if ((number1 < number2 && someBool == true) && (someName == "name"))
            {
                Debug.Log("this is too conusing, don't write in this way");
            }

            //shorthand if
            number3 = (number1 < number2) ? 100 : 200;
            // question with variable assigned to question   100 means when true 200 means when false
            //(number1 < number2) ? Debug.Log("number1 smaller than number2");
            // Normal if statement
            if (myNumber == 2)
            {
                Debug.Log("Your number is equal to 2.");
            }
            else
            {
                Debug.Log("Your number is not equal to 2.");
            }

            // Short if statement
            if (questionTime)
            {
                Debug.Log("Question time is true");
            }
            else
            {
                Debug.Log("Question time is false");
            }

            // Variable name is equal to either 1 or 0 based on the value of questionTime
            myVariableQuestionTime = (questionTime == true) ? 1 : 0;
            Debug.Log("The value of myVariableQuestionTime is: " + myVariableQuestionTime);

            // Question concatenation
            if (myNumber == 2 && questionTime == false)
            {
                Debug.Log("Your number is 2 and QT is false");
            }

            // Question or statement
            if (myNumber == 2 || questionTime == false)
            {
                Debug.Log("It may be that your number is 2 or it may be that QT is false");
            }

            // Loops

            // For loop statement (start value, how this ends, incrementation)
            string[] fruits = {"banana", "apple", "mango", "blueberry"};

            for (int i = 0; i < fruits.Length; i = i + 1)
            {
                Debug.Log("Fruit at position " + i + "is " + fruits[i]);
            }

            // Add 10 even numbers from 0 to 20
            for (int i = 0; i < 20; i = i + 2)
            {
                evenNumbers.Add(i);
                evenNumbersSmart[i / 2] = i;
            }

            // Print the list
            for (int i = 0; i < evenNumbers.Count; i++) // i = i + 1, i++
            {
                Debug.Log("Number is: " + evenNumbers[i]);
            }

            // Add 100 numbers to list and print the numbers that are divisible by 5
            List<int> myOneHundredNumbers = new List<int>();
            for (int i = 0; i <= 100; i++)
            {
                myOneHundredNumbers.Add(i);
            }

            // The smart way
            for (int i = 0; i < myOneHundredNumbers.Count; i = i + 5)
            {
                Debug.Log("Numbers divisible by 5: " + myOneHundredNumbers[i]);
            }

            // The less smart way
            for (int i = 0; i <= 100; i++)
            {
                if (i % 5 == 0)
                {
                    Debug.Log("Numbers divisible by 5: " + myOneHundredNumbers[i]);
                }
            }

            // While loop
            List<int> oddNumbers = new List<int>();
            int counter = 1;
            while (counter < 100)
            {
                oddNumbers.Add(counter);
                counter = counter + 2;
            }

            for (int i = 0; i < oddNumbers.Count; i++)
            {
                Debug.Log("Odd number : " + oddNumbers[i]);
            }

            // Create the tutors
            Human Octavian = new Human(31, 1.7f, true, "Octavian", "Gheorghiu");
            Human Tyson = new Human(34, 1.8f, true, "Tyson", "Hosmer");
            Human Dave = new Human(33, 1.75f, true, "Dave", "Reeves");

            rc3Tutors.Add(Octavian);
            rc3Tutors.Add(Tyson);
            rc3Tutors.Add(Dave);
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < rc3Tutors.Count; i++)
            {
                Debug.Log(rc3Tutors[i].GetFirstName());
            }
        }
    }
}