﻿using Assets.Scripts.Unity.Export.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Unity.Export.Math
{
    public struct Vector4d : IExportModel, ISerializableToBytes, Vector
    {
        public byte[] SerializeToBytes()
        {
            throw new NotImplementedException();
        }
    }
}
