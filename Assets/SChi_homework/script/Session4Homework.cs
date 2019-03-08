using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Session4Homework: MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> Cubes = new List<GameObject>();

    private int i;
    // Use this for initialization

    void Start ()
    {


            StartCoroutine(CreateCube());
            print("Coroutine started");



            StartCoroutine(ChangecolorCoroutine());



    }

    IEnumerator CreateCube()
    {
        //i present interface, here using IE define a interface then below express hwo to use it


        while (true)
        {
            Vector3 prefabPos = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10),
                UnityEngine.Random.Range(0, 10));
            Quaternion prefabRot = new Quaternion(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90), 1);
            var cc = Instantiate(prefab, prefabPos, prefabRot);
            cc.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);

            Cubes.Add(cc);

            yield return new WaitForSeconds(0.5f); //here is to tell when this loop can quit
        }
    }

    IEnumerator ChangecolorCoroutine()
    {
        //i present interface, here using IE define a interface then below express hwo to use it

        while (true)
        {
           
            foreach (var c in Cubes)
            {
                if (c == null)
                    Cubes.Remove(c);
               else
                c.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
             }
            Debug.Log(Cubes.Count);
            yield return new WaitForSeconds(1); //here is to tell when this loop can quit
        }
    }

    // Update is called once per frame
    void Update ()
    {

        if (Cubes.Count > 200)
        {
            StopAllCoroutines();
            print("Coroutine stops, 200 cubes have been generated in total");
        }
    }

}



//IEnumerator ChangecolorCoroutine()
//{
////i present interface, here using IE define a interface then below express hwo to use it

//while (true)
//{

//foreach (var c in Cubes)
//{
//if (c == null)
//Cubes.Remove(c);
//else
//c.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
//}
//Debug.Log(Cubes.Count);
//yield return new WaitForSeconds(1); //here is to tell when this loop can quit
//}
//}