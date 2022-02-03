using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubicBezierDemo : MonoBehaviour
{
    public Transform anchorStart, anchorEnd, controlStart, controlEnd;
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

        float p = Mathf.Clamp(TweenTimeCurrent / TweenTimeLength, 0, 1);
        p = temporalEasing.Evaluate(p);
        Vector3 pos = FindPointOnCurve(p);
        transform.position = pos;

        Vector3 pos2 = FindPointOnCurve(p + .05f);

        //rotation
        Vector3 curveForward = (pos2 - pos).normalized;
        Quaternion rot = Quaternion.LookRotation(curveForward);

        transform.rotation = rot;

        if (TweenTimeCurrent >= TweenTimeLength) isPlaying = false;
    }

    public void PlayTween(bool fromBeginning = true)
    {
        if (fromBeginning) TweenTimeCurrent = 0f;
        isPlaying = true;
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < curveResolution; ++i)
        {
            Vector3 a = FindPointOnCurve(i / (float)curveResolution);
            Vector3 b = FindPointOnCurve((i + 1) / (float)curveResolution);
            Gizmos.DrawLine(a, b);
        }
    }

    Vector3 FindPointOnCurve(float percent)
    {
        //A = point between controlStart and controlEnd
        Vector3 a = AnimMath.Lerp(controlStart.position, controlEnd.position, percent);

        //B = find point between anchorStart and controlStart
        //C = find point between controlEnd and anchorEnd
        Vector3 b = AnimMath.Lerp(anchorStart.position, controlStart.position, percent);
        Vector3 c = AnimMath.Lerp(controlEnd.position, anchorEnd.position, percent);

        //D = find point between B and A
        //E = point between A and C
        Vector3 d = AnimMath.Lerp(b, a, percent);
        Vector3 e = AnimMath.Lerp(a, c, percent);

        //F = point between D and E
        return AnimMath.Lerp(d, e, percent);
    }
}



[CustomEditor(typeof(CubicBezierDemo))]
public class CubicDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Play Tween"))
        {
            //((CubicBezierDemo)target).PlayTween();
            (target as CubicBezierDemo).PlayTween(true);
        }
    }
}