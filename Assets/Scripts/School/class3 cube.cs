using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class class3cube : MonoBehaviour {
    public GameObject cubePrefab;
    public GameObject Light;
    public int spacing = 10;
    public int gridX = 10;
    public int gridY = 10;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < gridX; i++)
        {
            for (int j = 0; j < gridX; j++)
            {
              ///  Instantiate(cubePrefab, Vector3 = (spacing*i,spacing *j,0),Quaternion.this, transform);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    Debug.Log("this computer can render a frame in" + Time.deltaTime);
	    Debug.Log("since I start render it tooks us" + Time.timeSinceLevelLoad);
	    Debug.Log("computer has count this amount of frames:" + Time.frameCount );
        //translation
        //move children gameobj in x axis make them random
        foreach (Transform child in this.transform)
        {
            Random random;

            child.Translate(0,0,Random.Range( -1f,1f)); //translate means position
        
	    }

        //rotation
        //rotation children gameobj around y axis
	    foreach (Transform child in this.transform)
	    {
            child.Rotate(0,Random.value,0);//when doing the rotation ,please minding the difference in choosing local pivot or global pivot
            //or the transform like
            child.RotateAroundLocal(Vector3.up,Random.value);
	    }

        //scale
	    foreach (Transform child in this.transform)
	    {
	        child.localScale = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));

	    }

        //record orignal scale
	    float[] originalScale = new float[this.transform.childCount];
        for(int i = 0; i<transform.childCount; i++)
	    {
	       /// originalScale[i] = transform.GetChild(i).localScale;
	    }

        //keyboard input_i havent finish this part
        if (Input.GetKeyDown(KeyCode.Space))
	    {
            //if I have pressed space
            //record the cubes original scale
	       
	    }

        //Mouse pressed(0 left,1 right,2 middle)
	    if (Input.GetMouseButton(0))
	    {
	        Light.GetComponent<Light>();
	        //"get component" is getting proporty from unity this case we get Light
	    }

    }
}

//debug part

//eg:Assets/Scripts/School/class3 cube.cs(20,51): error CS1644: Feature `tuples' cannot be used because it is not part of the C# 4.0 language specification
//means bug located in line 20 51th element, you will have a problem(but maybe not a precise place
// error number csXXXXX can be searched in stackoverflow.com
