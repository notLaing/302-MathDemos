using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath
{
    public static float Map(float v, float minA, float maxA, float minB, float maxB)
    {
        float p = (v - minA) / (maxA - minA);
        return Lerp(minB, maxB, p);
    }

    public static float Lerp(float  a, float b, float p, bool allowExtrapolation = true)
    {
        if(!allowExtrapolation)
        {
            if (p > 1f) p = 1f;
            else if (p < 0f) p = 0f;
        }
        return ((b - a) * p) + a;
        //return Mathf.Lerp(a, b, p);
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float p, bool allowExtrapolation = true)
    {
        if (!allowExtrapolation)
        {
            if (p > 1f) p = 1f;
            else if (p < 0f) p = 0f;
        }
        return ((b - a) * p) + a;
    }

    public static Quaternion Lerp(Quaternion a, Quaternion b, float p, bool allowExtrapolation = false)
    {
        Quaternion rot = Quaternion.identity;

        rot.x = Lerp(a.x, b.x, p, allowExtrapolation);
        rot.y = Lerp(a.y, b.y, p, allowExtrapolation);
        rot.z = Lerp(a.z, b.z, p, allowExtrapolation);
        rot.w = Lerp(a.w, b.w, p, allowExtrapolation);

        return rot;
    }

    public static float Ease(float current, float target, float percentLeftAfter1Second, float dt = -1)
    {
        if (dt < 0) dt = Time.deltaTime;

        float p = 1f - Mathf.Pow(percentLeftAfter1Second, dt);
        return Lerp(current, target, p);
    }

    public static Vector3 Ease(Vector3 current, Vector3 target, float percentLeftAfter1Second, float dt = -1)
    {
        if (dt < 0) dt = Time.deltaTime;

        float p = 1f - Mathf.Pow(percentLeftAfter1Second, dt);
        return Lerp(current, target, p);
    }
}
