using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Extensions
{
    static class VectorExtension
    {
        public static float GetVectorModule(this Vector2 vector)
        {
            return (float)Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2));
        }
    }
}
