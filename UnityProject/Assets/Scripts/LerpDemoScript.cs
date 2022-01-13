using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemoScript : MonoBehaviour
{
    public Transform pointA, pointB;
    [Range(0, 1)]
    public float percent = 0;

    void Interpolate()
    {
        if (pointA != null && pointB != null)
        {
            transform.position = Vector3.Lerp(pointA.position, pointB.position, percent);

            transform.rotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, percent);
        }
    }

    private void OnValidate()
    {
        Interpolate();
    }
}
