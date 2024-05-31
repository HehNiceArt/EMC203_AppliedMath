using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lerping : MonoBehaviour
{
    public GameObject LerpGO;
    public GameObject p0, p1;
    public float lerpSpeed = 0.5f;
    public float t = 0f;
    void Update()
    {
        t += lerpSpeed * Time.deltaTime;

        Vector3 lerpedPos = new Vector3(
            Mathf.Lerp(p0.transform.position.x, p1.transform.position.x, t),
            Mathf.Lerp(p0.transform.position.y, p1.transform.position.y, t),
            Mathf.Lerp(p0.transform.position.z, p1.transform.position.z, t)
            );
        LerpGO.transform.position = lerpedPos;

        if (t > 1f)
        {
            LerpGO.transform.position = p0.transform.position;
            t = 0f;
        }
    }
}