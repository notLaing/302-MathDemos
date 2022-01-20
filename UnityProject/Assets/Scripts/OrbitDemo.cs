using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDemo : MonoBehaviour
{
    public Transform orbitCenter;
    public float radius = 3f;
    public float offsetTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!orbitCenter) return;
        float x = Mathf.Cos(Time.time + offsetTime) * radius;
        float z = Mathf.Sin(Time.time + offsetTime) * radius;

        transform.position = new Vector3(x, 0, z) + orbitCenter.position;
    }
}
