using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelManager : MonoBehaviour
    {
        [SerializeField] private ModelInitializer _initializer;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countY = 10;

        private Cell[,] _cells;
        private GameOfLife2D _model;
        private int _stepCount;
        private IEnumerator changeColor; 

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            
            // create cell array
            _cells = new Cell[_countY, _countX];

            // instantiate cell prefabs and store in array
            for (int y = 0; y < _countY; y++)
            {
                for(int x = 0; x < _countX; x++)
                {
                    Cell cell = Instantiate(_cellPrefab, transform);
                    cell.transform.localPosition = new Vector3(x, y, 0);
                    _cells[y, x] = cell;
                }
            }

            // create model
            _model = new GameOfLife2D(_countY, _countX);

            // initialize model
            _initializer.Initialize(_model.CurrentState);

            
            changeColor = ChangecolorCoroutine();
            StartCoroutine(changeColor);
        }

        IEnumerator ChangecolorCoroutine()
        {
            //i present interface, here using IE define a interface then below express hwo to use it

            while (true)
            {
                Debug.Log("hah");
                foreach (var ce in _cells)
                {
                    int cellAge = ce.Age;
                   // ce.GetComponent<MeshRenderer>().material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                    ce.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.black, Color.white, cellAge);
                }
                yield return new WaitForSeconds(1); //here is to tell when this loop can quit
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            _model.Step();
            _stepCount++;
            // Debug.Log($"{_stepCount} steps taken!");

            int[,] state = _model.CurrentState;

            // update cells based on current state of model
            for (int y = 0; y < _countY; y++)
            {
                for (int x = 0; x < _countX; x++)
                    _cells[y, x].State = state[y, x];
            }
        }
    }
}
