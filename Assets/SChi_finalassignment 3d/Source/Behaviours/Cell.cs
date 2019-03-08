using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class Cell : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private IEnumerator changeColor;
        // Additional custom per-cell attributes
        private int _state = 0;
        private int _age = 0;
        // ...
        // ...
        // ...


        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            State = 0; // set dead by default
        }
        

        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                _renderer.enabled = (value == 1);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public MeshRenderer Renderer
        {
            get { return _renderer; }
        }

        //    void Start()
        //    {
        //        changeColor = ChangecolorCoroutine();
        //        StartCoroutine(changeColor);
        //    }



        //    IEnumerator ChangecolorCoroutine()
        //    {
        //        //i present interface, here using IE define a interface then below express hwo to use it

        //        while (true)
        //        { 

        //                _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);

        //            yield return new WaitForSeconds(1); //here is to tell when this loop can quit
        //        }
        //    }
    }
}
