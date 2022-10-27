using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    /// Returns a Vector3 with a modified yAxis
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns></returns>
    public static Vector3 Horizontal(this Vector3 vector3, float yAxis)
    {
        vector3.y = yAxis;
        return vector3;
    }
}
