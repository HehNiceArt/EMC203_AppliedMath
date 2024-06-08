using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    public Transform p1, p2;
    public Vector3 p0, p3;
    public float lineWidth;
    public int points = 20;
    public LineRenderer line;
    public GameObject obj;
    public float throwDuration = 2.0f;
    bool isThrowing = false;
    void Start()
    {
       line.startWidth = lineWidth;
       line.endWidth = lineWidth; 
    }

    // Update is called once per frame
    void Update()
    {
        p0 = transform.position;
        p3 = transform.position;

        if(points > 0)
        {
            line.positionCount = points;
        }
        for (int i = 0; i < points; i++)
        {
            float _t = i / (points - 1.0f);
            float _t2 = _t * _t;
            float _t3 = _t * _t * _t;
            float oneT = 1.0f - _t;
            float oneT2 = oneT * oneT;
            float oneT3 = oneT * oneT * oneT;

            Vector3 _p0 = p0;
            Vector3 _p1 = p1.position;
            Vector3 _p2 = p2.position;
            Vector3 _p3 = p3;

            Vector3 pos;
            pos = oneT3 * _p0 + 3 * oneT2 * _t * _p1 + (3 * oneT * _t2) * _p2 + _t3 * _p3;
            line.SetPosition(i, pos);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }
    }

    IEnumerator MoveAlongCurve()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = obj.transform.position;
        obj.SetActive(true);
        while (elapsedTime < throwDuration)
        {
            float t = elapsedTime / throwDuration;

            float t2 = t * t;
            float t3 = t * t * t;
            float oneT = 1.0f - t;
            float oneT2 = oneT * oneT;
            float oneT3 = oneT * oneT * oneT;

            Vector3 _p0 = p0;
            Vector3 _p1 = p1.position;
            Vector3 _p2 = p2.position;
            Vector3 _p3 = p3;

            Vector3 newPosition = oneT3 * _p0 + 3 * oneT2 * t * _p1 + 3 * oneT * t2 * _p2 + t3 * _p3;
            obj.transform.position = newPosition;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.SetActive(false);
        isThrowing = false; 
    }

    void Throw()
    {
        if (!isThrowing)
        {
            isThrowing = true;
            StartCoroutine(MoveAlongCurve());
        }
    }
}
