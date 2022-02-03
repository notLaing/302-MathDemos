using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuadraticBezierDemo : MonoBehaviour
{
    public Transform startPoint, endPoint, controlPoint;
    [Range(2, 100)]
    public int curveResolution = 10;

    public float TweenTimeLength = 3f;
    float TweenTimeCurrent = 0f;
    bool isPlaying = false;

    public AnimationCurve temporalEasing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying) TweenTimeCurrent += Time.deltaTime;

        float p = TweenTimeCurrent / TweenTimeLength;
        p = Mathf.Clamp(p, 0f, 1f);

        //temporal
        p = temporalEasing.Evaluate(p);

        Vector3 pos = FindPointOnCurve(p);
        transform.position = pos;

        if (TweenTimeCurrent >= TweenTimeLength) isPlaying = false;
    }

    public void PlayTween(bool fromBeginning = false)
    {
        if (fromBeginning) TweenTimeCurrent = 0f;
        isPlaying = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(controlPoint.position, Vector3.one);
        for(int i = 0; i < curveResolution; ++i)
        {
            Vector3 a = FindPointOnCurve(i / (float)curveResolution);
            Vector3 b = FindPointOnCurve((i + 1) / (float)curveResolution);

            Gizmos.DrawLine(a, b);
        }
    }

    Vector3 FindPointOnCurve(float percent)
    {
        Vector3 a = AnimMath.Lerp(startPoint.position, controlPoint.position, percent);
        Vector3 b = AnimMath.Lerp(controlPoint.position, endPoint.position, percent);
        return AnimMath.Lerp(a, b, percent);
    }
}



[CustomEditor(typeof(QuadraticBezierDemo))]
public class QuadraticDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Play Tween"))
        {
            //((QuadraticBezierDemo)target).PlayTween();
            (target as QuadraticBezierDemo).PlayTween(true);
        }
    }
}
