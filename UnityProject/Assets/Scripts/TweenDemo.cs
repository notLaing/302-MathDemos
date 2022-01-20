using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TweenDemo : MonoBehaviour
{
    public AnimationCurve curve;

    public Transform pointA;
    public Transform pointB;

    bool isPlaying = false;

    float timeCurrent = 0f;
    [Range(.25f, 5f)]
    public float timeTotal = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            timeCurrent += Time.deltaTime;
            DoInterp();
        }
    }

    void DoInterp()
    {
        if (pointA == null || pointB == null) return;
        float p = timeCurrent / timeTotal;
        p = curve.Evaluate(p);
        Vector3 pos = AnimMath.Lerp(pointA.position, pointB.position, p);

        transform.position = pos;

        if (timeCurrent >= timeTotal) isPlaying = false;
    }

    public void StartTween()
    {
        isPlaying = true;
        timeCurrent = 0f;
    }
}

[CustomEditor(typeof(TweenDemo))]
public class EditorTweenDemo : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Start Tween"))
        {
            (target as TweenDemo).StartTween();
        }
    }
}