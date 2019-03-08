using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(StackModel))]
    public class StackAnalyser : MonoBehaviour
    {
        private StackModel _model;
        private float _densitySum;
        private int _currentLayer; // index of the most recently analysed layer


        //data structure
        ArrayList layerdensity = new ArrayList();
        ArrayList layerAverageAge = new ArrayList();
        List<CellLayer> StackLayers = new List<CellLayer>();
        

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _model = GetComponent<StackModel>();
            ResetAnalysis();
        }


        /// <summary>
        /// 
        /// </summary>
        private void LateUpdate()
        {
            // reset analysis if necessary
            if (_currentLayer > _model.CurrentLayer)
                ResetAnalysis();

            // update analysis if model has been updated
            if (_currentLayer < _model.CurrentLayer)
                UpdateAnalysis();
        }


        /// <summary>
        /// Returns the current mean density of the stack
        /// </summary>
        public float MeanStackDensity
        {
            get { return _densitySum / (_model.CurrentLayer + 1); }
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdateAnalysis()
        {
            int currentLayer = _model.CurrentLayer;
            CellLayer layer = _model.Stack.Layers[currentLayer];

            //update layer current density
            var density = CalculateDensity(layer);
            Debug.Log(density);
            layer.Density = density;
            _densitySum += density; // add to running sum

            //data structure add information
            layerdensity.Add(density);

            var cells = layer.Cells;
            float agesum = 0;

            foreach (var cell in cells)
            {
                agesum += cell.Age;
            }

            layerAverageAge.Add(agesum / 400f);

            StackLayers.Add(layer);


            _currentLayer = currentLayer;
        }


        /// <summary>
        /// Calculate the density of alive cells for the given layer
        /// </summary>
        /// <returns></returns>
        private float CalculateDensity(CellLayer layer)
        {
            var cells = layer.Cells;
            int aliveCount = 0;

            foreach (var cell in cells)
              aliveCount += cell.State;
            
            return (float)aliveCount / cells.Length;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void ResetAnalysis()
        {
            _densitySum = 0.0f;
            _currentLayer = -1;
            StackLayers.Clear();
            layerAverageAge.Clear();
            layerdensity.Clear();
        }

        //show the data structure information
        void OnGUI()
        {

            GUI.Label(new Rect(600, 210, 300, 20), "layerdensity: " + layerdensity[_currentLayer].ToString());
            GUI.Label(new Rect(600, 230, 300, 20), "layerAverageAge: " + layerAverageAge[_currentLayer].ToString());
            GUI.Label(new Rect(600, 250, 300, 20), "Current Step: " + StackLayers.Count.ToString() + "/" + _model.Stack.LayerCount.ToString());
        }
    }
}
