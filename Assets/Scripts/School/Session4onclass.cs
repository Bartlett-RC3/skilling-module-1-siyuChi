using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session4onclass : MonoBehaviour
{

    public GameObject prefabReference;

	// Use this for initialization
	void Start () {
	    //how do we instantiate make a new prefab?-bygiving a obj position rotation and parent
	    Vector3 prefabPosition = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10),
	        UnityEngine.Random.Range(-10, 10));
	    //Quaternion prefabRotation = Quaternion.identity;
     //   for ( )
     //   {
     //       here we change the color of each component by using foreach loop

     //   }





    }
	
	// Update is called once per frame
	void Update () {
       // StartCoroutine( ) is to use coroutine
        }
    //Implmenet the coroutines
    IEnumerator DropPrefabsFromHeight()
    {
        //i present interface, here using IE define a interface then below express hwo to use it


        while (true)
        {
            Vector3 prefabPos = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10),
                UnityEngine.Random.Range(0, 10));
            Quaternion prefabRot = new Quaternion(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90), 1);
            Instantiate(prefabReference, prefabPos, prefabRot);
            yield return new WaitForSeconds(5); //here is to tell when this loop can quit
        }
    }


}
