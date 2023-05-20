using UnityEngine;
using System.Collections;
public static class Util
{
    public static float mapRange(float inStart, float inEnd, float outStart, float outEnd, float value)
    {
        float scale = (outEnd - outStart) / (inEnd - inStart);
        return (outStart + ((value - inStart) * scale));
    }

    public static IEnumerator Tweeng( this float duration, System.Action<float> var, float aa, float zz)
    {
        float sT = Time.time;
        float eT = sT + duration;

        while (Time.time < eT)
        {
            float t = (Time.time-sT)/duration;
            var(Mathf.SmoothStep(aa, zz, t));
            yield return null;
        }
        var(zz);
    }

    public static IEnumerator Tweeng(this float duration, System.Action<Vector3> var, Vector3 aa, Vector3 zz)
    {
        float sT = Time.time;
        float eT = sT + duration;

        while (Time.time < eT)
        {
            float t = (Time.time-sT)/duration;
            var(Vector3.Lerp(aa, zz, Mathf.SmoothStep(0f, 1f, t)));
            yield return null;
        }
        var(zz);
    }

    public static Transform getNearestTree()
    {
        Transform treesParent = GameObject.Find("trees").transform;

        Transform closest = treesParent.GetChild(0);
        foreach(Transform tree in treesParent)
        {
            float distance = Vector3.Distance(Survivor.instance.transform.position, tree.transform.position);
            if (distance < Vector3.Distance(Survivor.instance.transform.position, closest.position))
                closest = tree;
        }
        return closest;
    }

}
