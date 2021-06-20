﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Math
{
    public struct Matrix4x4
    {
        float[,] elements;

        public float this[int row, int column] {
            get
            {
                return elements[row, column];
            }
            set
            {
                elements[row, column] = value;
            }
        }

        public static Matrix4x4 FromUnityMatrix4x4(UnityEngine.Matrix4x4 unityMatrix4x4)
        {
            var result = new Matrix4x4();
            result.InitElements();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = unityMatrix4x4[i, j];
                }
            }
            return result;
        }

        public static Matrix4x4 operator *(Matrix4x4 matrixA, Matrix4x4 matrixB) => throw new NotImplementedException();

        public Vector4 GetColumn(int index)
        {
            var result = new Vector4();
            result.x = elements[0, index];
            result.y = elements[1, index];
            result.z = elements[2, index];
            result.w = elements[3, index];
            return result;
        }

        public UnityEngine.Vector4 GetUnityColumn(int index)
        {
            var result = new UnityEngine.Vector4();
            result.x = elements[0, index];
            result.y = elements[1, index];
            result.z = elements[2, index];
            result.w = elements[3, index];
            return result;
        }

        private void InitElements()
        {
            elements = new float[4, 4];
        }
    }
}