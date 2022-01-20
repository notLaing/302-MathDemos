using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseDemo : MonoBehaviour
{
    public Transform target;
    public float percentAfter1Second = .0001f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //naive
        //transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);

        transform.position = AnimMath.Ease(transform.position, target.position, percentAfter1Second, Time.deltaTime);
    }
}
