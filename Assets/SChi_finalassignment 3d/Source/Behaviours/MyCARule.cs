using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// Rule for Conway's game of life
    /// </summary>
    [RequireComponent(typeof(StackModel))]
    [RequireComponent(typeof(StackAnalyser))]
    public class MyCARule : MonoBehaviour, ICARule2D
    {
        private StackModel _model;
        private StackAnalyser _analyser;

        //death
        private GOLInstructionSet _instSetDead = new GOLInstructionSet(3, 5, 5, 5);//死亡

        //increase
        private GOLInstructionSet _instSetIncrease1 = new GOLInstructionSet(2, 3, 3, 4);//增长1
        private GOLInstructionSet _instSetIncrease2 = new GOLInstructionSet(3, 5, 3, 3);//增长2
        private GOLInstructionSet _instSetIncrease3 = new GOLInstructionSet(3, 4, 3, 4);//增长3
        private GOLInstructionSet _instSetIncrease4 = new GOLInstructionSet(1, 2, 3, 4);//增长4

        //decrease
        private GOLInstructionSet _instSetDecrease1 = new GOLInstructionSet(4, 7, 3, 3);//减少1
        private GOLInstructionSet _instSetDecrease2 = new GOLInstructionSet(2, 3, 3, 3);//减少2

        //column
        private GOLInstructionSet _instSetColumn = new GOLInstructionSet(0, 1, 3, 3);//柱子

        //stable
        private GOLInstructionSet _instSetStable1 = new GOLInstructionSet(2, 3, 2, 3);//稳定生长1
        private GOLInstructionSet _instSetStable2 = new GOLInstructionSet(1, 2, 2, 3);//稳定生长2
        private GOLInstructionSet _instSetStable3 = new GOLInstructionSet(3, 3, 2, 2);//稳定生长3
        private GOLInstructionSet _instSetStable4 = new GOLInstructionSet(1, 3, 3, 3);//稳定生长4
        private GOLInstructionSet _instSetStable5 = new GOLInstructionSet(2, 4, 1, 1);//稳定生长5
        private GOLInstructionSet _instSetVerticle = new GOLInstructionSet(2, 6, 4, 5);//垂直生长

        //rapid increase
        private GOLInstructionSet _instSetOriginalImage = new GOLInstructionSet(5, 8, 4, 4);//想到的有纹理的平面，使用5844（初始图像是什么，就可以得到什么图像）
        private GOLInstructionSet _instSetStripeImage = new GOLInstructionSet(2, 7, 0, 0);//想到的有条形纹理的平面



        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _model = GetComponent<StackModel>();
            _analyser = GetComponent<StackAnalyser>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public int NextAt(Index2 index, int[,] current)
        {
            //get current state
            int state = current[index.I, index.J];

            //get local neighborhood data
            int sumMO = GetNeighborSum(index, current, Neighborhoods.MooreR1);
            int sumVNPair = GetNeighborSum(index, current, Neighborhoods.VonNeumannPair1);

            //choose an instruction set
            GOLInstructionSet instructionSet = _instSetIncrease1;

            // collect relevant analysis results
            CellLayer[] layers = _model.Stack.Layers;
            int currentLayer = _model.CurrentLayer;
            
            float prevLayerDensity;
            int prevCellAge;

            // get attributes of corresponding cell on the previous layer (if it exists)
            if (currentLayer > 0)
            {
                var prevLayer = layers[currentLayer - 1];
                prevLayerDensity = prevLayer.Density;
                prevCellAge = prevLayer.Cells[index.I, index.J].Age;
            }
            else
            {
                prevLayerDensity = 1.0f;
                prevCellAge = 0;
            }
            

            //new rule
            if (currentLayer < 10)
                instructionSet = _instSetIncrease1;
            else
            {
                if (prevLayerDensity < 0.1 && prevLayerDensity >= 0.05)
            
                instructionSet = _instSetIncrease3;
            
                else if (prevLayerDensity >= 0.2)
                {
                instructionSet = _instSetDecrease1;
                }

                else
                {
                instructionSet = _instSetStripeImage;
                }
                
            }


        int output = 0;

            //if current state is "alive"
            if (state == 1)
            {
                if (sumMO < instructionSet.getInstruction(0))
                {
                    output = 0;
                }

                if (sumMO >= instructionSet.getInstruction(0) && sumMO <= instructionSet.getInstruction(1))
                {
                    output = 1;
                }

                if (sumMO > instructionSet.getInstruction(1))
                {
                    output = 0;
                }
            }

            //if current state is "dead"
            if (state == 0)
            {
                if (sumMO >= instructionSet.getInstruction(2) && sumMO <= instructionSet.getInstruction(3))
                {
                    output = 1;
                }
                else
                {
                    output = 0;
                }
            }

            return output;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="j0"></param>
        /// <returns></returns>
        private int GetNeighborSum(Index2 index, int[,] current, Index2[] neighborhood)
        {
            int nrows = current.GetLength(0);
            int ncols = current.GetLength(1);
            int sum = 0;

            foreach (Index2 offset in neighborhood)
            {
                int i1 = Wrap(index.I + offset.I, nrows);
                int j1 = Wrap(index.J + offset.J, ncols);

                if (current[i1, j1] > 0)
                    sum++;
            }

            return sum;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int Wrap(int i, int n)
        {
            i %= n;
            return (i < 0) ? i + n : i;
        }
    }
}