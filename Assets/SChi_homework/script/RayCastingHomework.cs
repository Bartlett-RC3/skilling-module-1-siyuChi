using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingHomework : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ray direction
        Vector3 castedRayDirection = transform.TransformDirection(Vector3.forward);

        // Store the object that is in front
        RaycastHit objectInFront;
        
        // Ray casting
        if (Physics.Raycast(transform.position, castedRayDirection, out objectInFront))
        {
            string objectInFrontName = objectInFront.transform.name;
            Debug.Log("There is an object in front of me! It`s name is: " + objectInFrontName);
            if (objectInFrontName.Contains("Cube") == true)
            //Destroy(objectInFront.transform.gameObject);
            objectInFront.transform.localScale = Vector3.zero;
        }

    }
}
