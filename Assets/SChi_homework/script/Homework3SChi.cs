using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework3SChi : MonoBehaviour
{
   [SerializeField]GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("click LBM to change color");
    }

    private int i = 0;

    private Vector3 Starpo = new Vector3(0f, 0f, 0f);
    private Vector3 Endpo = new Vector3(5f, 0f, 0f);

    // Update is called once per frame
    void Update()
    {
       prefab.transform.position += Vector3.right * 0.1f;

        //while (i < 1.0f)
        //{
        //    prefab.transform.position = Vector3.Lerp(Starpo , Endpo, i);
        //    i++;
        //}

        //    if (prefab.transform.position.x > 5f)
    //    {
    //        prefab.transform.position += Vector3.left * 0.1f;
    //       }
    //    else if (prefab.transform.position.x < -5f)
    //    {
    //        prefab.transform.position += Vector3.right * 0.1f;
    //}



            // Mouse input 
            if (Input.GetMouseButtonDown(0))
        {
            prefab.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }

        
    }
}
